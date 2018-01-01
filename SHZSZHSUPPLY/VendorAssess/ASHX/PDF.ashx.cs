using BLL;
using BLL.VendorAssess;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace SHZSZHSUPPLY.VendorAssess.ASHX
{
    /// <summary>
    /// PDF 的摘要说明
    /// </summary>
    public class PDF : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 处理request
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request.Params["requestType"])
            {
                case "showPDF":
                    outPutPDF(context);
                    break;
                default:
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "default fail" }));
                    break;
            }
        }

        /// <summary>
        /// 向前端发送临时pdf编号，如果是新的请求则重新生成后再发送
        /// </summary>
        private void outPutPDF(HttpContext context)
        {
            string url = context.Request.Params["pdfURL"];
            string options = context.Request.Params["options"];
            string sessionID = HttpContext.Current.Session.SessionID;
            string filePath = HttpContext.Current.Server.MapPath(Properties.Settings.Default.Transfer_Temp_Path) + sessionID + ".pdf";
            string root = HttpContext.Current.Server.MapPath("/");
            string vRoot = HttpContext.Current.Server.MapPath("~/");
            if (!root.Equals(vRoot))
            {
                vRoot = vRoot.Replace(root, "/");
            }
            else
            {
                vRoot = "/";
            }
            bool result = PDF_BLL.showPDF(url, sessionID, filePath, Properties.Settings.Default.PDF_Tool_Path,(sender,e)=> {
                if (((Process)sender).ExitCode == 0 || ((Process)sender).ExitCode == 1)
                {
                    //context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = context.Request.UrlReferrer.OriginalString.ToString().Replace(context.Request.UrlReferrer.PathAndQuery, Properties.Settings.Default.Transfer_Temp_Path.Remove(0, 1) + sessionID + ".pdf")}));
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = context.Request.Url.ToString().Replace(context.Request.Url.AbsolutePath, vRoot.Replace("\\","")+Properties.Settings.Default.Transfer_Temp_Path.Remove(0, 1) + sessionID + ".pdf") }));
                }
                else
                {
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, message = "PDF生成失败,错误代码："+ ((Process)sender).ExitCode }));
                }
            },options.Equals("")? "--zoom 0.8 " : options);
        }


        /// <summary>
        /// IsReusable
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}