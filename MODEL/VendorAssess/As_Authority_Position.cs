using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Authority_Position
    {
        private int id;
        private string authority_ID;
        private string position_ID;

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
    }
}
