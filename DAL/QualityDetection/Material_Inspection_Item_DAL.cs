using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.QualityDetection
{
    public class Material_Inspection_Item_DAL
    {
        public static int setOld(string SKU)
        {
            string sql = "update QT_Material_Inspection_Item set IS_First='No' where SKU=@SKU";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static string getSuitabilityClassLeval(string SKU)
        {
            string sql = "select Suitability_Inspection from QT_Component_List where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU)
            };
            string class_leval = "";
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    class_leval = Convert.ToString(dr["Suitability_Inspection"]);
                }
            }
            return class_leval;
        }

        public static bool IsOld(string sKU)
        {
            string sql = "select distinct SKU from QT_Material_Inspection_Item where SKU=@SKU AND IS_First='NO'";
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

        public static List<string> getSKUList()
        {
            string sql = "select distinct SKU from QT_Material_Inspection_Item";
            List<string> sku_list = new List<string>();
            DataTable table = DBHelp.GetDataSet(sql);
            string sku = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    sku = Convert.ToString(dr["SKU"]);
                    sku_list.Add(sku);
                }
            }
            return sku_list;
        }

        public static string getSurfaceClassLeval(string SKU)
        {
            string sql = "select Surface_Inspection from QT_Component_List where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU)
            };
            string class_leval = "";
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    class_leval = Convert.ToString(dr["Surface_Inspection"]);
                }
            }
            return class_leval;
        }


        public static string getAQL(string SKU)
        {
            string sql = "select AQL from QT_Component_List where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU)
            };
            string aql = "";
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    aql = Convert.ToString(dr["AQL"]);
                }
            }
            return aql;
        }

        public static string getKCI(string SKU)
        {
            string sql = "select MBR_Distinction from QT_Component_List where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU)
            };
            string kci = "";
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    kci = Convert.ToString(dr["MBR_Distinction"]);
                }
            }
            return kci;
        }
    }
}
