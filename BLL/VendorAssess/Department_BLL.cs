﻿using DAL.VendorAssess;
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

        internal static string findHead(string department_ID)
        {
            string sql = "Select Department_Head From As_Department Where Department_ID=@DeptID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@DeptID",department_ID)
            };
            return Department_DAL.findHead(sql, sp);
        }
    }
}
