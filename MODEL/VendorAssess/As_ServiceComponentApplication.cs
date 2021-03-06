﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_ServiceComponentApplication
    {
        private List<As_ServiceComponentApplication_Item> componentApplicationItem = new List<As_ServiceComponentApplication_Item>();
        private string form_Type_ID;
        private string form_ID;
        private string temp_Vendor_ID;
        private string temp_Vendor_Name;
        private string factory_Name;
        private string initiator;
        private string supply_Chain_Manager;
        private string finance_Manager;
        private string gM;
        private int flag;
        private string remark;

        public List<As_ServiceComponentApplication_Item> ComponentApplicationItem
        {
            get
            {
                return componentApplicationItem;
            }

            set
            {
                componentApplicationItem = value;
            }
        }

        public string Form_Type_ID
        {
            get
            {
                return form_Type_ID;
            }

            set
            {
                form_Type_ID = value;
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

        public string Initiator
        {
            get
            {
                return initiator;
            }

            set
            {
                initiator = value;
            }
        }

        public string Supply_Chain_Manager
        {
            get
            {
                return supply_Chain_Manager;
            }

            set
            {
                supply_Chain_Manager = value;
            }
        }

        public string Finance_Manager
        {
            get
            {
                return finance_Manager;
            }

            set
            {
                finance_Manager = value;
            }
        }

        public string GM
        {
            get
            {
                return gM;
            }

            set
            {
                gM = value;
            }
        }

        public int Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
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
    }
}
