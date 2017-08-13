using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class ShowApproveForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO::sql中添加factory
            string sql = "select * from View_Approve_Top where Position_Name='" + Session["Position_Name"].ToString() + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = SelectApproveForm_BLL.selectApproveForm(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "showDetails")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                Session["tempVendorID"] = TempVendor_BLL.getTempVendorID(GridView1.Rows[drv.RowIndex].Cells[2].Text.ToString().Trim());//获取temp_Vendor_ID 并放入Session
                Session["formid"] = GridView1.Rows[drv.RowIndex].Cells[0].Text;
                Session["formTypeID"] = e.CommandArgument.ToString();
                string formname = GridView1.Rows[drv.RowIndex].Cells[1].Text;//获取点击的那张表的名称

                //根据名称进入不同的页面
                switchShowPage(e.CommandArgument.ToString());
            }
        }

        private void switchShowPage(string formTypeID)
        {
            switch (formTypeID)
            {
                case "001":
                    Response.Redirect("ShowVendorDiscovery.aspx");
                    break;
                case "002":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "013":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "014":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "015":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "016":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "017":
                    Response.Redirect("ShowBiddingApprovalform.aspx");
                    break;
                case "003":
                    Response.Redirect("ShowVendorRiskAnalysis.aspx");
                    break;
                case "004":
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                    break;
                case "025":
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                    break;
                case "005":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "006":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "007":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "008":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "009":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "010":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "011":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "012":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "018":
                    Response.Redirect("ShowVendorSelection.aspx");
                    break;
                case "019":
                    Response.Redirect("ShowVendorCreation.aspx");
                    break;
                default:
                    break;
            }
        }
    }
}