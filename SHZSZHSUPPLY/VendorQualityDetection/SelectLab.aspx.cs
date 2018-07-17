using BLL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class SelectLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string factory_Name = Session["Factory_Name"].ToString();
            GridView1.DataSource = SelectLab_BLL.getAllReseracher(Session["Factory_Name"].ToString());
            GridView1.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            GridView1.DataBind();
            GridView1.SelectedIndex = 0;
            string s= GridView1.Rows[0].Cells[2].Text.ToString();
            Session["type"] = s;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));

            if (e.CommandName == "select")
            {
                //职位
                Session["type"] = GridView1.Rows[drv.RowIndex].Cells[2].Text.ToString();
                //ko号
                Session["ToPersonID"] = GridView1.Rows[drv.RowIndex].Cells[0].Text.ToString();
            }
        }
    }
}