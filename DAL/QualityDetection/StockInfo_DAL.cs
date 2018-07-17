using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using System.Data.SqlClient;

namespace DAL.QualityDetection
{
    public class StockInfo_DAL
    {
        public static int addStockInfo(StockInfo info)
        {
            string sql = "insert into QT_Stock_Info(Batch_No,Remark,Source_From,Status,Add_Time,RC,RJ)values(@Batch_No,@Remark,@Source_From,@Status,@Add_Time,@RC,@RJ)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",info.Batch_No),
                new SqlParameter("@Remark",info.Remark),
                new SqlParameter("@Source_From",info.Source_From),
                new SqlParameter("@Status",info.Status),
                new SqlParameter("@Add_Time",info.Add_Time),
                new SqlParameter("@RC",info.RC),
                new SqlParameter("@RJ",info.RJ)
            };

            return DBHelp.ExecuteCommand(sql, sp);
        }
    }
}
