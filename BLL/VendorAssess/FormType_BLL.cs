using DAL;
using System.Collections.Generic;

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
            /*
             * 如果获取的已经审批完成的表格中 最大值 < 当前优先级-1 说明还存在未审批完成的表格
             * 无法提交
             */
            int min = 100; //为0确保第一张表可以提交
            List<int> numbers = new List<int>();
            numbers = FormType_DAL.getVendorFormPriorityNumber(temp_Vendor_ID);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (min>numbers[i])
                {
                    min = numbers[i];//min为最小值
                }
            }
            if (min <= number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
