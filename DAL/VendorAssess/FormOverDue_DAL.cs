using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;

namespace DAL.VendorAssess
{
    public class FormOverDue_DAL
    {
        public static DataTable getOverDueForm(string sql)
        {
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }
        public static DataTable getFormnumber(string sql)
        {
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }

        public static int addVendorFormType(As_Vendor_Form_Type vendor)
        {
            string sql = "INSERT INTO As_Vendor_FormType(Temp_Vendor_ID,Form_Type_ID,Temp_Vendor_Name,flag,Form_Type_Name,Factory_Name,Form_ID) VALUES(@Temp_Vendor_ID,@Form_Type_ID,@Temp_Vendor_Name,@flag,@Form_Type_Name,@Factory_Name,@Form_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",vendor.Temp_Vendor_ID),
                new SqlParameter("@Form_Type_ID",vendor.Form_Type_ID),
                new SqlParameter("@Temp_Vendor_Name",vendor.Temp_Vendor_Name),
                new SqlParameter("@flag",vendor.Flag),
                new SqlParameter("@Form_Type_Name",vendor.Form_Type_Name),
                new SqlParameter("@Factory_Name",vendor.Factory_Name),
                new SqlParameter("@Form_ID",vendor.Form_ID)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static DataTable getFormInfo(string formID)
        {
            string tableName = "";
            tableName = switchFormID(formID);
            string sql = "select Factory_Name,Form_Type_ID,Temp_Vendor_ID from " + tableName + " where Form_ID='" + formID + "'";
            return DBHelp.GetDataSet(sql);
        }

        private static string switchFormID(string formID)//未完待续。。。
        {
            string table = "";
            if (formID.Contains("ContractApproval"))
            {
                table = "As_Contract_Approval";
            }
            else if (formID.Contains("VendorExtend"))
            {
                table = "As_Vendor_Extend";
            }
            else if (formID.Contains("VendorBlock"))
            {
                table = "As_Vendor_Block_Or_UnBlock";
            }
            else if (formID.Contains("VendorCreation"))
            {
                table = "As_VendorCreation";
            }
            else if (formID.Contains("VendorDesignated"))
            {
                table = "As_Vendor_Designated_Apply";
            }
            else if (formID.Contains("VendorDiscovery"))
            {
                table = "As_Vendor_Discovery";
            }
            else if (formID.Contains("BiddingForm"))
            {
                table = "As_Bidding_Approval_Form";
            }
            else if (formID.Contains("VendorSelection"))
            {
                table = "As_Vendor_Selection";
            }
            else if (formID.Contains("VendorRisk"))
            {
                table = "As_Vendor_Risk";
            }
            return table;
        }
    }
}