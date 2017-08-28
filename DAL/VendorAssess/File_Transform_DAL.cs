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
            string sql = "select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
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
            string sql = "select [File_ID] from As_File where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and [File_ID]='" + fileID + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                return false;
        }

        public static List<string> getFormIDs(string tempVendorID, string factory)
        {
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
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
            string sql = "select Form_ID from As_Form where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and Form_ID='" + formid + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
            return false;
        }

        public static bool AccessSuccessFul(string tempVendorID, string factory)
        {
            string sql = "select * from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and flag<>'4'";//4代表已经审批完成
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

        public static List<string> getFiles(string tempVendorID, string factory)
        {
            List<string> fileIDlist = new List<string>();
            string sql = "select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileIDlist.Add(dr["File_ID"].ToString().Trim());
                }
            }
            return fileIDlist;
        }

        public static DataTable getFilePath(string fileID)
        {
            string sql = "select File_Path from As_File where [File_ID]='" + fileID + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }

        public static List<string> getForms(string tempVendorID, string factory)
        {
            List<string> formIDlist = new List<string>();
            string sql = "select Form_ID from As_Vendor_FormTyle where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formIDlist.Add(dr["Form_ID"].ToString().Trim());
                }
            }
            return formIDlist;
        }

        public static DataTable getFormPath(string formID)
        {
            string sql = "select Form_Path from As_Form where Form_ID='" + formID + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }
    }
}
