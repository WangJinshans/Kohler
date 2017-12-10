using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public static string getEmployeeDepartment(string currentEmployeeID)
        {
            string sql = "select Department_Name from View_Employee_Department where Employee_ID=@Employee_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",currentEmployeeID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                List<string> idList = new List<string>();
                foreach (DataRow item in dt.Rows)
                {
                    return item["Department_Name"].ToString();
                }
            }
            return null;
        }

        public static string getEmployeePositionName(string employeeID)
        {
            string sql = "select Positon_Name from As_Employee where Employee_ID='" + employeeID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string positionName = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    positionName = dr["Positon_Name"].ToString().Trim();
                }
            }
            return positionName;
        }


        /// <summary>
        /// 获取员工的Ko号
        /// </summary>
        /// <param name="positionName"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static string getEmployeeeKoNumber(string positionName, string factory_Name)
        {
            string sql = "select Employee_ID from As_Employee where Factory_Name='" + factory_Name + "' and Positon_Name='" + positionName + "'";
            string employeeID = "";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    employeeID = dr["Employee_ID"].ToString();
                }
            }
            return employeeID;
        }

        public static List<string> getAuthority(string employee_ID)
        {
            string sql = "select * From As_Authority Where Authority_ID in (Select Authority_ID From As_Employee Where Employee_ID=@Employee_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_ID)
            };

            List<string> list = null;

            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                list = new List<string>();
                DataRow item = dt.Rows[0];
                list.Add(item["Au_New_Vendor"].ToString());
                list.Add(item["Au_Status"].ToString());
                list.Add(item["Au_Fill"].ToString());
                list.Add(item["Au_OverDue"].ToString());
                list.Add(item["Au_Assess"].ToString());
            }

            return list;
        }

        public static string getEmployeeFactory(string currentEmployeeID)
        {
            string sql = "select Factory_Name from View_Employee_Department where Employee_ID=@Employee_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",currentEmployeeID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                List<string> idList = new List<string>();
                foreach (DataRow item in dt.Rows)
                {
                    return item["Factory_Name"].ToString();
                }
            }
            return null;
        }

        public static List<string> viewGetEmployeeName(string department)
        {
            string sql = "select Employee_Name from View_Employee_Department where Department_Name=@Department_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Department_Name",department),
                new SqlParameter("@Factory_Name",HttpContext.Current.Session["Factory_Name"].ToString())
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                List<string> idList = new List<string>();
                foreach (DataRow item in dt.Rows)
                {
                    idList.Add(item["Employee_Name"].ToString());
                }
                return idList;
            }
            return null;
        }

        public static List<string> viewGetEmployeeID(string department)
        {
            string sql = "select Employee_ID from View_Employee_Department where Department_Name=@Department_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Department_Name",department),
                new SqlParameter("@Factory_Name",HttpContext.Current.Session["Factory_Name"].ToString())
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                List<string> idList = new List<string>();
                foreach (DataRow item in dt.Rows)
                {
                    idList.Add(item["Employee_ID"].ToString());
                }
                return idList;
            }
            return null;
        }

        public static As_Employee getEmolyeeById(string employee_ID)
        {
            As_Employee Employee = null;
            string sql = "SELECT * FROM View_Employee_Department WHERE Employee_ID=@employee_ID";
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
                    //Employee.Department_ID = Convert.ToString(dr["Department_ID"]);
                    Employee.Department_Name = Convert.ToString(dr["Department_Name"]);
                    Employee.Positon_Name = Convert.ToString(dr["Positon_Name"]);
                    Employee.Employee_Password = Convert.ToString(dr["Employee_Password"]);
                    Employee.Factory_Name = Convert.ToString(dr["Factory_Name"]);
                }
            }

            return Employee;
        }
    }
}
