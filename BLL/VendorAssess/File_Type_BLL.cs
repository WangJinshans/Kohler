using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class File_Type_BLL
    {
        public static string selectFileTypeName(string FileTypeID)
        {
            return File_Type_DAL.selectFileTypeName(FileTypeID);
        }
        public static string selectFileTypeID(string FileTypeName,string tempVendorID)
        {
            return File_Type_DAL.selectFileTypeID(FileTypeName, tempVendorID);
        }

        public static string getSpec(string fileTypeID)
        {
            return File_Type_DAL.getSpec(fileTypeID);
        }
        public static string getFormSpec(string fileTypeName)
        {
            return File_Type_DAL.getFormSpec(fileTypeName);
        }

        internal static bool getShared(string fileTypeID)
        {
            return File_Type_DAL.getShared(fileTypeID);
        }
    }
}
