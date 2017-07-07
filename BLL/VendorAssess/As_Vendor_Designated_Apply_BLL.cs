using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class As_Vendor_Designated_Apply_BLL
    {
        public static int SaveWholeForm(As_Vendor_Designated_Apply avda)
        {
            return As_Vendor_Designated_Apply_DAL.SaveWholeForm(avda);
        }

        public static As_Vendor_Designated_Apply GetWholeFormInfo(string vendorname)
        {
            return As_Vendor_Designated_Apply_DAL.GetWholeFormInfo(vendorname);
        }
        public static int UpdateWholeFormInfo(As_Vendor_Designated_Apply avda)
        {
            return As_Vendor_Designated_Apply_DAL.UpdateWholeFormInfo(avda);
        }

        public static int GetAsVendorDesignatedApplyFormID(As_Vendor_Designated_Apply avda)
        {
            return As_Vendor_Designated_Apply_DAL.GetAsVendorDesignatedApplyFormID(avda);
        }
        
    }
}
