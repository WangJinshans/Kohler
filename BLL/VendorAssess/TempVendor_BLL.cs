using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;
using DAL.VendorAssess;
using System.Web;
using System.Data.SqlClient;

namespace BLL
{
    public class TempVendor_BLL
    {
        public static string getTempVendorID(string TempVendorName)
        {
            return TempVendor_DAL.getTempVendorID(TempVendorName);
        }

        public static string getTempVendorName(string tempVendorID)
        {
            return TempVendor_DAL.getTempVendorName(tempVendorID);
        }

        public static bool checkUsed(string tempVendorID, string factoryName)
        {
            return TempVendor_DAL.getUsed(tempVendorID, factoryName);
        }

        /// <summary>
        /// 选择所有/单厂，通过filter控制
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string[]>> readVendorInfo(bool filter)
        {
            Dictionary<string, Dictionary<string, string[]>> info = new Dictionary<string, Dictionary<string, string[]>>();

            DataTable dt = ApprovalProgress_DAL.readVendor();

            string factoryName = Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());

            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (!info.ContainsKey(item["Factory_Name"].ToString()))
                    {
                        if (!item["Factory_Name"].ToString().Equals(factoryName))
                        {
                            if (!filter)
                            {
                                info.Add(item["Factory_Name"].ToString(), new Dictionary<string, string[]>());
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            info.Add(item["Factory_Name"].ToString(), new Dictionary<string, string[]>());
                        }
                    }
                    if (!info[item["Factory_Name"].ToString()].ContainsKey(item["Vendor_Type"].ToString()))
                    {
                        DataRow[] smlDr = dt.Select(String.Format("Factory_Name='{0}' and Vendor_Type='{1}'", item["Factory_Name"].ToString(), item["Vendor_Type"].ToString()));
                        string[] nm = new string[smlDr.Length * 2];
                        int t = 0;
                        for (int i = 0; i < smlDr.Length; i++)
                        {
                            nm[t] = smlDr[i]["Temp_Vendor_Name"].ToString();
                            nm[t + 1] = smlDr[i]["Temp_Vendor_ID"].ToString();
                            t += 2;
                        }
                        info[item["Factory_Name"].ToString()].Add(item["Vendor_Type"].ToString(), nm);
                    }
                }
            }
            return info;
        }

        /// <summary>
        /// 选择ko对应的供应商
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string[]>> readVendorInfo(string employeeID)
        {
            Dictionary<string, Dictionary<string, string[]>> info = new Dictionary<string, Dictionary<string, string[]>>();

            DataTable dt = SelectEmployeeVendor_DAL.readVendorInfo(employeeID);

            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (!info.ContainsKey(item["Factory_Name"].ToString()))
                    {
                        info.Add(item["Factory_Name"].ToString(), new Dictionary<string, string[]>());
                    }
                    if (!info[item["Factory_Name"].ToString()].ContainsKey(item["Vendor_Type"].ToString()))
                    {
                        DataRow[] smlDr = dt.Select(String.Format("Factory_Name='{0}' and Vendor_Type='{1}'", item["Factory_Name"].ToString(), item["Vendor_Type"].ToString()));
                        string[] nm = new string[smlDr.Length * 2];
                        int t = 0;
                        for (int i = 0; i < smlDr.Length; i++)
                        {
                            nm[t] = smlDr[i]["Temp_Vendor_Name"].ToString();
                            nm[t + 1] = smlDr[i]["Temp_Vendor_ID"].ToString();
                            t += 2;
                        }
                        info[item["Factory_Name"].ToString()].Add(item["Vendor_Type"].ToString(), nm);
                    }
                }
            }
            return info;
        }

        /// <summary>
        /// 选择过期供应商
        /// </summary>
        /// <param name="employeeID">Employee</param>
        /// <param name="overdue">是否只选择过期</param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string[]>> readVendorInfo(string employeeID, bool overdue)
        {
            Dictionary<string, Dictionary<string, string[]>> info = new Dictionary<string, Dictionary<string, string[]>>();

            DataTable dt = SelectEmployeeVendor_DAL.readVendorInfo(employeeID);
            DataTable overDt = FileOverDue_DAL.getTempVendorID_All(employeeID);

            List<string> list = (from DataRow dr in overDt.Rows select dr["Temp_Vendor_ID"].ToString()).ToList();

            string tempVendorID, tempVendorName;

            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (!info.ContainsKey(item["Factory_Name"].ToString()))
                    {
                        info.Add(item["Factory_Name"].ToString(), new Dictionary<string, string[]>());
                    }
                    if (!info[item["Factory_Name"].ToString()].ContainsKey(item["Vendor_Type"].ToString()))
                    {
                        DataRow[] smlDr = dt.Select(String.Format("Factory_Name='{0}' and Vendor_Type='{1}'", item["Factory_Name"].ToString(), item["Vendor_Type"].ToString()));
                        string[] nm = new string[smlDr.Length * 2];
                        int t = 0;
                        for (int i = 0; i < smlDr.Length; i++)
                        {
                            tempVendorID = smlDr[i]["Temp_Vendor_ID"].ToString();
                            tempVendorName = smlDr[i]["Temp_Vendor_Name"].ToString();
                            if (list.Contains(tempVendorID))
                            {
                                nm[t] = tempVendorName;
                                nm[t + 1] = tempVendorID;
                                t += 2;
                            }
                        }
                        info[item["Factory_Name"].ToString()].Add(item["Vendor_Type"].ToString(), (from str in nm where str!=null select str).ToArray<string>());
                    }
                }
            }
            return info;
        }

        internal static bool hasNormalCode(string tempVendorID)
        {
            string sql = "Select Normal_Vendor_ID From As_Temp_Vendor Where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            using (SqlDataReader reader = DBHelp.GetReader(sql, sp))
                if (reader.Read())
                {
                    return true;
                }
            return false;
        }
    }
}
