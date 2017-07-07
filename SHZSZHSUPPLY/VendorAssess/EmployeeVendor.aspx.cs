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
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from As_Employee_Vendor where Employee_ID='" + Session["Employee_ID"].ToString() + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = SelectEmployeeVendor_BLL.selectEmployeeVendor(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Session["tempvendorname"] = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            if (e.CommandName == "showDetails")
            {
                As_Vendor_FormType Vendor_Form = new As_Vendor_FormType();
                //根据供应商类型编号查询所有未填写表格类型
                string sql = "SELECT * FROM As_Vendor_FormType WHERE Temp_Vendor_ID='" + e.CommandArgument.ToString() + "'and flag ='0'";
                PagedDataSource objpds = new PagedDataSource();
                objpds.DataSource = SelectEmployeeVendor_BLL.listVendorFormType(sql);
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
        //向As_Form中添加表
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showDetails")
            {
                //获取供应商名称的值传入session;
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                Session["tempvendorname"] = GridView2.Rows[drv.RowIndex].Cells[2].Text;
                string formTypeID = e.CommandArgument.ToString();
                string tempvendorname = Session["tempvendorname"].ToString();

                //点击不同表格进入到不同界面.
                if (e.CommandArgument.ToString() == "004")//指定供应商申请表
                {
                    int checkfile = 0;
                    string formid = tempvendorname + "指定供应商申请表PR-05-10-2";//
                    checkfile = CheckFile_BLL.checkFile("001", tempvendorname, formid);//第一个参数传form_type_ID
                    if (checkfile == 0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        Response.Redirect("VendorDesignatedApply.aspx");
                    }
                }
                else if (e.CommandArgument.ToString() == "003") 
                {
                    Response.Redirect("VendorRiskAnalysis.aspx");
                }
                else if (e.CommandArgument.ToString() == "002")
                {
                    Response.Redirect("BiddingApprovalform.aspx");

                }
                else if (e.CommandArgument.ToString() == "001")
                {
                    int checkfile = 0;
                    string formid = tempvendorname + "调查表PR-05-01-5";
                    //独占，需要检查文件
                    checkfile = CheckFile_BLL.checkFile("001", tempvendorname, formid);
                    if(checkfile==0)
                    {
                        Response.Write("<script>window.alert('请先上传完整所需文件！')</script>");
                    }
                    else
                    {
                        Response.Redirect("VendorDiscovery.aspx");
                    }
                    
                }
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "供应商调查表")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                Session["tempvendorname"]= GridView3.Rows[drv.RowIndex].Cells[0].Text;
                Response.Redirect("ShowVendorDiscovery.aspx");
            }
            if (e.CommandArgument.ToString() == "指定供应商申请表")//跳进指定供应商申请表
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                Session["tempvendorname"] = GridView3.Rows[drv.RowIndex].Cells[0].Text;
                Response.Redirect("ShowVendorDesignatedApply.aspx");//指定供应商申请的查看页面
            }
        }
        //上传文件
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
                    string tempvendorname = Session["tempvendorname"].ToString();
                    file.Temp_Vendor_Name = tempvendorname;
                    file.File_ID = Session["tempvendorname"].ToString() + fileName;
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

    }
}