using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

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

        /// <summary>
        /// 暂时不可用，原因不明 2017年11月6日20:03:24
        /// </summary>
        /// <param name="mypage"></param>
        /// <param name="strScript"></param>
        internal static void CreateScript(Page mypage, string strScript)
        {
            string strscript = "<script language='javascript'>";
            strscript += strScript;
            strscript += "</script>";
            if (!mypage.ClientScript.IsStartupScriptRegistered(strScript))
                mypage.ClientScript.RegisterStartupScript(mypage.GetType(), strScript, strscript);
        }

        /// <summary>
        /// 注意：此方法为异步ajax，其执行顺序位于onload之前 2017年11月26日19:30:44
        /// </summary>
        /// <param name="page"></param>
        /// <param name="script"></param>
        /// <param name="name"></param>
        public static void createManagerScript(Page page, string script, string name)
        {
            string strscript = "<script language='javascript'>";
            strscript += script;
            strscript += "</script>";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), name, strscript, false);
        }

        /// <summary>
        /// 注意：此方法为异步ajax，其执行顺序位于onload之前 2017年11月26日19:30:47
        /// </summary>
        /// <param name="page"></param>
        /// <param name="script"></param>
        /// <param name="name"></param>
        /// <param name="afterReady"></param>
        public static void createManagerScript(Page page, string script, string name, bool afterReady = false)
        {
            string strscript = "";
            if (!afterReady)
            {
                strscript = "<script language='javascript'>";
                strscript += script;
                strscript += "</script>";
            }
            else
            {
                strscript += script;
            }

            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), name, strscript, afterReady);
        }
    }
}