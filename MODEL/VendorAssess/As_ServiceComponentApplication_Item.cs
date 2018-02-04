using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_ServiceComponentApplication_Item
    {
        private string item_No;
        private string description;
        private string sku_Number;
        private string uOM;
        private string supplier;
        private string service_Cost;
        private string original_Cost;
        private string mOQ;
        private string mOQ_PO;
        private string lead_Time;
        private string form_ID;

        public string Item_No
        {
            get
            {
                return item_No;
            }

            set
            {
                item_No = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Sku_Number
        {
            get
            {
                return sku_Number;
            }

            set
            {
                sku_Number = value;
            }
        }

        public string UOM
        {
            get
            {
                return uOM;
            }

            set
            {
                uOM = value;
            }
        }

        public string Supplier
        {
            get
            {
                return supplier;
            }

            set
            {
                supplier = value;
            }
        }

        public string Service_Cost
        {
            get
            {
                return service_Cost;
            }

            set
            {
                service_Cost = value;
            }
        }

        public string Original_Cost
        {
            get
            {
                return original_Cost;
            }

            set
            {
                original_Cost = value;
            }
        }

        public string MOQ
        {
            get
            {
                return mOQ;
            }

            set
            {
                mOQ = value;
            }
        }

        public string MOQ_PO
        {
            get
            {
                return mOQ_PO;
            }

            set
            {
                mOQ_PO = value;
            }
        }

        public string Lead_Time
        {
            get
            {
                return lead_Time;
            }

            set
            {
                lead_Time = value;
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
    }
}
