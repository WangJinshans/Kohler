using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Authority
    {
        private string authority_ID;
        private string authority_Name;
        private string authority_Describe;

        public string Authority_ID
        {
            get
            {
                return authority_ID;
            }

            set
            {
                authority_ID = value;
            }
        }

        public string Authority_Name
        {
            get
            {
                return authority_Name;
            }

            set
            {
                authority_Name = value;
            }
        }

        public string Authority_Describe
        {
            get
            {
                return authority_Describe;
            }

            set
            {
                authority_Describe = value;
            }
        }
    }
}
