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
            string sql = String.Format("select * from View_Approve_Top where Position_Name='{0}' and Factory_Name='{1}'", Session["Position_Name"].ToString(),Session["Factory_Name"]);
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
                string formname = HttpUtility.HtmlDecode(GridView1.Rows[drv.RowIndex].Cells[1].Text);//获取点击的那张表的名称

                //根据名称进入不同的页面
                switchShowPage(e.CommandArgument.ToString());
            }
        }

        private void switchShowPage(string formTypeID)
        {
            switch (formTypeID)
            {
                case "001":
                    Response.Redirect("ShowVendorDiscovery.aspx?type=001");
                    break;
                case "002":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=002");
                    break;
                case "013":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=013");
                    break;
                case "014":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=014");
                    break;
                case "015":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=015");
                    break;
                case "016":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=016");
                    break;
                case "017":
                    Response.Redirect("ShowBiddingApprovalform.aspx?type=017");
                    break;
                case "003":
                    Response.Redirect("ShowVendorRiskAnalysis.aspx?type=003");
                    break;
                case "004":
                    Response.Redirect("ShowVendorDesignatedApply.aspx?type=004");
                    break;
                case "025":
                    Response.Redirect("ShowVendorDesignatedApply.aspx?type=025");
                    break;
                case "005":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=005");
                    break;
                case "006":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=006");
                    break;
                case "007":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=007");
                    break;
                case "008":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=008");
                    break;
                case "009":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=009");
                    break;
                case "010":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=010");
                    break;
                case "011":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=011");
                    break;
                case "012":
                    Response.Redirect("ShowContractApprovalForm.aspx?type=012");
                    break;
                case "018":
                    Response.Redirect("ShowVendorSelection.aspx?type=018");
                    break;
                case "019":
                    Response.Redirect("ShowVendorCreation.aspx?type=019");
                    break;
                default:
                    break;
            }
        }
    }
}