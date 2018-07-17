using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using System.Data;

namespace DAL.QualityDetection
{
    public class MBR_DAL
    {
        public static void startMBR(string form_ID, string KCI)
        {
            //插入到QT_MBR_Results中 
            string sql = "insert into QT_MBR_Results(Form_ID,MBR_Distinction)values(@Form_ID,@MBR_Distinction)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID),
                new SqlParameter("@MBR_Distinction",KCI)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }



        public static int updateMBRState(string form_ID, string state)
        {
            string sql = "update QT_MBR_Results set Status=@Status where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Status",state),
                new SqlParameter("@Form_ID",form_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static bool isMeetAgrement_NotKCI(string form_ID)
        {
            string sql = "select Form_ID from QT_MBR_Results where Form_ID=@Form_ID and Meet_Agrement='YES'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
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

        public static bool isMBRNeeded(string form_ID)
        {
            string sql = "select Form_ID from QT_MBR_Results where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
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

        public static bool isMBRFinished(string form_ID)
        {
            string sql = "select Form_ID from QT_MBR_Results where Form_ID=@Form_ID and Status='YES'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
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

        public static List<MBR_Item> getMBRList(string position_Field, string status)
        {
            List<MBR_Item> list = new List<MBR_Item>();
            MBR_Item item = null;
            string sql = "select * from View_QT_MRB_List where " + position_Field + " is null and Status=@Status";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Status",status)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new MBR_Item();
                    item.Purchase_Manager = Convert.ToString(dr["Purchase_Manager"]);
                    item.Logistics_Manager = Convert.ToString(dr["Logistics_Manager"]);
                    item.Product_Manager = Convert.ToString(dr["Product_Manager"]);
                    item.Market_Manager = Convert.ToString(dr["Market_Manager"]);
                    item.Project_Manager = Convert.ToString(dr["Project_Manager"]);
                    item.Quiltty_Manager = Convert.ToString(dr["Quiltty_Manager"]);
                    item.General_Manager = Convert.ToString(dr["General_Manager"]);
                    item.MBR_Distinction = Convert.ToString(dr["MBR_Distinction"]);
                    item.Chief_Manager = Convert.ToString(dr["Chief_Manager"]);
                    item.Result = Convert.ToString(dr["Result"]);
                    item.Form_ID = Convert.ToString(dr["Form_ID"]);
                    item.Meet_Agrement = Convert.ToString(dr["Meet_Agrement"]);
                    item.States = Convert.ToString(dr["Status"]);
                    item.Vender_Name= Convert.ToString(dr["Vender_Name"]);
                    item.Detection_Count = Convert.ToString(dr["Detection_Count"]);
                    item.Product_Name = Convert.ToString(dr["Product_Name"]);
                    item.Batch_No = Convert.ToString(dr["Batch_No"]);
                    item.SKU = Convert.ToString(dr["SKU"]);

                    list.Add(item);
                }
            }

            return list;
        }

        public static void makeChoice(string choice,string position_Field,string form_ID)
        {
            string sql = "update QT_MBR_Results set "+ position_Field + "=@Choice where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Choice",choice),
                new SqlParameter("@Form_ID",form_ID)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static int setMBRResult(string form_ID, string result)
        {
            string sql = "update QT_MBR_Results set Result=@Result where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Result",result),
                new SqlParameter("@Form_ID",form_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }
    }
}
