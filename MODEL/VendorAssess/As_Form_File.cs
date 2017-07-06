using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Form_File
    {
        private int id;
        private string form_ID;
        private string file_ID;

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

        public string File_ID
        {
            get
            {
                return file_ID;
            }

            set
            {
                file_ID = value;
            }
        }
    }
}
