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

        public static bool deleteAssessFlow(string formID)
        {
            string sql = "delete from As_Form_AssessFlow where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",formID)
            };
            if (DBHelp.ExecuteCommand(sql,sp)>0)
            {
                return true;
            }
            return false;
        }

        public static int deleteFormAccess(string formID)
        {
            string sql = "delete from As_Form_AssessFlow where Form_ID='" + formID + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static As_Form_AssessFlow getFormAssessFlow(string formID)
        {
            string sql = "select * from As_Form_AssessFlow where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                As_Form_AssessFlow flow = new As_Form_AssessFlow();
                flow.First = dr["First"].ToString();
                flow.Second = dr["Second"].ToString();
                flow.Third = dr["Third"].ToString();
                flow.Four = dr["Four"].ToString();
                flow.Five = dr["Five"].ToString();
                flow.Kci = dr["KCI"].ToString();
                flow.Temp_Vendor_ID = dr["Temp_Vendor_ID"].ToString();
                flow.Factory_Name = dr["Factory_Name"].ToString();
                return flow;
            }
            return null;
        }

        public static int addFormAssessFlow(As_Form_AssessFlow Form_AssessFlow)
        {

            string sql = "insert into As_Form_AssessFlow values(@Form_ID,@First,@Second,@Third,@Four,@Five,@kci,@tempVendorID,@factory)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",Form_AssessFlow.Form_ID),
                new SqlParameter("First",Form_AssessFlow.First),
                new SqlParameter("Second",Form_AssessFlow.Second),
                new SqlParameter("Third",Form_AssessFlow.Third),
                new SqlParameter("Four",Form_AssessFlow.Four),
                new SqlParameter("Five",Form_AssessFlow.Five),
                new SqlParameter("kci",Form_AssessFlow.Kci),
                new SqlParameter("tempVendorID",Form_AssessFlow.Temp_Vendor_ID),
                new SqlParameter("factory",Form_AssessFlow.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }
        public static int addApprove(As_Approve approve)
        {

            string sql = "insert into As_approve values(@Form_ID,@Position_Name,@Assess_Flag,@Assess_Time,@Assess_Reason,@Temp_Vendor_ID,@Factory_Name,@Form_Type_Name,@Temp_Vendor_Name)";
            Object ob = DBNull.Value;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",approve.Form_ID),
                new SqlParameter("Position_Name",approve.Position_Name),
                new SqlParameter("Assess_Flag",approve.Assess_Flag),
                new SqlParameter("Assess_Time",ob),
                new SqlParameter("Assess_Reason",approve.Assess_Reason),
                new SqlParameter("Temp_Vendor_ID",approve.Temp_Vendor_ID),
                new SqlParameter("Factory_Name",approve.Factory_Name),
                new SqlParameter("Form_Type_Name",approve.Form_Type_Name),
                new SqlParameter("Temp_Vendor_Name",approve.Temp_Vendor_Name)
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
                    Approve.Assess_Time = Convert.ToString(dr["Assess_Time"]);
                    Approve.Factory_Name = dr["Factory_Name"].ToString();
                    Approve.Temp_Vendor_Name = dr["Temp_Vendor_Name"].ToString();
                    Approve.Form_Type_Name = dr["Form_Type_Name"].ToString();
                    list.Add(Approve);
                }
            }
            return list;
        }

        //TODO::已在数据库中分厂，此处可做可不做 2017年8月20日19:10:20
        public static int updateApprove(string formid,string positionname)
        {
            string sql = "UPDATE As_Approve SET Assess_flag='已通过',Assess_Time=@Assess_Time WHERE Form_ID=@Form_ID and Position_Name=@Position_Name";
            //string sql = "UPDATE As_Approve SET Assess_flag='已通过' WHERE Form_ID='" + formid+"'and Position_Name='"+ positionname + "'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Assess_Time",DateTime.Now),
                new SqlParameter("@Form_ID",formid),
                new SqlParameter("@Position_Name",positionname)
            };
            return DBHelp.ExecuteCommand(sql,sp);
        }
        public static int updateApproveFail(string formid, string positionname)
        {
            string sql = "UPDATE As_Approve SET Assess_flag='未通过' WHERE Form_ID='" + formid + "'and Position_Name='" + positionname + "'";
            return DBHelp.ExecuteCommand(sql);
        }
    }
}
