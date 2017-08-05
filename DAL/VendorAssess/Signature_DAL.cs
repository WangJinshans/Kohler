using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class Signature_DAL
    {
        public static string getPositionNameUrl(string position)
        {
            string sql = "select URL from As_Employee_Signature where Position_Name='" + position + "'";
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
            return DBHelp.ExecuteCommand(sql);
        }
        public static int SignatureDate(string sql)
        {
            return DBHelp.ExecuteCommand(sql);
        }
    }
}
