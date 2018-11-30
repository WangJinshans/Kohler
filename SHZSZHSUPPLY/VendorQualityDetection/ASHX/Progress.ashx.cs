using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorQualityDetection.ASHX
{
    /// <summary>
    /// Progress 的摘要说明
    /// </summary>
    public class Progress : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = "sadsa";
            string filePath = HttpContext.Current.Server.MapPath("~/VendorQualityDetection/upload/news.xlsx");
            FileStream fs = new FileStream(filePath,FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();

            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Length", bytes.Length.ToString());
            context.Response.AddHeader("Content-Transfer-Encoding", "Binary");
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
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