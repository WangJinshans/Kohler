using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Form
    {
        private string form_ID;
        private string form_Name;
        private string form_Path;
        private string form_Type_ID;
        private string temp_Vendor_Name;
        private string temp_Vendor_ID;
        private string factory_Name;
        private string assess_Status;

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

        public string Form_Type_Name
        {
            get
            {
                return form_Name;
            }

            set
            {
                form_Name = value;
            }
        }

        public string Form_Path
        {
            get
            {
                return form_Path;
            }

            set
            {
                form_Path = value;
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

        public string Assess_Status
        {
            get
            {
                return assess_Status;
            }

            set
            {
                assess_Status = value;
            }
        }
    }
}
