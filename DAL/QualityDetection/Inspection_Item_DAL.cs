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
            string factory_Name = Employee_DAL.getEmployeeFactory(employee_ID);
            string sql = sql = "select * from View_QT_Inspection_List where Go='YES' and (Employee_ID=@Employee_ID or Employee_ID='' or Employee_ID is NULL) and Factory_Name=@Factory_Name and Status<>'完成'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_ID),
                new SqlParameter("@Factory_Name",factory_Name)
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
                    item.Inspection_Type = dr["Inspection_Type"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 从inspectionList中获取数据，不从视图中获取
        /// </summary>
        /// <param name="type"></param>
        /// <param name="employee_ID"></param>
        /// <returns></returns>
        public static List<QT_Inspection_Item> getInspectionList(int type, string employee_ID)
        {
            List<QT_Inspection_Item> list = new List<QT_Inspection_Item>();
            QT_Inspection_Item item = null;
            string factory_Name = Employee_DAL.getEmployeeFactory(employee_ID);
            string sql = sql = "select * from QT_Inspection_List where Go='YES' and (Employee_ID=@Employee_ID or Employee_ID='' or Employee_ID is NULL) and Factory_Name=@Factory_Name and Status<>'完成'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_ID),
                new SqlParameter("@Factory_Name",factory_Name)
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
                    item.Inspection_Type = dr["Inspection_Type"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public static object getQualityClerkItems(int type, string employee_ID)
        {
            List<QT_Inspection_Item> list = new List<QT_Inspection_Item>();
            QT_Inspection_Item item = null;
            string factory_Name = Employee_DAL.getEmployeeFactory(employee_ID);
            string sql = sql = "select * from View_QT_Inspection_List where Go='NO' and (Employee_ID=@Employee_ID or Employee_ID is null) and Factory_Name=@Factory_Name and Status<>'完成'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_ID),
                new SqlParameter("@Factory_Name",factory_Name)
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
                    item.Inspection_Type = dr["Inspection_Type"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public static bool addInspection(QT_Inspection_Item item)
        {
            string sql = "insert into QT_Inspection_List(Batch_No,SKU,Product_Describes,Detection_Count,Status,Factory_Name,Add_Time,Import_KO)values(@Batch_No,@SKU,@Product_Describes,@Detection_Count,@Status,@Factory_Name,@Add_Time,@Import_KO)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",item.Batch_No),
                new SqlParameter("@SKU",item.SKU),
                new SqlParameter("@Product_Describes",item.Product_Describes),
                new SqlParameter("@Detection_Count",item.Detection_Count),
                new SqlParameter("@Status",item.Status),
                new SqlParameter("@Factory_Name",item.Factory_Name),
                new SqlParameter("@Add_Time",item.Add_Time),
                new SqlParameter("@Import_KO",item.Import_KO)
            };
            if (DBHelp.ExecuteCommand(sql, sp) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool hasSKU(string sKU)
        {
            string sql = "select SKU from QT_Component_List where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",sKU)
            };
            using (SqlDataReader reader = DBHelp.GetReader(sql, sp))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
