﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Form_File
    {
        private int id;
        private string form_ID;
        private string file_ID;
        private string temp_Vendor_ID;
        private string file_Type_Name;

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
    }
}
