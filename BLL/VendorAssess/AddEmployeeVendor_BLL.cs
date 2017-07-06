using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddEmployeeVendor_BLL
    {
        //添加临时供应商
        public static int addEmployeeVendor(As_Employee_Vendor employee_Vendor)
        {
            return AddEmployeeVendor_DAL.addEmployeeVendor(employee_Vendor);
        }
    }
}
