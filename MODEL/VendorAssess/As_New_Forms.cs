using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_New_Forms
    {
        private string form_ID;
        private string temp_Vendor_ID;
        private string factory_Name;
        private string form_Name;
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

        public string Form_Name
        {
            get
            {
                return form_Name;
            }

            set
            {
                form_Name = value;
            }
        }
    }
}
