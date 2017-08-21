using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class VendorFile_DAL
    {
        public static int addVendorFileType(As_Vendor_FileType Vendor_FileType)
        {
            string sql = "INSERT INTO As_Vendor_FileType(Temp_Vendor_ID,FileType_ID,FileType_Name,flag,[File_ID],Factory_Name)VALUES(@Temp_Vendor_ID,@FileType_ID,@FileType_Name,@flag,@File_ID,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",Vendor_FileType.Temp_Vendor_ID),
                new SqlParameter("@FileType_ID",Vendor_FileType.FileType_ID),
                new SqlParameter("@FileType_Name",Vendor_FileType.FileType_Name),
                new SqlParameter("@flag",Vendor_FileType.Flag),
                new SqlParameter("@File_ID",Vendor_FileType.File_ID),
                new SqlParameter("@Factory",Vendor_FileType.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static int updateFileID(string tempVendorID, string fileTypeID, string factoryName, string file_ID)
        {
            string sql = "update As_Vendor_FileType set File_ID=@File_ID where Temp_Vendor_ID=@Temp_Vendor_ID and FileType_ID=@FileType_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_ID",file_ID),
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@FileType_ID",fileTypeID),
                new SqlParameter("@Factory_Name",factoryName)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static string getFileName(string fileTypeID, string temp_Vendor_ID, string factory_Name)
        {
            string sql = "Select File_Name from View_Vendor_FileType where Temp_Vendor_ID=@Temp_Vendor_ID and FileType_ID=@FileType_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",temp_Vendor_ID),
                new SqlParameter("@FileType_ID",fileTypeID),
                new SqlParameter("@Factory_Name",factory_Name)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                return dt.Rows[0]["File_Name"].ToString();
            }
            return "";
        }
    }
}
