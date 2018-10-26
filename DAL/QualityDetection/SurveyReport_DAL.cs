using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.QualityDetection
{
    public class SurveyReport_DAL
    {

        public static void setInspectResult(string onePointFive, string twoPointFive, string batch_No)
        {
            string sql = "update QT_Inspection_Records set One_Point_Five=@One_Point_Five,Two_Point_Five=@Two_Point_Five where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@One_Point_Five",onePointFive),
                new SqlParameter("@Two_Point_Five",twoPointFive),
                new SqlParameter("@Batch_No",batch_No)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static DataTable getInspectionAndDatas(string form_ID)
        {
            string sql = "select * from QT_Survey_Item where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };

            return DBHelp.GetDataSet(sql, sp);
        }


        /// <summary>
        /// 获取该报告的所有内容
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static QT_Survey getSurveyReport(string form_ID)
        {
            string sql = "select * from QT_Survey where Form_ID=@Form_ID";
            QT_Survey survey = null;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };

            DataTable table = DBHelp.GetDataSet(sql, sp);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    survey = new QT_Survey();
                    survey.Sureface_Amount = Convert.ToString(dr["Sureface_Amount"]);
                    survey.Sureface_Bad = Convert.ToString(dr["Sureface_Bad"]);
                    survey.Sureface_Details = Convert.ToString(dr["Sureface_Details"]);
                    survey.Suitability_Amount = Convert.ToString(dr["Suitability_Amount"]);
                    survey.Suitability_Bad = Convert.ToString(dr["Suitability_Bad"]);
                    survey.Suitability_Details = Convert.ToString(dr["Suitability_Details"]);
                    survey.Remark = Convert.ToString(dr["Remark"]);
                    survey.Result = Convert.ToString(dr["Result"]);
                    survey.RC = Convert.ToString(dr["RC"]);
                    survey.RJ = Convert.ToString(dr["RJ"]);
                    survey.Un_Inspection_Type = Convert.ToString(dr["Un_Inspection_Type"]);
                    survey.PPAP_Result = Convert.ToString(dr["PPAP_Result"]);
                    survey.Broken_Detection_Result = Convert.ToString(dr["Broken_Detection_Result"]);
                    survey.SKU = Convert.ToString(dr["SKU"]);
                    survey.Batch_No = Convert.ToString(dr["Batch_No"]);
                    survey.Product_Name = Convert.ToString(dr["Product_Name"]);
                    survey.Vendor_Code = Convert.ToString(dr["Vendor_Code"]);
                    survey.Purchase_No = Convert.ToString(dr["Purchase_No"]);
                    survey.Arrave_Time = Convert.ToString(dr["Arrave_Time"]);
                    survey.Amount = Convert.ToString(dr["Amount"]);
                    survey.Region_Market = Convert.ToString(dr["Region_Market"]);
                    survey.Form_ID = Convert.ToString(dr["Form_ID"]);
                }
            }
            return survey;
        }

        public static DataTable showInspectionResults(string form_ID)
        {
            string sql = "select * from View_QT_InspectionResults where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };

            return DBHelp.GetDataSet(sql, sp);
        }


        #region 检验标准
        /// <summary>
        /// 判断连续两批是否 不可接受
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <returns></returns>
        public static bool StrictAvaliable(string vendor_Code)
        {
            string sql = "select TOP 2 * from QT_Inspection_Records where Vendor_Code=@Vendor_Code order by ID desc";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Vendor_Code",vendor_Code)
            };

            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (Convert.ToString(dr["Two_Point_Five"]).Equals("No"))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// 连续10批 AQL1.5 能接受 则放宽
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <returns></returns>
        public static bool LooseAvaliable(string vendor_Code)
        {
            string sql = "select TOP 10 * from QT_Inspection_Records where Vendor_Code=@Vendor_Code order by ID desc";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Vendor_Code",vendor_Code)
            };

            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (Convert.ToString(dr["One_Point_Five"]).Equals("No"))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static string getReportBatchNo(string form_ID)
        {
            string sql = "select Batch_No from QT_Inspection_List where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };

            DataTable table = DBHelp.GetDataSet(sql, sp);
            string batch_NO = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    batch_NO = Convert.ToString(dr["Batch_No"]);
                }
            }
            return batch_NO;
        }

        public static bool isKCINeeded(string form_ID)
        {
            string sql = "select Form_ID from View_QT_Inspection_List where Form_ID=@Form_ID and MBR_Distinction='YES'";
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

        public static int checkServeyReport(string form_ID)
        {
            string sql = "select * from QT_Survey where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int addServeyReport(string batch_No)
        {
            string sql = "insert into QT_Survey(Batch_No)values(@Batch_No)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int upDateFormID(string batch_No, string newFormID)
        {
            string sql = "update QT_Inspection_List set Form_ID=@Form_ID where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",newFormID),
                new SqlParameter("@Batch_No",batch_No)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }



        public static void addInspectionValue(string form_ID, string item, string standard, string result, string judgement)
        {
            string sql = "insert into QT_Survey_Item(Form_ID,Item,Standard,Result,Judgement)values(@Form_ID,@Item,@Standard,@Result,@Judgement)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID),
                new SqlParameter("@Item",item),
                new SqlParameter("@Standard",standard),
                new SqlParameter("@Result",result),
                new SqlParameter("@Judgement",judgement)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static void deleteAllInspectionValue(string form_ID)
        {

            string del = "delete from QT_Survey_Item where Form_ID=@Form_ID";
            SqlParameter[] delsp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DBHelp.ExecuteCommand(del, delsp);
        }


        public static void updateSurvey(QT_Survey survey)
        {
            string sql = "update QT_Survey set Sureface_Amount=@Sureface_Amount,Sureface_Bad=@Sureface_Bad,@Sureface_Details=Sureface_Details,Suitability_Amount=@Suitability_Amount,Suitability_Bad=@Suitability_Bad,Suitability_Details=@Suitability_Details,Remark=@Remark,Result=@Result,RC=@RC,RJ=@RJ,Un_Inspection_Type=@Un_Inspection_Type,PPAP_Result=@PPAP_Result,Broken_Detection_Result=@Broken_Detection_Result,SKU=@SKU,Batch_No=@Batch_No,Product_Name=@Product_Name,Vendor_Code=@Vendor_Code,Purchase_No=@Purchase_No,Arrave_Time=@Arrave_Time,Amount=@Amount,Region_Market=@Region_Market where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Sureface_Amount",survey.Sureface_Amount),
                new SqlParameter("@Sureface_Bad",survey.Sureface_Bad),
                new SqlParameter("@Sureface_Details",survey.Sureface_Details),
                new SqlParameter("@Suitability_Amount",survey.Suitability_Amount),
                new SqlParameter("@Suitability_Bad",survey.Suitability_Bad),
                new SqlParameter("@Suitability_Details",survey.Suitability_Details),
                new SqlParameter("@Remark",survey.Remark),
                new SqlParameter("@Result",survey.Result),
                new SqlParameter("@RC",survey.RC),
                new SqlParameter("@RJ",survey.RJ),
                new SqlParameter("@Un_Inspection_Type",survey.Un_Inspection_Type),

                new SqlParameter("@PPAP_Result",survey.PPAP_Result),
                new SqlParameter("@Broken_Detection_Result",survey.Broken_Detection_Result),
                new SqlParameter("@SKU",survey.SKU),
                new SqlParameter("@Batch_No",survey.Batch_No),
                new SqlParameter("@Product_Name",survey.Product_Name),
                new SqlParameter("@Vendor_Code",survey.Vendor_Code),

                new SqlParameter("@Purchase_No",survey.Purchase_No),
                new SqlParameter("@Arrave_Time",survey.Arrave_Time),
                new SqlParameter("@Amount",survey.Amount),
                new SqlParameter("@Region_Market",survey.Region_Market),

                new SqlParameter("@Form_ID",survey.Form_ID),
            };
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static void updateSurveyStatus(string form_ID, string status)
        {
            string sql = "update QT_Survey set Status=@Status where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Status",status),
                new SqlParameter("@Form_ID",form_ID)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static void setAddPermission(string permission, string form_ID)
        {
            string sql = "update QT_Survey set Add_Permission=@Add_Permission where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Add_Permission",permission),
                new SqlParameter("@Form_ID",form_ID)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static string getAddPermission(string form_ID)
        {
            string sql = "select Add_Permission from QT_Survey where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            string permission = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    permission = Convert.ToString(dr["Add_Permission"]);
                }
            }
            return permission;
        }

        public static void updateAddPermission(string form_ID, string newFormID)
        {
            string permission = getAddPermission(form_ID);
            if (permission != "")
            {
                string sql = "update QT_Survey set Add_Permission=@Add_Permission where Form_ID=@Form_ID";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@Add_Permission",permission),
                    new SqlParameter("@Form_ID",newFormID)
                };
                DBHelp.ExecuteCommand(sql, sp);
            }
        }


        /// <summary>
        /// 如果在复检中不存在该Batch_No 则说明只有一个form_ID
        /// 若存在Batch_No 则直接获取 New_Form_ID
        /// </summary>
        /// <param name="batch_No"></param>
        /// <returns></returns>
        public static string getReportFormID(string batch_No)
        {

            string sql = "";
            string sqls = "select Form_ID from QT_Re_Inspection where Batch_No=@Batch_No";
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };
            using (SqlDataReader reader = DBHelp.GetReader(sqls, sps))
            {
                if (reader.Read())
                {
                    sql = "select * from QT_Re_Inspection where Batch_No=@Batch_No";
                }
                else
                {
                    sql = "select * from QT_Survey where Batch_No=@Batch_No";

                }
            }

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            string formID = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = Convert.ToString(dr["Form_ID"]);
                }
            }
            return formID;
        }

        public static bool isReInspection(string form_ID)
        {
            string sql = "select Old_Form_ID from QT_Re_Inspection where Form_ID=@Form_ID";

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

        public static string getDecision(string position_Name, string form_ID)
        {
            string sql = "select" + position_Name + " from QT_MBR_Results where Form_ID=@Form_ID and Meet_Agrement='YES'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            string result = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    result = Convert.ToString(dr["Result"]);
                }
            }
            return result;
        }


        public static void setFinished(string form_ID)
        {
            string sql = "update QT_Inspection_List set Status='完成' where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DBHelp.ExecuteCommand(sql, sp);
        }


        #endregion


        /// <summary>
        /// 判断是否是刚添加进来的SKU  是 true  
        /// </summary>
        /// <param name="SKU"></param>
        /// <returns></returns>
        public static bool isNewSKU(string SKU)
        {
            string sql = "select SKU from QT_Material_Inspection_Item where SKU=@SKU AND IS_First='YES'";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU)
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
        /// <summary>
        /// 添加项目  
        /// </summary>
        /// <returns></returns>
        public static int addNewInspectionItem(string SKU, string Item, string Standard, string IS_First)
        {
            string sql = "insert into QT_Material_Inspection_Item(SKU,Item,Standard,IS_First) values (@SKU,@Item,@Standard,@IS_First)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter ("@SKU",SKU),
                new SqlParameter ("@Item",Item),
                new SqlParameter ("@Standard",Standard),
                new SqlParameter ("@IS_First",IS_First)

            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static void updateInspectionItem(string SKU, string Item, string Standard, string IS_First)
        {
            string sql = "update QT_Material_Inspection_Item set Item=@Item,Standard=@Standard,IS_First=@IS_First where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU),
                new SqlParameter("@Item",Item),
                new SqlParameter("@Standard",Standard),
                new SqlParameter("@IS_First",IS_First)
            };
            DBHelp.ExecuteCommand(sql, sp);

        }

        public static void deleteInspectionItem(string SKU, string Item)
        {
            string sql = "delete from QT_Material_Inspection_Item where SKU=@SKU and Item=@Item";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU),
                new SqlParameter("@Item",Item)

            };
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static DataTable getInsectionItems(string SKU)
        {
            string sql = "select * from QT_Material_Inspection_Item where SKU=@SKU";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                return table;
            }
            return null;
        }

        public static bool haveInsectionItem(string SKU, string Item)
        {
            string sql = "select * from QT_Material_Inspection_Item where SKU=@SKU and Item=@Item";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU),
                new SqlParameter("@Item",Item)

            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static void alterInspectionItem(string SKU, string Item, string Standard)
        {
            string sql = "update QT_Material_Inspection_Item set Standard=@Standard where SKU=@SKU and Item=@Item";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@SKU",SKU),
                new SqlParameter("@Item",Item),
                new SqlParameter("@Standard",Standard)
            };
            DBHelp.ExecuteCommand(sql, sp);

        }
    }
}
