using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class EmployeeVendor : BasePage
    {
        private static string temp_Vendor_ID;//可能因为得不到值  所以加了static
        private static string factory_Name;
        private static IList<As_Vendor_FormType> list = new List<As_Vendor_FormType>();

        public Dictionary<string, Dictionary<string, string[]>> info;
        public Dictionary<string, Dictionary<string, string>> infos;
        private string serializedJson;


        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            factory_Name = Session["Factory_Name"].ToString().Trim();

            if (!IsPostBack)
            {
                readVendorInfo();

                LocalScriptManager.CreateScript(Page, "recoverSelectData()", "recoverInfo");
            }
            else
            {
                //重新读取供应商列表
                LocalScriptManager.CreateScript(Page, "getParams()", "getparams");

                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "refreshVendor":
                        refreshVendor(Request.Form["__EVENTARGUMENT"]);
                        break;
                    case "asyncRefresh":
                        updatePanel.Update();
                        break;
                    case "ht":
                        //是否签订合同
                        contract(Request.Form["__EVENTARGUMENT"]);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selection"></param>
        private void contract(string selection)
        {
            if (selection.Equals("YES"))//立即签订
            {
                string form_Type_ID = FillVendorInfo_BLL.getVendorContractFormTypeID(temp_Vendor_ID, factory_Name);
                switchPage(form_Type_ID, temp_Vendor_ID);
            }
            if (selection.Equals("NO"))//暂不签订
            {

            }
        }

        /// <summary>
        /// 获取此用户所管理的供应商列表
        /// </summary>
        private void readVendorInfo()
        {
            bool isPurchasingDepartment = TempVendor_BLL.checkEmployeeAuthority(Session["Employee_ID"].ToString());
            if (!isPurchasingDepartment)
            {
                return;
            }
            info = TempVendor_BLL.readVendorInFactory(Session["Factory_Name"].ToString());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            serializedJson = jss.Serialize(info);
            LocalScriptManager.CreateScript(Page, String.Format("setParams('{0}')", serializedJson), "params");
        }

        /// <summary>
        /// 刷新供应商信息
        /// </summary>
        /// <param name="tempVendorID"></param>
        private void refreshVendor(string tempVendorID)
        {
            //session 数据绑定
            string factoryName = Session["Factory_Name"].ToString();
            Session["tempvendorname"] = TempVendor_BLL.getTempVendorName(tempVendorID);
            Session["tempVendorID"] = tempVendorID;
            temp_Vendor_ID = tempVendorID;


            //根据供应商类型编号查询所有未填写表格类型
            string sql = "SELECT * FROM View_Vendor_FormType_UnFill WHERE Temp_Vendor_ID='" + tempVendorID + "'and Factory_Name='" + factoryName + "' order by Form_Type_Priority_Number asc";
            PagedDataSource objpds = new PagedDataSource();
            IList<As_Vendor_FormType> gridView2list = new List<As_Vendor_FormType>();
            gridView2list = SelectEmployeeVendor_BLL.listVendorFormType(sql,true);
            objpds.DataSource = gridView2list;
            GridView2.DataSource = objpds;
            GridView2.DataBind();


            //查询所有等待其他部门填写的表格
            //string sql1 = String.Format("SELECT * FROM View_Wait_MultiFill WHERE Temp_Vendor_ID='{0}'and flag ='2' and Factory_Name='{1}' order by Form_Type_Priority_Number asc", tempVendorID, factoryName);
            string sql1 = String.Format("SELECT * FROM View_Wait_MultiFill WHERE Employee_ID='{0}'", Session["Employee_ID"].ToString());
            PagedDataSource objpds1 = new PagedDataSource();
            objpds1.DataSource = SelectForm_BLL.selectForm(sql1);
            if (objpds1.Count > 0)
            {
                Legend3.Visible = true;
                GridView1.DataSource = objpds1;
                GridView1.DataBind();
            }
            else
            {
                Legend3.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
            }


            //根据供应商类型编号查询所有已提交表格
            string sql2 = String.Format("SELECT * FROM View_Form_Status WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}'", tempVendorID, factoryName);
            PagedDataSource objpds2 = new PagedDataSource();
            objpds2.DataSource = SelectForm_BLL.selectForm(sql2);
            
            if (objpds2.Count > 0)
            {
                Legend1.Visible = true;
                GridView3.DataSource = objpds2;
                GridView3.DataBind();
            }
            else
            {
                Legend1.Visible = false;
                GridView3.DataSource = null;
                GridView3.DataBind();
            }


            //根据供应商类型编号查询所有待上传文件
            string sql3 = String.Format("SELECT * FROM View_Vendor_FileType WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}'", tempVendorID, factoryName);
            PagedDataSource objpds3 = new PagedDataSource();
            objpds3.DataSource = SelectEmployeeVendor_BLL.listVendorFileType(sql3);
            GridView4.DataSource = objpds3;
            GridView4.DataBind();


            //查询出该供应商只保存未提交的表格
            string sqlkeepfill = String.Format("SELECT * FROM View_MutipleForm_KeepFill WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}' and Fill_Flag='{2}'", tempVendorID, factoryName, 0);
            PagedDataSource objpds4 = new PagedDataSource();
            objpds4.DataSource = SelectEmployeeVendor_BLL.listVendorKeepFillForms(sqlkeepfill);
            GridView5.DataSource = objpds4;
            GridView5.DataBind();


            //合同签订提示  查询信息表是否审批完成 查询合同审批表是否提交
            //string sql4 = String.Format("select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='{0}' and Factory_Name='{1}' and Form_Type_ID='019' and flag=4", tempVendorID, factory_Name);
            //if (FillVendorInfo_BLL.isVendorCreationAssessed(sql4))//审批完成
            //{
            //    //查找合同审批表中是否已有记录
            //    string sql5 = "select Form_ID from As_Contract_Approval where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory_Name + "' and Flag=2";
            //    if (!FillVendorInfo_BLL.isVendorContractSubmited(sql5))//未提交
            //    {
            //        LocalScriptManager.CreateScript(Page, "popHT()", "HT");
            //    }
            //}
        }

        /// <summary>
        /// 填写表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showDetails")
            {
                //获取供应商名称转换为临时ID的值传入session;
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempvendorname = HttpUtility.HtmlDecode(GridView2.Rows[drv.RowIndex].Cells[2].Text);
                string formTypeID = e.CommandArgument.ToString();
                string tempVendorID = TempVendor_BLL.getTempVendorID(tempvendorname);
                Session["tempVendorID"] = tempVendorID;

                //点击不同表格进入到不同界面.
                switchPage(e.CommandArgument.ToString(), tempVendorID);
            }
            
        }

        /// <summary>
        /// 预跳转，做文件检查
        /// </summary>
        /// <param name="commandArgument"></param>
        /// <param name="tempVendorID"></param>
        private void switchPage(string commandArgument, string tempVendorID)
        {
            //进行填写前的文件检查 并返回结果
            string result = CheckFile_BLL.checkFileWithResult(commandArgument, tempVendorID);

            //  空 代表与该表绑定的所有文件均已经上传
            if (!result.Equals(""))
            {
                LocalScriptManager.createManagerScript(Page, "messageConfirmNone('请上传：" + result + "')", "msg");
                return;
            }

            try
            {
                //进行页面跳转
                pageRedirect(PageSelect.dcEditToShow[commandArgument], commandArgument);
            }
            catch (Exception e)
            {
                LocalScriptManager.createManagerScript(Page, "closeWaiting();messageConfirmNone('此功能暂时不可用：" + e.Message + "')", "msg");
            }
        }

        /// <summary>
        /// 查看表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showDetails")
            {
                //获取信息
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                Session["formID"] = GridView3.Rows[drv.RowIndex].Cells[2].Text;
                Session["formTypeID"] = e.CommandArgument.ToString();

                //跳转
                Response.Redirect("Show" + PageSelect.dcEditToShow[e.CommandArgument.ToString()] + "?type=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "showStatus")
            {
                Response.Redirect("ApprovalProgress.aspx?formID=" + e.CommandArgument.ToString());
            }
        }


        /// <summary>
        /// 继续填写表格的跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "keepFilling")
            {
                //获取信息
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempVendorID = Session["tempVendorID"].ToString();
                string formID = GridView5.Rows[drv.RowIndex].Cells[2].Text;
                //跳转 传入form_ID 和form_Type_ID
                //Response.Redirect(PageSelect.dcEditToShow[e.CommandArgument.ToString()] + "?type=" + e.CommandArgument.ToString()+"&Form_ID="+ GridView3.Rows[drv.RowIndex].Cells[2].Text+"&submit=yes");


                switchPage(e.CommandArgument.ToString(), tempVendorID, formID);

            }
            //删除表格
            else if (e.CommandName == "deleteForm")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempVendorID = Session["tempVendorID"].ToString();
                string formID = GridView5.Rows[drv.RowIndex].Cells[2].Text;
                Vendor_MutipleForm_BLL.deleteForm(e.CommandArgument.ToString().Trim());

                //包含合同审批表 比价表 指定供应商表 价格表 需要自动删除已经上传的文件
                if (formID.Contains("VendorDesignated"))
                {
                    File_Type_BLL.deleteBindSingleFile(formID, "065");
                }
                else if (formID.Contains("BiddingApprovalForm")|| formID.Contains("ServiceComponentApplication")|| formID.Contains("PurchasePriceApplication") || formID.Contains("PurchaseChanges"))
                {
                    File_Type_BLL.deleteBindSingleFile(formID, "012");
                }
                else if (formID.Contains("ContractApproval"))
                {
                    File_Type_BLL.deleteBindSingleFile(formID, "001");
                }

                string sqlkeepfill = String.Format("SELECT * FROM View_MutipleForm_KeepFill WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}' and Fill_Flag='{2}'", Session["tempVendorID"].ToString(), Session["Factory_Name"].ToString(), 0);
                PagedDataSource objpds4 = new PagedDataSource();
                objpds4.DataSource = SelectEmployeeVendor_BLL.listVendorKeepFillForms(sqlkeepfill);
                GridView5.DataSource = objpds4;
                GridView5.DataBind();
            }
        }

        private void switchPage(string formTypeID, string tempVendorID, string formID)
        {
            try
            {
                //跳转
                pageRedirect(PageSelect.dcEditToShow[formTypeID], formTypeID, formID);
            }
            catch (Exception e)
            {
                LocalScriptManager.createManagerScript(Page, "closeWaiting();messageConfirmNone('此功能暂时不可用：" + e.Message + "')", "msg");
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //上传
            if (e.CommandName == "UpLoad")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempVendorID = Session["tempVendorID"].ToString();
                string tempVendorName = Session["tempvendorname"].ToString();
                string fileTypeID = GridView4.Rows[drv.RowIndex].Cells[2].Text;
                string requestType = "fileUpload";

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "upload", String.Format("uploadFile('{0}','{1}','{2}','{3}',{4})", requestType, tempVendorID, tempVendorName, fileTypeID, GridView4.Rows[drv.RowIndex].Cells[5].Text.ToLower()), true);
                //LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}',{4})", requestType, tempVendorID, tempVendorName, fileTypeID, GridView4.Rows[drv.RowIndex].Cells[5].Text.ToLower()), "upload");
            }//覆盖
            else if (e.CommandName == "ReLoad")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempVendorID = Session["tempVendorID"].ToString();
                string tempVendorName = Session["tempvendorname"].ToString();
                string fileTypeID = GridView4.Rows[drv.RowIndex].Cells[2].Text;
                string requestType = "fileUpload";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "upload", String.Format("uploadFile('{0}','{1}','{2}','{3}',{4})", requestType, tempVendorID, tempVendorName, fileTypeID, GridView4.Rows[drv.RowIndex].Cells[5].Text.ToLower()), true);
                //LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}',{4})", requestType, tempVendorID, tempVendorName, fileTypeID, GridView4.Rows[drv.RowIndex].Cells[5].Text.ToLower()), "upload");
            }//查看
            else if (e.CommandName == "FileDetail")
            {
                string fileTypeID = e.CommandArgument.ToString();
                string fileName = File_BLL.getFileName(fileTypeID, Session["tempVendorID"].ToString(), factory_Name);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "showFileDetail", String.Format("<script>window.open('{0}');</script>", LSetting.File_Reltive_Path + fileName), false);
                //Response.Write(String.Format("<script>window.open('{0}');</script>", LSetting.File_Path + fileName));
            }
        }

        /// <summary>
        /// 填写跳转 
        /// 获取可选与非可选 如果是可选 检查它前面是否有正在审批的  如果是必选直接走
        /// </summary>
        /// <param name="aimPageName"></param>
        /// <param name="formTypeID"></param>
        private void pageRedirect(string aimPageName, string formTypeID)
        {
            //得到当前选中的的优先顺序数
            int type = Convert.ToInt32(formTypeID);
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(formTypeID);
            

            //老供应商直接跳转 不进行文件检查
            As_Employee_Vendor employeeVendor = AddEmployeeVendor_BLL.getEmployeeVendor(temp_Vendor_ID);
            if (employeeVendor.Type.Equals("OLD"))
            {
                if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                {
                    Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID);
                    return;
                }
                else
                {
                    Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID);
                    return;
                }
            }

            //可选必选结果
            string optional = getOptional(selectedFormPriorityNumber);
            if (optional == "可选")
            {
                if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString()) && isOptionalMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()) && isRequiredMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                {
                    Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID);
                }
                else
                {
                    Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID);
                }
            }
            else if (optional == "必选")
            {
                if (isMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                {
                    Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID);
                }
                else
                {
                    Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID);
                }
            }

        }


        private void pageRedirect(string aimPageName, string formTypeID, string formID)
        {
            //得到当前选中的的优先顺序数
            int type = Convert.ToInt32(formTypeID);
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(formTypeID);

            //老供应商直接跳转 不进行文件检查
            As_Employee_Vendor employeeVendor = AddEmployeeVendor_BLL.getEmployeeVendor(temp_Vendor_ID);
            if (employeeVendor.Type.Equals("OLD"))
            {
                if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                {
                    Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID + "&Form_ID=" + formID);
                    return;
                }
                else
                {
                    Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID + "&Form_ID=" + formID);
                    return;
                }
            }

            string optional = getOptional(selectedFormPriorityNumber);
            if (optional == "可选")
            {
                if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString()) && isOptionalMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()) && isRequiredMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                {
                    Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID + "&Form_ID=" + formID);
                }
                else
                {
                    Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID + "&Form_ID=" + formID);
                }
            }
            else if (optional == "必选")
            {
                if (isMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                {
                    Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID + "&Form_ID=" + formID);
                }
                else
                {
                    Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID + "&Form_ID=" + formID);
                }
            }

        }




        private string getOptional(int selectedFormPriorityNumber)
        {
            return FormType_BLL.getOptional(selectedFormPriorityNumber);
        }

        private bool withOutAccess(int number, string temp_vendor_ID)
        {
            return FormType_BLL.withOutAccess(number, temp_vendor_ID);
        }

        /// <summary>
        /// 控制审批顺序
        /// </summary>
        /// <param name="formTypeID"></param>
        /// <returns></returns>
        private int getSelectedFormPriorityNumber(string formTypeID)
        {
            return FormType_BLL.getSelectedFormPriorityNumber(formTypeID);
        }

        /// <summary>
        /// 当前选择是否是最小
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool isMinimum(int number, string temp_Vendor_ID)
        {
            bool ok = withOutAccess(number, Session["tempVendorID"].ToString());
            if (ok)
            {
                return FormType_BLL.isMinimumFormPriorityNumber(number, temp_Vendor_ID);
            }
            else
            {
                return false;
            }

        }

        private bool isOptionalMinimum(int number, string temp_Vendor_ID)
        {
            return FormType_BLL.isOptionalMinimum(number, temp_Vendor_ID);
        }
        private bool isRequiredMinimum(int number, string temp_Vendor_ID)//可选表前面的必须表都已经审完
        {
            return FormType_BLL.isRequiredMinimum(number, temp_Vendor_ID);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            string tempVendorID = Session["tempVendorID"].ToString();
            string factoryName = Session["Factory_Name"].ToString();
            //根据供应商类型编号查询所有待上传文件
            string sql3 = String.Format("SELECT * FROM View_Vendor_FileType WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}'", tempVendorID, factoryName);
            PagedDataSource objpds3 = new PagedDataSource();
            objpds3.DataSource = SelectEmployeeVendor_BLL.listVendorFileType(sql3);
            //获取数据源
            GridView4.DataSource = objpds3;
            //绑定数据源
            GridView4.DataBind();
            updatePanel.Update();
        }
    }
}