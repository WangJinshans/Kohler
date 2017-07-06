using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["Employee_ID"].ToString();
            Label2.Text = Session["Employee_Name"].ToString();
            Label4.Text = Session["Position_Name"].ToString();
        }
    }
}