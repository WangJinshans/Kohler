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

		public static DataTable selectListItem(string addtime)
		{
			string sql = "select distinct a.Product_Describes,b.Temp_Vendor_Name,a.[Go],a.[To],a.Form_ID,a.Status,a.Add_Time "+
							"from QT_Inspection_List a,As_Temp_Vendorchange b " +
							"where a.Vendor_Code = b.Normal_Vendor_ID and a.Add_Time like @Add_Time";
			SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@Add_Time",addtime+"%"),
			};
		
			return DBHelp.GetDataSet(sql, sp);
		}

		public static void selectListItem2(string addtime)
		{
			string sql = "select distinct a.Product_Describes,b.Temp_Vendor_Name,a.[Go],a.[To],a.Form_ID,a.Status,a.Add_Time " +
							"from QT_Inspection_List a,As_Temp_Vendorchange b " +
							"where a.Vendor_Code = b.Normal_Vendor_ID and a.Add_Time like @Add_Time";
			SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@Add_Time",addtime+"%"),
			};

			 DBHelp.ExecuteCommand(sql, sp);
		}


	}
}
