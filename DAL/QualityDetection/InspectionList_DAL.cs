﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.QualityDetection
{
    public class InspectionList_DAL
    {
        public static int LockItem(string batch_no,string employee_ID)
        {
            string sql = "update QT_Inspection_List set Employee_ID=@Employee_ID where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employee_ID),
                new SqlParameter("@Batch_No",batch_no)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static string isLocked(string batch_no)
        {
            string sql = "select Employee_ID from QT_Inspection_List where Batch_NO=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Batch_NO",batch_no)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (Convert.ToString(dr["Employee_ID"]).Equals(""))
                    {
                        return "";
                    }
                    else
                    {
                        return Convert.ToString(dr["Employee_ID"]);
                    }
                }
            }
            return "";
        }

        public static int updateFormID(string batch_no,string form_ID)
        {
            string sql = "update QT_Inspection_List set Form_ID=@Form_ID where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",form_ID),
                new SqlParameter("@Batch_No",batch_no)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }
    }
}