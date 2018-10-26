using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;

namespace DAL.QualityDetection
{
    public class InspectionPlan_DAL
    {
        public static string getSampleCode(string classLeval, string amount)
        {
            string sql = "select Sample_Code from QT_Amount_Leval where Class_Leval=@Class_Leval and Min_Count<=@Min_Count and Max_Count>=@Max_Count";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Class_Leval",classLeval),
                new SqlParameter("@Min_Count",amount),
                new SqlParameter("@Max_Count",amount)
            };
            string class_leval = "";
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    class_leval = Convert.ToString(dr["Sample_Code"]);
                }
            }
            return class_leval;
        }

        public static InspectionPlanResult getInspectionPlanResult(string sample_Code, string aql, string inspection_Leval)
        {
            InspectionPlanResult plan = new InspectionPlanResult();
            string sql = "select AC,RE,Sample_Amount from QT_Inspection_Standard where Sample_Code=@Sample_Code and AQL=@AQL and Inspection_Leval=@Inspection_Leval";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Sample_Code",sample_Code),
                new SqlParameter("@AQL",aql),
                new SqlParameter("@Inspection_Leval",inspection_Leval)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    plan.AC = Convert.ToString(dr["AC"]);
                    plan.Sample_Amount = Convert.ToString(dr["Sample_Amount"]);
                    plan.RE = Convert.ToString(dr["RE"]);
                }
            }
            return plan;
        }
    }
}
