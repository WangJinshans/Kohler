using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class EmployeeVendor : System.Web.UI.Page
    {
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

                list = SelectEmployeeVendor_BLL.listVendorFormType(sql);

                objpds.DataSource = list;
                //获取数据源
                GridView2.DataSource = objpds;
                //绑定数据源
                GridView2.DataBind();


                //根据供应商类型编号查询所有已填写表格
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
            Session["formID"]= GridView3.Rows[drv.RowIndex].Cells[2].Text;

            //选择
            switch (e.CommandArgument.ToString())
            {
                case "供应商调查表":
                    Response.Redirect("ShowVendorDiscovery.aspx");
                    break;
                case "指定供应商申请表":
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                    break;
                case "供应商信息表":
                    Response.Redirect("ShowVendorCreation.aspx");
                    break;
                case "供应商风险分析表":
                    Response.Redirect("ShowVendorRiskAnalysis.aspx");
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
                string fullFileName = FileUpload1.PostedFile.FileName;//取出本地路径
                string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);//取出文件名
                string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);//限定格式为pdf
                if (type == "pdf")
                {
                    //文件保存在服务器的files文件中
                    string saveFileName = Server.MapPath("/files") + "//" + fileName;
                    FileUpload1.PostedFile.SaveAs(saveFileName);

                    //向数据库中存储相应通知的附件的目录  
                    As_File file = new As_File();     //创建附件的实体  

                    file.File_Name = fileName;               //附件名  
                    file.File_Path = saveFileName;        //附件的存储路径  
                    file.Temp_Vendor_ID = Session["tempVendorID"].ToString();
                    string tempvendorname = Session["tempvendorname"].ToString();

                    file.Temp_Vendor_Name = tempvendorname;
                    file.File_ID = tempvendorname + fileName;
                    file.File_Enable_Time = "100";
                    file.File_Due_Time = "200";
                    GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                    file.File_Type_ID = GridView4.Rows[drv.RowIndex].Cells[2].Text;

                    string Temp_Vendor_ID = TempVendor_BLL.getTempVendorID(tempvendorname);
                    int join = File_BLL.addFile(file);
                    int flag = UpdateFlag_BLL.updateFileFlag(file.File_Type_ID, Temp_Vendor_ID);
                    if (join > 0 && flag > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('上传成功！');</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('上传失败！');</script>");
                    }

                    
                }


            }

        }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        private void pageRedirect(string aimPageName,string formTypeID)
        {
            //得到当前选中的的优先顺序数
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(formTypeID);

            if (isMinimum(selectedFormPriorityNumber))
            {
                Response.Redirect(aimPageName+"?submit=" + "yes");
            }
            else
            {
                Response.Redirect(aimPageName + "?submit=" + "no");
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
        private bool isMinimum(int number)
        {
            List<string> vendorlist = new List<string>();
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    vendorlist.Add(list[i].Form_Type_ID);
                }
            }
            int minimum = FormType_BLL.getMinimumFormPriorityNumber(vendorlist);
            if (number <= minimum) //优先级是最高的 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}