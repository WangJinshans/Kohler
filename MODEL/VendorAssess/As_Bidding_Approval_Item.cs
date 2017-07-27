using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Bidding_Approval_Item
    {
        private string item;
        private string description;
        private string price1;
        private string price2;
        private string price3;
        private string remark;
        private string form_ID;

        public string Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
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

        public string Price1
        {
            get
            {
                return price1;
            }

            set
            {
                price1 = value;
            }
        }

        public string Price2
        {
            get
            {
                return price2;
            }

            set
            {
                price2 = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
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

        public string Price3
        {
            get
            {
                return price3;
            }

            set
            {
                price3 = value;
            }
        }
    }
}
