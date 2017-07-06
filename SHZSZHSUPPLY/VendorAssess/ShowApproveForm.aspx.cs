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
            string sql = "select * from As_Approve where Position_Name='" + Session["Position_Name"].ToString() + "'";
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
                Session["formid"] = GridView1.Rows[drv.RowIndex].Cells[0].Text;
                Response.Redirect("ShowVendorDiscovery.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}