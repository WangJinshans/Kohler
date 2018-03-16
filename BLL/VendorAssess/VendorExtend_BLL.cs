using System;
using DAL.VendorAssess;
using MODEL;
using BLL.VendorAssess;

namespace BLL
{
    public class VendorExtend_BLL
    {
        public static int addVendorExtend(As_Vendor_Extend VendorExtend) //初始化表格赋值表格编号和表格种类编号
        {
            return VendorExtend_DAL.addVendorExtend(VendorExtend);
        }

        public static int updateVendorExtend(As_Vendor_Extend VendorExtend)//flag未更新
        {
            return VendorExtend_DAL.updateVendorExtend(VendorExtend);
        }



        public static int checkVendorExtend(string FormId)//查询是否有表记录,1为存在 0为不存在
        {
            return VendorExtend_DAL.checkVendorExtend(FormId);
        }

        public static As_Vendor_Extend getVendorExtend(string FormId)//
        {
            return VendorExtend_DAL.getVendorExtend(FormId);
        }

        public static int getVendorExtendFlag(string FormId)//按照表格编号和供应商名称查询相应记录返回flag
        {

            return VendorExtend_DAL.getVendorExtendFlag(FormId);
        }

        public static string getFormID(string tempVendorID,string formTypeID,string factory)
        {
            return VendorExtend_DAL.getFormID(tempVendorID,formTypeID, factory);
        }

        public static int SubmitOk(string formID)
        {
            return VendorExtend_DAL.SubmitOk(formID);
        }

        public static string getVendorExtendFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            return VendorExtend_DAL.getVendorExtendFormID(tempVendorID, fORM_TYPE_ID, factory, n);
        }
    }
}


