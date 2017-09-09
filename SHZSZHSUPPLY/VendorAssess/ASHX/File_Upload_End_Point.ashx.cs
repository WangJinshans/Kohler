using BLL;
using Model;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace SHZSZHSUPPLY.VendorAssess.ASHX
{
    /// <summary>
    /// File_Upload_End_Point 的摘要说明
    /// </summary>
    public class File_Upload_End_Point : IHttpHandler, IRequiresSessionState
    {
        public const int NORMAL_UPLOAD = 1;
        public const int KCI_UPLOAD = 2;
        public const int MULTI_UPLOAD = 3;


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request.Params["requestType"])
            {
                case "fileUpload":
                    doFileUpload(context);
                    break;
                case "kciUpload":
                    doKCIFileUpload(context);
                    break;
                case "multiFillUpload":
                    multiFillUpload(context);
                    break;
                default:
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "default fail" }));
                    break;
            }
        }

        private void doKCIFileUpload(HttpContext context)
        {
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string startTime = context.Request.Params["startTime"];
            string endTime = context.Request.Params["endTime"];

            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string formID= context.Request.Params["fileTypeID"];        //实际传入formID
            string fileTypeID = Properties.Settings.Default.File_Type_ID_KCI;
            string factoryName = Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());
            string fileID = tempVendorID + File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID,factoryName);
            string path = HttpContext.Current.Server.MapPath("../../files/") + fileID + ".pdf";
            postFile.SaveAs(path);


            /*由于KCI需要与form_ID进行绑定 并且 不能触发As_File中的各种触发器
             *故新建As_KCI_File表存储KCI文件 与表进行对应 
             * KCI文件需要有一个typeID
             */
             //TODO::文件转移KCI 2017年9月9日15:25:42
            As_Kci_File file = new As_Kci_File();//KCI文件

            file.File_Path = path;
            file.Temp_Vendor_ID = tempVendorID;
            file.Temp_Vendor_Name = tempVendorName;
            file.File_ID = fileID;
            file.File_Name = fileID + ".pdf";
            file.File_Enable_Time = startTime;
            file.File_Due_Time = endTime;
            file.File_Type_ID = fileTypeID;
            file.Form_ID = formID;//formID

            if (File_BLL.addFile(file) > 0)
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "数据库写入完毕，文件上传完成" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "数据库写入失败" }));
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void doFileUpload(HttpContext context)
        {
            As_File file = upload(context,NORMAL_UPLOAD);

            writeResult(context,file);
        }

        private void reDoFileUpload(HttpContext context)
        {
            As_File file = upload(context, NORMAL_UPLOAD);

            writeResult(context,file);
        }

        private void multiFillUpload(HttpContext context)
        {
            As_File file = upload(context, NORMAL_UPLOAD);

            writeResult(context, file);
        }

        /// <summary>
        /// 执行文件保存，返回文件信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private As_File upload(HttpContext context,int type)
        {
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string startTime = context.Request.Params["startTime"];
            string endTime = context.Request.Params["endTime"];

            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string fileTypeID = context.Request.Params["fileTypeID"];
            string factoryName = Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());
            string fileInfo = File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID,factoryName);
            string fileID = tempVendorID + fileInfo;
            string path = HttpContext.Current.Server.MapPath("../../files/") + fileID + ".pdf";

            As_File file = new As_File();
            file.File_Path = path;
            file.Temp_Vendor_ID = tempVendorID;
            file.Temp_Vendor_Name = tempVendorName;
            file.File_ID = fileID;
            file.File_Name = fileID + ".pdf";
            file.File_Enable_Time = startTime;
            file.File_Due_Time = endTime;
            file.File_Type_ID = fileTypeID;
            file.Factory_Name = factoryName;

            postFile.SaveAs(path);
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                return file;
            }
            return null;
        }
        
        /// <summary>
        /// 回写结果
        /// </summary>
        /// <param name="context"></param>
        /// <param name="file"></param>
        private void writeResult(HttpContext context,As_File file)
        {
            if (file != null)
            {
                if (File_BLL.addFile(file) > 0)
                {
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "数据库写入完毕，文件上传完成" }));
                }
                else
                {
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "数据库写入失败" }));
                }
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "文件保存失败" }));
            }
        }
    }

    public class Msg
    {
        public bool success { get; set; }
        public bool preventRetry { get; set; }
        public bool reset { get; set; }
        public string newUuid { get; set; }
        public string error { get; set; }
        public string message { get; set; }

        public int status { get; set; }
    }
}