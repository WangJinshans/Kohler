using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class TempVendor_BLL
    {
        public static string getTempVendorID(string TempVendorName)
        {
            return TempVendor_DAL.getTempVendorID(TempVendorName);
        }

        public static string getTempVendorName(string tempVendorID)
        {
            return TempVendor_DAL.getTempVendorName(tempVendorID);
        }

        public static bool checkUsed(string tempVendorID, string factoryName)
        {
            return TempVendor_DAL.getUsed(tempVendorID, factoryName);
        }
    }
}
