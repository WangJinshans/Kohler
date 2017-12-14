using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Vendor_FormType
    {
        private int id;
        private string temp_Vendor_ID;
        private string form_Type_ID;
        private string temp_Vendor_Name;
        private int flag;
        private string form_Type_Name;
        private string form_Type_Is_Optional;
        private string form_ID;
        private int prority;
        private string factory_Name;

        public const string FLAG0 = "待发起人填写/提交";
        public const string FLAG1 = "已提交,等待审批";
        public const string FLAG2 = "已确认，等待其他部门填写";
        public const string FLAG3 = "等待kci审批";
        public const string FLAG4 = "审批完毕";


        public static string translateFlag(string flag)
        {
            string st = "";
            switch (flag)
            {
                case "0":
                    st = FLAG0;
                    break;
                case "1":
                    st = FLAG1;
                    break;
                case "2":
                    st = FLAG2;
                    break;
                case "3":
                    st = FLAG3;
                    break;
                case "4":
                    st = FLAG4;
                    break;
                default:
                    break;
            }
            return st;
        }


        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Temp_Vendor_ID
        {
            get
            {
                return temp_Vendor_ID;
            }

            set
            {
                temp_Vendor_ID = value;
            }
        }

        public string Temp_Vendor_Name
        {
            get
            {
                return temp_Vendor_Name;
            }

            set
            {
                temp_Vendor_Name = value;
            }
        }

        public string Form_Type_ID
        {
            get
            {
                return form_Type_ID;
            }

            set
            {
                form_Type_ID = value;
            }
        }

        public int Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }

        public string Form_Type_Name
        {
            get
            {
                return form_Type_Name;
            }

            set
            {
                form_Type_Name = value;
            }
        }

        public string Form_Type_Is_Optional
        {
            get
            {
                return form_Type_Is_Optional;
            }

            set
            {
                form_Type_Is_Optional = value;
            }
        }

        public string Form_ID
        {
            get
            {
                return form_ID;
            }

            set
            {
                form_ID = value;
            }
        }

        public int Prority
        {
            get
            {
                return prority;
            }

            set
            {
                prority = value;
            }
        }

        public string Factory_Name
        {
            get
            {
                return factory_Name;
            }

            set
            {
                factory_Name = value;
            }
        }
    }
}
