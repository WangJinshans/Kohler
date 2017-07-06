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
            string sql = "insert into As_Form_File(Form_ID,File_ID) values (@Form_ID,@File_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",Form_File.Form_ID),
                new SqlParameter("File_ID",Form_File.File_ID)
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
                    list.Add(Form_File);
                }
            }
            return list;
        }
    }
}
