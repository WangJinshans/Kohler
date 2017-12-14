using BLL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess.Html_Template
{
    public partial class SignatureSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string[]> dc = new Dictionary<string, string[]>();

            Employee_BLL.createSignatureSelection(dc);

            LocalScriptManager.CreateScript(Page, "setParams('"+ new JavaScriptSerializer().Serialize(dc)+ "')", "set");
        }
    }
}