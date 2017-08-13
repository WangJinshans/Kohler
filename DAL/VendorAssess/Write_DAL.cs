using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Write_DAL
    {
        public static int addWrite(As_Write write)
        {
            string sql = "insert into As_Write(Employee_ID,Form_ID,Form_Fill_Time,Manul,Temp_Vendor_ID,Manul_Type)values(@Employee_ID,@Form_ID,@Form_Fill_Time,@Manul,@Temp_Vendor_ID,@Manul_Type)";
            sql += ";SELECT @@IDENTITY";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Employee_ID",write.Employee_ID),
                new SqlParameter("Form_ID",write.Form_ID),
                new SqlParameter("Form_Fill_Time",write.Form_Fill_Time),
                new SqlParameter("@Manul",write.Manul),
                new SqlParameter("@Temp_Vendor_ID",write.Temp_Vendor_ID),
                new SqlParameter("@Manul_Type",write.Manul_Type)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static DataTable getHistory(string manulType, string formID, bool asc)
        {
            string orderType = "asc";
            if (!asc)
            {
                orderType = "desc";
            }
            string sql = "SELECT * FROM As_Write WHERE Form_ID=@Form_ID and Manul_Type=@Manul_Type ORDER BY id "+orderType;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID),
                new SqlParameter("@Manul_Type",manulType)
            };
            DataTable dt = DBHelp.GetDataSet(sql,sp);
            return dt;
        }
    }
}
