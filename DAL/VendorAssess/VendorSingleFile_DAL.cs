using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class VendorSingleFile_DAL
    {
        public static void addSingleFile(string formID, string formTypeID, string tempVendorID, string tempVendorName, string factory_Name,string fileTypeID)
        {
            //添加单个文件绑定
            string sqls = "insert into As_Form_Single_File(Temp_Vendor_ID,Factory_Name,Temp_Vendor_Name,Form_Type_ID,Form_ID,File_Type_ID)values(@Temp_Vendor_ID,@Factory_Name,@Temp_Vendor_Name,@Form_Type_ID,@Form_ID,@File_Type_ID)";
            SqlParameter[] sps = new SqlParameter[]
            {
               new SqlParameter("@Temp_Vendor_ID",tempVendorID),
               new SqlParameter("@Factory_Name",factory_Name),
               new SqlParameter("@Temp_Vendor_Name",tempVendorName),
               new SqlParameter("@Form_Type_ID",formTypeID),
               new SqlParameter("@Form_ID",formID),
               new SqlParameter("@File_Type_ID",fileTypeID)
            };
            DBHelp.GetScalar(sqls, sps);
        }

        public static string getOldFileID(string formID)
        {
            string oldFileID = "";
            string sql = "select File_ID from As_Form_Single_File where Form_ID='" + formID + "' and Flag=1";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    oldFileID = dr["File_ID"].ToString().Trim();
                }
            }
            return oldFileID;
        }

        public static int updateSingleFileFlag(string formID, string fileID)
        {
            string sql = "update As_Form_Single_File set File_ID='" + fileID +"',Flag=1 where Form_ID='" + formID + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static bool isSingleFileSubmit(string formID)
        {
            string sql = "select File_ID from As_Form_Single_File where Form_ID='" + formID + "' and Flag=1";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
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
}
