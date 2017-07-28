using DAL.VendorAssess;
using System;

namespace BLL.VendorAssess
{
    public class Signature_BLL
    {
        public static void setSignature(string formID, string position, string dataField)
        {
            string tableName = "";//哪张表
            string signatureurl = getPositionNameUrl(position);//获取签名的文件地址
            tableName = switchFormID(formID);
            //通过formID确定是具体的那一张表
            if (signatureurl != null)
            {
                string sql = "update " + tableName + " set " + dataField + "='" + signatureurl + "' where Form_ID='" + formID + "'";
                Signature_DAL.Signature(sql);
            }
        }

        public static void setSignatureDate(string formID, string position, string dataField)
        {
            string tableName = "";//哪张表
            string positionNameDate = dataField + "_Date";
            tableName = switchFormID(formID);
            string sql = "update " + tableName + " set " + positionNameDate + "='" + DateTime.Now.ToString().Trim() + "' where Form_ID='" + formID + "'";
            Signature_DAL.SignatureDate(sql);
        }

        private static string getPositionNameUrl(string position)//获取当前职位的签名地址绝对路径
        {
            return Signature_DAL.getPositionNameUrl(position);
        }

        private static string switchFormID(string formID)//未完待续。。。
        {
            string table = "";
            if(formID.Contains("ContractApproval"))
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

    }
}
