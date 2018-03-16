using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class CheckFlag_DAL
    {
        public static int checkFormStatus(string tempVendorID, string formType,string factory_Name)
        {
            string sql = "select Flag from As_Vendor_FormType where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_Type_ID",formType),
                new SqlParameter("@Factory_Name",factory_Name)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                return Convert.ToInt32(dt.Rows[0]["Flag"]);
            }
            return -1;
        }

        public static int checkMultiFillStatus(string formID, string tempVendorID)
        {
            string sql = "select Multi_Edit from As_Form_EditFlow where Temp_Vendor_ID=@Temp_Vendor_ID and Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Multi_Edit"]);
            }
            return -1;
        }
    }
}
