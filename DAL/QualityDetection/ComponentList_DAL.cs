using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DAL.QualityDetection;

namespace DAL.QualityDetection
{
    public class ComponentList_DAL
    {
        public static bool addComponent(QT_Component_List item)
        {
            string sql = "insert into QT_Inspection_List(SKU,Product_Name,Product_Describes,Detection_Requirement,PPAP,Broken_Detection,MBR_Distinction,Factory_Name,Vendor_Code,Class_Leval,AQL,Surface_Inspection,Suitability_Inspection) " +
                "values(@SKU,@Product_Name,@Product_Describes,@Detection_Requirement,@PPAP,@Broken_Detection,@MBR_Distinction,@Factory_Name,@Vendor_Code,@Class_Leval,@AQL,@Surface_Inspection,@Suitability_Inspection)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",item.SKU),
                new SqlParameter("@Product_Name",item.Product_Name),
                new SqlParameter("@Product_Describes",item.Product_Describes),
                new SqlParameter("@Detection_Requirement",item.Detection_Requirement),
                new SqlParameter("@PPAP",item.PPAP),
                new SqlParameter("@Broken_Detection",item.Broken_Detection),
                new SqlParameter("@MBR_Distinction",item.MBR_Distinction),
                new SqlParameter("@Factory_Name",item.Factory_Name),
                new SqlParameter("@Vendor_Code",item.Vendor_Code),
                new SqlParameter("@Class_Leval",item.Class_Leval),
                new SqlParameter("@AQL",item.AQL),
                new SqlParameter("@Surface_Inspection",item.Surface_Inspection),
                new SqlParameter("@Suitability_Inspection",item.Suitability_Inspection)
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

        //通過判断是否有SKU然后查询如果没有则提示
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

        public static void updateComponent(string SKU, QT_Component_List item)
        {
            string sql = "update QT_Component_List set " +
                "Product_Name=@Product_Name,Product_Describes=@Product_Describes,Detection_Requirement=@Detection_Requirement,PPAP=@PPAP,Broken_Detection=@Broken_Detection,MBR_Distinction=@MBR_Distinction,Factory_Name=@Factory_Name,Vendor_Code=@Vendor_Code," +
                "Class_Leval=@Class_Leval,AQL=@AQL,Surface_Inspection=@Surface_Inspection,Suitability_Inspection=@Suitability_Inspection where SKU=@SKU";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU),
                new SqlParameter("@Product_Name",item.Product_Name),
                new SqlParameter("@Product_Describes",item.Product_Describes),
                new SqlParameter("@Detection_Requirement",item.Detection_Requirement),
                new SqlParameter("@PPAP",item.PPAP),
                new SqlParameter("@Broken_Detection",item.Broken_Detection),
                new SqlParameter("@MBR_Distinction",item.MBR_Distinction),
                new SqlParameter("@Factory_Name",item.Factory_Name),
                new SqlParameter("@Vendor_Code",item.Vendor_Code),
                new SqlParameter("@Class_Leval",item.Class_Leval),
                new SqlParameter("@AQL",item.AQL),
                new SqlParameter("@Surface_Inspection",item.Surface_Inspection),
                new SqlParameter("@Suitability_Inspection",item.Suitability_Inspection)
            };
            DBHelp.ExecuteCommand(sql, sp);

        }

        //获取对应SKU的Component
        public static DataTable selectComponentBySKU(string SKU)
        {
            string sql = "select SKU,Product_Name,Product_Describes,Detection_Requirement,PPAP,Broken_Detection,MBR_Distinction,Factory_Name,Vendor_Code,Class_Leval,AQL,Surface_Inspection,Suitability_Inspection " +

                            "from QT_Component_List " +

                            "where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU),
            };

            return DBHelp.GetDataSet(sql, sp);
        }


        
    }
}
