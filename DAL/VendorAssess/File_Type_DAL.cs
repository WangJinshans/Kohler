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

        public static string selectFileTypeID(string FileTypeName)
        {
            string file_Type_ID = "";
            string sql = "select File_Type_ID from As_File_Type where File_Type_Name=@File_Type_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_Name",FileTypeName)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    file_Type_ID = Convert.ToString(dr["File_Type_ID"]);
                }
            }
            return file_Type_ID;
        }
    }
}
