using BLL;
using Model;
using MODEL;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorBlockOrUnBlock : System.Web.UI.Page
    {
        private As_Vendor_Block_Or_UnBlock Vendor;
        private string Temp_Vendor_ID = "hhhh";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int check = VendorBlockOrUnBlock_BLL.checkVendorBlock(Temp_Vendor_ID);//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    Vendor = new As_Vendor_Block_Or_UnBlock();
                    Vendor.Form_Type_ID = "001";
                    Vendor.Temp_Vendor_Name = Temp_Vendor_ID;
                    Vendor.Flag = 0;//将表格标志位信息改为已填写
                    int n = VendorBlockOrUnBlock_BLL.addVendorBlock(Vendor);
                }
                else
                {
                    Vendor = VendorBlockOrUnBlock_BLL.getVendorBlock(Temp_Vendor_ID);
                    showForm(Vendor);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Vendor = getVendorBlock();
            saveForm(Vendor);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        private As_Vendor_Block_Or_UnBlock getVendorBlock()
        {
            As_Vendor_Block_Or_UnBlock v = new As_Vendor_Block_Or_UnBlock();
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
            v.Line_Manager = TextBox6.Text.ToString().Trim();
            v.Purchasing_Manager= TextBox7.Text.ToString().Trim();
            v.Comments = TextBox8.Text.ToString().Trim();
            return v;
        }
        private void saveForm(As_Vendor_Block_Or_UnBlock v)
        {
            VendorBlockOrUnBlock_BLL.updateVendorBlock(v);
        }
        private void showForm(As_Vendor_Block_Or_UnBlock v)
        {
            TextBox1.Text = v.Purpose;
            dropDownList1.Text = v.Laguage;
            TextBox2.Text = v.Initiator_Name;
            TextBox3.Text = v.Initiator_Tel;
            TextBox4.Text = v.Company_Code;
            TextBox5.Text = v.Vendor_Code;
            TextBox6.Text = v.Line_Manager;
            TextBox7.Text = v.Purchasing_Manager;
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
    }
}