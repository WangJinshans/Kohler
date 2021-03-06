﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class File_Type_DAL
    {
        public static string selectFileTypeName(string FileTypeID)
        {
            As_File_Type File_Type = null;
            string sql = "select File_Type_Name from As_File_Type where File_Type_ID=@File_Type_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",FileTypeID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                File_Type = new As_File_Type();
                foreach (DataRow dr in dt.Rows)
                {
                  File_Type.File_Type_Name = Convert.ToString(dr["File_Type_Name"]);
                }
            }
            return File_Type.File_Type_Name;
        }

        public static bool getShared(string fileTypeID)
        {
            string sql = "select Is_Shared From As_File_Type where File_Type_ID=@File_Type_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",fileTypeID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToBoolean(dt.Rows[0]["Is_Shared"]);
            }
            return false;
        }

        public static void updateFileStatus(string oldFileID)
        {
            string sql = "update As_File set Status='old' where File_ID='" + oldFileID + "'";
            DBHelp.ExecuteCommand(sql);
        }

        public static void deleteBindSingleFile(string formID, string fileTypeID)
        {
            //TODO::As_Form_File删除？
            string sql = "delete from As_File where Source_From='" + formID + "' and File_Type_ID='" + fileTypeID + "'";
            DBHelp.ExecuteCommand(sql);
        }

        public static string getFileTypeNameByID(string fileTypeID)
        {
            string fileTypeName = "";
            string sql = "select File_Type_Name from As_File_Type where File_Type_ID='" + fileTypeID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileTypeName = dr["File_Type_Name"].ToString().Trim();
                }
            }
            return fileTypeName;
        }

        public static string getFileTypeIDByItemCategory(string itemCategory)
        {
            string fileTypeName = "";
            string sql = "select File_Type_ID from As_File_Type where File_Type_Name='" + itemCategory + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileTypeName = dr["File_Type_ID"].ToString().Trim();
                }
            }
            return fileTypeName;
        }

        public static string getSpec(string fileTypeID)
        {
            string sql = "select File_Label_Spec From As_File_Type where File_Type_ID=@File_Type_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",fileTypeID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                return dt.Rows[0]["File_Label_Spec"].ToString();
            }
            return "";
        }

        public static string getFormSpec(string formTypeName)
        {
            string sql = "select File_Label_Spec From As_File_Type where File_Type_Name=@File_Type_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_Name",formTypeName)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["File_Label_Spec"].ToString();
            }
            return "";
        }

        public static string selectFileTypeID(string FileTypeName,string tempVendorID)
        {
            string file_Type_ID = "";
            string sql = "select FileType_ID from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "' and FileType_Name='" + FileTypeName + "'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@FileType_Name",FileTypeName)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    file_Type_ID = Convert.ToString(dr["FileType_ID"]);
                }
            }
            return file_Type_ID;
        }

        public static string getFileTypeID(string fileTypeName)
        {
            string sql = "select File_Type_ID from As_File_Type Where File_Type_Name=@Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Name",fileTypeName)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return Convert.ToString(dr["File_Type_ID"]);
                }
            }
            return null;
        }
    }
}
