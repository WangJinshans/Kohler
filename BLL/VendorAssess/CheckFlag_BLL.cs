using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class CheckFlag_BLL
    {
        public static bool multiFillFinished(string formID,string tempVendorID,string formType,string factory_Name)
        {
            if (CheckFlag_DAL.checkFormStatus(tempVendorID,formType,factory_Name) == 0 && CheckFlag_DAL.checkMultiFillStatus(formID,tempVendorID) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
