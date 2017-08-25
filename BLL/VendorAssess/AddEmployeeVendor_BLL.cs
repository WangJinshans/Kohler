using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public static bool hasEmployeeID(string tempVendorID ,string employee_ID)
        {
            DataTable dt = AddEmployeeVendor_DAL.getEmployeeID(tempVendorID);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Employee_ID"].ToString().Equals(employee_ID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
