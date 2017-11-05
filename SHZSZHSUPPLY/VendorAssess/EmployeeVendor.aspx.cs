using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
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
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 获取此用户所管理的供应商列表
        /// </summary>
        private void readVendorInfo()
        {
            info = TempVendor_BLL.readVendorInfo(Session["Employee_ID"].ToString());
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
            string factoryName = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());

            //绑定session
            Session["tempvendorname"] = TempVendor_BLL.getTempVendorName(tempVendorID);
            Session["tempVendorID"] = tempVendorID;

            As_Vendor_FormType Vendor_Form = new As_Vendor_FormType();
            //根据供应商类型编号查询所有未填写表格类型
            string sql = "SELECT * FROM View_Vendor_FormType WHERE Temp_Vendor_ID='" + tempVendorID + "'and flag ='0' and Factory_Name='" + factoryName + "' order by Form_Type_Priority_Number asc";
            PagedDataSource objpds = new PagedDataSource();
            IList<As_Vendor_FormType> gridView2list = new List<As_Vendor_FormType>();
            gridView2list = SelectEmployeeVendor_BLL.listVendorFormType(sql);
            objpds.DataSource = gridView2list;

            //获取数据源
            GridView2.DataSource = objpds;
            //绑定数据源
            GridView2.DataBind();


            //查询所有等待其他部门填写的表格
            string sql1 = String.Format("SELECT * FROM View_Vendor_FormType WHERE Temp_Vendor_ID='{0}'and flag ='2' and Factory_Name='{1}' order by Form_Type_Priority_Number asc", tempVendorID, factoryName);
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
            //As_Form form = new As_Form();
            string sql2 = String.Format("SELECT * FROM View_Form_Status WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}' and Status='new'", tempVendorID, factoryName);
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
            //获取数据源
            GridView4.DataSource = objpds3;
            //绑定数据源
            GridView4.DataBind();
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
                string tempvendorname = GridView2.Rows[drv.RowIndex].Cells[2].Text;
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
            string result = CheckFile_BLL.checkFileWithResult(commandArgument, tempVendorID);
            if (!result.Equals(""))
            {
                LocalScriptManager.CreateScript(Page, "message('请上传：" + result + "')", "msg");
                return;
            }

            //跳转
            pageRedirect(PageSelect.dcEditToShow[commandArgument], commandArgument);
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
                Response.Redirect("/VendorAssess/ApprovalProgress.aspx?formID=" + e.CommandArgument.ToString());
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

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "showFileDetail", String.Format("<script>window.open('{0}');</script>", LSetting.File_Path + fileName), false);
                //Response.Write(String.Format("<script>window.open('{0}');</script>", LSetting.File_Path + fileName));
            }
        }

        /// <summary>
        /// 填写跳转
        /// </summary>
        /// <param name="aimPageName"></param>
        /// <param name="formTypeID"></param>
        private void pageRedirect(string aimPageName, string formTypeID)
        {
            //得到当前选中的的优先顺序数
            int type = Convert.ToInt32(formTypeID);
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(formTypeID);

            //获取可选与非可选 如果是可选 检查它前面是否有正在审批的  如果是必选直接走
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
            }else if (optional == "必选")
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
    }
}