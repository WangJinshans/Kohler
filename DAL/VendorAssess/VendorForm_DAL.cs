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
    public class VendorForm_DAL
    {
        public static int addVendorFormType(As_Vendor_FormType Vendor_FormType)
        {
            string sql = "INSERT INTO As_Vendor_FormType(Temp_Vendor_ID,Form_Type_ID,Temp_Vendor_Name,Form_Type_Name,Factory_Name,Form_ID)VALUES(@Temp_Vendor_ID,@Form_Type_ID,@Temp_Vendor_Name,@Form_Type_Name,@Factory_Name,@Form_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",Vendor_FormType.Temp_Vendor_ID),
                new SqlParameter("@Form_Type_ID",Vendor_FormType.Form_Type_ID),
                new SqlParameter("@Temp_Vendor_Name",Vendor_FormType.Temp_Vendor_Name),
                new SqlParameter("@Form_Type_Name",Vendor_FormType.Form_Type_Name),
                new SqlParameter("@Factory_Name",Vendor_FormType.Factory_Name),
                new SqlParameter("@Form_ID",Vendor_FormType.Form_ID),
            };
            return DBHelp.GetScalar(sql, sp);
        }
        //通过表格类型编号查询表格类型对象
        public static IList<As_Vendor_FormType> listVendorFormType(string sql)
        {
            IList<As_Vendor_FormType> list = new List<As_Vendor_FormType>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Vendor_FormType Vendor_FormType = new As_Vendor_FormType();
                    //Vendor_FormType.Id = Convert.ToInt32(dr["id"]);
                    Vendor_FormType.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    Vendor_FormType.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    Vendor_FormType.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    Vendor_FormType.Form_Type_Name = Convert.ToString(dr["Form_Type_Name"]);
                    try
                    {
                        Vendor_FormType.Prority = Convert.ToInt32(dr["Form_Type_Priority_Number"]);
                    }
                    catch (Exception)
                    {
                        Vendor_FormType.Prority = 0;
                    }
                    try
                    {
                        Vendor_FormType.Form_Type_Is_Optional = Convert.ToString(dr["Form_Type_Is_Optional"]);
                        if (Vendor_FormType.Form_Type_Is_Optional == "可选")
                        {
                            Vendor_FormType.Form_Type_Is_Optional = null;
                        }
                    }
                    catch (Exception)
                    {
                        Vendor_FormType.Form_Type_Is_Optional = null;
                    }

                    list.Add(Vendor_FormType);
                }
            }
            return list;
        }

        public static string getVendorFormID(string tempVendorID, string factory, string formTypeID)
        {
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "' and Form_Type_ID='" + formTypeID + "'" + "and Factory_Name='" + factory + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string result = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    result = dr["Form_ID"].ToString().Trim();
                }
            }
            return result;
        }

        public static void deleteVendorFormType(string sql)
        {
            DBHelp.ExecuteCommand(sql);
        }

        public static string getFactoryByFormID(string formid)
        {
            string sql = "select Factory_Name from As_Vendor_FormType where Form_ID='" + formid + "'";
            string factory = "";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    factory = dr["Factory_Name"].ToString().Trim();
                }
            }
            return factory;
        }

        public static bool isAccessSuccessful(string form)
        {
            string sql = "select Form_ID from As_Vendor_FormType where Form_ID='" + form + "' and flag=4";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        public static string getFormTypeIDByFormID(string formid)
        {
            string sql = "select Form_Type_ID from As_Vendor_FormType where Form_ID='" + formid + "'";
            string formTypeID = "";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formTypeID = dr["Form_Type_ID"].ToString().Trim();
                }
            }
            return formTypeID;
        }

        public static bool isVendorContractSubmited(string sql)
        {
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public static bool isVendorCreationAssessed(string sql4)
        {
            using (SqlDataReader reader = DBHelp.GetReader(sql4))
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public static string isOverDue(string temp_Vendor_ID,string form_Type_ID,string factory)
        {
            string sql = "select flag from As_Vendor_FormType where Temp_Vendor_ID='" + temp_Vendor_ID + "' and Form_Type_ID='" + form_Type_ID + "' and Factory_Name='" + factory + "'";
            DataTable table = new DataTable();
            int flag = 0;
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    flag = Convert.ToInt32(dr["flag"]);
                    if (flag == 5)
                    {
                        return "过期";
                    }
                    else
                    {
                        return "未过期";
                    }
                }
            }
            return "无记录";
        }
    }
}
