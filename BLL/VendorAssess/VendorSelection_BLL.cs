using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using DAL.VendorAssess;

namespace BLL.VendorAssess
{
    public class VendorSelection_BLL
    {
        public static As_Vendor_Selection checkFlag(string formID)
        {
            As_Vendor_Selection vendorSelection = new As_Vendor_Selection();
            int flag = VendorSelection_DAL.getVendorSelectionFlag(formID);
            return VendorSelection_DAL.getVendorSelection(formID);
        }

        public static string getFormID(string tempVendorID)
        {
            return VendorSelection_DAL.getFormID(tempVendorID);
        }

        public static int checkVendorSelection(string formID)
        {
            return VendorSelection_DAL.checkVendorSelection(formID);
        }

        public static int addVendorSelection(As_Vendor_Selection vendor_Selection)
        {
            return VendorSelection_DAL.addVendorSelection(vendor_Selection);
        }

        public static int updateVendorSelection(As_Vendor_Selection vendorSelection)
        {
            return VendorSelection_DAL.updateVendorSelection(vendorSelection);
        }
    }
}
