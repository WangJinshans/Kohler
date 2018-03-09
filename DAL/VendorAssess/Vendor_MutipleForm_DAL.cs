using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;
using MODEL;

namespace DAL.VendorAssess
{
    public class Vendor_MutipleForm_DAL
    {
        public static void addVendorMutileForms(As_MutipleForm forms)
        {
            string sql = "insert into As_Vendor_MutiplyForm(Temp_Vendor_ID,Form_Type_ID,Factory_Name,Fill_Flag,Form_ID)values('" + forms.Temp_Vendor_ID + "','" + forms.Form_Type_ID + "','" + forms.Factory_Name + "','" + forms.Fill_Flag + "','" + forms.Form_ID + "')";
            DBHelp.ExecuteCommand(sql);
        }

        public static void deleteForm(string formID)
        {
            int n = formID.IndexOf("_");
            string realFormID = formID.Substring(0, n);
            string table = PageSelect.dcFormToModel[realFormID].ToString().Trim();
            string sql = "delete from " + table + " where Form_ID='" + formID + "'";
            DBHelp.ExecuteCommand(sql);
            sql = "delete from As_Vendor_MutiplyForm where Form_ID='" + formID + "'";
            DBHelp.ExecuteCommand(sql);
        }
    }
}
