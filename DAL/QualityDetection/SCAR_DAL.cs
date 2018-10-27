using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.QualityDetection
{
    public class SCAR_DAL
    {
 
        public static string getSCARFormID(QT_SCAR SCAR)
        {
            string formID = "";
            string sql = "select Form_ID from QT_SCAR where Factory = @Factory and Batch_No = @Batch_No and Vendor_Code = @Vendor_Code  ";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Factory",SCAR.Factory),
                new SqlParameter("Batch_No", SCAR.Batch_No),
                new SqlParameter("Vendor_Code",SCAR.Vendor_Code)
               
            };
            DataTable tb = DBHelp.GetDataSet(sql, sp);
            if(tb.Rows.Count > 0 )
            {
                foreach(DataRow dr in tb.Rows)
                {
                    formID = dr["Form_ID"].ToString();
                }
            }
            return formID;
        }

        public static int isSCARQuilifited(string vendor_Code, string factory)
        {
            List<string> type = TempVendor_DAL.getVendorTypeByCode(vendor_Code, factory);
            if (type.Contains("直接物料常规"))
            {
                //直接物料连续二批出现不合格 1
                if (constantly(vendor_Code, 1, factory))
                {
                    return 1;
                }
            }
            else if (type.Contains("非生产性常规"))
            {
                //非生产性物料连续三批出现不合格 2
                if (constantly(vendor_Code, 2, factory))
                {
                    return 2;
                }
            }

            return 0;//不满足
        }

        /// <summary>
        /// 查询连续几次 需要减去1 因为 本次 自带一次
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <param name="times"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static bool constantly(string vendor_Code,int times,string factory_Name)
        {
            string sql = "select top @Times Result from View_QT_InspectionWithResult where Vendor_Code=@Vendor_Code and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Times",times),
                new SqlParameter("@Vendor_Code",vendor_Code),
                new SqlParameter("@Factory_Name",factory_Name)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (Convert.ToInt32(dr["Result"]) != 3)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static bool haveSCAR(string batch_No, string vendorCode)
        {
            string sql = "select Form_ID from QT_SCAR where Batch_No=@Batch_No and Vendor_Code=@Vednor_Code";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No),
                new SqlParameter("@Vendor_Code",vendorCode)
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

        public static string getFormIDbyBatch_No(string Batch_No)
        {
            string formID="";
            string sql = "select Form_ID from QT_SCAR where Batch_No=@Batch_No";
            SqlParameter [] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",Batch_No)
            };
            DataTable tb = DBHelp.GetDataSet(sql, sp);
            if (tb.Rows.Count > 0)
            {
                foreach(DataRow i in tb.Rows)
                {
                    formID = Convert.ToString(i["Form_ID"]);
                }
            }
            return formID;
        }

        public static bool checkSCAR(string form_ID)
        {
            string sql = "select * from QT_SCAR where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int addSCAR(QT_SCAR qtSCAR)
        {
            string sql = "insert into QT_SCAR(Batch_No,Vendor_Code,Factory) values(@Batch_No,@Vendor_Code,@Factory) select TOP 1 SCOPE_IDENTITY() AS returnName from QT_SCAR";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",qtSCAR.Batch_No),
                new SqlParameter("@Vendor_Code",qtSCAR.Vendor_Code),
                new SqlParameter("@Factory",qtSCAR.Factory)
            };
            return DBHelp.GetScalarID(sql, sp);             //获得formID
        }

        public static void updateSCAR(QT_SCAR qtSCAR)
        {
            //测试
            //string sqlcs = "update QT_SCAR SET Subject=@Subject,Flag=@Flag,Person_Pro=@Person_Pro,Machine_Pro=@Machine_Pro,Material_Pro=@Material_Pro," +
            //    "Law_Pro=@Law_Pro,Environment_Pro=@Environment_Pro,Measure_Pro=@Measure_Pro,Deverlop_Team_Member=@Deverlop_Team_Member,IQC_Team_Member=@IQC_Team_Member,Business_Team_Member=@Business_Team_Member,Produce_Team_Member=@Produce_Team_Member,Project_Team_Member=@Project_Team_Member,Purchasing_Team_Member=@Purchasing_Team_Member,QA_Team_Member=@QA_Team_Member where Form_ID=@Form_ID";
            //SqlParameter[] spcs = new SqlParameter[]
            //{
            //    new SqlParameter("@Subject",qtSCAR.Subject),
            //    new SqlParameter("@Flag",qtSCAR.Flag),
            //    new SqlParameter("@Form_ID",qtSCAR.Form_ID),
            //    new SqlParameter("@Person_Pro",qtSCAR.Person_Pro),
            //    new SqlParameter("@Machine_Pro",qtSCAR.Machine_Pro),
            //    new SqlParameter("@Law_Pro",qtSCAR.Law_Pro),
            //    new SqlParameter("@Material_Pro",qtSCAR.Material_Pro),
            //    new SqlParameter("@Deverlop_Team_Member",qtSCAR.Deverlop_Team_Member),
            //    new SqlParameter("@IQC_Team_Member",qtSCAR.IQC_Team_Member),
            //    new SqlParameter("@Business_Team_Member",qtSCAR.Business_Team_Member),
            //    new SqlParameter("@Produce_Team_Member",qtSCAR.Produce_Team_Member),
            //    new SqlParameter("@Project_Team_Member",qtSCAR.Project_Team_Member),
            //    new SqlParameter("@Purchasing_Team_Member",qtSCAR.Purchasing_Team_Member),
            //    new SqlParameter("@QA_Team_Member",qtSCAR.QA_Team_Member),
            //    new SqlParameter("@Environment_Pro",qtSCAR.Environment_Pro),
            //    new SqlParameter("@Measure_Pro",qtSCAR.Measure_Pro)
            //};

            //DBHelp.ExecuteCommand(sqlcs, spcs);
            string sql = "update QT_SCAR set " +
                "Approved_by2=@Approved_by2,I_C_A_Approved_by=@I_C_A_Approved_by,Approved_by4=@Approved_by4,P_C_A_Approved_by=@P_C_A_Approved_by,P_R_Approved_by=@P_R_Approved_by,V_E_Approved_by=@V_E_Approved_by," +

                "P_C_A_Approved_Date=@P_C_A_Approved_Date,I_C_A_Approved_Date=@I_C_A_Approved_Date,P_R_Approved_Date=@P_R_Approved_Date,V_E_Approved_Date=@V_E_Approved_Date," +

                "Batch_No=@Batch_No,Business_Team_Member=@Business_Team_Member,Produce_Team_Member=@Produce_Team_Member,Project_Team_Member=@Project_Team_Member,Purchasing_Team_Member=@Purchasing_Team_Member,QA_Team_Member=@QA_Team_Member," +

                "Completed_Date2=@Completed_Date2,Completed_Date4=@Completed_Date4,Customer=@Customer,Customer_satisfaction_degree=@Customer_satisfaction_degree," +

                "Date_Raised=@Date_Raised,Define_and_Verify_Root_Causes=@Define_and_Verify_Root_Causes," +

                "Deverlop_Team_Member=@Deverlop_Team_Member,Due_Date=@Due_Date," +

                "IQC_Team_Member=@IQC_Team_Member," +

                "Memo=@Memo,Occurred_Qty=@Occurred_Qty,Occurred_Site=@Occurred_Site,Occurred_Time=@Occurred_Time," +

                "Part_Name=@Part_Name,Part_Number=@Part_Number," +

                "Prepared_by2=@Prepared_by2,Prepared_by4=@Prepared_by4,Problem_Description=@Problem_Description," +

                "Qtv_Ins=@Qtv_Ins,Qtv_Rei=@Qtv_Rei,Flag=@Flag,Factory=@Factory," +

                "Raised_by=@Raised_by,Rea_For_CA=@Rea_For_CA,Subject=@Subject,Supplier=@Supplier,Vendor_Code=@Vendor_Code," +

                "Person_Pro=@Person_Pro,Machine_Pro=@Machine_Pro,Material_Pro=@Material_Pro,Law_Pro=@Law_Pro,Environment_Pro=@Environment_Pro,Measure_Pro=@Measure_Pro " +

                "where Form_ID=@Form_ID";

            //措施等
            string sql1 = "insert into QT_SCAR_Immediate_Containment_Actions(Immediate_Containment_Actions_No,Immediate_Containment_Actions_Content,Form_ID," +
                "Leader,Date) Values(@Immediate_Containment_Actions_No,@Immediate_Containment_Actions_Content,@Form_ID,@Leader,@Date) ";

            string sql2 = "insert into QT_SCAR_Permanent_Corrective_Actions(Permanent_Corrective_Actions_No,Permanent_Corrective_Actions_Content,Form_ID," +
                "Leader,Date) Values(@Permanent_Corrective_Actions_No,@Permanent_Corrective_Actions_Content,@Form_ID,@Leader,@Date) ";

            string sql3 = "insert into QT_SCAR_Prevent_Recurrence(Prevent_Recurrence_No,Prevent_Recurrence_Content,Form_ID," +
               "Leader,Date) Values(@Prevent_Recurrence_No,@Prevent_Recurrence_Content,@Form_ID,@Leader,@Date) ";

            string sql4 = "insert into QT_SCAR_Verification_of_Effectiveness(Verification_of_Effectiveness_No,Verification_of_Effectiveness_Content,Form_ID," +
                "Verifier,Date) Values(@Verification_of_Effectiveness_No,@Verification_of_Effectiveness_Content,@Form_ID,@Verifier,@Date) ";
            //SCAR表的基本内容
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Approved_by2",qtSCAR.Approved_by2) ,
                new SqlParameter("@Approved_by4",qtSCAR.Approved_by4) ,
                new SqlParameter("@V_E_Approved_by",qtSCAR.V_E_Approved_by) ,
                new SqlParameter("@I_C_A_Approved_by",qtSCAR.I_C_A_Approved_by) ,
                new SqlParameter("@P_C_A_Approved_by",qtSCAR.P_C_A_Approved_by ) ,
                new SqlParameter("@P_R_Approved_by",qtSCAR.P_R_Approved_by) ,
                new SqlParameter("@I_C_A_Approved_Date",qtSCAR.I_C_A_Approved_Date) ,
                new SqlParameter("@P_C_A_Approved_Date",qtSCAR.P_C_A_Approved_Date) ,
                new SqlParameter("@V_E_Approved_Date",qtSCAR.V_E_Approved_Date) ,
                new SqlParameter("@P_R_Approved_Date",qtSCAR.P_R_Approved_Date) ,
                new SqlParameter("@Batch_No",qtSCAR.Batch_No) ,
                new SqlParameter("@Business_Team_Member",qtSCAR.Business_Team_Member) ,
                new SqlParameter("@Completed_Date2",qtSCAR.Completed_Date2) ,
                new SqlParameter("@Completed_Date4",qtSCAR.Completed_Date4) ,
                new SqlParameter("@Customer",qtSCAR.Customer) ,
                new SqlParameter("@Customer_satisfaction_degree",qtSCAR.Customer_satisfaction_degree) ,
                new SqlParameter("@Date_Raised",qtSCAR.Date_Raised) ,
                new SqlParameter("@Define_and_Verify_Root_Causes",qtSCAR.Define_and_Verify_Root_Causes) ,
                new SqlParameter("@Deverlop_Team_Member",qtSCAR.Deverlop_Team_Member) ,
                new SqlParameter("@Due_Date",qtSCAR.Due_Date) ,
                new SqlParameter("@Factory",qtSCAR.Factory) ,
                new SqlParameter("@Flag",qtSCAR.Flag) ,
                new SqlParameter("@Form_ID",qtSCAR.Form_ID) ,
                new SqlParameter("@ID",qtSCAR.ID) ,
                new SqlParameter("@IQC_Team_Member",qtSCAR.IQC_Team_Member) ,
                new SqlParameter("@Memo",qtSCAR.Memo) ,
                new SqlParameter("@Occurred_Qty",qtSCAR.Occurred_Qty) ,
                new SqlParameter("@Occurred_Site",qtSCAR.Occurred_Site) ,
                new SqlParameter("@Occurred_Time",qtSCAR.Occurred_Time) ,
                new SqlParameter("@Part_Name",qtSCAR.Part_Name) ,
                new SqlParameter("@Part_Number",qtSCAR.Part_Number) ,
                new SqlParameter("@Prepared_by2",qtSCAR.Prepared_by2) ,
                new SqlParameter("@Prepared_by4",qtSCAR.Prepared_by4) ,
                new SqlParameter("@Problem_Description",qtSCAR.Problem_Description) ,
                new SqlParameter("@Produce_Team_Member",qtSCAR.Produce_Team_Member) ,
                new SqlParameter("@Project_Team_Member",qtSCAR.Project_Team_Member) ,
                new SqlParameter("@Purchasing_Team_Member",qtSCAR.Purchasing_Team_Member) ,
                new SqlParameter("@QA_Team_Member",qtSCAR.QA_Team_Member) ,
                new SqlParameter("@Qtv_Ins",qtSCAR.Qtv_Ins) ,
                new SqlParameter("@Qtv_Rei",qtSCAR.Qtv_Rei) ,
                new SqlParameter("@Raised_by",qtSCAR.Raised_by) ,
                new SqlParameter("@Rea_For_CA",qtSCAR.Rea_For_CA) ,
                new SqlParameter("@Subject",qtSCAR.Subject) ,
                new SqlParameter("@Supplier",qtSCAR.Supplier) ,
                new SqlParameter("@Vendor_Code",qtSCAR.Vendor_Code) ,
                new SqlParameter("@Person_Pro",qtSCAR.Person_Pro),
                new SqlParameter("@Machine_Pro",qtSCAR.Machine_Pro),
                new SqlParameter("@Material_Pro",qtSCAR.Material_Pro),
                new SqlParameter("@Law_Pro",qtSCAR.Law_Pro),
                new SqlParameter("@Environment_Pro",qtSCAR.Environment_Pro),
                new SqlParameter("@Measure_Pro",qtSCAR.Measure_Pro)

        };
            if (qtSCAR.Immediate_Containment_Actions != null)//
            {
                for (int i = 0; i < qtSCAR.Immediate_Containment_Actions.Count; i++)
                {
                    SqlParameter[] sp1 = new SqlParameter[]
                    {
                        new SqlParameter("@Immediate_Containment_Actions_Content",qtSCAR.Immediate_Containment_Actions[i].Immediate_Containment_Actions_Content),
                        new SqlParameter("@Immediate_Containment_Actions_No",qtSCAR.Immediate_Containment_Actions[i].Immediate_Containment_Actions_No),
                        new SqlParameter("@Leader",qtSCAR.Immediate_Containment_Actions[i].Leader),
                        new SqlParameter("@Form_ID",qtSCAR.Immediate_Containment_Actions[i].Form_ID),
                        new SqlParameter("@Date",qtSCAR.Immediate_Containment_Actions[i].Date)
                    };
                    DBHelp.ExecuteCommand(sql1, sp1);
                }
            }

            if (qtSCAR.Permanent_Corrective_Actions != null)
            {
                for (int i = 0; i < qtSCAR.Permanent_Corrective_Actions.Count; i++)
                {
                    SqlParameter[] sp2 = new SqlParameter[]
                    {
                        new SqlParameter("@Permanent_Corrective_Actions_Content",qtSCAR.Permanent_Corrective_Actions[i].Permanent_Corrective_Actions_Content),
                        new SqlParameter("@Permanent_Corrective_Actions_No",qtSCAR.Permanent_Corrective_Actions[i].Permanent_Corrective_Actions_No),
                        new SqlParameter("@Leader",qtSCAR.Permanent_Corrective_Actions[i].Leader),
                        new SqlParameter("@Form_ID",qtSCAR.Permanent_Corrective_Actions[i].Form_ID),
                        new SqlParameter("@Date",qtSCAR.Permanent_Corrective_Actions[i].Date)
                    };
                    DBHelp.ExecuteCommand(sql2, sp2);
                }
            }

            if (qtSCAR.Prevent_Recurrence != null)
            {
                for (int i = 0; i < qtSCAR.Prevent_Recurrence.Count; i++)
                {
                    SqlParameter[] sp3 = new SqlParameter[]
                    {
                        new SqlParameter("@Prevent_Recurrence_Content",qtSCAR.Prevent_Recurrence[i].Prevent_Recurrence_Content),
                        new SqlParameter("@Prevent_Recurrence_No",qtSCAR.Prevent_Recurrence[i].Prevent_Recurrence_No),
                        new SqlParameter("@Leader",qtSCAR.Prevent_Recurrence[i].Leader),
                        new SqlParameter("@Form_ID",qtSCAR.Prevent_Recurrence[i].Form_ID),
                        new SqlParameter("@Date",qtSCAR.Prevent_Recurrence[i].Date)
                    };
                    DBHelp.ExecuteCommand(sql3, sp3);
                }
            }

            if (qtSCAR.Verification_of_Effectiveness != null)//
            {
                for (int i = 0; i < qtSCAR.Verification_of_Effectiveness.Count; i++)
                {
                    SqlParameter[] sp4 = new SqlParameter[]
                    {
                        new SqlParameter("@Verification_of_Effectiveness_Content",qtSCAR.Verification_of_Effectiveness[i].Verification_of_Effectiveness_Content),
                        new SqlParameter("@Verification_of_Effectiveness_No",qtSCAR.Verification_of_Effectiveness[i].Verification_of_Effectiveness_No),
                        new SqlParameter("@Verifier",qtSCAR.Verification_of_Effectiveness[i].Verifier),
                        new SqlParameter("@Form_ID",qtSCAR.Verification_of_Effectiveness[i].Form_ID),
                        new SqlParameter("@Date",qtSCAR.Verification_of_Effectiveness[i].Date)
                    };
                    DBHelp.ExecuteCommand(sql4, sp4);
                }
            }
            DBHelp.ExecuteCommand(sql, sp);
        }

        public static QT_SCAR getSCAR(string formID)
        {
            QT_SCAR qtSCAR = null;
            string sql = "select * from QT_SCAR where Form_ID=@From_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Form_ID", formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql,sp);
            if(dt.Rows.Count > 0)
            {
                qtSCAR = new QT_SCAR();
                foreach(DataRow item in dt.Rows)
                {
                    qtSCAR.Approved_by2 = item["Approved_by2"].ToString().Trim();
                    qtSCAR.Approved_by4 = item["Approved_by4"].ToString().Trim();
                    
                }
                return qtSCAR;
            }
            else
            {
                return null;
            }
           
        }


    }
}
