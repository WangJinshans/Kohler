using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.QualityDetection
{
    public class ReInspection_DAL
    {
        public static int addReInspection(string new_Form_ID,string form_ID, string batch_No)
        {
            string sql = "insert into QT_Re_Inspection(Form_ID,Old_Form_ID,Batch_No)values(@Form_ID,@Old_Form_ID,@Batch_No)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",new_Form_ID),
                new SqlParameter("@Old_Form_ID",form_ID),
                new SqlParameter("@Batch_No",batch_No)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int addReInspectionServeyReport(string batch_No)
        {
            string sql = "insert into QT_Survey(Batch_No)values(@Batch_No)select TOP 1 SCOPE_IDENTITY() AS returnName from QT_Survey";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No)
            };
            return DBHelp.GetScalarID(sql, sp);
        }

        public static bool isReInspection(string form_ID)
        {
            string sqls = "select Form_ID from QT_Re_Inspection where Form_ID=@Form_ID";
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID)
            };
            using (SqlDataReader reader = DBHelp.GetReader(sqls, sps))
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

        public static string getReInspectionSurveyFormID(string batch_No, int n)
        {
            string sql = "select Form_ID from QT_Survey where Batch_No=@Batch_No and ID=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_No",batch_No),
                new SqlParameter("@ID",n),
            };
            string form_ID = "";
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    form_ID = Convert.ToString(dr["Form_ID"]);
                }
            }
            return form_ID;
        }
    }
}
