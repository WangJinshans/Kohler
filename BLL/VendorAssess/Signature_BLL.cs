using DAL.VendorAssess;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace BLL.VendorAssess
{
    public class Signature_BLL
    {
        public const string urlPath = "./TEST/files/{0}.png";

        public static void setSignature(string formID, string position, string dataField)
        {
            string factory = getFactory(formID);
            string tableName = "";//哪张表
            string signatureurl = String.Format(urlPath, HttpContext.Current.Session["Employee_ID"]);// getPositionNameUrl(position, factory);//获取签名的文件地址
            tableName = switchFormID(formID);
            //通过formID确定是具体的那一张表
            if (signatureurl != null)
            {
                string sql = "update " + tableName + " set " + dataField + "='" + signatureurl + "' where Form_ID='" + formID + "'";
                Signature_DAL.Signature(sql);
            }
        }


        private static string getFactory(string formID)
        {
            return Signature_DAL.getFactory(formID);
        }



        /*
         * 
         *由于在审批的时候 某职位的负责人只需要点击同意或者拒绝  然后进行动态的签名
         * 那么当一张表中需要多个他多次签名的时候 由于他只能点击一次 所以只能在签名
         * 的时候全部进行操作 若同意 则该表所有需要他签名的地方都同意 都附上签名 
         * 
         * 合同审批表中 需要同一个职位多次签名的 该表只有一个字段 多个位置共同使用
         */


        public static bool setSignature(string formID, string position)
        {
            string factory = getFactory(formID);
            string tableName = "";//哪张表
            string signatureurl = String.Format(urlPath, HttpContext.Current.Session["Employee_ID"]);// getPositionNameUrl(position, factory);//获取签名的文件地址
            tableName = switchFormID(formID);
            if (tableName == "")
            {
                return true;//压根儿不需要签名的表
            }
            string posotionName = switchPositionName(position);
            //通过formID确定是具体的那一张表
            if (signatureurl != ""&&tableName!=""&&posotionName!="")//确定该表是否需要签名
            {
                string sql = "update " + tableName + " set " + posotionName + "='" + signatureurl + "' where Form_ID='" + formID + "'";
                if (Signature_DAL.Signature(sql)>0)
                {
                    return true;
                }
            }
            return false;
        }

        public static int setSignatureDate(string formID, string position)
        {
            try
            {
                string tableName = "";//哪张表
                string positionNameDate = switchPositionName(position) + "_Date";
                tableName = switchFormID(formID);
                string sql = "update " + tableName + " set " + positionNameDate + "='" + DateTime.Now.ToString().Trim() + "' where Form_ID='" + formID + "'";
                if (Signature_DAL.SignatureDate(sql) > 0)
                {
                    return 1;//SUCCESS
                }
            }
            catch (Exception)
            {
                return 2;//NO DATE
            }
            return -1;//ERROR
        }
        public static int setUserDepartmentSignatureDate(string formID,string dataFiled)
        {
            try
            {
                string tableName = "";//哪张表
                tableName = switchFormID(formID);
                string sql = "update " + tableName + " set " + dataFiled + "='" + DateTime.Now.ToString().Trim() + "' where Form_ID='" + formID + "'";
                if (Signature_DAL.SignatureDate(sql) > 0)
                {
                    return 1;//SUCCESS
                }
            }
            catch (Exception)
            {
                return 2;//NO DATE
            }
            return -1;//ERROR
        }

        private static string getPositionNameUrl(string position,string factory)//获取当前职位的签名地址绝对路径
        {
            return Signature_DAL.getPositionNameUrl(position, factory);
        }

        public static string switchFormID(string formID)//未完待续。。。
        {
            string table = "", tempFormID = formID.Substring(0, formID.LastIndexOf("_"));
            try
            {
                table = PageSelect.dcFormToModel[tempFormID];
            }
            catch (Exception)
            {
                if (true)
                {
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
                    else if (formID.Contains("Selection"))
                    {
                        table = "As_Vendor_Selection";
                    }
                    else if (formID.Contains("VendorRisk"))
                    {
                        table = "As_Vendor_Risk";
                    }
                    else if (formID.Contains("PurchaseChanges"))
                    {
                        table = "As_Purchase_Changes";
                    }
                }
                else if (formID.Contains("VendorModify"))
                {
                    table = "As_VendorModify";
                }
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
            else if (position == "供应链经理")
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


        /// <summary>
        /// 删除该表的所有签名
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static bool deleteSignature(string formID)
        {
            string dataFiled = "";
            string tableName = switchFormID(formID);
            //在As_Form_AccessFlow中查出所有会审批的人的职位
            List<string> positions = getAccessPositions(formID);
            if (positions.Count > 0)//需要进行审批
            {
                //删除用户部门的签名以及时间
                string sql1 = "update " + tableName + " set User_Department_Manager='',User_Department_Manager_Date='' where Form_ID='" + formID + "'";
                Signature_DAL.deleteSignature(sql1);

                foreach (string position in positions)
                {
                    dataFiled = switchPositionName(position);
                    string sql = "update " + tableName + " set " + dataFiled + "=''";
                    Signature_DAL.deleteSignatureDate(sql);
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// 删除签名时间
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        internal static bool deleteSignatureDate(string formID)
        {
            string dataFiled = "";
            string tableName = switchFormID(formID);
            //在As_Form_AccessFlow中查出所有会审批的人的职位
            List<string> positions = getAccessPositions(formID);
            if (positions.Count > 0)//需要进行审批
            {
                foreach (string position in positions)
                {
                    dataFiled = switchPositionName(position) + "_Date";
                    string sql = "update " + tableName + " set " + dataFiled + "=''";
                    Signature_DAL.deleteSignature(sql);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 从As_Form_AssessFlow中查出该表所有需要审批的人的职位  并放入数组中返回
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        private static List<string> getAccessPositions(string formID)
        {
            List<string> positions = new List<string>();
            string first, second, third, four, five;
            string sql = "select First,Second,Third,Four,Five from As_Form_AssessFlow where Form_ID='" + formID + "'";
            DataTable table = Signature_DAL.getAccessPositions(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    first = dr["First"].ToString().Trim();
                    second = dr["Second"].ToString().Trim();
                    third = dr["Third"].ToString().Trim();
                    four = dr["Four"].ToString().Trim();
                    five = dr["Five"].ToString().Trim();
                    if (first != "")
                    {
                        positions.Add(first);
                    }
                    if (second != "")
                    {
                        positions.Add(second);
                    }
                    if (third != "")
                    {
                        positions.Add(third);
                    }
                    if (four != "")
                    {
                        positions.Add(four);
                    }
                    if (five != "")
                    {
                        positions.Add(five);
                    }
                }
            }
            return positions;
        }
    }
}
