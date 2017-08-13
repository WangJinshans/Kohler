using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class Approve_DAL
    {
        public static int updateReason(string formID, string position, string factory, string reason)
        {
            string sql = "update As_Approve set Assess_Reason=@Reason where Form_ID=@Form_ID and Position_Name=@Position_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Reason",reason),
                new SqlParameter("@Position_Name",position),
                new SqlParameter("@Factory_Name",factory),
                new SqlParameter("Form_ID",formID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static bool deleteApproveRecord(string formID)
        {
            string sql = "delete from As_Approve where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            if (DBHelp.ExecuteCommand(sql,sp)>0)
            {
                return true;
            }
            return false;
        }
    }
}
