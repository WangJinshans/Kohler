using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Form_Reject
    {
        private string form_ID;
        private string temp_Vendor_ID;

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
    }
}
