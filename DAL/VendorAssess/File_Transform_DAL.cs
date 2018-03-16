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
            string sql = "select [File_ID] from View_File where Temp_Vendor_ID='" + tempVendorID + "' OR Normal_Vendor_ID='" + TempVendor_DAL.getNormalCode(tempVendorID) + "' and Factory_Name in ('" + factory + "','ALL') and [File_ID]='" + fileID + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                return false;
        }

        //不检查合同
        public static List<string> getFormIDs(string tempVendorID, string factory)
        {
            string sql = "select Form_ID FROM View_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "' And Form_Type_ID not in ('005','006','007','008','009','010','011','012')";
            List<string> formlist = new List<string>();
            string formID = "";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_ID"].ToString().Trim();
                    formlist.Add(formID);
                }
            }
            return formlist;
        }

        public static bool checkFormSubmit(string tempVendorID, string factory, string formID)
        {
            string sql = "select Form_Path from As_Form where Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and Form_ID='" + formID + "'";
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
            string sql = "select * from View_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "' and Fill_Flag<>4 And Form_Type_Is_Optional='必选' And Form_Type_ID not in ('005','006','007','008','009','010','011','012')";//4代表已经审批完成
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return false;
                }
            return true;
        }

        public static bool insertNormalCode(string normalCode,string tempVendorID)
        {
            string sql = "update As_Temp_Vendorchange set Normal_Vendor_ID='" + normalCode + "' where Temp_Vendor_ID='" + tempVendorID + "'";
            if (DBHelp.ExecuteCommand(sql) > 0)//无影响返回-1 成功返回影响的行数
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkNecessaryFormSubmit(string tempVendorID, string factory)
        {
            string sql = "select flag FROM View_Vendor_FormType_UnFill where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "' And Form_Type_ID not in ('005','006','007','008','009','010','011','012') and Form_Type_Is_Optional='必选' and flag<>4";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static void addNewForms(string tempVendorID, string factory)
        {
            SqlCommand cmd = new SqlCommand("normalVendorProcedure", DBHelp.Connection);
            cmd.CommandType = CommandType.StoredProcedure;//存储过程
            cmd.Parameters.Add(new SqlParameter("@temp_vendor_id", SqlDbType.NVarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@factory", SqlDbType.NVarChar, 20));
            cmd.Parameters["@temp_vendor_id"].Value = tempVendorID;
            cmd.Parameters["@factory"].Value = factory;
            cmd.ExecuteNonQuery();
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

        /// <summary>
        /// 获取修改后的文件路径
        /// </summary>
        /// <param name="file_Nmae"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static string getModifyFileID(string file_Type_ID, string tempVendorID, string factory)
        {
            string sql = "select [File_ID] from As_File where File_Type_ID='" + file_Type_ID + "' and Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
            DataTable table = DBHelp.GetDataSet(sql);
            string file_ID = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    file_ID = dr["File_ID"].ToString().Trim();
                }
            }
            return file_ID;
        }

        /// <summary>
        /// 获取所有修改的需要上传的文件名称
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static List<string> getModifyFileList(string tempVendorID, string factory)
        {
            string sql = "select File_Type_ID from As_Vendor_Modify_File where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory + "'";
            List<string> fileList = new List<string>();
            string file_Type_ID = "";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    file_Type_ID = dr["File_Type_ID"].ToString().Trim();
                    fileList.Add(file_Type_ID);
                }
            }
            return fileList;
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

        /// <summary>
        /// 判断信息修改后需要上传的文件是否已经上传完成
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static bool isModifyFileUploadOK(string temp_Vendor_ID, string factory_Name)
        {
            if (temp_Vendor_ID.Equals(""))
            {
                return false;
            }
            //判断这个temp_Vendor_ID是否存在 不存在直接返回false
            string sql1 = "select Temp_Vendor_ID from As_Vendor_Modify_File where Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + factory_Name + "'";
            using (SqlDataReader reader = DBHelp.GetReader(sql1))
            {
                if (!reader.Read())
                {
                    return false;
                }
            }
            string sql = "select File_Type_Name from As_Vendor_Modify_File where Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + factory_Name + "' and Flag=0";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }


        /// <summary>
        /// 检查正在审批的标志是否为YES
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static bool isNotChanging(string temp_Vendor_ID, string factory_Name)
        {
            if (temp_Vendor_ID.Equals(""))
            {
                return false;
            }
            string sql = "select Temp_Vendor_ID from As_Vendor_Modify_Info where Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + factory_Name + "' and IsChanging='YES'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static int updateVendorFile(string sql, SqlParameter[] sq)
        {
            return DBHelp.ExecuteCommand(sql, sq);
        }

        public static int deleteALL(string code)
        {
            string sql = "delete From itemList where Vender_Code=@Code";
            return DBHelp.ExecuteCommand(sql, new SqlParameter[] { new SqlParameter("@Code", code) });
        }
    }
}
