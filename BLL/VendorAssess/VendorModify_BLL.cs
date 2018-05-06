using DAL.VendorAssess;
using MODEL.VendorAssess;
using System.Data;
using System;
using System.Web;

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

        public static string getVendorModifyFormID(string tempVendorID, string v, string factory, int n)
        {
            return VendorModify_DAL.getVendorModification(tempVendorID, v, factory, n);
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

        public static void VendorModifyOK(string tempVendorID)
        {
            //根据Form_ID取出该表中的所有信息，
            string info = VendorModify_DAL.getModifyInfo(tempVendorID);
            string[] array = info.Split(',');
            if (info != null && info != "")
            {
                string temp_Vendor_ID = array[0];
                string temp_Vendor_Name = array[1];
                string factory_Name = array[2];
                string newType = array[3];
                string oldType = array[4];
                bool promise = Convert.ToBoolean(array[5]);
                bool assign = Convert.ToBoolean(array[6]);
                bool charge = Convert.ToBoolean(array[7]);
                float money = (float)Convert.ToDouble(array[8]);
                VendorCheckResult_BLL.modify_CheckResult("vendor_Modify_exist", temp_Vendor_Name, factory_Name, newType, oldType, promise, assign, charge, money, HttpContext.Current.Session["Employee_ID"].ToString());
            }

        }

        public static string getFactoryName(string formID)
        {
            return VendorModify_DAL.getFactoryName(formID);
        }
    }
}
