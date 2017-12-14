using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLearning.Model
{
    public class Vendor_Modify_File
    {
        private string temp_Vendor_ID;
        private string file_Type_ID;
        private string file_Type_Name;
        private string factory_Name;
        private string temp_Vendor_Name;
        private string flag;
        private string iD;

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

        public string File_Type_ID
        {
            get
            {
                return file_Type_ID;
            }

            set
            {
                file_Type_ID = value;
            }
        }

        public string File_Type_Name
        {
            get
            {
                return file_Type_Name;
            }

            set
            {
                file_Type_Name = value;
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

        public string ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string Flag
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
    }
}