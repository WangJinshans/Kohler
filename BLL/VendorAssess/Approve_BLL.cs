﻿using DAL;
using DAL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return true;
        }
    }
}