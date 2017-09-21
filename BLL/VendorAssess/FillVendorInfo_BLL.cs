using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Web;

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
        public static string selectVendorTypeId(bool promise, bool advanceCharge, bool vendorAssign, string vendorType)
        {
            return VendorType_DAL.selectVendorTypeId(promise, advanceCharge, vendorAssign, vendorType);
        }
        //添加临时供应商
        public static int addTempVendor(As_Temp_Vendor Temp_Vendor)
        {
            Temp_Vendor.SH = Temp_Vendor.ZS = Temp_Vendor.ZH = DBNull.Value.ToString();
            switch (Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_Id"].ToString()))
            {
                case "上海科勒":
                    Temp_Vendor.SH = "上海科勒";
                    break;
                case "中山科勒":
                    Temp_Vendor.ZS = "中山科勒";
                    break;
                case "珠海科勒":
                    Temp_Vendor.ZH = "珠海科勒";
                    break;
                default:
                    break;
            }
            return TempVendor_DAL.addTempVendor(Temp_Vendor);
        }
        //添加供应商_表格
        public static int addVendorFormType(As_Vendor_FormType Vendor_FormType)
        {
            return VendorForm_DAL.addVendorFormType(Vendor_FormType);
        }
        public static string getVendorFormID(string tempVendorID,string factory,string formTypeID)
        {
            return VendorForm_DAL.getVendorFormID(tempVendorID, factory,formTypeID);
        }
        //添加供应商文件
        public static  int  addVendorFileType(As_Vendor_FileType Vendor_FileType)
        {
            return VendorFile_DAL.addVendorFileType(Vendor_FileType);
        }

        /// <summary>
        /// 动态绑定供应商的表格和文件
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="checked1"></param>
        /// <param name="checked2"></param>
        /// <param name="checked3"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int addNewVendorFormAndFile(string tempVendorID, bool promise, bool assign, bool charge, string money,string factory)
        {
            return TempVendor_DAL.addBindVendorFormAndFile(tempVendorID, promise, assign, charge, money,factory);
        }

        /// <summary>
        /// 添加其他类型
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="promise"></param>
        /// <param name="assign"></param>
        /// <param name="charge"></param>
        /// <param name="money"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static int addMultiTypeVendor(string tempVendorID, bool promise, bool assign, bool charge, string money, string factory)
        {
            return TempVendor_DAL.addMultiTypeVendor(tempVendorID, promise, assign, charge, money, factory);
        }

        internal static string getFactoryByFormID(string formid)
        {
            return VendorForm_DAL.getFactoryByFormID(formid);
        }

        internal static string getFormTypeIDByFormID(string formid)
        {
            return VendorForm_DAL.getFormTypeIDByFormID(formid);
        }
    }
}
