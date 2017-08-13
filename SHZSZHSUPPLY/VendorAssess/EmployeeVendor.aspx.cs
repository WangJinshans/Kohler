using BLL;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class EmployeeVendor : System.Web.UI.Page
    {
        private static string temp_Vendor_ID;//可能因为得不到值  所以加了static
        private static IList<As_Vendor_FormType> list = new List<As_Vendor_FormType>();
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //TODO::处理session过期问题,封装数据库操作到DAL层
                string sql = "select * from As_Employee_Vendor where Employee_ID='" + Session["Employee_ID"].ToString() + "'";
                PagedDataSource objpds = new PagedDataSource();
                objpds.DataSource = SelectEmployeeVendor_BLL.selectEmployeeVendor(sql);
                GridView1.DataSource = objpds;
                GridView1.DataBind();
            }
        }

        /// <summary>
        /// 待填写、提交表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //
            string factoryName = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());

            //row
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));

            //绑定session
            Session["tempvendorname"] = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            Session["tempVendorID"] = GridView1.Rows[drv.RowIndex].Cells[1].Text;

            if (e.CommandName == "showDetails")
            {
                As_Vendor_FormType Vendor_Form = new As_Vendor_FormType();
                //根据供应商类型编号查询所有未填写表格类型
                string sql = "SELECT * FROM View_Vendor_FormType WHERE Temp_Vendor_ID='" + e.CommandArgument.ToString() + "'and flag ='0' and Factory_Name='"+factoryName+"'";
                PagedDataSource objpds = new PagedDataSource();
                IList<As_Vendor_FormType> gridView2list = new List<As_Vendor_FormType>();
                gridView2list= SelectEmployeeVendor_BLL.listVendorFormType(sql);

                //提交判断的list status中1代表已经完成审批 0代表未完成审批
                //string sql1 = "SELECT * FROM As_Form_Type,As_Form WHERE As_Form_Type.Form_Type_ID=As_Form.Form_Type_ID and Temp_Vendor_ID='" + e.CommandArgument.ToString() + "'and Status='1'";
                //list = SelectEmployeeVendor_BLL.listVendorFormType(sql1);

                temp_Vendor_ID = e.CommandArgument.ToString();//获取temp_Vendor_ID;方便后面获取最小值时使用
                objpds.DataSource = gridView2list;
                //获取数据源
                GridView2.DataSource = objpds;
                //绑定数据源
                GridView2.DataBind();

                //TODO::查询所有待确认表格

                //根据供应商类型编号查询所有已提交表格
                As_Form form = new As_Form();
                string sql2 = String.Format("SELECT * FROM As_Form WHERE Temp_Vendor_ID='{0}' and Factory_Name='{1}'", e.CommandArgument.ToString(), factoryName);
                PagedDataSource objpds2 = new PagedDataSource();
                objpds2.DataSource = SelectForm_BLL.selectForm(sql2);
                //获取数据源
                GridView3.DataSource = objpds2;
                //绑定数据源
                GridView3.DataBind();


                //根据供应商类型编号查询所有待上传文件
                string sql3 = String.Format("SELECT * FROM As_Vendor_FileType WHERE flag=0 and Temp_Vendor_ID='{0}' and Factory_Name='{1}'", e.CommandArgument.ToString(), factoryName);
                PagedDataSource objpds3 = new PagedDataSource();
                objpds3.DataSource = SelectEmployeeVendor_BLL.listVendorFileType(sql3);
                //获取数据源
                GridView4.DataSource = objpds3;
                //绑定数据源
                GridView4.DataBind();

                //根据供应商类型编号查询所有已上传文件
                As_File file = new As_File();
                string sql4 = String.Format("SELECT * FROM As_File WHERE Temp_Vendor_ID='{0}' and Factory_Name in ('{1}','ALL')", e.CommandArgument.ToString(), factoryName);
                //string sql4 = "SELECT * FROM As_File WHERE Temp_Vendor_ID='" + e.CommandArgument.ToString() + "' and Factory_Name='" + factoryName + "'";
                PagedDataSource objpds4 = new PagedDataSource();
                objpds4.DataSource = File_BLL.selectFile(sql4);
                //获取数据源
                GridView5.DataSource = objpds4;
                //绑定数据源
                GridView5.DataBind();

            }
        }

        /// <summary>
        /// 向As_Form中添加表
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

        private void switchPage(string commandArgument, string tempVendorID)
        {
            string result = CheckFile_BLL.checkFileWithResult(commandArgument, tempVendorID);
            if (!result.Equals(""))
            {
                LocalScriptManager.CreateScript(Page, "lay_message('请上传："+result+"')", "msg");
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
                    Response.Redirect("ShowVendorDiscovery.aspx");
                    break;
                case "002":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "013":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "014":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "015":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "016":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "017":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "003":
                    Response.Redirect("ShowVendorRiskAnalysis.aspx");
                    break;
                case "004":
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                    break;
                case "025":
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                    break;
                case "005":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "006":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "007":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "008":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "009":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "010":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "011":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "012":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "018":
                    Response.Redirect("ShowVendorSelection.aspx");
                    break;
                case "019":
                    Response.Redirect("ShowVendorCreation.aspx");
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
            if (e.CommandName == "UpLoad")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempVendorID = Session["tempVendorID"].ToString();
                string tempVendorName = Session["tempvendorname"].ToString();
                string fileTypeID = GridView4.Rows[drv.RowIndex].Cells[2].Text;
                string requestType = "fileUpload";
                LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}')",requestType,tempVendorID,tempVendorName,fileTypeID), "upload");
            }
        }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

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
                        Response.Redirect(aimPageName + "?submit=" + "yes");
                    }
                    else
                    {
                        Response.Redirect(aimPageName + "?submit=" + "no");
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
                        Response.Redirect(aimPageName + "?submit=" + "yes");
                    }
                    else
                    {
                        Response.Redirect(aimPageName + "?submit=" + "no");
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