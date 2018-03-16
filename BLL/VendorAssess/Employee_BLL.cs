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
        public static As_Employee getEmolyeeById(string employee_ID,string factory)
        {
            //return Employee_DAL.getEmolyeeById(employee_ID).FirstOrDefault(u => u.Employee_ID==employee_ID.ToLower()&&u.Factory_Name==factory);
            return Employee_DAL.getEmolyeeById(employee_ID).FirstOrDefault(u => u.Factory_Name == factory);
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

        public static string getEmployeeDepartment(string currentEmployeeID,string positionName)
        {
            return Employee_DAL.getEmployeeDepartment(currentEmployeeID,positionName);
        }

        /// <summary>
        /// 弃用
        /// </summary>
        /// <param name="currentEmployeeID"></param>
        /// <returns></returns>
        public static string getEmployeeFactory(string currentEmployeeID)
        {
            return Employee_DAL.getEmployeeFactory(currentEmployeeID);
        }

        public static List<string> getAuthority(string auid)
        {
            return Employee_DAL.getAuthority(auid);
        }

        public static string findHead(string employeeID)
        {
            //TODO::动态查找目标，此处暂时取0位置，2018年1月11日10:11:33
            As_Employee ae = Employee_DAL.getEmolyeeById(employeeID)[0];
            string head = Department_BLL.findHead(ae.Department_ID);
            return head;
        }
        public static string getEmployeeeKoNumber(string positionName, string factory_Name)
        {
            return Employee_DAL.getEmployeeeKoNumber(positionName, factory_Name);
        }

        public static string getEmployeePositionName(string employeeID)
        {
            if (employeeID.Equals(HttpContext.Current.Session["Employee_ID"]))
            {
                return HttpContext.Current.Session["Position_Name"].ToString();
            }
            //TODO::否则需要更多条件才能确定名字
            return Employee_DAL.getEmployeePositionName(employeeID);
        }

        public static List<As_Employee> getEmolyeeListById(string employeeId)
        {
            return Employee_DAL.getEmolyeeById(employeeId);
        }
    }
}
