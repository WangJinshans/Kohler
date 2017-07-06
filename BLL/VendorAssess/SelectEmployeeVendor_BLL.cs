using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SelectEmployeeVendor_BLL
    {
        public static IList<As_Employee_Vendor> selectEmployeeVendor(string sql)
        {
            return SelectEmployeeVendor_DAL.selectEmployeeVendor(sql);
        }
        public static IList<As_Vendor_FormType> listVendorFormType(string sql)
        {
            return VendorForm_DAL.listVendorFormType(sql);
        }
        public static IList<As_Vendor_FileType> listVendorFileType(string sql)
        {
            return File_DAL.listVendorFileType(sql);
        }
    }
}
