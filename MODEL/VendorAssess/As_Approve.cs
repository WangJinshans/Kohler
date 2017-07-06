using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Approve
    {
        private string form_ID;
        private string position_Name;
        private string assess_Flag;
        private DateTime assess_Time;
        private string assess_Reason;

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

        public string  Assess_Flag
        {
            get
            {
                return assess_Flag;
            }

            set
            {
                assess_Flag = value;
            }
        }


        public string Assess_Reason
        {
            get
            {
                return assess_Reason;
            }

            set
            {
                assess_Reason = value;
            }
        }

        public string Position_Name
        {
            get
            {
                return position_Name;
            }

            set
            {
                position_Name = value;
            }
        }

        public DateTime Assess_Time
        {
            get
            {
                return assess_Time;
            }

            set
            {
                assess_Time = value;
            }
        }
    }
}
