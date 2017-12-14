using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Modify_CheckResult
    {
        private string item_Name;//需要修改的选项 可以是文件，也可以是表格
        private string type;
        private string vendor_Name;
        private string form_Or_File_Type_ID;

        public string Item_Name
        {
            get
            {
                return item_Name;
            }

            set
            {
                item_Name = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Vendor_Name
        {
            get
            {
                return vendor_Name;
            }

            set
            {
                vendor_Name = value;
            }
        }

        public string Form_Or_File_Type_ID
        {
            get
            {
                return form_Or_File_Type_ID;
            }

            set
            {
                form_Or_File_Type_ID = value;
            }
        }
    }
}
