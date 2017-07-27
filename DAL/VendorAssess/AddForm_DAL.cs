﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddForm_DAL
    {
        public static int addForm(As_Form form)
        {
            string sql = "INSERT INTO As_Form(Form_ID,Form_Name,Form_Path,Form_Type_ID,Temp_Vendor_Name,Temp_Vendor_ID) VALUES(@Form_ID,@Form_Name,@Form_Path,@Form_Type_ID,@Temp_Vendor_Name,@Temp_Vendor_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",form.Form_ID),
                new SqlParameter("Form_Name",form.Form_Name),
                new SqlParameter("Form_Path",form.Form_Path),
                new SqlParameter("Form_Type_ID",form.Form_Type_ID),
                new SqlParameter("Temp_Vendor_Name",form.Temp_Vendor_Name),
                new SqlParameter("Temp_Vendor_ID",form.Temp_Vendor_ID)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static string GetVendorName(string formID)
        {
            string sql = "select Temp_Vendor_Name from As_Form where Form_ID='" + formID + "'";
            DataTable dt = new DataTable();
            dt = DBHelp.GetDataSet(sql);
            string vendorname = dt.Rows[0]["Temp_Vendor_Name"].ToString().Trim();
            return vendorname;
        }

        public static string GetForm_Type_ID(string formID)
        {
            string sql = "select Form_Type_ID from As_Form where Form_ID='" + formID + "'";
            DataTable dt = new DataTable();
            dt = DBHelp.GetDataSet(sql);
            string formid = dt.Rows[0]["Form_Type_ID"].ToString().Trim();
            return formid;
        }
    }
}
