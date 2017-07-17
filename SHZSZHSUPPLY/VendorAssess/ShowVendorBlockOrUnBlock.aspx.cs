using BLL;
using Model;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowVendorBlockOrUnBlock : System.Web.UI.Page
    {
        private As_Vendor_Block_Or_UnBlock Vendor;
        private string Temp_Vendor_ID;
        private string Form_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Vendor = VendorBlockOrUnBlock_BLL.getVendorBlock(Temp_Vendor_ID);
            if (Vendor != null)
            {
                showForm(Vendor);
            }
            showapproveform(Form_ID);
            showfilelist(Form_ID);
        }

        private void showForm(As_Vendor_Block_Or_UnBlock v)
        {
            TextBox1.Text = v.Purpose1;
            dropDownList1.Text = v.Laguage1;
            TextBox2.Text = v.Initiator_Name1;
            TextBox3.Text = v.Initiator_Tel1;
            TextBox4.Text = v.Company_Code1;
            TextBox5.Text = v.Vendor_Code1;
            TextBox6.Text = v.Line_Manager1;
            TextBox7.Text = v.Purchasing_Manager1;
            TextBox8.Text = v.Comments1;
        }
        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        public void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM As_Approve WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "approvesuccess")
            {

                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
                string positionname = Session["Position_Name"].ToString();
                int i = AssessFlow_BLL.updateApprove(formid, positionname);
                if (i == 1)
                {
                    //Response.Redirect("Vendor_Discovery.aspx");
                }
                else if (e.CommandName == "fail")
                {
                    int j = AssessFlow_BLL.updateApproveFail(formid, positionname);
                }
            }
        }
    }
}