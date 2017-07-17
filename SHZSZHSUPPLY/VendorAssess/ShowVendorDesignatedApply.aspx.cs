using BLL;
using Model;
using System;
using System.Web.UI.WebControls;

namespace VendorAssess
{
    public partial class ShowVendorDesignatedApply : System.Web.UI.Page
    {
        private string formID = null;

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //重新获取session
                getSessionInfo();

                int check = As_Vendor_Designated_Apply_BLL.checkVendorDesignatedApply(formID);
                if (check > 0)
                {
                    showThisForm();
                }
            }
        }

        private void showThisForm()
        {
            InitWholeForm();
            showapproveform(formID);
            showfilelist(formID);
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
            As_Vendor_Designated_Apply form = As_Vendor_Designated_Apply_BLL.checkFlag(formID);
            if (form != null)
            {
                TextBox1.Text = form.VendorName;
                TextBox2.Text = form.SAPCode1;
                TextBox3.Text = form.BusinessCategory;
                TextBox4.Text = form.EffectiveTime.ToString();
                TextBox5.Text = form.PurchaseAmount;
                TextBox6.Text = form.Reason;
                TextBox7.Text = form.Initiator;
                TextBox8.Text = form.Date.ToString();
                TextBox9.Text = form.Applicant;
                TextBox10.Text = form.RequestDeptHead;
                TextBox11.Text = form.FinManager;
                TextBox12.Text = form.ApplicantDate.ToString();
                TextBox13.Text = form.RequestDeptHeadDate.ToString();
                TextBox14.Text = form.FinManagerDate.ToString();
                TextBox15.Text = form.PurchasingManager;
                TextBox16.Text = form.GM;
                TextBox17.Text = form.PurchasingManagerDtae.ToString();
                TextBox18.Text = form.GMDate1.ToString();
                TextBox19.Text = form.Director;
                TextBox20.Text = form.SupplyChainDirector;
                TextBox21.Text = form.DirectorDtae.ToString();
                TextBox22.Text = form.SupplyChainDirectorDate.ToString();
                TextBox23.Text = form.Persident;
                TextBox24.Text = form.FinalDate.ToString();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //TODO::简单的审批权限控制，通过之后无法再拒绝，拒绝之后无法再通过，拒绝需要填写原因，三厂区分
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
                    else
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
                    int i = AssessFlow_BLL.updateApproveFail(formid, positionName);
                    if (i == 1)
                    {
                        Response.Write("<script>window.alert('成功拒绝审批！');window.location.href='ShowVendorDesignatedApply.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorDesignatedApply.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
            }
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
        private void getSessionInfo()
        {
            formID = Session["formID"].ToString();
        }
    }
}