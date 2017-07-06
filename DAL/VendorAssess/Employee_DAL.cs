using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employee_DAL
    {
        public static IList<As_Employee> selectEmployee(string sql)
        {
            IList<As_Employee> list = new List<As_Employee>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Employee Employee = new As_Employee();
                    Employee.Department_ID= Convert.ToString(dr["Department_ID"]);
                    Employee.Employee_Name = Convert.ToString(dr["Employee_Name"]);
                    Employee.Positon_Name = Convert.ToString(dr["Positon_Name"]);
                    Employee.Employee_Email = Convert.ToString(dr["Employee_Email"]);
                    list.Add(Employee);
                }

            }
            return list;
        }
        public static As_Employee getEmolyeeById(string employee_ID)
        {
            As_Employee Employee = null;
            string sql = "SELECT * FROM As_Employee WHERE Employee_ID=@employee_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@employee_ID",employee_ID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Employee = new As_Employee();
                foreach (DataRow dr in dt.Rows)
                {
                    Employee.Employee_ID = Convert.ToString(dr["Employee_ID"]);
                    Employee.Employee_Name = Convert.ToString(dr["Employee_Name"]);
                    Employee.Employee_Email = Convert.ToString(dr["Employee_Email"]);
                    Employee.Department_ID = Convert.ToString(dr["Department_ID"]);
                    Employee.Positon_Name = Convert.ToString(dr["Positon_Name"]);
                    Employee.Employee_Password = Convert.ToString(dr["Employee_Password"]);
                }
            }

            return Employee;
        }
    }
}
