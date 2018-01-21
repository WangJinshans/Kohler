using BLL;
using BLL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
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

            List<string> list = Employee_BLL.getAuthority(Session["Authority_ID"].ToString());

            //LocalScriptManager.CreateScript(Page, String.Format("filterNavigation('{0}', '{1}', '{2}', '{3}', '{4}')",list[0], list[1], list[2], list[3], list[4]), "dis");
            LocalScriptManager.CreateScript(Page, "filterNavigation('TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE')", "dis");
        }
    }
}