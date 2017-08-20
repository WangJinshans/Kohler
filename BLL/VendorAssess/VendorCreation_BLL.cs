using System;
using DAL;
using MODEL;
using BLL.VendorAssess;
using System.Data;
using DAL.VendorAssess;

namespace BLL
{
    public class VendorCreation_BLL
    {
        public static int checkVendorCreation(string formID)
        {
            return VendorCreation_DAL.checkVendorCreation(formID);
        }
        public static int getVendorCreationFlag(string formID)//获取标志位
        {
            return VendorCreation_DAL.getVendorCreationFlag(formID);
        }
        public static int addVendorCreation(As_Vendor_Creation vendorCreation)//添加表
        {
            return VendorCreation_DAL.addVendorCreation(vendorCreation);
        }

        public static int updateVendorCreation(As_Vendor_Creation vendorCreation)
        {
            return VendorCreation_DAL.updateVendorCreation(vendorCreation);
        }
        public static As_Vendor_Creation getVendorCreation(string formID)
        {
            return VendorCreation_DAL.getVendorCreation(formID);
        }

        public static string getFormID(string tempVendorID, string form_Name,string factory)
        {
            return VendorCreation_DAL.getFormID(tempVendorID, form_Name,factory);
        }

        public static int SubmitOk(string formID)
        {
            return VendorCreation_DAL.SubmitOk(formID);
        }

        public static string getFilePath(string fileID)
        {
            DataTable table = new DataTable();
            string filePath = "";
            table = File_Transform_DAL.getFilePath(fileID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    filePath = dr["File_Path"].ToString().Trim();
                }
            }
            return filePath;
        }
    }
}
