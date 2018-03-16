using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MODEL.VendorAssess;

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

        public static IList<As_MutipleForm> listVendorKeepFillForms(string sqlkeepfill)
        {
            List<As_MutipleForm> formsList = new List<As_MutipleForm>();
            As_MutipleForm mutilpeForm = null;
            DataTable table = DBHelp.GetDataSet(sqlkeepfill);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    mutilpeForm = new As_MutipleForm();
                    mutilpeForm.Form_ID = dr["Form_ID"].ToString().Trim();
                    mutilpeForm.Form_Type_ID = dr["Form_Type_ID"].ToString().Trim();
                    mutilpeForm.Temp_Vendor_ID = dr["Temp_Vendor_ID"].ToString().Trim();
                    mutilpeForm.Temp_Vendor_Name = dr["Temp_Vendor_Name"].ToString().Trim();
                    mutilpeForm.Form_Type_Name = dr["Form_Type_Name"].ToString().Trim();
                    mutilpeForm.Form_ID = dr["Form_ID"].ToString().Trim();
                    mutilpeForm.Factory_Name= dr["Factory_Name"].ToString().Trim();
                    mutilpeForm.Fill_Flag = Convert.ToInt32(dr["Fill_Flag"].ToString().Trim());
                    formsList.Add(mutilpeForm);
                }
            }
            return formsList;
        }

        public static DataTable readVendorInfo(string employeeID)
        {
            string sql = "SELECT * FROM View_Employee_Vendor WHERE Employee_ID=@Employee_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employeeID)
            };
            return DBHelp.GetDataSet(sql, sp);
        }

        public static DataTable readVendorInFactory(string factory_Name)
        {
            string sql = "SELECT * FROM View_VendorFactory WHERE Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Factory_Name",factory_Name)
            };
            return DBHelp.GetDataSet(sql, sp);
        }
    }
}
