using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Form_EditFlow
    {
        private string form_ID;
        private string one;
        private string two;
        private string three;
        private int multi_Edit;
        private string temp_Vendor_ID;
        private string factory_Name;

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

        public string One
        {
            get
            {
                return one;
            }

            set
            {
                one = value;
            }
        }

        public string Two
        {
            get
            {
                return two;
            }

            set
            {
                two = value;
            }
        }

        public string Three
        {
            get
            {
                return three;
            }

            set
            {
                three = value;
            }
        }

        public int Multi_Edit
        {
            get
            {
                return multi_Edit;
            }

            set
            {
                multi_Edit = value;
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
