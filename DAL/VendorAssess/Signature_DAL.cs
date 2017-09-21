using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class Signature_DAL
    {
        public static string getPositionNameUrl(string position,string factory)
        {
            string sql = "select URL from As_Employee_Signature where Position_Name='" + position + "' and Factory_Name='" + factory + "'";
            string url = null;
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    url= item["URL"].ToString().Trim();
                }
            }
            return url;
        }

        public static int Signature(string sql)
        {
            int result = 0;
            try
            {
                result = DBHelp.ExecuteCommand(sql);
            }
            catch (SqlException e)
            {
                result = 1;
            }
            return result;
        }

        public static string getFactory(string formID)
        {
            string factory = "";
            string sql = "select Factory_Name from As_Form where Form_ID='" + formID + "'";
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

        public static int SignatureDate(string sql)
        {
            int result;
            try
            {
                DBHelp.ExecuteCommand(sql);
                result = 1;
            }
            catch (Exception e)
            {
                result = 2;
            }
            return result;
        }

        public static DataTable getAccessPositions(string sql)
        {
            return DBHelp.GetDataSet(sql);
        }



        /// <summary>
        /// 1表示执行成功，2表示执行失败
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteSignature(string sql)
        {
            try
            {
                DBHelp.ExecuteCommand(sql);
                return 1;
            }
            catch (Exception e)
            {
                return 2;
            }
        }
    }
}
