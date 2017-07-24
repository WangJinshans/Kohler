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
    public partial class ShowVendorExtend : System.Web.UI.Page
    {
        private string formID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int check = VendorExtend_BLL.checkVendorExtend(formID);
            if (check > 0)
            {
                showForm();
            }

            showapproveform(formID);
            showfilelist(formID);
        }

        private void showForm()
        {
            As_Vendor_Extend v = new As_Vendor_Extend();
            v = VendorExtend_BLL.getVendorExtend(formID);
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
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string positionName = Session["Position_Name"].ToString();
            if (e.CommandName == "approvesuccess")
            {
                if (positionName.Equals(Session["Position_Name"].ToString()))
                {
                    int i = AssessFlow_BLL.updateApprove(formid, positionName);
                    if (i == 1)
                    {
                        Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowVendorDiscovery.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorDiscovery.aspx'</script>");
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
                    int i = AssessFlow_BLL.updateApproveFail(formid, positionName);
                    if (i == 1)
                    {
                        Response.Write("<script>window.alert('成功拒绝审批！');window.location.href='ShowVendorDiscovery.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorDiscovery.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
            }
        }
    }
}