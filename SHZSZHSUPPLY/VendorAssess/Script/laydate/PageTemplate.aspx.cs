using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess.Html_Template
{
    public partial class PageTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "submitForm":
                        LocalApproveManager.submitForm();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}