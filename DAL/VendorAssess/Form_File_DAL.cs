using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public class Form_File_DAL
    {
        public static int addFormFile(As_Form_File Form_File)
        {
            string sql = "insert into As_Form_File(Form_ID,File_ID,Temp_Vendor_ID) values (@Form_ID,@File_ID,@Temp_Vendor_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",Form_File.Form_ID),
                new SqlParameter("@File_ID",Form_File.File_ID),
                new SqlParameter("@Temp_Vendor_ID",Form_File.Temp_Vendor_ID)
            };
            return DBHelp.GetScalar(sql,sp);
        }

        public static IList<As_Form_File> listFile(string sql)
        {
            IList<As_Form_File> list = new List<As_Form_File>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Form_File Form_File = new As_Form_File();
                    Form_File.Form_ID = Convert.ToString(dr["Form_ID"]);
                    Form_File.File_ID = Convert.ToString(dr["File_ID"]);
                    Form_File.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    list.Add(Form_File);
                }
            }
            return list;
        }

        public static int checkFormFile(string formID, string fileType)
        {
            string sql = "select * from View_Form_File where Form_ID=@Form_ID and File_Type_ID=@File_Type_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID),
                new SqlParameter("@File_Type_ID",fileType)
            };
            return DBHelp.GetScalar(sql, sp);
        }
    }
}
