﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Form_OverDue
    {
        private string form_ID;
        private string position;
        private string temp_Vendor_ID;
        private string status;
        private string form_Type_Is_Optional;
        private string form_Type_ID;
        private string factory_Name;//三厂审批分离
        private string vendor_Code;
        private string vendor_Type;
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

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }


        public string Form_Type_Is_Optional
        {
            get
            {
                return form_Type_Is_Optional;
            }

            set
            {
                form_Type_Is_Optional = value;
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

        public string Vendor_Code
        {
            get
            {
                return vendor_Code;
            }

            set
            {
                vendor_Code = value;
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
