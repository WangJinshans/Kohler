using DAL.VendorAssess;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class Department_BLL
    {
        public static Dictionary<string, string> getDepartments(string v)
        {
            string sql = "select * From As_Department Where Department_Describe=@Factory";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Factory",v)
            };
            return Department_DAL.getDepartments(sql, sp);
        }
    }
}
