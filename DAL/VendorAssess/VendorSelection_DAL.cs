using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;
using System.Data;

namespace DAL.VendorAssess
{
    public class VendorSelection_DAL
    {
        public static int getVendorSelectionFlag(string formID)
        {
            int flag = -1;
            string sql = "select Flag from As_Vendor_Selection where Form_ID=@Form_ID";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    flag = Convert.ToInt32(item["Flag"]);
                }
            }
            return flag;
        }

        public static string getFormID(string tempVendorID,string form_Name,string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_NewForms_ID where Temp_Vendor_ID=@Temp_Vendor_ID and Form_ID=@Form_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_Name",form_Name),
                new SqlParameter("@Factory_Name",factory)

            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    formID = dr["Form_ID"].ToString();
                }
            }
            return formID;
        }

        public static int checkVendorSelection(string formID)
        {
            string sql = "select * from As_Vendor_Selection where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);

            return dt.Rows.Count > 0 ? 1 : 0; 
        }

        public static int SubmitOk(string formID)
        {
            int submit = -1;
            string sql = "select Submit from As_Vendor_Selection WHERE Form_ID='" + formID + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    submit = Convert.ToInt32(dr["Submit"]);
                }
            }
            return submit;
        }

        public static int addVendorSelection(As_Vendor_Selection vendor_Selection)
        {
            string sql = "insert into As_Vendor_Selection(Temp_Vendor_ID,Form_Type_ID,Temp_Vendor_Name,Flag,Factory_Name) values(@Temp_Vendor_ID,@Form_Type_ID,@Temp_Vendor_Name,@Flag,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",vendor_Selection.Temp_Vendor_ID),
                new SqlParameter("@Temp_Vendor_Name",vendor_Selection.Temp_Vendor_Name),
                new SqlParameter("@Flag",vendor_Selection.Flag),
                new SqlParameter("@Form_Type_ID",vendor_Selection.Form_Type_ID),
                new SqlParameter("@Factory_Name",vendor_Selection.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static As_Vendor_Selection getVendorSelection(string formID)
        {
            As_Vendor_Selection vendorSelection = null;
            string sql = "select * from As_Vendor_Selection where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };

            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorSelection = new As_Vendor_Selection();
                foreach (DataRow dr in dt.Rows)
                {
                    vendorSelection.Form_ID = Convert.ToString(dr["Form_ID"]);
                    vendorSelection.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    vendorSelection.Flag = Convert.ToInt32(dr["Flag"]);
                    //vendorSelection.Product = Convert.ToString(dr["Product"]);
                    //vendorSelection.Bar_Code = Convert.ToString(dr["Bar_Code"]);
                    vendorSelection.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    vendorSelection.Ref_No = Convert.ToString(dr["Ref_No"]);
                    vendorSelection.Date = Convert.ToString(dr["Date"]);
                    vendorSelection.Supplier_One_ID = Convert.ToString(dr["Supplier_One_ID"]);
                    vendorSelection.Supplier_Two_ID = Convert.ToString(dr["Supplier_Two_ID"]);
                    vendorSelection.Supplier_Three_ID = Convert.ToString(dr["Supplier_Three_ID"]);
                    vendorSelection.Supplier_Four_ID = Convert.ToString(dr["Supplier_Four_ID"]);
                    vendorSelection.Supplier_Five_ID = Convert.ToString(dr["Supplier_Five_ID"]);
                    vendorSelection.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    vendorSelection.Factory_Name= Convert.ToString(dr["Factory_Name"]);
                }
            }
            return vendorSelection;
        }

        public static int updateVendorSelection(As_Vendor_Selection vendorSelection)
        {
            string sql = "update As_Vendor_Selection SET Form_Type_ID=@Form_Type_ID,Flag=@Flag,Temp_Vendor_ID=@Temp_Vendor_ID,Ref_No=@Ref_No,Date=@Date,Supplier_One_ID=@Supplier_One_ID,Supplier_Two_ID=@Supplier_Two_ID,Supplier_Three_ID=@Supplier_Three_ID,Supplier_Four_ID=@Supplier_Four_ID,Supplier_Five_ID=@Supplier_Five_ID,Temp_Vendor_Name=@Temp_Vendor_Name where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",vendorSelection.Form_ID),
                new SqlParameter("@Form_Type_ID",vendorSelection.Form_Type_ID),
                new SqlParameter("@Flag",vendorSelection.Flag),
                new SqlParameter("@Temp_Vendor_ID",vendorSelection.Temp_Vendor_ID),
                new SqlParameter("@Ref_No",vendorSelection.Ref_No),
                new SqlParameter("@Date",vendorSelection.Date),
                new SqlParameter("@Supplier_One_ID",vendorSelection.Supplier_One_ID),
                new SqlParameter("@Supplier_Two_ID",vendorSelection.Supplier_Two_ID),
                new SqlParameter("@Supplier_Three_ID",vendorSelection.Supplier_Three_ID),
                new SqlParameter("@Supplier_Four_ID",vendorSelection.Supplier_Four_ID),
                new SqlParameter("@Supplier_Five_ID",vendorSelection.Supplier_Five_ID),
                new SqlParameter("@Temp_Vendor_Name",vendorSelection.Temp_Vendor_Name)
            };
            int result = DBHelp.ExecuteCommand(sql, sp);
            return result;
        }
    }
}
