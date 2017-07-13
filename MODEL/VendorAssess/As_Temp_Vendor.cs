using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Temp_Vendor
    {
        private string temp_Vendor_ID;
        private string temp_Vendor_Name;
        private string vendor_Type_ID;
        private string normal_Vendor_ID;
        private int id;

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
    }
}
