using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace DAL.QualityDetection
{
    public class RepertoryInspection_DAL
    {
        /// <summary>
        /// 添加检验
        /// </summary>
        /// <param name="inspection"></param>
        /// <returns></returns>
        public static int addRepertoryInspection(QT_RepertoryInspection inspection)
        {
            string sql = "insert into QT_RepertoryInspection(Batch_No,Status,Type,Take_Out,Unit,Bad)values(@Batch_No,@Status,@Type,@Take_Out,@Unit,@Bad)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",inspection.Batch_No),
                new SqlParameter("@Status",inspection.Status),
                new SqlParameter("@Type",inspection.Type),
                new SqlParameter("@Take_Out",inspection.Take_Out),
                new SqlParameter("@Unit",inspection.Unit),
                new SqlParameter("@Bad",inspection.Bad)

            };

            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static DataTable getRepertoryInspection()
        {
            string sql = "select * QT_RepertoryInspection where Status='NO'";
            return DBHelp.GetDataSet(sql);
        }

        public static int checkRepertoryInspection(string batch_No)
        {
            string sql = "update QT_RepertoryInspection set Status='YES' where Status='NO' and Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static void copyInspection(string batch_No)
        {
            string sql = "insert into QT_Inspection_List(select Batch_No,SKU,Product_Name,Product_Describes,Vendor_Code,Detection_Count,Remark,Go,[To],Status,Factory_Name,Add_Time,Employee_ID,Import_KO,Re_Inspection,Inspetion_Type from QT_Inspection_List where Batch_No=@Batch_No) select TOP 1 SCOPE_IDENTITY() AS returnName from QT_Inspection_List";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };
            int ID = DBHelp.GetScalarID(sql, sp);

            string sqls = "update QT_Inspection_List set Inspetion_Type='退货检验',Status='未完成' where Batch_No=@Batch_No and ID=@ID";
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No),
                new SqlParameter("@ID",ID)
            };
            DBHelp.ExecuteCommand(sqls, sp);
        }

        public static void updateRepertoryInspection(string batch_No)
        {
            string sql = "update QT_RepertoryInspection set [Type]='仓库' where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };

            DBHelp.ExecuteCommand(sql, sp);
        }
    }
}
