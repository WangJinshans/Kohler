using DAL;
using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;
using Model;
using System.Text;

namespace BLL
{
    public class FormType_BLL
    {
        public static int getSelectedFormPriorityNumber(string formtypeid)
        {
            return FormType_DAL.getSelectedFormPriorityNumber(formtypeid);
        }
        public static int getMinimumFormPriorityNumber(List<string> list)
        {
            return FormType_DAL.getMinimumFormPriorityNumber(list);
        }

        public static bool isMinimumFormPriorityNumber(int number,string temp_Vendor_ID)
        {
            int min = 100;
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary = FormType_DAL.getVendorFormPriorityNumber(temp_Vendor_ID);
            foreach (KeyValuePair<int, string> pair in dictionary)
            {
                if(min>pair.Key&&pair.Value!="可选")//只筛出必选
                {
                    min = pair.Key;
                }
            }
            if (number <= min)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getOptional(int selectedFormPriorityNumber)
        {
            //获取该表是否可选
            return FormType_DAL.getOptional(selectedFormPriorityNumber);
        }
        public static string getOptional(string formID)
        {
            //获取该表是否可选
            return FormType_DAL.getOptional(formID);
        }

        public static bool withOutAccess(int number, string temp_vendor_ID)
        {
            //判断是否有正在审批的表  优先级高于number的表
            List<int> numbers = new List<int>();
            bool ok = FormType_DAL.getAccessPriorityNumber(temp_vendor_ID);
            if (ok)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool withOutAccess(string vendorType, string temp_vendor_ID)
        {
            //4代表审批完成
            string sql = "select As_Vendor_FormType.flag from As_Vendor_FormType,As_Vendor_Type where As_Vendor_FormType.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Vendor_FormType.Temp_Vendor_ID='" + temp_vendor_ID + "' and As_Vendor_Type.Vendor_Type_Name='" + vendorType + "' and As_Vendor_FormType.flag<>4";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
                {
                    //存在不等于4的代表还有审批
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public static bool isOptionalMinimum(int number, string temp_Vendor_ID)
        {
            int min = 100;
            List<int> numbers = new List<int>();
            numbers = FormType_DAL.getOptionalNumbers(temp_Vendor_ID);
            //全部都已经审批过了 
            if (numbers == null)
            {
                return true;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];//min为最小值
                }
            }
            if (number <= min)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 在实时绑定表中获取formid
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="formTypeName"></param>
        /// <returns></returns>
        public static string getFormID(string tempVendorID, string formTypeName)
        {
            DataTable table = new DataTable();
            string formID = "";
            table = FormType_DAL.getFormID(tempVendorID,formTypeName);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_ID"].ToString().Trim();
                }
            }
            return formID;
        }

        public static bool isRequiredMinimum(int number, string temp_Vendor_ID)
        {
            int min = 100;
            List<int> numbers = new List<int>();
            numbers = FormType_DAL.getRequiredNumbers(temp_Vendor_ID);
            if (numbers == null)
            {
                return true;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];//min为最小值
                }
            }
            if (number <= min)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getFormNameByTypeID(string form_Type_ID)
        {
            DataTable table = new DataTable();
            string formName = "";
            table = FormType_DAL.getFormNameByTypeID(form_Type_ID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formName = dr["Form_Type_Name"].ToString().Trim();
                }
            }
            table.Dispose();
            return formName;
        }

        public static string getFormNameByFormID(string form_Type_ID)
        {
            DataTable table = new DataTable();
            string formName = "";
            table = FormType_DAL.getFormNameByFormID(form_Type_ID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formName = dr["Form_Type_Name"].ToString().Trim();
                }
            }
            return formName;
        }

        /// <summary>
        /// 判断此formid是否正在审批中
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        internal static bool isPending(string form_ID)
        {

            string sql = "Select count(*) from As_Vendor_FormType Where flag<>0 and Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            return DBHelp.GetScalarFix(sql, sp) > 0;
        }

        /// <summary>
        /// 获取当前pending的表格
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static string getCurrentAssessState(string tempVendorID)
        {
            StringBuilder reason = new StringBuilder();
            DataTable dt = FormType_DAL.getVendorFormType(tempVendorID);
            if (dt != null && dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    reason.Append(item["Form_Type_Name"]);
                    reason.Append(" 状态：");
                    reason.Append(As_Vendor_FormType.translateFlag(item["flag"].ToString()));
                    reason.Append("<br/>");
                }
                reason.Append("供应商：");
                reason.Append(dt.Rows[0]["Temp_Vendor_Name"].ToString());
            }
            if (reason.Length == 0)
            {
                reason.Append("顺序越界，请提交此表之前的表格");
            }
            return reason.ToString();
        }
        public static string getFormTypeIDByName(string form_Name)
        {
            return FormType_DAL.getFormTypeIDByName(form_Name);
        }
    }
}
