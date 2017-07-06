using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class FormFile_BLL
    {
        public static IList<As_Form_File> listFile(string sql)
        {
            return Form_File_DAL.listFile(sql);
        }

        public static int addFormFile(As_Form_File asFormFile)
        {
            return Form_File_DAL.addFormFile(asFormFile);
        }
    }
}
