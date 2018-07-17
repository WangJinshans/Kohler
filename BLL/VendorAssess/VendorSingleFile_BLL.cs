using DAL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class VendorSingleFile_BLL
    {
        public static void addSingleFile(string formID,string formTypeID,string tempVendorID,string tempVendorName,string factroy_Name,string fileTypeID)
        {
            VendorSingleFile_DAL.addSingleFile(formID, formTypeID, tempVendorID, tempVendorName, factroy_Name, fileTypeID);
        }

        public static void bindSelectedFile(string formID, string formTypeID, string tempVendorID, string tempVendorName, string factroy_Name, string fileTypeID)
        {
            //VendorSingleFile_DAL.addSingleFile(formID, formTypeID, tempVendorID, tempVendorName, factroy_Name, fileTypeID);
        }

        public static bool isSingleFileSubmit(string formID)
        {
            return VendorSingleFile_DAL.isSingleFileSubmit(formID);
        }
        public static int updateSingleFileFlag(string formID, string fileID)
        {
            return VendorSingleFile_DAL.updateSingleFileFlag(formID, fileID);
        }

        public static string getOldFileID(string formID)
        {
            return VendorSingleFile_DAL.getOldFileID(formID);
        }
    }
}
