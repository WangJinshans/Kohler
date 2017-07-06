using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class FillVendorInfo_BLL
    {
        //查询所需填写表格类型名称
        public static IList<As_VendorType_FormType> listVendorTypeFormType(string sql)
        {
            return VendorType_DAL.listVendorTypeFormType(sql);
        }

        //查询所需文件类型名称
        public static IList<As_VendorType_FileType> listVendorTypeFileType(string sql)
        {
            return VendorType_DAL.listVendorTypeFileType(sql);
        }

        //查询供应商类型编号
        public static string selectVendorTypeId(string promise,string purchaseMoney, string advanceCharge, string vendorAssign, string vendorType)
        {
            return VendorType_DAL.selectVendorTypeId(promise, purchaseMoney, advanceCharge, vendorAssign, vendorType);
        }
        //添加临时供应商
        public static int addTempVendor(As_Temp_Vendor Temp_Vendor)
        {
            return TempVendor_DAL.addTempVendor(Temp_Vendor);
        }
        //添加供应商_表格
        public static int addVendorFormType(As_Vendor_FormType Vendor_FormType)
        {
            return VendorForm_DAL.addVendorFormType(Vendor_FormType);
        }

        //添加供应商文件
        public static  int  addVendorFileType(As_Vendor_FileType Vendor_FileType)
        {
            return VendorFile_DAL.addVendorFileType(Vendor_FileType);
        }
    }
}
