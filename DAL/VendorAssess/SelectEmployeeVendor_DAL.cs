using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SelectEmployeeVendor_DAL
    {

        //通过员工编号查询员工所负责供应商
        public static IList<As_Employee_Vendor> selectEmployeeVendor(string sql)
        {
            IList<As_Employee_Vendor> list = new List<As_Employee_Vendor>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Employee_Vendor Employee_Vendor = new As_Employee_Vendor();
                    Employee_Vendor.Temp_Vendor_ID= Convert.ToString(dr["Temp_Vendor_ID"]);
                    Employee_Vendor.Vendor_Type_ID = Convert.ToString(dr["Vendor_Type_ID"]);
                    Employee_Vendor.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    list.Add(Employee_Vendor);
                }

            }
                return list;
        }
    }
}
