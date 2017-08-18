using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class File_Transform_DAL
    {
        public static List<string> getFileIDs(string tempVendorID, string factory)
        {
            string sql = "select File_ID form As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "'";
            List<string> filelist = new List<string>();
            string fileid = "";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileid = dr["File_ID"].ToString().Trim();
                    filelist.Add(fileid);
                }
            }
            return filelist;
        }

        public static bool checkFileSubmit(string tempVendorID, string factory,string fileID)
        {
            string sql = "select [File_ID] form As_File where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "' and [File_ID]='" + fileID + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                return false;
        }

        public static List<string> getFormIDs(string tempVendorID, string factory)
        {
            string sql = "select Form_ID form As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "'";
            List<string> formlist = new List<string>();
            string formid = "";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formid = dr["Form_ID"].ToString().Trim();
                    formlist.Add(formid);
                }
            }
            return formlist;
        }

        public static bool checkFormSubmit(string tempVendorID, string factory, string formid)
        {
            string sql = "select Form_ID form As_Form where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "' and Form_ID='" + formid + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
            return false;
        }

        public static bool AccessSuccessFul(string tempVendorID, string factory)
        {
            string sql = "select * form As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "flag<>'4'";//4代表已经审批完成
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return false;
                }
            return true;
        }

        public static bool insertNormalCode(string normalCode,string tempVendorID)
        {
            string sql = "update As_Temp_Vendor set Normal_Vendor_ID='" + normalCode + " where Temp_Vendor_ID='" + tempVendorID + "'";
            if (DBHelp.ExecuteCommand(sql) > 0)//无影响返回-1 成功返回影响的行数
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
