using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.ASHX
{
    /// <summary>
    /// MyAjaxTest 的摘要说明
    /// </summary>
    public class MyAjaxTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            string data = context.Request.Form["datas"];
            string fileName = context.Request["fileName"] ?? ""; //编码格式
            string formID = context.Request["formID"] ?? "";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}