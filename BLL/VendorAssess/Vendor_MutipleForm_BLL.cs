using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using DAL.VendorAssess;

namespace BLL.VendorAssess
{
    public class Vendor_MutipleForm_BLL
    {
        /// <summary>
        /// 添加到As_Vendor_MutipleForm中
        /// </summary>
        /// <param name="forms"></param>
        public static void addVendorMutileForms(As_MutipleForm forms)
        {
            Vendor_MutipleForm_DAL.addVendorMutileForms(forms);
        }

        public static void deleteForm(string formID)
        {
            Vendor_MutipleForm_DAL.deleteForm(formID);
        }
    }
}
