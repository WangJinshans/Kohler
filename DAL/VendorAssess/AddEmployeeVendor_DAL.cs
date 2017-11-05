using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class AddEmployeeVendor_DAL
    {
        //添加临时供应商
        public static int addEmployeeVendor(As_Employee_Vendor employee_Vendor)
        {
            string sql = "INSERT INTO As_Employee_Vendor VALUES(@Employee_ID,@Temp_Vendor_ID,@Vendor_Type_ID,@Temp_Vendor_Name,@Type)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_Vendor.Employee_ID),
                new SqlParameter("@Temp_Vendor_ID",employee_Vendor.Temp_Vendor_ID),
                new SqlParameter("@Temp_Vendor_Name",employee_Vendor.Temp_Vendor_Name),
                new SqlParameter("@Vendor_Type_ID",employee_Vendor.Vendor_Type_ID),
                new SqlParameter("@Type",employee_Vendor.Type)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static DataTable getEmployeeID(string tempVendorID)
        {
            string sql = "Select Employee_ID from As_Employee_Vendor Where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            return DBHelp.GetDataSet(sql, sp);
        }

        public static As_Employee_Vendor get(string tempVendorID)
        {
            string sql = "Select * From As_Employee_Vendor Where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            As_Employee_Vendor ae = null;
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0) 
            {
                ae = new As_Employee_Vendor();
                foreach (DataRow dr in dt.Rows)
                {
                    ae.Employee_ID = dr["Employee_ID"].ToString();
                    ae.Temp_Vendor_ID = tempVendorID;
                    ae.Vendor_Type_ID = dr["Vendor_Type_ID"].ToString();
                    ae.Temp_Vendor_Name = dr["Temp_Vendor_Name"].ToString();
                    ae.Type = dr["Type"].ToString();
                }
            }
            return ae;
        }
    }
}
