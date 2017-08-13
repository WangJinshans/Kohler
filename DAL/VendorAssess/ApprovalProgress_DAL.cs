using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class ApprovalProgress_DAL
    {
        public static DataTable readVendor()
        {
            string sql = "select distinct * from View_Temp_Vendor";

            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count>0)
            {
                return dt;
            }
            return null;
        }
    }
}
