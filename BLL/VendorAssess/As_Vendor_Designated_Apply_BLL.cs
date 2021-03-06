﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using BLL.VendorAssess;
using System.Data;
using DAL.VendorAssess;

namespace BLL
{
    public class As_Vendor_Designated_Apply_BLL
    {
        public static int checkVendorDesignatedApply(string formID)
        {
            return As_Vendor_Designated_Apply_DAL.checkVendorDesignatedApply(formID);
        }

        public static int addForm(As_Vendor_Designated_Apply vendorDesignatedApply)
        {
            return As_Vendor_Designated_Apply_DAL.addForm(vendorDesignatedApply);
        }

        public static string getFormID(string tempVendorID, string form_Type_ID, string factory)
        {
            return As_Vendor_Designated_Apply_DAL.getFormID(tempVendorID, form_Type_ID, factory);
        }

        public static As_Vendor_Designated_Apply checkFlag(string formID)
        {
            return As_Vendor_Designated_Apply_DAL.getForm(formID);
        }

        public static int updateForm(As_Vendor_Designated_Apply vendor_Designated)
        {
            return As_Vendor_Designated_Apply_DAL.updateForm(vendor_Designated);
        }

        public static int SubmitOk(string formID)
        {
            return As_Vendor_Designated_Apply_DAL.SubmitOk(formID);
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

        public static string getVendorDesignatedFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            return As_Vendor_Designated_Apply_DAL.getVendorDesignatedFormID(tempVendorID, fORM_TYPE_ID, factory, n);
        }
    }
}
