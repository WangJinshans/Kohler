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
using MODEL.VendorAssess;

namespace BLL
{
    public class TempVendor_BLL
    {
        public const int NOT_EXISTED = 10;
        public const int EXISTED = 11;
        public const int NO_TYPE = 12;

        public const int REUSE_FATAL_ERROR = -1;
        public const int REUSE_NOT_EXECUTE = 0;
        public const int REUSE_SUCCESS = 1;
        public const int REUSE_OTHER_ERROR = 2;

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

        internal static string getTempVendorIDFixed(string temp_Vendor_Name,string vendor_Type)
        {
            return TempVendor_DAL.getTempVendorIDFixed(temp_Vendor_Name, vendor_Type);
        }

        public static As_Vendor_Modify_Info getTempVendorByVendorCode(string temp_Vendor_ID)
        {
            return TempVendor_DAL.getTempVendorByVendorCode(temp_Vendor_ID);
        }

        /// <summary>
        /// 读取全部厂的信息
        /// </summary>
        /// <returns></returns>
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

            DataTable dt = TempVendor_DAL.readVendor(null);
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
        /// 由于一个供应商只有一个VendorCode 但是一个类型对应了一个Temp_Vendor_ID,vendor_Type_ID + VnedorCode 能找到对应的临时供应商 
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <param name="vendorType"></param>
        /// <returns></returns>
        public static string getTempVendorIDByCodeAndType(string vendor_Code,string vendorType)
        {
            string temp_Vendor_ID = "";
            string sql = "select As_Temp_Vendor.Temp_Vendor_ID from As_Temp_Vendor,As_Vendor_Type where As_Temp_Vendor.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendor.Temp_Vendor_Name='" + vendor_Code + "' and As_Vendor_Type.Vendor_Type='" + vendorType + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    temp_Vendor_ID = dr["Temp_Vendor_ID"].ToString().Trim();
                }
            }
            return temp_Vendor_ID;
        }

        public static As_Temp_Vendor getTempVendor(string tempVendorID)
        {
            return TempVendor_DAL.getTempVendor(tempVendorID);
        }

        public static string getNormalCode(string tempVendorID)
        {
            return TempVendor_DAL.getNormalCode(tempVendorID);
        }

        /// <summary>
        /// 选择所有/单厂，通过filter控制
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string[]>> readVendorInfo(bool filter)
        {
            Dictionary<string, Dictionary<string, string[]>> info = new Dictionary<string, Dictionary<string, string[]>>();
            DataTable dt = null;

            string factoryName = Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());

            if (filter)
            {
                dt = TempVendor_DAL.readVendor(new string[] {factoryName });
            }
            else
            {
                dt = TempVendor_DAL.readVendor(null);
            }


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


        public static string getTempVendorFactory(string tempVendorID)
        {
            string sql = "select Factory_Name from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "'";
            return TempVendor_DAL.getTempVendorFactory(sql);
        }

        /// <summary>
        /// 根据tempVendorID查出该供应商是哪一类 直接物料常规等等
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static string getTempVendorType(string tempVendorID)
        {
            string VendorType = "";
            string sql = "select Vendor_Type from View_Temp_Vendor where Temp_Vendor_ID='" + tempVendorID + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    VendorType = dr["Vendor_Type"].ToString().Trim();
                }
            }
            return VendorType;
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
            string sql = "Select Normal_Vendor_ID From As_Temp_Vendor Where Temp_Vendor_ID=@Temp_Vendor_ID and Normal_Vendor_ID is not null";
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


        /// <summary>
        /// 调用复用存储过程，目前仅返回bool类型（可根据UI需要返回更多详细错误信息）
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="sourceFactory"></param>
        /// <param name="factory"></param>
        /// <param name="employee_ID"></param>
        /// <returns></returns>
        public static bool vendorSharedUse(string tempVendorID, string sourceFactory, string factory, string employee_ID)
        {
            int result = TempVendor_DAL.vendorSharedUse(tempVendorID, sourceFactory, factory, employee_ID);

            if (result == REUSE_SUCCESS)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 供应商是否存在
        /// </summary>
        /// <param name="v"></param>
        /// <param name="vendorTypeID"></param>
        /// <returns></returns>
        public static int vendorExisted(string name, string vendorTypeName)
        {
            if (!TempVendor_DAL.vendorNameExist(name))
            {
                return NOT_EXISTED;
            }
            else if (TempVendor_DAL.vendorTypeExist(name, vendorTypeName))
            {
                return EXISTED;
            }
            else
            {
                return NO_TYPE;
            }
        }

        public static string getTempVendorIDByVendorCode(string tempVendorID)
        {
            string vendorCode = "";
            string sql = "select Temp_Vendor_ID from As_Temp_Vendor where Normal_Vendor_ID='" + tempVendorID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    vendorCode = dr["Temp_Vendor_ID"].ToString().Trim();
                }
            }
            return vendorCode;
        }
    }
}
