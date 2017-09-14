using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_File_OverDue
    {
        private string item_Category;
        private string temp_Vendor_ID;
        private string position;
        private string category;
        private string factory_Name;//三厂审批分离

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

        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
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

        public string Item_Category
        {
            get
            {
                return item_Category;
            }

            set
            {
                item_Category = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }
    }
}
