using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorExtend : System.Web.UI.Page
    {
        private As_Vendor_Extend Vendor;
        private string Temp_Vendor_ID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Temp_Vendor_ID = "hhhh";
            if (!IsPostBack)
            {
                Vendor = new As_Vendor_Extend();
                int check = VendorExtend_BLL.checkVendorExtend(Temp_Vendor_ID);//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    Vendor.Form_Type_ID = "001";
                    Vendor.Temp_Vendor_Name = Temp_Vendor_ID;
                    Vendor.Flag = 0;//将表格标志位信息改为已填写
                    int n = VendorExtend_BLL.addVendorExtend(Vendor);
                }
                else
                {
                    Vendor = VendorExtend_BLL.getVendorExtend(Temp_Vendor_ID);
                    showForm(Vendor);
                }
            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)//保存
        {
            Vendor = getVendorExtend();
            saveForm(Vendor);
        }

        protected void Button2_Click(object sender, EventArgs e)//提交
        {
            saveForm(Vendor);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
        private As_Vendor_Extend getVendorExtend()
        {
            As_Vendor_Extend v = new As_Vendor_Extend();
            v.Temp_Vendor_Name = "hhh";
            v.Temp_Vendor_ID = "hhhdsa";
            v.Bar_Code = "PR-05-07-04";
            v.Form_Type_ID = "001";
            v.Laguage = dropDownList1.SelectedValue.ToString().Trim();
            v.Purpose = TextBox1.Text.ToString().Trim();
            v.Initiator_Name = TextBox2.Text.ToString().Trim();
            v.Initiator_Tel = TextBox3.Text.ToString().Trim();
            v.Company_Code = TextBox4.Text.ToString().Trim();
            v.Vendor_Code = TextBox5.Text.ToString().Trim();
            v.From_Company = TextBox6.Text.ToString().Trim();
            v.Email = TextBox7.Text.ToString().Trim();
            v.Money_Type = TextBox8.Text.ToString().Trim();
            v.Line_Manager= TextBox9.Text.ToString().Trim();
            v.Comments = TextBox10.Text.ToString().Trim();
            return v;
        }
        private void saveForm(As_Vendor_Extend v)
        {
            VendorExtend_BLL.updateVendorExtend(v);
        }

        private void showForm(As_Vendor_Extend v)
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
            TextBox9.Text = v.Line_Manager;
            TextBox10.Text = v.Comments;
        }

    }
}