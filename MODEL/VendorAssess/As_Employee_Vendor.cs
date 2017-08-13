using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Employee_Vendor
    {
        public const string NEW_VENDOR = "新建";
        public const string REUSE_VENDOR = "复用";

        private string employee_ID;
        private string temp_Vendor_ID;
        private string temp_Vendor_Name;
        private string vendor_Type_ID;
        private string type;

        public string Employee_ID
        {
            get
            {
                return employee_ID;
            }

            set
            {
                employee_ID = value;
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

        public string Vendor_Type_ID
        {
            get
            {
                return vendor_Type_ID;
            }

            set
            {
                vendor_Type_ID = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
