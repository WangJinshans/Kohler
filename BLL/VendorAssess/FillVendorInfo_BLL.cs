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
            Temp_Vendor.Factory_Name = HttpContext.Current.Session["Factory_Name"].ToString();
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
        /// 查找出该供应商的合同审批表的formTypeID
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static string getVendorContractFormTypeID(string temp_Vendor_ID, string factory_Name)
        {
            return VendorFile_DAL.getVendorContractFormTypeID(temp_Vendor_ID, factory_Name);
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

        internal static void deleteVendorType(string oldTempVendorID,string factory_Name)
        {
            TempVendor_DAL.deleteVendorType(oldTempVendorID, factory_Name);
        }

        /// <summary>
        /// 删除As_Vendor_Form_Type中的一条记录
        /// </summary>
        /// <param name="formID"></param>
        public static void deleteVendorFormType(string formID)
        {
            string sql = "delete from As_Vendor_FormType where Form_ID='" + formID + "'";
            VendorForm_DAL.deleteVendorFormType(sql);
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

        public static bool isAccessSuccessful(string form)
        {
            return VendorForm_DAL.isAccessSuccessful(form);
        }

        /// <summary>
        /// 查询供应商信息表是否审批完成
        /// </summary>
        /// <param name="sql4"></param>
        /// <returns></returns>
        public static bool isVendorCreationAssessed(string sql4)
        {
            return VendorForm_DAL.isVendorCreationAssessed(sql4);
        }
        /// <summary>
        /// 合同是否已经提交
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool isVendorContractSubmited(string sql)
        {
            return VendorForm_DAL.isVendorContractSubmited(sql);
        }
    }
}
