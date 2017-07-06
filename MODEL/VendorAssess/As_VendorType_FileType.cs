using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class As_VendorType_FileType
    {
        string vendorType_ID;
        string fileType_ID;
        string fileType_Name;

        public string VendorType_ID
        {
            get
            {
                return vendorType_ID;
            }

            set
            {
                vendorType_ID = value;
            }
        }

        public string FileType_ID
        {
            get
            {
                return fileType_ID;
            }

            set
            {
                fileType_ID = value;
            }
        }

        public string FileType_Name
        {
            get
            {
                return fileType_Name;
            }

            set
            {
                fileType_Name = value;
            }
        }
    }
}
