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

        public static int updateFlag(string formTypeId,string tempVendorID,string factoryName)
        {
            string sql= "UPDATE As_Vendor_FormType SET flag=1 WHERE Form_Type_ID='"+ formTypeId+ "'AND Temp_Vendor_ID='"+ tempVendorID + "' and Factory_Name='"+factoryName+"'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFileFlag(string fileTypeId, string tempVendorid, string factoryName)
        {
            string sql = "UPDATE As_Vendor_FileType SET flag=1 WHERE FileType_ID='" + fileTypeId + "'AND Temp_Vendor_ID='" + tempVendorid + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateNonStandardConstractFlag(string formID, string factoryName)//非标准合同
        {
            string sql = "UPDATE As_Contract_Approval SET Standard_Contract='no' WHERE Form_ID='" + formID + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql);
        }
        public static int updateFlagAsFinish(string formTypeID, string tempVendorID, string factoryName)
        {
            string sql = "UPDATE As_Vendor_FormType SET flag=0 WHERE Form_Type_ID='" + formTypeID + "'AND Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql); 
        }

        public static int updateEditFlowFlag(string formID, string tempVendorID, string factoryName)
        {
            string sql = "UPDATE As_Form_EditFlow SET Multi_Edit=1 WHERE Form_ID='" + formID + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFlagAsApproved(string formTypeID, string tempVendorID, string factoryName)
        {
            string sql = "UPDATE As_Vendor_FormType SET flag=4 WHERE Form_Type_ID='" + formTypeID + "'AND Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFlagAsHold(object formTypeID, string tempVendorID, string factoryName)
        {
            string sql = "UPDATE As_Vendor_FormType SET flag=2 WHERE Form_Type_ID='" + formTypeID + "'AND Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFlagWaitKCI(string formTypeID,string tempVendorID, string factoryName)
        {
            string sql = "UPDATE As_Vendor_FormType SET flag=3 WHERE Form_Type_ID='" + formTypeID + "'AND Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql);
        }
    }
}
