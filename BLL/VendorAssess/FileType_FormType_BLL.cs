using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class FileType_FormType_BLL
    {
        public static IList<As_FileType_FormType> selectFileTypeID(string formtypeid)
        {
            return FileType_FormType_DAL.selectFileTypeID(formtypeid);
        }
    }
}
