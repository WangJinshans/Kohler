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
                string formname = GridView1.Rows[drv.RowIndex].Cells[0].Text;//获取点击的那张表的名称
                //根据GridView1.Rows[drv.RowIndex].Cells[0].Text获得的不同的ID然后进入不同的页面
                if (formname.Contains("调查表"))//类型调查表
                {
                    //传输数据
                    Response.Redirect("ShowVendorDiscovery.aspx");
                }
                else if (formname.Contains("申请表"))
                {
                    //获取Temp_Vendor_name 表 ：As_form
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}