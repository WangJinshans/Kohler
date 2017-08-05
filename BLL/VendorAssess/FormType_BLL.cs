using DAL;
using System.Collections;
using System.Collections.Generic;
using System;

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

        public static bool isOptionalMinimum(int number, string temp_Vendor_ID)
        {
            int min = 100;
            List<int> numbers = new List<int>();
            numbers = FormType_DAL.getOptionalNumbers(temp_Vendor_ID);
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
    }
}
