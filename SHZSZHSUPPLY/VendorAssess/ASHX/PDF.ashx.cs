using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.ASHX
{
    /// <summary>
    /// PDF 的摘要说明
    /// </summary>
    public class PDF : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string fileName = context.Request["fileName"] ?? "";
            string formID = context.Request["formID"] ?? "";
            FileInfo fi = new FileInfo("C:\\Users\\Manchester United\\Downloads\\" + fileName);
            string newPath = "D:\\test\\" + fileName;
            while (!fi.Exists)
            {
                fi = new FileInfo("C:\\Users\\Manchester United\\Downloads\\" + fileName);
            }
            fi.MoveTo(newPath);
        
            //As_Form中添加字段Form_Path 保存PDF文件的路径
            As_Form form = new As_Form();
            form.Form_ID = formID;
            form.Form_Path = newPath;
            int result=AddForm_BLL.upDateFormPath(formID, newPath);
            if (result == 1)
            {
                context.Response.Write("pdf生成成功！");
            }
            else
            {
                context.Response.Write("pdf生成失败！");
            }
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