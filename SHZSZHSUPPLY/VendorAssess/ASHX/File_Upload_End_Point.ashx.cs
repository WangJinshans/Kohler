﻿using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using WebLearning.BLL;

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
                    //正常文件上传
                    doFileUpload(context);
                    break;
                case "kciUpload":
                    doKCIFileUpload(context);
                    break;
                case "multiFillUpload":
                    multiFillUpload(context);
                    break;
                case "modifyFileUpload":
                    modifyFileUpload(context);
                    break;
                case "signleupload":
                    singleFileUpload(context);
                    break;
                default:
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, error = "default fail" }));
                    break;
            }
        }

        private void singleFileUpload(HttpContext context)
        {
            bool isFileUpload = false;

            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string startTime = context.Request.Params["startTime"];
            string endTime = context.Request.Params["endTime"];
            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string formID = context.Request.Params["fileTypeID"];//实际传入formID

            if (formID == null || formID.Equals(""))
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "上传过程中出错，请退出本页面之后再进入并重新上传" }));
                return;
            }
            string fileTypeID = "";
            #region
            if (formID.Contains("BiddingForm"))
            {
                fileTypeID = "012";
            }
            else if (formID.Contains("PurchaseChanges"))
            {
                fileTypeID = "012";
            }
            else if (formID.Contains("PurchasePriceApplication"))
            {
                fileTypeID = "012";
            }
            else if (formID.Contains("ServiceComponentApplication"))
            {
                fileTypeID = "012";
            }
            else if (formID.Contains("VendorDesignated"))
            {
                fileTypeID = "065";
            }
            else if (formID.Contains("ContractApproval"))
            {
                fileTypeID = "001";
            }
            #endregion         
            string factoryName = HttpContext.Current.Session["Factory_Name"].ToString();
            string fileID = tempVendorID + File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID, factoryName);
            string path = LSetting.File_Path + fileID + ".pdf";
            postFile.SaveAs(HttpContext.Current.Server.MapPath(path));


            //判断该formID是否已经上传了文件 如果上传则为覆盖
            isFileUpload = VendorSingleFile_BLL.isSingleFileSubmit(formID);
            if (isFileUpload)
            {
                //保留原来的记录方便日后删除
                string oldFileID = VendorSingleFile_BLL.getOldFileID(formID);
                if (oldFileID != "")
                {
                    //更新Status为 old
                    File_Type_BLL.updateFileStatus(oldFileID);
                }
            }



            As_File files = new As_File();
            files.File_Path = path;
            files.Temp_Vendor_ID = tempVendorID;
            files.Temp_Vendor_Name = tempVendorName;
            files.File_ID = fileID;
            files.File_Name = fileID + ".pdf";
            files.File_Enable_Time = startTime;
            files.File_Due_Time = endTime;
            files.File_Type_ID = fileTypeID;
            files.Factory_Name = factoryName;
            files.Source_From = formID;
            try
            {
                File_BLL.addFile(files);
                //手动添加文件绑定记录
                CheckFile_BLL.bindSingleFormFile(fileID, tempVendorID, formID);
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "数据库写入完毕，文件上传完成" }));
            }
            catch
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, message = "数据库写入失败，文件上传失败" }));
            }
        }

        private void modifyFileUpload(HttpContext context)
        {
            As_File file = modifyUpload(context, NORMAL_UPLOAD);
            writeResult(context, file);
        }

        private As_File modifyUpload(HttpContext context, int nORMAL_UPLOAD)
        {
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string startTime = context.Request.Params["startTime"];
            string endTime = context.Request.Params["endTime"];

            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string fileTypeID = context.Request.Params["fileTypeID"];
            string factoryName = HttpContext.Current.Session["Factory_Name"].ToString();
            string fileInfo = File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID, factoryName);
            string fileID = tempVendorID + fileInfo;
            string path = LSetting.File_Path + fileID + ".pdf";

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
            file.Source_From = "";
            postFile.SaveAs(HttpContext.Current.Server.MapPath(path));
            string file_Type_Name = File_Type_BLL.getFileTypeNameByID(fileTypeID);
            Vendor_Modify_File_BLL.upDataUploadFlag(tempVendorName, factoryName, file_Type_Name);

            FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath(path));
            if (fi.Exists)
            {
                return file;
            }
            return null;
        }

        private void overDueUpload(HttpContext context)
        {
            As_File file = upload(context, NORMAL_UPLOAD);
            string tempVendorID = context.Request.Params["tempVendorID"];
            string fileTypeID = context.Request.Params["fileTypeID"];
            string fileTypeName = File_Type_BLL.selectFileTypeName(fileTypeID);
            string factoryName = HttpContext.Current.Session["Factory_Name"].ToString();
            UpdateFlag_BLL.updateFileOverDueFlagAsHold(fileTypeName, tempVendorID, factoryName);
            writeResult(context, file);
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
            string factoryName = HttpContext.Current.Session["Factory_Name"].ToString();
            string fileID = tempVendorID + File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID,factoryName);
            string path = LSetting.File_Path + fileID + ".pdf";
            postFile.SaveAs(HttpContext.Current.Server.MapPath(path));


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
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string startTime = context.Request.Params["startTime"];
            string endTime = context.Request.Params["endTime"];

            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string fileTypeID = context.Request.Params["fileTypeID"];
            string factoryName = HttpContext.Current.Session["Factory_Name"].ToString();
            string fileInfo = File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID, factoryName);
            string fileID = tempVendorID + fileInfo;
            string path = LSetting.File_Path + fileID + ".pdf";

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
            file.Source_From = "";
            postFile.SaveAs(HttpContext.Current.Server.MapPath(path));

            writeResult(context,file);
        }

        private void reDoFileUpload(HttpContext context)
        {
            As_File file = upload(context, NORMAL_UPLOAD);

            writeResult(context,file);
        }

        private void multiFillUpload(HttpContext context)
        {
            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string startTime = context.Request.Params["startTime"];
            string endTime = context.Request.Params["endTime"];

            string tempVendorID = context.Request.Params["tempVendorID"];
            string tempVendorName = context.Request.Params["tempVendorName"];
            string formID = context.Request.Params["fileTypeID"];
            string fileTypeID = "032";
            string factoryName = HttpContext.Current.Session["Factory_Name"].ToString();
            string fileInfo = File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID, factoryName);
            string fileID = tempVendorID + fileInfo;
            string path = LSetting.File_Path + fileID + ".pdf";

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
            file.Source_From = formID;

            postFile.SaveAs(HttpContext.Current.Server.MapPath(path));

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
            string formID = context.Request.Params["fileTypeID"];
            string fileTypeID = "032";
            string factoryName = HttpContext.Current.Session["Factory_Name"].ToString();
            string fileInfo = File_Type_BLL.getSpec(fileTypeID) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID,factoryName);
            string fileID = tempVendorID + fileInfo;
            string path = LSetting.File_Path + fileID + ".pdf";

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
            file.Source_From = formID;

            postFile.SaveAs(HttpContext.Current.Server.MapPath(path));
            FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath(path));
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