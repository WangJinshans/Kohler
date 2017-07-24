using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using DAL.VendorAssess;
using System.Reflection;

namespace BLL.VendorAssess
{
    public class VendorSelectionSupplier_BLL
    {
        public static List<string> objToList(As_Vendor_Selection_Supplier supplier)
        {
            List<string> list = new List<string>();

            PropertyInfo[] properties = supplier.GetType().GetProperties();
            foreach (PropertyInfo item in properties)
            {
                list.Add(item.GetValue(supplier, null).ToString());
            }
            return list;
        }

        public static Dictionary<string, List<string>> checkSupplier(string formID)
        {
            string[] strArray = { "one", "two", "three", "four", "five" };

            List<As_Vendor_Selection_Supplier> list = VendorSelectionSupplier_DAL.checkSupplier(formID);
            Dictionary<string, List<string>> dc = new Dictionary<string, List<string>>();
            for (int i = 0; i < list.Count; i++)
            {
                dc.Add(strArray[i], objToList(list[i]));
            }
            return dc;
        }

        public static int addVendorSupplier(As_Vendor_Selection_Supplier supplier)
        {
            return VendorSelectionSupplier_DAL.addVendorSupplier(supplier);
        }

        public static int updateVendorSupplier(List<As_Vendor_Selection_Supplier> list)
        {
            return VendorSelectionSupplier_DAL.updateVendorSupplier(list);
        }
    }
}
