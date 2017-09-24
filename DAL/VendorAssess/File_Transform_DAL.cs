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
            string sql = "select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and File_Is_Necessary='TRUE'";
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
            string sql = "select [File_ID] from As_File where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name in ('" + factory + "','ALL') and [File_ID]='" + fileID + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                return false;
        }

        public static List<string> getFormIDs(string tempVendorID, string factory)
        {
            string sql = "select Form_ID FROM As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "'";
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
            // string sql = "select Form_ID from As_Form where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "' and Form_ID='" + formid + "' and Status='new'";
            string sql = "select Form_ID from As_Form where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and Form_ID='" + formid + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
            return false;
        }

        public static DataTable getKciFilePath(string formID)
        {
            string sql = "select * from As_KCI_File where Form_ID='" + formID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            return table;
        }

        public static List<string> getKciForms(string tempVendorID, string factory)//保证是最新的formID而不是获取到旧的formID
        {
            List<string> formIDs = new List<string>();
            string sql = "select As_Vendor_FormType.Form_ID from As_Form_AssessFlow,As_Vendor_FormType where As_Form_AssessFlow.Form_ID=As_Vendor_FormType.Form_ID and As_Vendor_FormType.Temp_Vendor_ID='" + tempVendorID + "' and As_Vendor_FormType.Factory_Name in ('" + factory + "' ,'ALL') and As_Form_AssessFlow.KCI=1";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formIDs.Add(dr["Form_ID"].ToString().Trim());//添加form_ID
                }
            }
            return formIDs;
        }

        public static bool isFormKCI(string formid)
        {
            string sql = "select * from As_Form_AssessFlow where Form_ID='" + formid + "' and KCI='1'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
            return false;
        }

        public static bool isKciFileSubmit(string formid)
        {
            string sql = "select * from As_KCI_File where Form_ID='" + formid + "'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
            return false;
        }

        public static bool AccessSuccessFul(string tempVendorID, string factory)
        {
            string sql = "select * from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "' and flag<>4";//4代表已经审批完成
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return false;
                }
            return true;
        }

        public static bool insertNormalCode(string normalCode,string tempVendorID)
        {
            string sql = "update As_Temp_Vendor set Normal_Vendor_ID='" + normalCode + "' where Temp_Vendor_ID='" + tempVendorID + "'";
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
            string sql = "select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "'";
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
            string sql = "select * from View_File where [File_ID]='" + fileID + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }

        public static List<string> getForms(string tempVendorID, string factory)
        {
            List<string> formIDlist = new List<string>();
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "'";
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

        public static int changeStatus(string sql, SqlParameter[] sp)
        {
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static DataTable getFormPath(string formID)
        {
            string sql = "select * from View_Form where Form_ID='" + formID + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }

    
        public static List<string> getOverDueOldFormID(string tempVendorID, string factory)
        {
            List<string> formIDs = new List<string>();
            string sql = "select Form_ID from As_VendorForm_OverDue where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "')";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formIDs.Add(dr["Form_ID"].ToString().Trim());//旧的formID

                }
            }
            return formIDs;
        }

        public static string getFormTypeID(string formID)
        {
            string formTypeID = "";
            string sql = "select Form_Type_ID from As_Form where Form_ID='" + formID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formTypeID = dr["Form_Type_ID"].ToString().Trim();
                }
            }
            return formTypeID;
        }

        public static string getOverDueNewFormID(string tempVendorID, string formTypeID, string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Form_Type_ID='" + formTypeID + "' and Factory_Name='" + factory + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_ID"].ToString().Trim();
                }
            }
            return formID;
        }

        public static List<string> getFileTypeIDs(string tempVendorID, string factory)
        {
            List<string> fileTypeIDs = new List<string>();
            string sql = "select File_Type_ID from View_VendorFile_OverDue where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and Status='Hold'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileTypeIDs.Add(dr["File_Type_ID"].ToString().Trim());
                }
            }
            return fileTypeIDs;
        }

        public static string getFileIDByType(string tempVendorID, string fileTypeID, string factory)
        {
            string fileID = "";
            string sql = "select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "' and FileType_ID='" + fileTypeID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileID = dr["File_ID"].ToString().Trim();
                }
            }
            return fileID;
        }

        public static string getFormIDByFileID(string fileID)
        {
            string formID = "";
            string sql = "select Form_ID from As_Form_File where [File_ID]='" + fileID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_ID"].ToString().Trim();
                }
            }
            return formID;
        }

        public static string getFormPathByFormID(string formID)
        {
            string formPath = "";
            string sql = "select Form_Path from As_Form where Form_ID='" + formID + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formPath = dr["Form_Path"].ToString().Trim();
                }
            }
            return formPath;
        }

        public static int addNormalCode(string sql)
        {
            return DBHelp.ExecuteCommand(sql);
        }

        public static int addVendorFile(string sql, SqlParameter[] sq)
        {
            return DBHelp.ExecuteCommand(sql, sq);
        }

        public static int addVendorPlantInfo(string sql, SqlParameter[] sq)
        {
            return DBHelp.ExecuteCommand(sql, sq);
        }

        public static bool recordExist(string fileID)
        {
            string sql = "select count(*) from itemList where Item_Label=@File_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_ID",fileID)
            };
            if (DBHelp.GetScalarFix(sql, sp) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
