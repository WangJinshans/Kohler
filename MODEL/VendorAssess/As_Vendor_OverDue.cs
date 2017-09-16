using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Vendor_OverDue
    {
        private string temp_Vendor_ID;
        private string factory_Name;
        private string item_Plant;

        public string Item_Plant
        {
            get
            {
                return item_Plant;
            }

            set
            {
                item_Plant = value;
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
