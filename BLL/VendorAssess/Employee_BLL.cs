using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Employee_BLL
    {
        public static As_Employee getEmolyeeById(string employee_ID)
        {
            return Employee_DAL.getEmolyeeById(employee_ID);
        }
        public static IList<As_Employee> selectEmployee(string sql)
        {
            return Employee_DAL.selectEmployee(sql);
        }

        public static List<string> viewGetEmployeeID(string department)
        {
            return Employee_DAL.viewGetEmployeeID(department);
        }

        public static List<string> viewGetEmployeeName(string department)
        {
            return Employee_DAL.viewGetEmployeeName(department);
        }

        public static string getEmployeeDepartment(string currentEmployeeID)
        {
            return Employee_DAL.getEmployeeDepartment(currentEmployeeID);
        }
    }
}
