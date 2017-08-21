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
    }
}
