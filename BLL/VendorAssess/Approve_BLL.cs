using DAL;
using DAL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MODEL.VendorAssess;

namespace BLL.VendorAssess
{
    public class Approve_BLL
    {
        public static bool updateReason(string formID,string position,string factory,string reason)
        {
            if (Approve_DAL.updateReason(formID,position,factory,reason)>0)
            {
                return true;
            }
            return false;
        }

        public static bool resetFormStatus(string formID,string formTypeID, string tempVendorID)
        {
            //删除签名
            Signature_BLL.deleteSignature(formID);
            //删除签名时间
            Signature_BLL.deleteSignatureDate(formID);
            FormType_DAL.setFormFlag(formTypeID,tempVendorID, 0);
            Approve_DAL.deleteApproveRecord(formID);
            AddForm_DAL.deleteForm(formID);
            AssessFlow_DAL.deleteAssessFlow(formID);
            KCIApproval_DAL.deleteKCIApproval(formID);
            if (EditFlow_DAL.getEditFlow(formTypeID) != null)
            {
                EmployeeForm_DAL.deleteEmployeeForm(formID);
                EditFlow_DAL.deleteFormEditFlow(formID);
            }

            //添加拒绝记录
            As_Form_Reject form = new As_Form_Reject();
            form.Form_ID = formID;
            form.Temp_Vendor_ID = tempVendorID;
            if (!FormReject_BLL.isExist(form))
            {
                FormReject_BLL.insertFormReject(form);
            }

            return true;
        }

        public static As_Approve getApproveTop(string formID)
        {
            return Approve_DAL.getApproveTop(formID);
        }

        public static bool userDepartMentAsLastOne(string formID, string positionName)
        {
            return Approve_DAL.userDepartMentAsLastOne(formID,positionName);
        }
    }
}
