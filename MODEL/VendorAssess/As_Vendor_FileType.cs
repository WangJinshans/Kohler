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
        private string file_ID;
        private string factory_Name;
        private string file_Type_Range;
        private string file_Is_Necessary;



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

        public string File_Is_Necessary
        {
            get
            {
                return file_Is_Necessary;
            }

            set
            {
                file_Is_Necessary = value;
            }
        }
    }
}
