using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class UpdateFlag_BLL
    {
        public static int updateFlag(string formTypeID, string tempVendorID)//更新供应商信息
        {
            return UpdateFlag_DAL.updateFlag(formTypeID, tempVendorID,Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static int updateNonStandardConstractFlag(string formID)//更新供应商信息
        {
            return UpdateFlag_DAL.updateNonStandardConstractFlag(formID, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }


        public static int updateFileFlag(string fileTypeID, string tempVendorid)
        {
            return UpdateFlag_DAL.updateFileFlag(fileTypeID, tempVendorid, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static int updateFlagAsHold(string fORM_TYPE_ID, string tempVendorID)
        {
            return UpdateFlag_DAL.updateFlagAsHold(fORM_TYPE_ID, tempVendorID, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }
        public static int updateFileOverDueFlagAsHold(string fileTypeName, string tempVendorID,string factory)
        {
            return UpdateFlag_DAL.updateFileOverDueFlagAsHold(fileTypeName, tempVendorID,factory);
        }
        public static int updateFlagAsFinish(string FORM_TYPE_ID,string tempVendorID)
        {
            return UpdateFlag_DAL.updateFlagAsFinish(FORM_TYPE_ID, tempVendorID, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static int updateEditFlowFlag(string formID, string tempVendorID)
        {
            return UpdateFlag_DAL.updateEditFlowFlag(formID, tempVendorID, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static int updateFlagWaitKCI(string formTypeID, string tempVendorID)
        {
            return UpdateFlag_DAL.updateFlagWaitKCI(formTypeID, tempVendorID, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static int updateFlagAsApproved(string formID, string formTypeID, string tempVendorID, string factoryName)
        {
            return UpdateFlag_DAL.updateFlagAsApproved(formID, formTypeID, tempVendorID, factoryName);
        }
        public static int updateReAccessFormStatus(string formID, string tempVendorID)
        {
            return UpdateFlag_DAL.updateReAccessFormStatus(formID, tempVendorID);
        }

        public static int setFormUnSubmit(string formID)
        {
            return UpdateFlag_DAL.setFormUnSubmit(formID);
        }

        public static int updateReAccessFileStatus(string fileID)
        {
            return UpdateFlag_DAL.updateReAccessFileStatus(fileID);
        }

        public static int updateFillFlag(string formID)
        {
            return UpdateFlag_DAL.updateFillFlag(formID);
        }
    }
}
