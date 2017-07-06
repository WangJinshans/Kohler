using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI ;
using System.Web;

namespace BLL.ErrorMessage
{
    public class ErrorMsg_BLL
    {
        public static void WebMessage(Page webpage,string msg)
        {
            webpage.ClientScript.RegisterStartupScript(webpage.GetType(), "", "<script language=javascript>alert('" + msg + "')</script>");
        }
    }
}
