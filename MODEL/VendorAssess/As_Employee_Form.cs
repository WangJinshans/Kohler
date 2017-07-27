using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Employee_Form
    {
        private string employee_ID;
        private string form_ID;
        private string form_Type_Name;
        private int fill_Flag;
        private string temp_Vendor_ID;

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

        public int Fill_Flag
        {
            get
            {
                return fill_Flag;
            }

            set
            {
                fill_Flag = value;
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
    }
}
