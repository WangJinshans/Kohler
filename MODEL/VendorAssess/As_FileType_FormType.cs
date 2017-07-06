using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_FileType_FormType
    {
        private int id;
        private string form_Type_ID;
        private string file_Type_ID;

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

        public string File_Type_ID
        {
            get
            {
                return file_Type_ID;
            }

            set
            {
                file_Type_ID = value;
            }
        }
    }
}
