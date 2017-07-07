using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorAssess
{
    public partial class ShowVendorDesignatedApply : System.Web.UI.Page
    {
        private string formid = null;
        private As_Vendor_Designated_Apply form;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tempvendorname = null;
                if (Session["tempvendorname"] != null)
                {
                    tempvendorname = Session["tempvendorname"].ToString();
                    formid = tempvendorname + "指定供应商申请表PR-05-10-2";
                }
                else
                {
                    formid = Session["formid"].ToString();
                }
                InitWholeForm();
                showapproveform(formid);
                showfilelist(formid);
            }
        }

        private void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM As_Approve WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        private void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }
        private void InitWholeForm()//从数据库初始化整个数据表
        {
            string vendorname = Session["tempvendorname"].ToString();
            form = As_Vendor_Designated_Apply_BLL.GetWholeFormInfo(vendorname);
            TextBox2.Text = form.SAPCode1;
            TextBox3.Text = form.BusinessCategory;
            TextBox4.Text = form.EffectiveTime.ToString();
            //TextBox5.Text = form.PurchaseAmount;
            //TextBox6.Text = form.Reason;
            //TextBox7.Text = form.Initiator;
            //TextBox8.Text = form.Date.ToString();
            //TextBox9.Text = form.Applicant;
            //TextBox10.Text = form.RequestDeptHead;
            //TextBox11.Text = form.FinManager;
            //TextBox12.Text = form.ApplicantDate.ToString();
            //TextBox13.Text = form.RequestDeptHeadDate.ToString();
            //TextBox14.Text = form.FinManagerDate.ToString();
            //TextBox15.Text = form.PurchasingManager;
            //TextBox16.Text = form.GM1;
            //TextBox17.Text = form.PurchasingManagerDtae.ToString();
            //TextBox18.Text = form.GMDate1.ToString();
            //TextBox19.Text = form.Director;
            //TextBox20.Text = form.SupplyChainDirector;
            //TextBox21.Text = form.DirectorDtae.ToString();
            //TextBox22.Text = form.SupplyChainDirectorDate.ToString();
            //TextBox23.Text = form.Persident;
            //TextBox24.Text = form.FinalDate.ToString();
            //unEditable();
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