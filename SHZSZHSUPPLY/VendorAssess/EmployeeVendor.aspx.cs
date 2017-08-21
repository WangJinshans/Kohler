using BLL;
using BLL.VendorAssess;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class EmployeeVendor : System.Web.UI.Page
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
            string sql = "SELECT * FROM View_Vendor_FormType WHERE Temp_Vendor_ID='" + tempVendorID + "'and flag ='0' and Factory_Name='" + factoryName + "'";
            PagedDataSource objpds = new PagedDataSource();
            IList<As_Vendor_FormType> gridView2list = new List<As_Vendor_FormType>();
            gridView2list = SelectEmployeeVendor_BLL.listVendorFormType(sql);
            objpds.DataSource = gridView2list;

            //获取数据源
            GridView2.DataSource = objpds;
            //绑定数据源
            GridView2.DataBind();

            //根据供应商类型编号查询所有已提交表格
            As_Form form = new As_Form();
            string sql2 = String.Format("SELECT * FROM As_Form WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}' and Status='new'", tempVendorID, factoryName);
            PagedDataSource objpds2 = new PagedDataSource();
            objpds2.DataSource = SelectForm_BLL.selectForm(sql2);
            GridView3.DataSource = objpds2;
            GridView3.DataBind();
            //根据供应商类型编号查询所有待上传文件
            string sql3 = String.Format("SELECT * FROM View_Vendor_FileType WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}'", tempVendorID, factoryName);
            PagedDataSource objpds3 = new PagedDataSource();
            objpds3.DataSource = SelectEmployeeVendor_BLL.listVendorFileType(sql3);
            //获取数据源
            GridView4.DataSource = objpds3;
            //绑定数据源
            GridView4.DataBind();

            ////根据供应商类型编号查询所有已上传文件 
            //As_File file = new As_File();
            //string sql4 = String.Format("SELECT * FROM As_File WHERE Temp_Vendor_ID='{0}' and Factory_Name in ('{1}','ALL') and Status='new'", tempVendorID, factoryName);
            //PagedDataSource objpds4 = new PagedDataSource();
            //objpds4.DataSource = File_BLL.selectFile(sql4);
            ////获取数据源
            //GridView5.DataSource = objpds4;
            ////绑定数据源
            //GridView5.DataBind();
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
                LocalScriptManager.CreateScript(Page, "message('请上传："+result+"')", "msg");
                return;
            }

            switch (commandArgument)
            {
                case "001":
                    pageRedirect("VendorDiscovery.aspx","001");
                    break;
                case "002":
                    pageRedirect("BiddingApprovalform.aspx", "002");
                    break;
                case "013":
                    pageRedirect("BiddingApprovalform.aspx", "013");
                    break;
                case "014":
                    pageRedirect("BiddingApprovalform.aspx", "014");
                    break;
                case "015":
                    pageRedirect("BiddingApprovalform.aspx", "015");
                    break;
                case "016":
                    pageRedirect("BiddingApprovalform.aspx", "016");
                    break;
                case "017":
                    pageRedirect("BiddingApprovalform.aspx", "017");
                    break;
                case "003":
                    pageRedirect("VendorRiskAnalysis.aspx", "003");
                    break;
                case "004":
                    pageRedirect("VendorDesignatedApply.aspx", "004");
                    break;
                case "025":
                    pageRedirect("VendorDesignatedApply.aspx", "025");
                    break;
                case "005":
                    pageRedirect("ContractApprovalForm.aspx", "005");
                    break;
                case "006":
                    pageRedirect("ContractApprovalForm.aspx", "006");
                    break;
                case "007":
                    pageRedirect("ContractApprovalForm.aspx", "007");
                    break;
                case "008":
                    pageRedirect("ContractApprovalForm.aspx", "008");
                    break;
                case "009":
                    pageRedirect("ContractApprovalForm.aspx", "009");
                    break;
                case "010":
                    pageRedirect("ContractApprovalForm.aspx", "010");
                    break;
                case "011":
                    pageRedirect("ContractApprovalForm.aspx", "011");
                    break;
                case "012":
                    pageRedirect("ContractApprovalForm.aspx", "012");
                    break;
                case "018":
                    pageRedirect("VendorSelection.aspx", "018");
                    break;
                case "019":
                    pageRedirect("VendorCreation.aspx", "019");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 查看表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //获取信息
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Session["formID"] = GridView3.Rows[drv.RowIndex].Cells[2].Text;
            Session["formTypeID"] = e.CommandArgument.ToString();

            switch (e.CommandArgument.ToString())
            {
                case "001":
                    Response.Redirect("ShowVendorDiscovery.aspx?type=001");
                    break;
                case "002":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=002");
                    break;
                case "013":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=013");
                    break;
                case "014":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=014");
                    break;
                case "015":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=015");
                    break;
                case "016":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=016");
                    break;
                case "017":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=017");
                    break;
                case "003":
                    Response.Redirect("ShowVendorRiskAnalysis.aspx?type=003");
                    break;
                case "004":
                    Response.Redirect("ShowVendorDesignatedApply.aspx?type=004");
                    break;
                case "025":
                    Response.Redirect("ShowVendorDesignatedApply.aspx?type=025");
                    break;
                case "005":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=005");
                    break;
                case "006":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=006");
                    break;
                case "007":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=007");
                    break;
                case "008":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=008");
                    break;
                case "009":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=009");
                    break;
                case "010":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=010");
                    break;
                case "011":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=011");
                    break;
                case "012":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=012");
                    break;
                case "018":
                    Response.Redirect("ShowVendorSelection.aspx?type=018");
                    break;
                case "019":
                    Response.Redirect("ShowVendorCreation.aspx?type=019");
                    break;
                default:
                    break;
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
                LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}')",requestType,tempVendorID,tempVendorName,fileTypeID), "upload");
            }//覆盖
            else if (e.CommandName == "ReLoad")
            {

            }//查看
            else if (e.CommandName == "FileDetail")
            {
                string fileTypeID = e.CommandArgument.ToString();
                string fileName = File_BLL.getFileName(fileTypeID, Session["tempVendorID"].ToString(), factory_Name);

                Response.Write(String.Format("<script>window.open('{0}');</script>",LSetting.File_Path+fileName));
            }
        }

        /// <summary>
        /// 填写跳转
        /// </summary>
        /// <param name="aimPageName"></param>
        /// <param name="formTypeID"></param>
        private void pageRedirect(string aimPageName,string formTypeID)
        {
            //得到当前选中的的优先顺序数
            int type = Convert.ToInt32(formTypeID);
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(formTypeID);
            //获取可选与非可选 如果是可选 检查它前面是否有正在审批的  如果是必选直接走
            string optional = getOptional(selectedFormPriorityNumber);
            if (optional == "可选")
            {
                if (type == 2 || (type >= 11 && type <= 15))
                {
                    if (CheckFile_BLL.checkFile(formTypeID, Session["tempVendorID"].ToString()) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString())&& isOptionalMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString())&& isRequiredMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                        {
                            Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID);
                        }
                        else
                        {
                            Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID);
                        }
                    }
                }
                else if (type >= 5 && type <= 9)
                {
                    if (CheckFile_BLL.checkFile(formTypeID, Session["tempVendorID"].ToString()) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString())&& isOptionalMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString())&& isRequiredMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                        {
                            Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID);
                        }
                        else
                        {
                            Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID);
                        }
                    }
                }
                else
                {
                    if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString())&& isOptionalMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString())&& isRequiredMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
                    {
                        Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID);
                    }
                    else
                    {
                        Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID);
                    }
                }
            }
            if (optional == "必选")
            {
                if (type == 2 || (type >= 11 && type <= 15))
                {
                    if (CheckFile_BLL.checkFile(formTypeID, Session["tempVendorID"].ToString()) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
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
                else if (type >= 5 && type <= 9)
                {
                    if (CheckFile_BLL.checkFile(formTypeID, Session["tempVendorID"].ToString()) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
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
                else
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
            

        }

        private string getOptional(int selectedFormPriorityNumber)
        {
            return FormType_BLL.getOptional(selectedFormPriorityNumber);
        }

        private bool withOutAccess(int number,string temp_vendor_ID)
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
        private bool isMinimum(int number,string temp_Vendor_ID)
        {
            bool ok=withOutAccess(number, Session["tempVendorID"].ToString());
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