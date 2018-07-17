using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.QualityDetection
{
    public class Inspection_Records_DAL
    {

        #region QT_Inspection_Records的CRUD
        public static bool hadRecords(string vendor_Code)
        {
            string sql = "select count(*) as number from QT_Inspection_Records where Vendor_Code=@Vendor_Code";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Vendor_Code",vendor_Code)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            int times = 0;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    times = Convert.ToInt32(dr["number"]);
                }
            }

            //历史进货次数
            if (times > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 生词表格的时候就添加纪录
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <param name="factory_Name"></param>
        /// <param name="batch_No"></param>
        /// <param name="onePointFive"></param>
        /// <param name="twoPointFive"></param>
        public static void addInspectResult(string vendor_Code,string factory_Name, string batch_No,string onePointFive, string twoPointFive)
        {
            string sql = "insert into QT_Inspection_Records(Vendor_Code,Factory_Name,Batch_No,One_Point_Five,Two_Point_Five,Add_Time)values(@Vendor_Code,@Factory_Name,@Batch_No,@One_Point_Five,@Two_Point_Five,@Add_Time)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Vendor_Code",onePointFive),
                new SqlParameter("@Factory_Name",twoPointFive),
                new SqlParameter("@Batch_No",batch_No),
                new SqlParameter("@One_Point_Five",onePointFive),
                new SqlParameter("@Two_Point_Five",twoPointFive),
                new SqlParameter("@Add_Time",DateTime.Now.ToString())
            };
            DBHelp.ExecuteCommand(sql, sp);
        }


        #endregion
    }
}
