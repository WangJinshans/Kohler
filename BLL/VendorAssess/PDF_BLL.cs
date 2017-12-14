using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL.VendorAssess
{
    public class PDF_BLL
    {
        /// <summary>
        /// 后台生成PDF instance记录
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="PDF_Tool_Path"></param>
        /// <param name="File_Path"></param>
        /// <param name="page"></param>
        public static void outPutPDF(string formID, string tempVendorID, string PDF_Tool_Path, string File_Path, System.Web.UI.Page page)
        {
            try
            {
                string url = HttpContext.Current.Request.Url.ToString() + "&outPutID=" + formID;

                string fileTypeName = FormType_BLL.getFormNameByFormID(formID);
                string factory = AddForm_BLL.getFactoryByFormID(formID);
                string file = HttpContext.Current.Server.MapPath(File_Path) + File_BLL.generateFileID(tempVendorID, fileTypeName, factory) + ".pdf";


                Process process = new Process();
                process.StartInfo.FileName = PDF_Tool_Path;
                process.StartInfo.Arguments = "--zoom 0.8 " + url + " \"" + file + "\"";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.EnableRaisingEvents = true;
                process.Start();
                if (!process.WaitForExit(10000)) //10s内必须退出
                {
                    process.Kill();
                    throw new Exception("TimeOut");
                }
                else
                {
                    As_Form form = new As_Form();
                    form.Form_ID = formID;
                    form.Form_Path = file;
                    int result = AddForm_BLL.upDateFormPath(formID, file);
                    if (result <= 0)
                    {
                        throw new Exception("数据库更新失败");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void ProcessExited(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 为前台生成PDF预览到临时文件夹
        /// </summary>
        /// <returns></returns>
        public static bool showPDF(string url, string sessionID, string filePath, string PDF_Tool_Path, EventHandler eventHandler,string options= "--zoom 0.8 ")
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = PDF_Tool_Path;
                process.StartInfo.Arguments = options + url + " \"" + filePath + "\"";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.EnableRaisingEvents = true;
                process.Exited += eventHandler;
                process.Start();
                if (!process.WaitForExit(10000)) //10s内必须退出
                {
                    process.Kill();
                    throw new Exception("TimeOut");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
