using BLL;
using Model;
using System;
using System.Collections.Generic;
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

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request.Params["requestType"])
            {
                case "fileUpload":
                    doFileUpload(context);
                    break;
                case "kciUpload":

                    break;
                case "multiFillUpload":
                    multiFillUpload(context);
                    break;
                default:
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "default fail" }));
                    break;
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
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string path = HttpContext.Current.Server.MapPath("../../files/") + postFile.FileName;
            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string fileTypeID = context.Request.Params["fileTypeID"];

            postFile.SaveAs(path);

            As_File file = new As_File();

            file.File_Name = postFile.FileName;
            file.File_Path = path;
            file.Temp_Vendor_ID = tempVendorID;
            file.Temp_Vendor_Name = tempVendorName;
            file.File_ID = tempVendorName + file.File_Name; ;
            file.File_Enable_Time = "100";
            file.File_Due_Time = "200";
            file.File_Type_ID = fileTypeID;
            file.Factory_Name = Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());

            int join = File_BLL.addFile(file);
            int flag = UpdateFlag_BLL.updateFileFlag(fileTypeID, tempVendorID);
            if (join > 0 && flag > 0)
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "数据库写入完毕，文件上传完成" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "数据库写入失败" }));
            }

        }




        private void reDoFileUpload(HttpContext context)
        {
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string path = HttpContext.Current.Server.MapPath("../../files/") + postFile.FileName;
            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string fileTypeID = context.Request.Params["fileTypeID"];
            postFile.SaveAs(path);

            As_File file = new As_File();
            file.File_Name = postFile.FileName;
            file.File_Path = path;
            file.Temp_Vendor_ID = tempVendorID;
            file.Temp_Vendor_Name = tempVendorName;
            file.File_ID = tempVendorName + file.File_Name; ;
            file.File_Enable_Time = "100";
            file.File_Due_Time = "200";
            file.File_Type_ID = fileTypeID;
            file.Factory_Name = Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());
            
            int join = File_BLL.addFile(file);
            int flag = UpdateFlag_BLL.updateFileFlag(fileTypeID, tempVendorID);
            if (join > 0 && flag > 0)
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "数据库写入完毕，文件上传完成" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "数据库写入失败" }));
            }
        }

        private void multiFillUpload(HttpContext context)
        {
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string path = HttpContext.Current.Server.MapPath("./files/") + postFile.FileName;
            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string fileTypeID = context.Request.Params["fileTypeID"];

            postFile.SaveAs(path);

            As_File file = new As_File();

            file.File_Name = postFile.FileName;
            file.File_Path = path;
            file.Temp_Vendor_ID = tempVendorID;
            file.Temp_Vendor_Name = tempVendorName;
            file.File_ID = tempVendorName + file.File_Name; ;
            file.File_Enable_Time = "100";
            file.File_Due_Time = "200";
            file.File_Type_ID = fileTypeID;
            file.Factory_Name = Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());


            int join = File_BLL.addFile(file);
            if (join > 0)
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "数据库写入完毕，文件上传完成" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "数据库写入失败" }));
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