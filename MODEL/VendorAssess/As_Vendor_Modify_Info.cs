﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Vendor_Modify_Info
    {
        private string temp_Vendor_ID;
        private string temp_Vendor_Name;
        private string vendor_Type_ID;
        private string normal_Vendor_ID;
        private int id;
        private int purchase_Amount;
        private string zH, zS, sH;
        private string vendor_Type;
        private string vendor_Assign;
        private string advance_Charge;
        private string promise;
        private string isChanging;


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

        public string Temp_Vendor_Name
        {
            get
            {
                return temp_Vendor_Name;
            }

            set
            {
                temp_Vendor_Name = value;
            }
        }

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

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Normal_Vendor_ID
        {
            get
            {
                return normal_Vendor_ID;
            }

            set
            {
                normal_Vendor_ID = value;
            }
        }

        public int Purchase_Amount
        {
            get
            {
                return purchase_Amount;
            }

            set
            {
                purchase_Amount = value;
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

        public string IsChanging
        {
            get
            {
                return isChanging;
            }

            set
            {
                isChanging = value;
            }
        }

        public string ZH
        {
            get
            {
                return zH;
            }

            set
            {
                zH = value;
            }
        }

        public string ZS
        {
            get
            {
                return zS;
            }

            set
            {
                zS = value;
            }
        }

        public string SH
        {
            get
            {
                return sH;
            }

            set
            {
                sH = value;
            }
        }
    }
}
