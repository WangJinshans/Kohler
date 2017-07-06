using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Position
    {
        private string position_ID;
        private string position_Name;
        private string position_Describe;

        public string Position_ID
        {
            get
            {
                return position_ID;
            }

            set
            {
                position_ID = value;
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

        public string Position_Describe
        {
            get
            {
                return position_Describe;
            }

            set
            {
                position_Describe = value;
            }
        }
    }
}
