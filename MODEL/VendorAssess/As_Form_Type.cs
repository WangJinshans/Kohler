using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Form_Type
    {
        private string form_Type_ID;
        private string form_Type_Name;

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

        public string Form_Type_Name
        {
            get
            {
                return form_Type_Name;
            }

            set
            {
                form_Type_Name = value;
            }
        }
    }
}
