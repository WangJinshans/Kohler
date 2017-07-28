using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

        public static List<int> getVendorFormPriorityNumber(string temp_Vendor_ID)
        {
            List<int> numbers = new List<int>();
            //获取该供应商所有需要填写的且已经审批完成的表格
            string sql = "select Form_Type_Priority_Number from As_Form_Type,As_Vendor_FormType where As_Form_Type.Form_Type_ID=As_Vendor_FormType.Form_Type_ID and As_Vendor_FormType.flag <> '4' and As_Vendor_FormType.Temp_Vendor_ID='" + temp_Vendor_ID + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            int number;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    number = Convert.ToInt32(dr["Form_Type_Priority_Number"]);
                    numbers.Add(number);
                }
            }
            return numbers;
        }
    }
}
