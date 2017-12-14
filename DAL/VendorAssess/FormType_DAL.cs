using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace DAL
{
    /// <summary>
    /// 对As_Form_Type进行操作
    /// </summary>
    public class FormType_DAL
    {
        public static int getSelectedFormPriorityNumber(string formtypeid)
        {
            string sql = "select Form_Type_Priority_Number from As_Form_Type where Form_Type_ID='" + formtypeid + "'";
            int number = Convert.ToInt32(DBHelp.GetScalar(sql));
            return number;
        }
        public static int getMinimumFormPriorityNumber(List<string> list)
        {
            int min = 100;
            for (int i = 0; i < list.Count; i++)
            {
                string sql = "select Form_Type_Priority_Number from As_Form_Type where Form_Type_ID='" + list[i] + "'";
                int number = Convert.ToInt32(DBHelp.GetScalar(sql));
                if (number <= min)
                {
                    min = number;
                }
            }
            return min;
        }

        public static bool setFormFlag(string formTypeID,string tempVendorID, int flag)
        {
            string sql = "update As_Vendor_FormType set flag=@flag where Form_Type_ID=@Form_Type_ID and Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@flag",flag),
                new SqlParameter("@Form_Type_ID",formTypeID),
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            if (DBHelp.ExecuteCommand(sql,sp)>0)
            {
                return true;
            }
            return false;
        }

        public static Dictionary<int, string> getVendorFormPriorityNumber(string temp_Vendor_ID)
        {
            List<int> numbers = new List<int>();
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            //获取该供应商所有需要填写的且已经审批完成的表格
            string sql = "select Form_Type_Priority_Number,Form_Type_Is_Optional from As_Form_Type,As_Vendor_FormType where As_Form_Type.Form_Type_ID=As_Vendor_FormType.Form_Type_ID and As_Vendor_FormType.flag <> '4' and As_Vendor_FormType.Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='"+Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString())+"'";
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dictionary.Add(Convert.ToInt32(dr["Form_Type_Priority_Number"]), dr["Form_Type_Is_Optional"].ToString().Trim());
                }
            }
            return dictionary;
        }

        public static string getOptional(int selectedFormPriorityNumber)
        {
            string sql = "select Form_Type_Is_Optional from As_Form_Type where As_Form_Type.Form_Type_Priority_Number='" + selectedFormPriorityNumber + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            string optional = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    optional = dr["Form_Type_Is_Optional"].ToString();
                }
            }
            return optional;
        }

        public static string getOptional(string formID)
        {
            string sql = "select As_Form_Type.Form_Type_Is_Optional from As_Form_Type,As_Form where As_Form_Type.Form_Type_ID=As_Form.Form_Type_ID and As_Form.Form_ID='" + formID + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            string optional = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    optional = dr["Form_Type_Is_Optional"].ToString();
                }
            }
            return optional;
        }

        public static List<int> getRequiredNumbers(string temp_Vendor_ID)
        {
            List<int> numbers = new List<int>();
            string sql = "select Form_Type_Priority_Number from As_Form_Type,As_Vendor_FormType where As_Form_Type.Form_Type_ID=As_Vendor_FormType.Form_Type_ID and As_Vendor_FormType.flag <> '4' and As_Form_Type.Form_Type_Is_Optional ='必选' and As_Vendor_FormType.Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()) + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            int number;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    number = Convert.ToInt32(dr["Form_Type_Priority_Number"]);
                    numbers.Add(number);
                }
                return numbers;
            }
            return null;
        }

        public static DataTable getFormNameByFormID(string FormID)
        {
            string sql = "select Form_Type_Name from As_Form where Form_ID='" + FormID + "'";
            return DBHelp.GetDataSet(sql);
        }

        public static DataTable getFormID(string tempVendorID,string typeName)
        {
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID+"' and Form_Type_Name='" + typeName + "'";
            return DBHelp.GetDataSet(sql);
        }

        public static DataTable getFormNameByTypeID(string form_Type_ID)
        {
            string sql = "select Form_Type_Name from As_Form_Type where Form_Type_ID='" + form_Type_ID + "'";
            return DBHelp.GetDataSet(sql);
        }

        /// <summary>
        /// 获取全表flag为1，2，3
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static DataTable getVendorFormType(string tempVendorID)
        {
            DataTable dt = null;
            string sql = "SELECT * FROM View_Vendor_FormType Where Temp_Vendor_ID=@Temp_Vendor_ID and flag in (1,2,3)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            using (dt = DBHelp.GetDataSet(sql,sp))
            return dt;
        }

        /// <summary>
        /// 获取所有可选的表的优先顺序
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <returns></returns>
        public static List<int> getOptionalNumbers(string temp_Vendor_ID)
        {
            List<int> numbers = new List<int>();
            string sql = "select Form_Type_Priority_Number from As_Form_Type,As_Vendor_FormType where As_Form_Type.Form_Type_ID=As_Vendor_FormType.Form_Type_ID and As_Vendor_FormType.flag <> '4' and As_Form_Type.Form_Type_Is_Optional ='可选' and As_Vendor_FormType.Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()) + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            int number;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    number = Convert.ToInt32(dr["Form_Type_Priority_Number"]);
                    numbers.Add(number);
                }
                return numbers;
            }
            return null;
        }

        public static bool getAccessPriorityNumber(string temp_Vendor_ID)
        {
            List<int> numbers = new List<int>();
            string sql = "select Form_Type_Priority_Number from As_Form_Type,As_Vendor_FormType where As_Form_Type.Form_Type_ID=As_Vendor_FormType.Form_Type_ID and As_Vendor_FormType.flag <> '4' and As_Vendor_FormType.flag <> '0' and As_Vendor_FormType.Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()) + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                //foreach (DataRow dr in dt.Rows)
                //{
                //    number = Convert.ToInt32(dr["Form_Type_Priority_Number"]);
                //    numbers.Add(number);
                //}
                return false;
            }
            return true;
        }

    }
}
