using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using System.Data.SqlClient;

namespace DAL.QualityDetection
{
    public class GoodsReturned_DAL
    {
        public static int addGoodReturned(QT_Goods_Returned good)
        {
            string sql = "insert into QT_Goods_Returned(Form_ID,Batch_No,Vendor_Code,Total,Reject,Reason,Scar_ID,Factory_Name)values(@Form_ID,@Batch_No,@Vendor_Code,@Total,@Reject,@Reason,@Scar_ID,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",good.Form_ID),
                new SqlParameter("@Batch_No",good.Batch_No),
                new SqlParameter("@Vendor_Code",good.Vendor_Code),
                new SqlParameter("@Total",good.Total),
                new SqlParameter("@Reject",good.Reject),
                new SqlParameter("@Reason",good.Reason),
                new SqlParameter("@Scar_ID",good.Scar_ID),
                new SqlParameter("@Factory_Name",good.Factory_Name)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int deleteGoodReturned(string batch_No)
        {
            string sql = "delete from QT_Goods_Returned where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }
    }
}
