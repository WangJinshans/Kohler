using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL.VendorAssess
{
    public class Department_DAL
    {
        public static Dictionary<string, string> getDepartments(string sql, SqlParameter[] sp)
        {
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                Dictionary<string, string> departments = new Dictionary<string, string>();
                foreach (DataRow item in dt.Rows)
                {
                    departments.Add(item["Department_Name"].ToString(), item["Department_ID"].ToString());
                }
                return departments;
            }
            return null;
        }
    }
}
