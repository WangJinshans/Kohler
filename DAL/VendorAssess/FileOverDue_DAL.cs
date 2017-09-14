using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class FileOverDue_DAL
    {
        public static DataTable getOverDueFile(string sql)
        {
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }
        public static DataTable getFormnumber(string sql)
        {
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }

        /// <summary>
        /// 通过File_Type_ID，Temp_Vendor_ID,Factory_Nmae Status='new'在As_File中查出最新的File_ID
        /// 通过File_ID在As_Form_File中查出文件的绑定记录(因为该文件关联到了某张表)
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="file_Type_Name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static List<string> getOverDueForm(string temp_Vendor_ID, string file_Type_Name,string factory)//文件过期找form的方法
        {
            As_Form_OverDue form = new As_Form_OverDue();
            string file_Type_ID = File_Type_DAL.selectFileTypeID(file_Type_Name, temp_Vendor_ID);
            List<string> list = new List<string>();
            //As_Form_File 是表与文件绑定的地方
            string sql = "select File_ID from As_File where Temp_Vendor_ID ='" + temp_Vendor_ID + "' and File_Type_ID='" + file_Type_ID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and Status='new'";//获取对应的Form_ID
            DataTable table = new DataTable();
            DataTable tables = new DataTable();
            table = FormOverDue_DAL.getOverDueForm(sql);//查到的是File_ID
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    sql = "select Form_ID from As_Form_File where File_ID='" + Convert.ToString(dr["File_ID"]) + "'";
                    tables = FormOverDue_DAL.getOverDueForm(sql);//获取每个File_ID对应的所有的Form_ID  Form_ID可能会有重复
                    if (tables.Rows.Count > 0)
                    {
                        foreach (DataRow drs in tables.Rows)
                        {
                            list.Add(drs["Form_ID"].ToString().Trim());
                        }
                    }
                }
                return list.Distinct().ToList();//去重
            }
            else
            {
                return null;//查不到formID就返回空
            }
        }

        /// <summary>
        /// 新的方法获取File_ID 和Form_ID
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="file_Type_Name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static Dictionary<string,string> newGetOverDueForm(string temp_Vendor_ID, string file_Type_Name, string factory)//文件过期找form的方法
        {
            As_Form_OverDue form = new As_Form_OverDue();
            string file_Type_ID = File_Type_DAL.selectFileTypeID(file_Type_Name, temp_Vendor_ID);
            Dictionary<string, string> dc = new Dictionary<string, string>();
            //As_Form_File 是表与文件绑定的地方
            string sql = "select File_ID from As_File where Temp_Vendor_ID ='" + temp_Vendor_ID + "' and File_Type_ID='" + file_Type_ID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL') and Status='new'";//获取对应的Form_ID
            DataTable tables = new DataTable();
            string fileID = "";
            DataTable table = FormOverDue_DAL.getOverDueForm(sql);//查到的是File_ID
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileID = Convert.ToString(dr["File_ID"]);
                    sql = "select Form_ID from As_Form_File where File_ID='" + Convert.ToString(dr["File_ID"]) + "'";
                    tables = FormOverDue_DAL.getOverDueForm(sql);//获取每个File_ID对应的所有的Form_ID  Form_ID可能会有重复
                    if (tables.Rows.Count > 0)
                    {
                        foreach (DataRow drs in tables.Rows)
                        {
                            dc.Add(fileID,drs["Form_ID"].ToString().Trim());
                        }
                    }
                }
                return dc;
            }
            else
            {
                return null;//查不到formID就返回空
            }
        }

        public static int reAccessForm(string formID, string temp_Vendor_ID)
        {
            try
            {
                string form_type_ID = AddForm_DAL.GetForm_Type_ID(formID);//获取form_type_ID
                string sql = "delete from As_Approve where Form_ID='" + formID + "'";//可以再次提交
                DBHelp.ExecuteCommand(sql);
                sql = "delete from As_Form where Form_ID='" + formID + "'";//可以再次提交
                DBHelp.ExecuteCommand(sql);
                sql = "delete from As_Form_AssessFlow where Form_ID='" + formID + "'";//可以再次选择审批流程
                DBHelp.ExecuteCommand(sql);
                sql = "update As_Vendor_FormType set flag=0 where Form_Type_ID='" + form_type_ID + "' and Temp_Vendor_ID='" + temp_Vendor_ID + "'";//更新flag
                DBHelp.ExecuteCommand(sql);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static DataTable getTempVendorID_All(string employeeID)
        {
            string sql = "Select distinct Temp_Vendor_ID From View_File_OverDue Where Employee_ID=@Employee_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employeeID)
            };
            return DBHelp.GetDataSet(sql, sp);
        }

        public static DataTable isFileOverDueInfo(string fileID)
        {
            string sql = "select Temp_Vendor_ID,File_Type_ID,Factory_Name from As_File where [File_ID]='" + fileID + "'";
            return DBHelp.GetDataSet(sql);
        }
      
        public static bool isFileOverDue(string tempvendorID,string fileTypeID,string factory)
        {
            string sql = "select * from As_Vendor_FileType_History where Temp_Vendor_ID='" + tempvendorID + "' and FileType_ID='" + fileTypeID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
      
        public static bool checkVendor(string tempVendorID)
        {
            string sql = "Select count(*) from As_VendorFile_OverDue Where Temp_Vendor_ID=@Temp_Vendor_ID and Status='hold'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            if (DBHelp.GetScalarFix(sql, sp) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
