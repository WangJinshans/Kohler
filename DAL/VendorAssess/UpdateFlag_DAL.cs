using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class UpdateFlag_DAL
    {
        public const int FILLED = 1;
        public const int HOLD = 2;

        public static int updateFlag(string formTypeId,string tempVendorID)
        {
            string sql= "UPDATE As_Vendor_FormType SET flag=1 WHERE Form_Type_ID='"+ formTypeId+ "'AND Temp_Vendor_ID='"+ tempVendorID + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFileFlag(string fileTypeId, string tempVendorid)
        {
            string sql = "UPDATE As_Vendor_FileType SET flag=1 WHERE FileType_ID='" + fileTypeId + "'AND Temp_Vendor_ID='" + tempVendorid + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateNonStandardConstractFlag(string formID)//非标准合同
        {
            string sql = "UPDATE As_Contract_Approval SET Standard_Contract='no' WHERE Form_ID='" + formID + "'";
            return DBHelp.ExecuteCommand(sql);
        }
        public static int updateFlagAsFinish(string formTypeID, string tempVendorID)
        {
            string sql = "UPDATE As_Vendor_FormType SET flag=0 WHERE Form_Type_ID='" + formTypeID + "'AND Temp_Vendor_ID='" + tempVendorID + "'";
            return DBHelp.ExecuteCommand(sql); 
        }

        public static int updateEditFlowFlag(string formID, string tempVendorID)
        {
            string sql = "UPDATE As_Form_EditFlow SET Multi_Edit=1 WHERE Form_ID='" + formID + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFlagAsHold(object formTypeID, string tempVendorID)
        {
            string sql = "UPDATE As_Vendor_FormType SET flag=2 WHERE Form_Type_ID='" + formTypeID + "'AND Temp_Vendor_ID='" + tempVendorID + "'";
            return DBHelp.ExecuteCommand(sql);
        }
    }
}
