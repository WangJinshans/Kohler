using BLL;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorExtend : System.Web.UI.Page
    {
        public const string FORM_NAME = "供应商信息表(扩展)";
        public const string FORM_TYPE_ID = "022";
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";
        private static string language;//判断语言
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = false;
            if (!IsPostBack)
            {
                int check = VendorExtend_BLL.checkVendorExtend(formID);//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_Vendor_Extend vendor = new As_Vendor_Extend();
                    vendor.Form_Type_ID = FORM_TYPE_ID;
                    vendor.Temp_Vendor_Name = tempVendorID;
                    vendor.Flag = 0;//将表格标志位信息改为已填写
                    vendor.Factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());

                    int n = VendorExtend_BLL.addVendorExtend(vendor);
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
                    showVendorExtend();
                }
            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)//保存
        {
            saveForm(1,"保存");
        }

        protected void Button2_Click(object sender, EventArgs e)//提交
        {
            if (submit == "yes")
            {
                saveForm(2, "提交");
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

        private void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        private As_Vendor_Extend getVendorExtend()
        {
            As_Vendor_Extend v = new As_Vendor_Extend();
            v.Temp_Vendor_Name = tempVendorName;
            v.Temp_Vendor_ID = tempVendorID;
            v.Bar_Code = "PR-05-07-04";//
            v.Form_Type_ID = FORM_TYPE_ID;
            v.Laguage = dropDownList1.SelectedValue.ToString().Trim();
            v.Purpose = TextBox1.Text.ToString().Trim();
            v.Initiator_Name = TextBox2.Text.ToString().Trim();
            v.Initiator_Tel = TextBox3.Text.ToString().Trim();
            v.Company_Code = TextBox4.Text.ToString().Trim();
            v.Vendor_Code = TextBox5.Text.ToString().Trim();
            v.From_Company = TextBox6.Text.ToString().Trim();
            v.Email = TextBox7.Text.ToString().Trim();
            v.Money_Type = TextBox8.Text.ToString().Trim();
            //v.Line_Manager= Image1.ImageUrl.ToString().Trim();
            v.Comments = TextBox10.Text.ToString().Trim();
            return v;
        }
        private As_Vendor_Extend saveForm(int flag,string manul)
        {
            As_Vendor_Extend vs = new As_Vendor_Extend();
            vs = VendorExtend_BLL.getVendorExtend(formID);
            int join = VendorExtend_BLL.updateVendorExtend(vs);
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
                return vs;
            }
            else
            {
                return null;
            }

        }

        private void showVendorExtend()
        {
            As_Vendor_Extend v = new As_Vendor_Extend();
            v = VendorExtend_BLL.getVendorExtend(formID);
            if (v != null)
            {
                TextBox1.Text = v.Purpose;
                dropDownList1.Text = v.Laguage;
                TextBox2.Text = v.Initiator_Name;
                TextBox3.Text = v.Initiator_Tel;
                TextBox4.Text = v.Company_Code;
                TextBox5.Text = v.Vendor_Code;
                TextBox6.Text = v.From_Company;
                TextBox7.Text = v.Email;
                TextBox8.Text = v.Money_Type;
                Image1.ImageUrl = v.Line_Manager;
                TextBox10.Text = v.Comments;
            }    
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
            if (LocalApproveManager.doAddApprove(formId, FORM_NAME, FORM_TYPE_ID, tempVendorID))
            {
                Response.Write("<script>window.alert('提交成功！');window.location.href='EmployeeVendor.aspx'</script>");
            }
        }

        private void getSessionInfo()
        {
            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            formID = VendorExtend_BLL.getFormID(tempVendorID);
            submit = Request.QueryString["submit"];
        }
    }
}