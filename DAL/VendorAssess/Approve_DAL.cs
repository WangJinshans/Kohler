﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL.VendorAssess
{
    public class Approve_DAL
    {
        public static int updateReason(string formID, string position, string factory, string reason)
        {
            string sql = "update As_Approve set Assess_Reason=@Reason where Form_ID=@Form_ID and Position_Name=@Position_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Reason",reason),
                new SqlParameter("@Position_Name",position),
                new SqlParameter("@Factory_Name",factory),
                new SqlParameter("Form_ID",formID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static bool deleteApproveRecord(string formID)
        {
            string sql = "delete from As_Approve where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            if (DBHelp.ExecuteCommand(sql,sp)>0)
            {
                return true;
            }
            return false;
        }

        public static As_Approve getApproveTop(string formID)
        {
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + formID + "'";
            DataTable dt = DBHelp.GetDataSet(sql);

            As_Approve ap = null;
            if (dt.Rows.Count > 0)
            {
                ap = new As_Approve();
                ap.Position_Name = dt.Rows[0]["Position_Name"].ToString();
                ap.Form_ID = dt.Rows[0]["Form_ID"].ToString();
                ap.Form_Type_Name = dt.Rows[0]["Form_Type_Name"].ToString();
                ap.Factory_Name = dt.Rows[0]["Factory_Name"].ToString();
                ap.Employee_ID = dt.Rows[0]["Employee_ID"].ToString();
                ap.Email = dt.Rows[0]["Employee_Email"].ToString();
                ap.Employee_Name = dt.Rows[0]["Employee_Name"].ToString();
                ap.User_Department = dt.Rows[0]["User_Department"].ToString();
                //TODO::添加其他参数
            }
            return ap;
        }

        public static bool userDepartMentAsLastOne(string formID, string positionName)
        {
            string sql = "select * from As_Approve where Form_ID=@Form_ID and Position_Name=@Position_Name and User_Department='YES' and Assess_Flag='0'";
            SqlParameter[] SP = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID),
                new SqlParameter("@Position_Name",positionName)
            };
            using (SqlDataReader reader = DBHelp.GetReader(sql, SP))
                if (reader.Read())
                {
                    return true;//存在用户部门未审批记录 返回false
                }
                else
                {
                    return false;//不存在用户部门未审批记录 返回false
                }
        }

        public static int refuseAssess(string formID, string position, string factory, string reason, string formTypeID, string tempVendorID, string employeeID, string tableName)
        {
            SqlCommand cmd = new SqlCommand("refuseAssess", DBHelp.Connection);
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@formID",formID),
                new SqlParameter("@position",position),
                new SqlParameter("@factory",factory),
                new SqlParameter("@reason",reason),
                new SqlParameter("@formTypeID",formTypeID),
                new SqlParameter("@tempVendorID",tempVendorID),
                new SqlParameter("@employeeID",employeeID),
                new SqlParameter("@aimFormName",tableName)
            };
            SqlParameter paramReturn = new SqlParameter("@return", SqlDbType.Int);
            paramReturn.Direction = ParameterDirection.ReturnValue;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(sp);
            cmd.Parameters.Add(paramReturn);
            cmd.ExecuteNonQuery();
            DBHelp.Connection.Close();

            return Convert.ToInt32(paramReturn.Value);
        }
    }
}
