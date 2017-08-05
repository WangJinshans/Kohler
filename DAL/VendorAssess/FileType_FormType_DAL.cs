using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class FileType_FormType_DAL
    {
        public static IList<As_FileType_FormType> selectFileTypeID(string formtypeid)
        {
            IList<As_FileType_FormType> list = new List<As_FileType_FormType>();
            string sql= "select File_Type_ID from As_FileType_FormType where Form_Type_ID='"+formtypeid+"'";
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_FileType_FormType FileType_FormType =new As_FileType_FormType();
                    FileType_FormType.File_Type_ID = Convert.ToString(dr["File_Type_ID"]);
                    list.Add(FileType_FormType);
                }
            }
            return list;
        }

        public static IList<string> selectFileTypeName(string formTypeID)
        {
            IList<string> list = new List<string>();
            string sql = "select File_Type_Name from View_FormType_FileType where Form_Type_ID=@Form_Type_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_Type_ID",formTypeID)
            };
            DataTable dt = DBHelp.GetDataSet(sql,sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_FileType_FormType FileType_FormType = new As_FileType_FormType();
                    list.Add(dr["File_Type_Name"].ToString());
                }
            }
            return list;
        }
    }
}
