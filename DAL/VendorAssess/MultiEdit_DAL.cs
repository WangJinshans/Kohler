using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class MultiEdit_DAL
    {
        public static DataTable getMultiEditTop(string formID)
        {
            string sql = "Select * From View_Wait_MultiFill Where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            return dt;
        }
    }
}
