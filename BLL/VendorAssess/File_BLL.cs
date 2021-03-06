﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Web;
using System.Data;
using MODEL.VendorAssess;

namespace BLL
{
    public class File_BLL
    {
        public static int addFile(As_File file)
        {
            return File_DAL.addFile(file);
        }
        public static int addFile(As_Kci_File file)
        {
            return File_DAL.addFile(file);
        }

        public static int selectFileID(string tempVendorID, string filetypeid)//根据供应商名称与文件类型查询文件的id是否存在
        {
            return File_DAL.selectFileID(tempVendorID, filetypeid, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static string selectFileid(string tempVendorID, string filetypeid)    //返回文件id
        {
            return File_DAL.selectFileid(tempVendorID,filetypeid,Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }
       
        /// <summary>
        /// 获取文件分类格式
        /// </summary>
        /// <param name="fileTypeID"></param>
        /// <param name="factoryName"></param>
        /// <returns></returns>
        public static string getSimpleFactory(string fileTypeID,string factoryName)
        {
            bool shared = File_Type_BLL.getShared(fileTypeID);
            if (shared)
            {
                return "ALL";
            }
            else
            {
                switch (factoryName)
                {
                    case "上海科勒":
                        return "SH";
                    case "中山科勒":
                        return "ZS";
                    case "珠海科勒":
                        return "ZH";
                    case "ALL":
                        return "ALL";
                    default:
                        break;
                }
            }
            return "";
        }

        public static string getFileName(string fileTypeID, string temp_Vendor_ID, string factory_Name)
        {
            return VendorFile_DAL.getFileName(fileTypeID, temp_Vendor_ID, factory_Name);
        }


        internal static string getFilePathByID(string fileID)
        {
            string path = "";
            string sql = "select File_Path from As_File where [File_ID]='" + fileID + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    path = dr["File_Path"].ToString().Trim();
                }
            }
            return path;
        }

        public static string generateFileID(string tempVendorID, string fileTypeName, string factory)
        {
            string fileTypeID = File_Type_DAL.getFileTypeID(fileTypeName);
            return tempVendorID + File_Type_BLL.getFormSpec(fileTypeName) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(fileTypeID, factory);
        }

        public static string getFileID(string tempVendorID, string factory, string fileTypeName)
        {
            string fileTypeID = File_Type_BLL.getFileTypeIDByItemCategory(fileTypeName);
            string sql = "select File_ID from As_File where File_Type_ID='" + fileTypeID + "' and Factory_Name in('ALL','" + factory + "') and Temp_Vendor_ID='" + tempVendorID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string fileID = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileID = dr["File_ID"].ToString();
                }
            }
            return fileID;
        }

        public static string getFilePath(string fileID)
        {
            string sql = "select File_Path from As_File where File_ID='" + fileID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string filePath = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    filePath = dr["File_Path"].ToString();
                }
            }
            return filePath;
        }
    }
}
