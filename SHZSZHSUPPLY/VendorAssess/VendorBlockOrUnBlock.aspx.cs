using BLL;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorBlockOrUnBlock : System.Web.UI.Page
    {
        private As_Vendor_Block_Or_UnBlock Vendor;
        private static string factory;
        public const string FORM_NAME = "供应商信息表(恢复/删除/block)";
        public const string FORM_TYPE_ID = "021";//未改
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            Image1.Visible = false;//非show页面中不可操作
            Image2.Visible = false;
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = VendorBlockOrUnBlock_BLL.checkVendorBlock(formID);//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    Vendor = new As_Vendor_Block_Or_UnBlock();
                    Vendor.Form_Type_ID = FORM_TYPE_ID;
                    Vendor.Temp_Vendor_Name = tempVendorID;
                    Vendor.Flag = 0;//将表格标志位信息改为已填写
                    Vendor.Factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());

                    int n = VendorBlockOrUnBlock_BLL.addVendorBlock(Vendor);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        //获取formID信息
                        getSessionInfo();

                        //向FormFile表中添加相应的文件、表格绑定信息
                        bindingFormWithFile();
                    }
                }
                else
                {
                    Vendor = VendorBlockOrUnBlock_BLL.getVendorBlock(formID);
                    showForm(Vendor);
                }
            }
            else
            {
               //
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            saveForm(1,"保存");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //int submits = 1;
            //submits = VendorBlockOrUnBlock_BLL.SubmitOk(formID);
            if (submit == "yes")
            {
                saveForm(1, "提交");
                approveAssess(formID);
            }
            else
            {
                Response.Write("<script>window.alert('无法提交！')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeVendor.aspx");
        }

        private void bindingFormWithFile()
        {
            if (CheckFile_BLL.bindFormFile(FORM_TYPE_ID, tempVendorID, formID) == 0)
            {
                Response.Write("<script>window.alert('表格初始化错误（文件绑定失败）！')</script>");//若没有记录 返回文件不全
            }
        }


        public void approveAssess(string formId)
        {
            if (LocalApproveManager.doAddApprove(formId,FORM_NAME,FORM_TYPE_ID, tempVendorID))
            {
                Response.Write("<script>window.alert('提交成功！');window.location.href='EmployeeVendor.aspx'</script>");
            }
        }

        private As_Vendor_Block_Or_UnBlock getVendorBlock()
        {
            As_Vendor_Block_Or_UnBlock v = new As_Vendor_Block_Or_UnBlock();
            v.Temp_Vendor_Name = tempVendorName;
            v.Temp_Vendor_ID = tempVendorID;
            v.Bar_Code = "PR-05-07-04";
            v.Form_Type_ID = "001";
            v.Laguage = dropDownList1.SelectedValue.ToString().Trim();
            v.Purpose = TextBox1.Text.ToString().Trim();
            v.Initiator_Name = TextBox2.Text.ToString().Trim();
            v.Initiator_Tel = TextBox3.Text.ToString().Trim();
            v.Company_Code = TextBox4.Text.ToString().Trim();
            v.Vendor_Code = TextBox5.Text.ToString().Trim();
            v.Line_Manager = Image1.ImageUrl.ToString().Trim();
            v.Purchasing_Manager= Image2.ImageUrl.ToString().Trim();
            v.Comments = TextBox8.Text.ToString().Trim();
            return v;
        }

        private As_Vendor_Block_Or_UnBlock saveForm(int flag, string manul)
        {
            //读取session
            getSessionInfo();
            As_Vendor_Block_Or_UnBlock v = new As_Vendor_Block_Or_UnBlock();
            v = getVendorBlock();
            v.Flag = flag;
            int join = VendorBlockOrUnBlock_BLL.updateVendorBlock(v);
            if (join > 0)
            {
                As_Write write = new As_Write();//将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = formID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = tempVendorID;
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    Response.Write("<script>window.alert('保存成功！')</script>");
                }
                return v;
            }
            else
            {
                return null;
            }
        }

        private void showForm(As_Vendor_Block_Or_UnBlock v)
        {
            TextBox1.Text = v.Purpose;
            dropDownList1.Text = v.Laguage;
            TextBox2.Text = v.Initiator_Name;
            TextBox3.Text = v.Initiator_Tel;
            TextBox4.Text = v.Company_Code;
            TextBox5.Text = v.Vendor_Code;
            Image1.ImageUrl = v.Line_Manager;//直线经理的签名
            Image2.ImageUrl = v.Purchasing_Manager;//销售经理的签名
            TextBox8.Text = v.Comments;
        }

        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }
        private void getSessionInfo()
        {
            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            factory = Session["Factory_Name"].ToString().Trim();
            formID = VendorBlockOrUnBlock_BLL.getFormID(tempVendorID,FORM_NAME, factory);
            submit = Request.QueryString["submit"];
        }
    }
}