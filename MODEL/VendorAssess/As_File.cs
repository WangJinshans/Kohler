using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_File
    {
        private string file_ID;
        private string file_Name;
        private string file_Path;
        private string file_Enable_Time;
        private string file_Due_Time;
        private string temp_Vendor_Name;
        private string file_Type_ID;
        private string temp_Vendor_ID;
        private bool is_Shared;
        private string file_Type_Range;
        private string file_Type_Name;
        private string factory_Name;

        public string File_ID
        {
            get
            {
                return file_ID;
            }

            set
            {
                file_ID = value;
            }
        }

        public string File_Name
        {
            get
            {
                return file_Name;
            }

            set
            {
                file_Name = value;
            }
        }

        public string File_Path
        {
            get
            {
                return file_Path;
            }

            set
            {
                file_Path = value;
            }
        }

        public string File_Enable_Time
        {
            get
            {
                return file_Enable_Time;
            }

            set
            {
                file_Enable_Time = value;
            }
        }

        public string File_Due_Time
        {
            get
            {
                return file_Due_Time;
            }

            set
            {
                file_Due_Time = value;
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

        public bool Is_Shared
        {
            get
            {
                return is_Shared;
            }

            set
            {
                is_Shared = value;
            }
        }

        public string File_Type_Range
        {
            get
            {
                return file_Type_Range;
            }

            set
            {
                file_Type_Range = value;
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
    }
}
