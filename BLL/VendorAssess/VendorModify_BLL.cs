using DAL.VendorAssess;
using MODEL.VendorAssess;
using System.Data;
using System;

namespace BLL.VendorAssess
{
    public class VendorModify_BLL
    {
        /// <summary>
        /// 判断该表是否存在
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static int checkVendorModification(string formID)
        {
            return VendorModify_DAL.checkVendorModification(formID);
        }

        /// <summary>
        /// 该供应商该表的标志
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static int getVendorModificationFlag(string formID)//获取标志位
        {
            return VendorModify_DAL.getVendorModificationFlag(formID);
        }

        /// <summary>
        /// 添加一次修改信息
        /// </summary>
        /// <param name="vendorModify"></param>
        /// <returns></returns>
        public static int addVendorModification(As_Vendor_Modify vendorModify)//添加表
        {
            return VendorModify_DAL.addVendorModification(vendorModify);
        }

        /// <summary>
        /// 更新更改信息
        /// </summary>
        /// <param name="vendorModify"></param>
        /// <returns></returns>
        public static int updateVendorModification(As_Vendor_Modify vendorModify)
        {
            return VendorModify_DAL.updateVendorModification(vendorModify);
        }

        /// <summary>
        /// 获取更改信息
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static As_Vendor_Modify getVendorModification(string formID)
        {
            return VendorModify_DAL.getVendorModification(formID);
        }

        /// <summary>
        /// 获取指定修改表的Form_ID
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="formTypeID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static string getFormID(string tempVendorID, string formTypeID, string factory)
        {
            return VendorModify_DAL.getFormID(tempVendorID, formTypeID, factory);
        }




        /// <summary>
        /// 获取某个文件的路径
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public static string getFilePath(string fileID)
        {
            DataTable table = new DataTable();
            string filePath = "";
            table = VendorModify_DAL.getFilePath(fileID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    filePath = dr["File_Path"].ToString().Trim();
                }
            }
            return filePath;
        }

        internal static string getFormID(string tempVendorID,string factory_Name)
        {
            return VendorModify_DAL.getFormID(tempVendorID, factory_Name);
        }
    }
}
