using BLL;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowVendorBlockOrUnBlock : System.Web.UI.Page
    {
        private string formID = null;
        private string positionName = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = VendorBlockOrUnBlock_BLL.checkVendorBlock(formID);
                if (check > 0)
                {
                    showVendorBlock();
                }
            }

        }

        private void showVendorBlock()
        {
            As_Vendor_Block_Or_UnBlock v = new As_Vendor_Block_Or_UnBlock();
            v = VendorBlockOrUnBlock_BLL.getVendorBlock(formID);
            if (v != null)
            {
                TextBox1.Text = v.Purpose;
                dropDownList1.Text = v.Laguage;
                TextBox2.Text = v.Initiator_Name;
                TextBox3.Text = v.Initiator_Tel;
                TextBox4.Text = v.Company_Code;
                TextBox5.Text = v.Vendor_Code;
                hideImage(v.Line_Manager, Image1);
                hideImage(v.Purchasing_Manager, Image2);
                TextBox8.Text = v.Comments;
            }
            else
            {
                Image1.Visible = false;
                Image2.Visible = false;
            }
            showapproveform(formID);
            showfilelist(formID);
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
            objpds.DataSource = AssessFlow_BLL.listApprove(sql,positionName);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }


        private void getSessionInfo()
        {
            formID = Session["formID"].ToString();
            positionName = Session["Position_Name"].ToString();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "approvesuccess")
            {

                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
                string positionName = GridView1.Rows[drv.RowIndex].Cells[1].Text;
                if (e.CommandName == "approvesuccess")
                {
                    if (positionName.Equals(Session["Position_Name"].ToString()))
                    {
                        int i = AssessFlow_BLL.updateApprove(formid, positionName);
                        if (i == 1)
                        {
                            Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowVendorDesignatedApply.aspx'</script>");
                        }
                        else if (e.CommandName == "fail")
                        {
                            Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorDesignatedApply.aspx'</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                    }
                }
                else if (e.CommandName == "fail")
                {
                    if (positionName.Equals(Session["Position_Name"].ToString()))
                    {
                        LocalScriptManager.CreateScript(Page, String.Format("openReasonDialog('{0}','{1}','{2}',{3})", formID, positionName, Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString()), "null"), "reasonDialog");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                    }
                }
            }
        }

        private void hideImage(string signature, Image image)
        {
            if (signature != "")
            {
                image.ImageUrl = signature;
            }
            else
            {
                image.Visible = false;
            }
        }
    }
}