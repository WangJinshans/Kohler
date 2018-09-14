using DAL;
using DAL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    /// <summary>
    /// 待检物料
    /// </summary>
    public class Inspection_Item_BLL
    {
        /// <summary>
        /// 获取指定type的所有item   需要区分厂
        /// 0 ------>所有的item
        /// 1 ------>已经处理过的item
        /// 2 ------>未处理的item
        /// 3 ------>时间段筛选
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<QT_Inspection_Item> getInspecctorItems(int type,string employee_ID)
        {
            return Inspection_Item_DAL.getInspecctorItems(type, employee_ID);
        }

        public static object getQualityClerkItems(int type, string employee_ID)
        {
            return Inspection_Item_DAL.getQualityClerkItems(type, employee_ID);
        }

        public static void insertItem(QT_Inspection_Item item)
        {
            string sql = "insert into QT_Inspection_List(Batch_No,SKU,Product_Name,Product_Describes,Vendor_Code,Detection_Count,Remark,Factory_Name,Add_Time,Import_KO)"
                + "values(@Batch_No,@SKU,@Product_Name,@Product_Describes,@Vendor_Code,@Detection_Count,@Remark,@Factory_Name,@Add_Time,@Import_KO)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",item.Batch_No),
                new SqlParameter("@SKU",item.SKU),
                new SqlParameter("@Product_Name",item.Product_Name),
                new SqlParameter("@Product_Describes",item.Product_Describes),
                new SqlParameter("@Vendor_Code",item.Vendor_Code),
                new SqlParameter("@Detection_Count",item.Detection_Count),
                new SqlParameter("@Remark",item.Remark),
                new SqlParameter("@Factory_Name",item.Factory_Name),
                new SqlParameter("@Add_Time",item.Add_Time),
                new SqlParameter("@Import_KO",item.Import_KO)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }


        /// <summary>
        /// 维护零件清单 查看是否已经存在该SKU了
        /// </summary>
        /// <param name="sKU"></param>
        /// <returns></returns>
        public static bool hasSKU(string sKU)
        {
            return Inspection_Item_DAL.hasSKU(sKU);
        }

        /// <summary>
        /// 添加到待检列表里面 数据不全暂时 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool addInspection(QT_Inspection_Item item)
        {
            return Inspection_Item_DAL.addInspection(item);
        }
    }
}
