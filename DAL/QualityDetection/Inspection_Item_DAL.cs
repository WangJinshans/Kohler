using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using System.Data;
using System.Data.SqlClient;

namespace DAL.QualityDetection
{
    public class Inspection_Item_DAL
    {
        public static List<QT_Inspection_Item> getInspecctorItems(int type, string employee_ID)
        {
            List<QT_Inspection_Item> list = new List<QT_Inspection_Item>();
            QT_Inspection_Item item = null;
            string sql = sql = "select * from View_QT_Inspection_List where Go='YES' and (Employee_ID=@Employee_ID or Employee_ID is null)";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@Employee_ID",employee_ID)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new QT_Inspection_Item();
                    item.Batch_No = dr["Batch_No"].ToString();
                    item.SKU = dr["SKU"].ToString();
                    item.Product_Name = dr["Product_Name"].ToString();
                    item.Product_Describes = dr["Product_Describes"].ToString();
                    item.Detection_Count = dr["Detection_Count"].ToString();
                    item.Remark = dr["Remark"].ToString();
                    item.Vendor_Code = dr["Vendor_Code"].ToString();
                    item.Go = dr["Go"].ToString();
                    item.To = dr["To"].ToString();
                    item.Form_ID = dr["Form_ID"].ToString();
                    item.Status = dr["Status"].ToString();
                    item.Factory_Name = dr["Factory_Name"].ToString();
                    item.Add_Time = dr["Add_Time"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public static object getQualityClerkItems(int type, string employee_ID)
        {
            List<QT_Inspection_Item> list = new List<QT_Inspection_Item>();
            QT_Inspection_Item item = null;
            string sql = sql = "select * from View_QT_Inspection_List where Go='NO' and (Employee_ID=@Employee_ID or Employee_ID is null)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_ID)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new QT_Inspection_Item();
                    item.Batch_No = dr["Batch_No"].ToString();
                    item.SKU = dr["SKU"].ToString();
                    item.Product_Name = dr["Product_Name"].ToString();
                    item.Product_Describes = dr["Product_Describes"].ToString();
                    item.Detection_Count = dr["Detection_Count"].ToString();
                    item.Remark = dr["Remark"].ToString();
                    item.Vendor_Code = dr["Vendor_Code"].ToString();
                    item.Go = dr["Go"].ToString();
                    item.To = dr["To"].ToString();
                    item.Form_ID = dr["Form_ID"].ToString();
                    item.Status = dr["Status"].ToString();
                    item.Factory_Name = dr["Factory_Name"].ToString();
                    item.Add_Time = dr["Add_Time"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
