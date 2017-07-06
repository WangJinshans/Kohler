using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AssessFlow_DAL
    {
        public static As_Assess_Flow getFirstAssessFlow(string formtypeid)
        {
            As_Assess_Flow Assess_Flow = null;
            string sql = "SELECT * FROM As_Assess_Flow Where Form_Type_ID=@formtypeid";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@formtypeid",formtypeid)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Assess_Flow = new As_Assess_Flow();
                foreach (DataRow dr in dt.Rows)
                {
                    Assess_Flow.Form_Type_ID= Convert.ToString(dr["Form_Type_ID"]);
                    Assess_Flow.User_Department_Assess = Convert.ToString(dr["User_Department_Assess"]);
                    Assess_Flow.Assess_Two_ID = Convert.ToString(dr["Assess_Two_ID"]);
                    Assess_Flow.Assess_Three_ID = Convert.ToString(dr["Assess_Three_ID"]);
                    Assess_Flow.Assess_Four_ID = Convert.ToString(dr["Assess_Four_ID"]);
                    Assess_Flow.Assess_Five_ID= Convert.ToString(dr["Assess_Five_ID"]);
                    Assess_Flow.Assess_Six_ID = Convert.ToString(dr["Assess_Six_ID"]);
                }
            }

            return Assess_Flow;
        }
        public static int addFormAssessFlow(As_Form_AssessFlow Form_AssessFlow)
        {

            string sql = "insert into As_Form_AssessFlow values(@Form_ID,@First,@Second,@Third,@Four,@Five,@kci)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",Form_AssessFlow.Form_ID),
                new SqlParameter("First",Form_AssessFlow.First),
                new SqlParameter("Second",Form_AssessFlow.Second),
                new SqlParameter("Third",Form_AssessFlow.Third),
                new SqlParameter("Four",Form_AssessFlow.Four),
                new SqlParameter("Five",Form_AssessFlow.Five),
                new SqlParameter("kci",Form_AssessFlow.Kci)
            };
            return DBHelp.GetScalar(sql, sp);
        }
        public static int addApprove(As_Approve approve)
        {

            string sql = "insert into As_approve values(@Form_ID,@Position_Name,@Assess_Flag,@Assess_Time,@Assess_Reason)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",approve.Form_ID),
                new SqlParameter("Position_Name",approve.Position_Name),
                new SqlParameter("Assess_Flag",approve.Assess_Flag),
                new SqlParameter("Assess_Time",approve.Assess_Time),
                new SqlParameter("Assess_Reason",approve.Assess_Reason)
            };
            return DBHelp.GetScalar(sql, sp);
        }
        public static IList<As_Approve> listApprove(string sql)
        {
            IList<As_Approve> list = new List<As_Approve>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Approve Approve = new As_Approve();
                    Approve.Assess_Flag = Convert.ToString(dr["Assess_Flag"]);
                    Approve.Form_ID = Convert.ToString(dr["Form_ID"]);
                    Approve.Position_Name = Convert.ToString(dr["Position_Name"]);
                    Approve.Assess_Reason = Convert.ToString(dr["Assess_Reason"]);
                    Approve.Assess_Time = Convert.ToDateTime(dr["Assess_Time"]);
                    list.Add(Approve);
                }
            }
            return list;
        }

        public static int updateApprove(string formid,string positionname)
        {
            string sql = "UPDATE As_Approve SET Assess_flag='已通过' WHERE Form_ID='" + formid+"'and Position_Name='"+ positionname + "'";
            return DBHelp.ExecuteCommand(sql);
        }
        public static int updateApproveFail(string formid, string positionname)
        {
            string sql = "UPDATE As_Approve SET Assess_flag='未通过' WHERE Form_ID='" + formid + "'and Position_Name='" + positionname + "'";
            return DBHelp.ExecuteCommand(sql);
        }
    }
}
