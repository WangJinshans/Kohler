using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public static class LocalScriptManager
    {
        /// <summary>
        /// 处理js脚本
        /// </summary>
        /// <param name="mypage"></param>
        /// <param name="strScript"></param>
        /// <param name="ID"></param>
        public static void CreateScript(System.Web.UI.Page mypage, string strScript, string ID)
        {
            string strscript = "<script language='javascript'>";
            strscript += strScript;
            strscript += "</script>";
            if (!mypage.ClientScript.IsStartupScriptRegistered(ID))
                mypage.ClientScript.RegisterStartupScript(mypage.GetType(), ID, strscript);
        }
    }
}