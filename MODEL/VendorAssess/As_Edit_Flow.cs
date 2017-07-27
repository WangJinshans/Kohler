using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Edit_Flow
    {
        private string form_Type_ID;
        private string edit_One_Department;
        private string edit_Two_Department;
        private string edit_Three_Department;
        private int multi_Edit;

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

        public string Edit_One_Department
        {
            get
            {
                return edit_One_Department;
            }

            set
            {
                edit_One_Department = value;
            }
        }

        public string Edit_Two_Department
        {
            get
            {
                return edit_Two_Department;
            }

            set
            {
                edit_Two_Department = value;
            }
        }

        public string Edit_Three_Department
        {
            get
            {
                return edit_Three_Department;
            }

            set
            {
                edit_Three_Department = value;
            }
        }

        public int Multi_Edit
        {
            get
            {
                return multi_Edit;
            }

            set
            {
                multi_Edit = value;
            }
        }
    }
}
