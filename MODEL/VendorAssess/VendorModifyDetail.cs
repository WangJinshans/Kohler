using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class VendorModifyDetail
    {
        private string vendor_Name;
        private string newVendor_Type;
        private string purchase_Money;
        private string oldVendor_Type;
        private bool promise;
        private bool advance_charge;
        private bool vendor_Assign;
        private string factory_Name;
        private float money;

        public string Vendor_Name
        {
            get
            {
                return vendor_Name;
            }

            set
            {
                vendor_Name = value;
            }
        }

        public string NewVendor_Type
        {
            get
            {
                return newVendor_Type;
            }

            set
            {
                newVendor_Type = value;
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

        public string OldVendor_Type
        {
            get
            {
                return oldVendor_Type;
            }

            set
            {
                oldVendor_Type = value;
            }
        }

        public bool Promise
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

        public bool Advance_charge
        {
            get
            {
                return advance_charge;
            }

            set
            {
                advance_charge = value;
            }
        }

        public bool Vendor_Assign
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

        public float Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }
    }
}
