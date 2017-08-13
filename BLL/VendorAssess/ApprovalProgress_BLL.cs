using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAL.VendorAssess;
using DAL;
using Model;

namespace BLL.VendorAssess
{
    public class ApprovalProgress_BLL
    {
        public static Dictionary<string, Dictionary<string, string[]>> readVendorInfo()
        {
            Dictionary<string, Dictionary<string, string[]>> info = new Dictionary<string, Dictionary<string, string[]>>();
            //Dictionary<string, string[]> names = new Dictionary<string, string[]>();
            //string[] strTest = new string[] { "name1", "id1", "name2", "id2" };
            //string[] strTest1 = new string[] { "name2", "name2", "name3" };
            //string[] strTest2 = new string[] { "name3", "name2", "name3" };
            //string[] strTest3 = new string[] { "name4", "name2", "name3" };
            //string[] strTest4 = new string[] { "name5", "name2", "name3" };
            //string[] strTest5 = new string[] { "name6", "name2", "name3" };
            //names.Add("直接物料常规", strTest);
            //names.Add("直接物料危化品", strTest1);
            //names.Add("非生产性质量部有标准的物料", strTest2);
            //names.Add("非生产性危化品", strTest3);
            //names.Add("非生产性特种劳防品", strTest4);
            //names.Add("非生产性常规", strTest5);

            //info = new Dictionary<string, Dictionary<string, string[]>>();
            //info.Add("上海科勒", names);
            //info.Add("中山科勒", names);
            //info.Add("珠海科勒", names);

            DataTable dt = ApprovalProgress_DAL.readVendor();
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
                            nm[t + 1] = smlDr[i]["Temp_Vendor_Id"].ToString();
                            t += 2;
                        }
                        info[item["Factory_Name"].ToString()].Add(item["Vendor_Type"].ToString(), nm);
                    }
                }
            }
            return info;
        }

        public static DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone();  // 复制DataRow的表结构
            foreach (DataRow row in rows)
                tmp.Rows.Add(row);  // 将DataRow添加到DataTable中
            return tmp;
        }

        public static string readFormExceptionInfo(string formID)
        {
            string result = "";
            DataTable dt = Write_DAL.getHistory(As_Write.APPROVE_FAIL, formID, true);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    result += item["Manul"];
                    result += "<br/>";
                }
            }
            return result;
        }

        public static string readFormNormalInfo(string formID)
        {
            string result = "";
            DataTable dt = Write_DAL.getHistory(As_Write.APPROVE_SUCCESS, formID, true);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    result += item["Manul"];
                    result += "<br/>";
                }
            }
            return result;
        }
    }
}