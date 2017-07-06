using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class Write_DAL
    {
        public static int addWrite(As_Write write)
        {
            string sql = "insert into As_Write(Employee_ID,Form_ID,Form_Fill_Time,Manul)values(@Employee_ID,@Form_ID,@Form_Fill_Time,@Manul)";
            sql += ";SELECT @@IDENTITY";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Employee_ID",write.Employee_ID),
                new SqlParameter("Form_ID",write.Form_ID),
                new SqlParameter("Form_Fill_Time",write.Form_Fill_Time),
                new SqlParameter("@Manul",write.Manul)
            };
            return DBHelp.GetScalar(sql, sp);
        }

    }
}
