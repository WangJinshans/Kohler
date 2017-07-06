using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Vendor_Type
    {
        private string vendor_Type_ID;
        private string promise;
        private string purchase_Money;
        private string advance_Charge;
        private string vendor_Assign;
        private string vendor_Type;

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

        public string Promise
        {
            get
            {
                return promise;
            }

            set
            {
                promise = value;
            }
        }

        public string Purchase_Money
        {
            get
            {
                return purchase_Money;
            }

            set
            {
                purchase_Money = value;
            }
        }

        public string Advance_Charge
        {
            get
            {
                return advance_Charge;
            }

            set
            {
                advance_Charge = value;
            }
        }

        public string Vendor_Assign
        {
            get
            {
                return vendor_Assign;
            }

            set
            {
                vendor_Assign = value;
            }
        }

        public string Vendor_Type
        {
            get
            {
                return vendor_Type;
            }

            set
            {
                vendor_Type = value;
            }
        }
    }
}
