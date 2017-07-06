using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_VendorType_FormType
    {
        private int id;
        private string form_Type_ID;
        private string vendor_Type_ID;
        private string form_Type_Name;

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

        public string Form_Type_Name
        {
            get
            {
                return form_Type_Name;
            }

            set
            {
                form_Type_Name = value;
            }
        }
    }
}
