using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using System.Data.SqlClient;
using System.Data;

namespace DAL.QualityDetection
{
    public class LabInspectionList_DAL
    {
        public static List<ConsignmentInspection> getConsignmentInspectionList(int type,string factory_Name)
        {
            List<ConsignmentInspection> list = new List<ConsignmentInspection>();
            ConsignmentInspection inspection = null;
            string labName = "";
            if (type == 1)
            {
                labName = "亚克力";
            }
            else
            {
                labName = "铸铁";
            }
            string sql = "select * from QT_ConsignmentInspection where Lab_Name=@Lab_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Lab_Name",labName),
                new SqlParameter("@Factory_Name",factory_Name)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    inspection = new ConsignmentInspection();

                    inspection.Batch_No = dr["Batch_No"].ToString();
                    inspection.Consignment_KO = dr["Consignment_KO"].ToString();
                    inspection.SKU = dr["SKU"].ToString();
                    inspection.Product_Name = dr["Product_Name"].ToString();
                    inspection.Vendor_Name = dr["Vendor_Name"].ToString();
                    inspection.Amount = dr["Amount"].ToString();
                    inspection.Arrave_Time = dr["Arrave_Time"].ToString();
                    inspection.Lab_Name = dr["Lab_Name"].ToString();
                    inspection.Factory_Name = dr["Factory_Name"].ToString();
                    list.Add(inspection);
                }
            }

            return list;
        }

        public static int updateStatus(string batch_no)
        {
            string sql = "update QT_ConsignmentInspection set Status='已完成' where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_no)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int addConsignmentInspection(ConsignmentInspection inspection)
        {
            string sql = "insert into QT_ConsignmentInspection(Batch_No,Consignment_KO,SKU,Product_Name,Vendor_Name,Amount,Arrave_Time,Factory_Name)values(@Batch_No,@Consignment_KO,@SKU,@Product_Name,@Vendor_Name,@Amount,@Arrave_Time,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",inspection.Batch_No),
                new SqlParameter("@Consignment_KO",inspection.Consignment_KO),
                new SqlParameter("@SKU",inspection.SKU),
                new SqlParameter("@Product_Name",inspection.Product_Name),
                new SqlParameter("@Vendor_Name",inspection.Vendor_Name),
                new SqlParameter("@Amount",inspection.Amount),
                new SqlParameter("@Arrave_Time",inspection.Arrave_Time),
                new SqlParameter("@Lab_Name",inspection.Lab_Name),
                new SqlParameter("@Factory_Name",inspection.Factory_Name)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }
    }
}
