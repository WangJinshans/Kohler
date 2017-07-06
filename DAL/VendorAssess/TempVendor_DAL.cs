﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TempVendor_DAL
    {
        public static int addTempVendor(As_Temp_Vendor Temp_Vendor)
        {
            string sql = "INSERT INTO As_Temp_Vendor(Temp_Vendor_Name,Vendor_Type_ID)VALUES(@Temp_Vendor_Name,@Vendor_Type_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_Name",Temp_Vendor.Temp_Vendor_Name),
                new SqlParameter("@Vendor_Type_ID",Temp_Vendor.Vendor_Type_ID),
            };
            return DBHelp.GetScalar(sql, sp);
        }
        public static string getTempVendorID(string TempVendorName)
        {
            As_Employee_Vendor Employee_Vendor = null;
            string sql = "select Temp_Vendor_ID from As_Employee_Vendor where Temp_Vendor_Name=@Temp_Vendor_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("Temp_Vendor_Name",TempVendorName)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Employee_Vendor = new As_Employee_Vendor();
                foreach (DataRow dr in dt.Rows)
                {
                    Employee_Vendor.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                }
            }
            return Employee_Vendor.Temp_Vendor_ID;
        }
    }
}
