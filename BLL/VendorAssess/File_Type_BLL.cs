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

        public static string getFileTypeIDByItemCategory(string itemCategory)
        {
            return File_Type_DAL.getFileTypeIDByItemCategory(itemCategory);
        }

        public static string getFileTypeNameByID(string fileTypeID)
        {
            return File_Type_DAL.getFileTypeNameByID(fileTypeID);
        }

        public static void updateFileStatus(string oldFileID)
        {
            File_Type_DAL.updateFileStatus(oldFileID);
        }
    }
}
