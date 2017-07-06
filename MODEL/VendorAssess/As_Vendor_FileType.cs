using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Vendor_FileType
    {
        private string temp_Vendor_ID;
        private string fileType_ID;
        private string fileType_Name;
        private int flag;



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
    }
}
