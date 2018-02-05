using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_PurchasePriceApplication_Item
    {
        private string nO;
        private string sKU;
        private string description;
        private string supplier;
        private string uSD_Cost;
        private string tooling_Cost;
        private string tTL_Cost;
        private string mOQ;
        private string lead_time;
        private string other_Source;
        private string order_Share;
        private string now_Price;
        private string form_ID;

        public string NO
        {
            get
            {
                return nO;
            }

            set
            {
                nO = value;
            }
        }

        public string SKU
        {
            get
            {
                return sKU;
            }

            set
            {
                sKU = value;
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

        public string USD_Cost
        {
            get
            {
                return uSD_Cost;
            }

            set
            {
                uSD_Cost = value;
            }
        }

        public string Tooling_Cost
        {
            get
            {
                return tooling_Cost;
            }

            set
            {
                tooling_Cost = value;
            }
        }

        public string TTL_Cost
        {
            get
            {
                return tTL_Cost;
            }

            set
            {
                tTL_Cost = value;
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

        public string Lead_time
        {
            get
            {
                return lead_time;
            }

            set
            {
                lead_time = value;
            }
        }

        public string Other_Source
        {
            get
            {
                return other_Source;
            }

            set
            {
                other_Source = value;
            }
        }

        public string Order_Share
        {
            get
            {
                return order_Share;
            }

            set
            {
                order_Share = value;
            }
        }

        public string Now_Price
        {
            get
            {
                return now_Price;
            }

            set
            {
                now_Price = value;
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
