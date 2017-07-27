using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class As_KCI_Approval
    {
        private string form_ID;
        private string temp_Vendor_ID;
        private string position_Name;
        private int status;

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

        public string Position_Name
        {
            get
            {
                return position_Name;
            }

            set
            {
                position_Name = value;
            }
        }

        public int Status
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
    }
}
