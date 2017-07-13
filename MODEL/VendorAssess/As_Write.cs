using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Write
    {
        private int id;
        private string employee_ID;
        private string form_ID;
        private string form_Fill_Time;
        private string manul;
        private string temp_Vendor_ID;

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

        public string Employee_ID
        {
            get
            {
                return employee_ID;
            }

            set
            {
                employee_ID = value;
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

        public string Form_Fill_Time
        {
            get
            {
                return form_Fill_Time;
            }

            set
            {
                form_Fill_Time = value;
            }
        }

        public string Manul
        {
            get
            {
                return manul;
            }

            set
            {
                manul = value;
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
