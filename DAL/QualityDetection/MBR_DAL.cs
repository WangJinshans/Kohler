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

        public static List<QT_Goods_Returned> getGoodReturnedList(string factory_Name,string status)
        {
            string sql = "select * from QT_Goods_Returned where Factory_Name=@Factory_Name and Status=@Status";
            QT_Goods_Returned good = null;
            List<QT_Goods_Returned> list = new List<QT_Goods_Returned>();
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Factory_Name",factory_Name),
                new SqlParameter("@Status",status)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    good = new QT_Goods_Returned();
                    good.Status = Convert.ToString(dr["Status"]);
                    good.Scar_ID= Convert.ToString(dr["Scar_ID"]);
                    good.Vendor_Code = Convert.ToString(dr["Vendor_Code"]);
                    good.Total = Convert.ToString(dr["Total"]);
                    good.Reject = Convert.ToString(dr["Reject"]);
                    good.Reason = Convert.ToString(dr["Reason"]);
                    good.Form_ID = Convert.ToString(dr["Form_ID"]);
                    list.Add(good);
                }
            }
            return list;
        }

        public static MBRSingleChoice getEveryOneChoice(string form_ID)
        {
            MBRSingleChoice choice = new MBRSingleChoice();
            string sql = "select * from QT_MBR_Results where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    choice.Purchase_Manager = Convert.ToString(dr["Purchase_Manager"]);
                    choice.Logistics_Manager = Convert.ToString(dr["Logistics_Manager"]);
                    choice.Product_Manager = Convert.ToString(dr["Product_Manager"]);
                    choice.Market_Manager = Convert.ToString(dr["Market_Manager"]);
                    choice.Project_Manager = Convert.ToString(dr["Project_Manager"]);
                    choice.Quiltty_Manager = Convert.ToString(dr["Quiltty_Manager"]);
                    choice.General_Manager = Convert.ToString(dr["General_Manager"]);
                    choice.Chief_Manager = Convert.ToString(dr["Chief_Manager"]);

                    choice.Purchase_Reason = Convert.ToString(dr["Purchase_Reason"]);
                    choice.Logistics_Reason = Convert.ToString(dr["Logistics_Reason"]);
                    choice.Product_Reason = Convert.ToString(dr["Product_Reason"]);
                    choice.Market_Reason = Convert.ToString(dr["Market_Reason"]);
                    choice.Project_Reason = Convert.ToString(dr["Project_Reason"]);
                    choice.Quiltty_Reason = Convert.ToString(dr["Quiltty_Reason"]);
                    choice.General_Reason = Convert.ToString(dr["General_Reason"]);
                    choice.Chief_Reason = Convert.ToString(dr["Chief_Reason"]);
                }
            }
            return choice;
        }

        public static string getMBRResult(string form_ID)
        {
            string result = "";
            string sql = "select Result from QT_MBR_Results where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    result = Convert.ToString(dr["Result"]);
                }
            }

            if (result == "0")
            {
                result = "让步接收";
            }
            else if (result == "1")
            {
                result = "让步接收";
            }
            else if (result == "2")
            {
                result = "返工";
            }
            else
            {
                result = "挑选全检";
            }

            return result;
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

        public static void makeChoice(string choice, string reason, string position_Field,string position_Reason_Field, string form_ID)
        {
            string sql = "update QT_MBR_Results set "+ position_Field + "=@Choice,"+ position_Reason_Field + "=@position_Reason_Field where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Choice",choice),
                new SqlParameter("@position_Reason_Field",reason),
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
