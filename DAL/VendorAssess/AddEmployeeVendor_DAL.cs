using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddEmployeeVendor_DAL
    {
        //添加临时供应商
        public static int addEmployeeVendor(As_Employee_Vendor employee_Vendor)
        {
            string sql = "INSERT INTO As_Employee_Vendor VALUES(@Employee_ID,@Temp_Vendor_ID,@Vendor_Type_ID,@Temp_Vendor_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_Vendor.Employee_ID),
                new SqlParameter("@Temp_Vendor_ID",employee_Vendor.Temp_Vendor_ID),
                new SqlParameter("@Temp_Vendor_Name",employee_Vendor.Temp_Vendor_Name),
                new SqlParameter("@Vendor_Type_ID",employee_Vendor.Vendor_Type_ID),
            };
            return DBHelp.GetScalar(sql, sp);
        }
    }
}
