using System;
using System.Collections.Generic;
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
    }
}
