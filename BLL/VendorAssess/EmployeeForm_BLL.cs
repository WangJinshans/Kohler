using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using DAL.VendorAssess;

namespace BLL.VendorAssess
{
    public class EmployeeForm_BLL
    {
        public static int addEmployeeForm(As_Employee_Form item)
        {
            return EmployeeForm_DAL.addEmployeeForm(item);
        }


        public static int changeFillFlag(string employeeID,string formID, int flag)
        {
            return EmployeeForm_DAL.changeFillFlag(employeeID,formID, flag);
        }
    }
}
