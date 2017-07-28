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
            //TODO::处理session过期问题,封装数据库操作到DAL层
            string sql = "select * from As_Employee_Vendor where Employee_ID='" + Session["Employee_ID"].ToString() + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = SelectEmployeeVendor_BLL.selectEmployeeVendor(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        /// <summary>
        /// 待填写、提交表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //row
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));

            //绑定session
            Session["tempvendorname"] = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            Session["tempVendorID"] = GridView1.Rows[drv.RowIndex].Cells[1].Text;

            if (e.CommandName == "showDetails")
            {
                As_Vendor_FormType Vendor_Form = new As_Vendor_FormType();
                //根据供应商类型编号查询所有未填写表格类型
                string sql = "SELECT * FROM As_Vendor_FormType WHERE Temp_Vendor_ID='" + e.CommandArgument.ToString() + "'and flag ='0'";
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
                string sql2 = "SELECT * FROM As_Form WHERE Temp_Vendor_Name='" + GridView1.Rows[drv.RowIndex].Cells[2].Text + "'";
                PagedDataSource objpds2 = new PagedDataSource();
                objpds2.DataSource = SelectForm_BLL.selectForm(sql2);
                //获取数据源
                GridView3.DataSource = objpds2;
                //绑定数据源
                GridView3.DataBind();


                //根据供应商类型编号查询所有待上传文件
                string sql3 = "select * from As_Vendor_FileType where Temp_Vendor_ID='" + e.CommandArgument.ToString() + "'and flag ='0'";
                PagedDataSource objpds3 = new PagedDataSource();
                objpds3.DataSource = SelectEmployeeVendor_BLL.listVendorFileType(sql3);
                //获取数据源
                GridView4.DataSource = objpds3;
                //绑定数据源
                GridView4.DataBind();

                //根据供应商类型编号查询所有已上传文件
                As_File file = new As_File();
                string sql4 = "SELECT * FROM As_File WHERE Temp_Vendor_Name='" + GridView1.Rows[drv.RowIndex].Cells[2].Text + "'";
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
            switch (commandArgument)
            {
                case "001":
                    if (CheckFile_BLL.checkFile("001", tempVendorID) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        pageRedirect("VendorDiscovery.aspx","001");
                    }
                    break;
                case "002":
                    pageRedirect("BiddingApprovalform.aspx", "002");
                    break;
                case "011":
                    pageRedirect("BiddingApprovalform.aspx", "011");
                    break;
                case "012":
                    pageRedirect("BiddingApprovalform.aspx", "012");
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
                case "003":
                    if (CheckFile_BLL.checkFile("003",tempVendorID) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        pageRedirect("VendorRiskAnalysis.aspx", "003");
                    }
                    break;
                case "004":
                    if (CheckFile_BLL.checkFile("004", tempVendorID) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        pageRedirect("VendorDesignatedApply.aspx", "004");
                    }
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
                case "016":
                    pageRedirect("VendorSelection.aspx", "016");
                    break;
                case "017":
                    if (CheckFile_BLL.checkFile("017",tempVendorID) == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        pageRedirect("VendorCreation.aspx", "017");
                    }
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
            string switchPage = "";//由于多张表都叫合同审批表只是金额不同 填写查看时进入相同的表
            if (e.CommandArgument.ToString().Contains("合同审批表"))
            {
                switchPage = "合同审批表(承诺<=RMB1.5M)";
            }
            else
            {
                switchPage = e.CommandArgument.ToString();
            }
            //选择
            switch (switchPage)
            {
                case "供应商调查表":
                    Response.Redirect("ShowVendorDiscovery.aspx");
                    break;
                case "bidding form比价资料/会议纪要(非承诺<=RMB1.5M)":
                    Response.Redirect("ShowBiddingApprovalForm.aspx");
                    break;
                case "指定供应商申请表":
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                    break;
                case "供应商信息表(建立)":
                    Response.Redirect("ShowVendorCreation.aspx");
                    break;
                case "供应商风险分析表":
                    Response.Redirect("ShowVendorRiskAnalysis.aspx");
                    break;
                case "合同审批表(承诺<=RMB1.5M)":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "合同审批表(非承诺<=RMB3M)":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "供应商选择表":
                    Response.Redirect("ShowVendorSelection.aspx");
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
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(formTypeID);
            int type = Convert.ToInt32(formTypeID);
            if (type == 2 || (type >= 11 && type <= 15)) 
            {
                if (CheckFile_BLL.checkFile(formTypeID, Session["tempVendorID"].ToString()) == 0)
                {
                    Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                }
                else
                {
                    if (isMinimum(selectedFormPriorityNumber,Session["tempVendorID"].ToString()))
                    {
                        Response.Redirect(aimPageName + "?submit=yes&type=" + formTypeID);
                    }
                    else
                    {
                        Response.Redirect(aimPageName + "?submit=no&type=" + formTypeID);
                    }
                }
            }
            else if (type >=5 && type <= 9){
                if (CheckFile_BLL.checkFile(formTypeID, Session["tempVendorID"].ToString()) == 0)
                {
                    Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                }
                else
                {
                    if (isMinimum(selectedFormPriorityNumber,Session["tempVendorID"].ToString()))
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
                if (isMinimum(selectedFormPriorityNumber,Session["tempVendorID"].ToString()))
                {
                    Response.Redirect(aimPageName + "?submit=" + "yes");
                }
                else
                {
                    Response.Redirect(aimPageName + "?submit=" + "no");
                }
            }

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
            //List<string> vendorlist = new List<string>();
            //if (list != null && list.Count > 0)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        vendorlist.Add(list[i].Form_Type_ID);
            //    }
            //}
            //int minimum = FormType_BLL.getMinimumFormPriorityNumber(vendorlist);
            //if (number <= minimum) //优先级是最高的 
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return FormType_BLL.isMinimumFormPriorityNumber(number, temp_Vendor_ID);
        }
    }
}