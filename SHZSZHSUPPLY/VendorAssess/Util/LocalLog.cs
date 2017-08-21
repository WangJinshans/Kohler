using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class LocalLog
    {
        public static bool writeLog(string employeeID, string formID, string manul, string manulType, string tempVendorID)
        {
            if (LSetting.Log_Enabled)
            {
                return Write_BLL.writeLog(employeeID, formID, manul, manulType, tempVendorID);
            }
            return false;
        }

        public static bool writeLog(string formID, string manul, string manulType, string tempVendorID)
        {
            if (LSetting.Log_Enabled)
            {
                return Write_BLL.writeLog(formID, manul, manulType, tempVendorID);
            }
            return false;
        }

        public static bool writeLog(string formID, string manul, string tempVendorID)
        {
            if (LSetting.Log_Enabled)
            {
                return Write_BLL.writeLog(formID, manul, tempVendorID);
            }
            return false;
        }
    }
}