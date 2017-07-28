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
    }
}
