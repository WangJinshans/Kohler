using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_File_Type
    {
        private string file_Type_ID;
        private string file_Type_Name;

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

        public string File_Type_Name
        {
            get
            {
                return file_Type_Name;
            }

            set
            {
                file_Type_Name = value;
            }
        }
    }
}
