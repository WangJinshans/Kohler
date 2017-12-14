using BLL.VendorAssess;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public static void createSignatureSelection(Dictionary<string, string[]> dc)
        {
            DataTable dt = Employee_DAL.getAllEmployee(HttpContext.Current.Session["Factory_Name"]);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (!dc.ContainsKey(item["Department_Name"].ToString()))
                    {
                        dc.Add(item["Department_Name"].ToString(), null);
                    }
                    {
                        DataRow[] smlDr = dt.Select(String.Format("Department_Name='{0}'", item["Department_Name"].ToString()));
                        string[] nm = new string[smlDr.Length * 2];
                        int t = 0;
                        for (int i = 0; i < smlDr.Length; i++)
                        {
                            nm[t] = smlDr[i]["Employee_Name"].ToString();
                            nm[t + 1] = smlDr[i]["Employee_ID"].ToString();
                            t += 2;
                        }
                        dc[item["Department_Name"].ToString()] = nm;
                    }
                }
            }
        }

        public static List<string> viewGetEmployeeName(string department)
        {
            return Employee_DAL.viewGetEmployeeName(department);
        }

        public static string getEmployeeDepartment(string currentEmployeeID)
        {
            return Employee_DAL.getEmployeeDepartment(currentEmployeeID);
        }

        public static string getEmployeeFactory(string currentEmployeeID)
        {
            return Employee_DAL.getEmployeeFactory(currentEmployeeID);
        }

        public static List<string> getAuthority(string employee_ID)
        {
            return Employee_DAL.getAuthority(employee_ID);
        }

        public static string findHead(string employeeID)
        {
            As_Employee ae = Employee_DAL.getEmolyeeById(employeeID);
            string head = Department_BLL.findHead(ae.Department_ID);
            return head;
        }
        public static string getEmployeeeKoNumber(string positionName, string factory_Name)
        {
            return Employee_DAL.getEmployeeeKoNumber(positionName, factory_Name);
        }

        internal static string getEmployeePositionName(string employeeID)
        {
            return Employee_DAL.getEmployeePositionName(employeeID);
        }
    }
}
