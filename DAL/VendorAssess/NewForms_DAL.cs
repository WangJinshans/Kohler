using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class NewForms_DAL
    {
        public static int addNewForm(As_New_Forms form)
        {
            string sql = "INSERT INTO As_NewForms_ID(Form_ID,Temp_Vendor_ID,Factory_Name,Form_Name) VALUES(@Form_ID,@Temp_Vendor_ID,@Factory_Name,@Form_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form.Form_ID),
                new SqlParameter("@Temp_Vendor_ID",form.Temp_Vendor_ID),
                new SqlParameter("@Factory_Name",form.Factory_Name),
                new SqlParameter("@Form_Name",form.Form_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static DataTable getNewFormID(As_New_Forms form)
        {
            string sql = "select Form_ID from As_NewForms_ID where Temp_Vendor_ID=@Temp_Vendor_ID and Factory_Name=@Factory_Name and Form_Name=@Form_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",form.Temp_Vendor_ID),
                new SqlParameter("@Factory_Name",form.Factory_Name),
                new SqlParameter("@Form_Name",form.Form_Name)
            };
            return DBHelp.GetDataSet(sql, sp);
        }

        public static int upDateNewForm(As_New_Forms form, As_New_Forms oldform)
        {
            string delSql = "delete from As_NewForms_ID where Form_ID=@Form_ID and Factory_Name=@Factory_Name and Form_Name=@Form_Name";
            SqlParameter[] delsp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",oldform.Form_ID),
                new SqlParameter("@Temp_Vendor_ID",oldform.Temp_Vendor_ID),
                new SqlParameter("@Factory_Name",oldform.Factory_Name),
                new SqlParameter("@Form_Name",oldform.Form_Name)
            };
            DBHelp.GetScalar(delSql, delsp);
            string sql = "INSERT INTO As_NewForms_ID(Form_ID,Temp_Vendor_ID,Factory_Name,Form_Name) VALUES(@Form_ID,@Temp_Vendor_ID,@Factory_Name,@Form_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form.Form_ID),
                new SqlParameter("@Temp_Vendor_ID",form.Temp_Vendor_ID),
                new SqlParameter("@Factory_Name",form.Factory_Name),
                new SqlParameter("@Form_Name",form.Form_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

    }
}
