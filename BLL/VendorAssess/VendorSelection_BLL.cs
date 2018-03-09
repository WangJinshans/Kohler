using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MODEL.VendorAssess;
using DAL.VendorAssess;
using Model;

namespace BLL.VendorAssess
{
    public class VendorSelection_BLL
    {
        public static As_Vendor_Selection checkFlag(string formID)
        {
            As_Vendor_Selection vendorSelection = new As_Vendor_Selection();
            int flag = VendorSelection_DAL.getVendorSelectionFlag(formID);
            return VendorSelection_DAL.getVendorSelection(formID);
        }

        public static string getFormID(string tempVendorID,string formTypeID,string factory)
        {
            return VendorSelection_DAL.getFormID(tempVendorID, formTypeID,factory);
        }

        public static int checkVendorSelection(string formID)
        {
            return VendorSelection_DAL.checkVendorSelection(formID);
        }

        public static int addVendorSelection(As_Vendor_Selection vendor_Selection)
        {
            return VendorSelection_DAL.addVendorSelection(vendor_Selection);
        }

        public static int updateVendorSelection(As_Vendor_Selection vendorSelection)
        {
            return VendorSelection_DAL.updateVendorSelection(vendorSelection);
        }

        public static bool checkDepartment(string currentEmployeeID, As_Edit_Flow edtFlow)
        {
            string department = Employee_BLL.getEmployeeDepartment(currentEmployeeID,  HttpContext.Current.Session["Position_Name"].ToString());
            if (department.Equals(edtFlow.Edit_One_Department))
            {
                return true;
            }
            return false;
        }

        public static bool checkRDFile(string formID,string fileType)
        {
            if (CheckFile_BLL.checkExistFile(formID,fileType))
            {
                return true;
            }
            return false;
        }

        public static int SubmitOk(string formID)
        {
            return VendorSelection_DAL.SubmitOk(formID);
        }

        public static string getVendorSelectionFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            return VendorSelection_DAL.getVendorSelectionFormID(tempVendorID, fORM_TYPE_ID, factory, n);
        }
    }
}
