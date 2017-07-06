using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Department
    {
        private string department_ID;
        private string department_Name;
        private string department_Describe;


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

        public string Department_Name
        {
            get
            {
                return department_Name;
            }

            set
            {
                department_Name = value;
            }
        }

        public string Department_Describe
        {
            get
            {
                return department_Describe;
            }

            set
            {
                department_Describe = value;
            }
        }
    }
}
