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
    }
}
