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



        /*
         * 
         *由于在审批的时候 某职位的负责人只需要点击同意或者拒绝  然后进行动态的签名
         * 那么当一张表中需要多个他多次签名的时候 由于他只能点击一次 所以只能在签名
         * 的时候全部进行操作 若同意 则该表所有需要他签名的地方都同意 都附上签名 
         * 
         * 合同审批表中 需要同一个职位多次签名的 该表只有一个字段 多个位置共同使用
         */


        public static void setSignature(string formID, string position)
        {
            string tableName = "";//哪张表
            string signatureurl = getPositionNameUrl(position);//获取签名的文件地址
            tableName = switchFormID(formID);
            string posotionName = switchPositionName(position);
            //通过formID确定是具体的那一张表
            if (signatureurl != ""&&tableName!=""&&posotionName!="")//确定该表是否需要签名
            {
                string sql = "update " + tableName + " set " + posotionName + "='" + signatureurl + "' where Form_ID='" + formID + "'";
                Signature_DAL.Signature(sql);
            }
        }

        public static void setSignatureDate(string formID, string position)
        {
            string tableName = "";//哪张表
            string positionNameDate = switchPositionName(position) + "_Date";
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

        private static string switchPositionName(string position)//未完待续。。。
        {
            string PositionName = "";
            if (position == "人事部经理")
            {
                PositionName = "User_Department_Manager";
            }
            else if (position == "三厂供应链高级经理")
            {
                PositionName = "Supplier_Chain_Leader";
            }
            else if (position == "财务部经理")
            {
                PositionName = "Finance_Leader";
            }
            else if (position == "采购部经理")
            {
                PositionName = "Purchasing_Manager";
            }
            else if (position == "质量部经理")
            {
                PositionName = "Quality_Dept_Manager";
            }
            else if (position == "直线经理")
            {
                PositionName = "Line_Manager";
            }
            else if (position == "法务部")
            {
                PositionName = "Legal_Affair_Department";
            }
            else if (position == "总经理")
            {
                PositionName = "General_Manager";
            }
            return PositionName;
        }

    }
}
