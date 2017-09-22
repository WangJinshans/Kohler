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

        public static int updateFileOverDueFlagAsHold(string fileTypeName, string tempVendorID, string factory)
        {
            string sql = "update As_VendorFile_OverDue set Status='Hold' where FileType_Name='" + fileTypeName + "' and Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name in ('" + factory + "','ALL')";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateEditFlowFlag(string formID, string tempVendorID, string factoryName)
        {
            string sql = "UPDATE As_Form_EditFlow SET Multi_Edit=1 WHERE Form_ID='" + formID + "' and Factory_Name='" + factoryName + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFlagAsApproved(string formTypeID, string tempVendorID, string factoryName)
        {
            string sql = "UPDATE As_Vendor_FormType SET flag=4 WHERE Form_Type_ID='" + formTypeID + "'AND Temp_Vendor_ID='" + tempVendorID + "' and (Factory_Name='" + factoryName + "' or Factory_Name='ALL')";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateReAccessFormStatus(string formID, string tempVendorID)
        {
            string sql = "UPDATE As_VendorForm_OverDue SET Status='Hold' WHERE Form_ID='" + formID + "'AND Temp_Vendor_ID='" + tempVendorID + "'";
            try
            {
                DBHelp.ExecuteCommand(sql);
                return 2;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static int setFormUnSubmit(string formID)
        {
            string formName = "";
            formName = switchFormID(formID);
            if (formName != "")
            {
                string sql = "UPDATE " + formName + " SET Submit=1 WHERE Form_ID='" + formID + "'";
                return DBHelp.ExecuteCommand(sql);
            }
            return -1;//出错
        }

        public static int updateReAccessFileStatus(string fileID)
        {
            string fileTypeName = File_DAL.getFileTypeNameByFileID(fileID);
            string sql = "UPDATE As_VendorFile_OverDue SET Status='Hold' WHERE [FileType_Name]='" + fileTypeName + "'";
            try
            {
                DBHelp.ExecuteCommand(sql);
                return 2;
            }
            catch (Exception e)
            {
                return -1;
            }
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
            return table;
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
