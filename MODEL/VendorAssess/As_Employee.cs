using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Employee
    {
        private string employee_ID;
        private string employee_Name;
        private string employee_Email;
        private string department_ID;
        private string positon_Name;
        private string employee_Password;

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

        public string Employee_Name
        {
            get
            {
                return employee_Name;
            }

            set
            {
                employee_Name = value;
            }
        }

        public string Employee_Email
        {
            get
            {
                return employee_Email;
            }

            set
            {
                employee_Email = value;
            }
        }

        public string Department_ID
        {
            get
            {
                return department_ID;
            }

            set
            {
                department_ID = value;
            }
        }

        public string Positon_Name
        {
            get
            {
                return positon_Name;
            }

            set
            {
                positon_Name = value;
            }
        }

        public string Employee_Password
        {
            get
            {
                return employee_Password;
            }

            set
            {
                employee_Password = value;
            }
        }
    }
}
