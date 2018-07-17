using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL.QualityDetection
{
    public class SelectLab_DAL
    {
        public static List<As_Employee> getAllReseracher(string factory_Name)
        {
            As_Employee employee = null;
            List<As_Employee> employeeList = new List<As_Employee>();
            string sql = "select * from As_Employee where Factory_Name=@Factory_Name and Positon_Name='实验室主管'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Factory_Name",factory_Name)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    employee = new As_Employee();
                    employee.Department_ID = dr["Department_ID"].ToString();
                    employee.Employee_Email = dr["Employee_Email"].ToString();
                    employee.Employee_ID = dr["Employee_ID"].ToString();
                    employee.Employee_Name = dr["Employee_Name"].ToString();
                    employee.Positon_Name = dr["Positon_Name"].ToString();
                    employee.Factory_Name = factory_Name;
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }
    }
}
