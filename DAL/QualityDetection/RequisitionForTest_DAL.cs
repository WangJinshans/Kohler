using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL.QualityDetection;

namespace DAL.QualityDetection
{
	public class RequisitionForTest_DAL
	{
		public static string getRequisitionForTestFormID(string R_F_TNO, string Factory)
		{
			string formID = "";
			string sql = "select FormID from QT_RequisitionForTest where Factory = @Factory and R_F_TNO = @R_F_TNO  ";
			SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@Factory",Factory),
				new SqlParameter("@R_F_TNO",R_F_TNO)

			};
			DataTable tb = DBHelp.GetDataSet(sql, sp);
			if (tb.Rows.Count > 0)
			{
				foreach (DataRow dr in tb.Rows)
				{
					formID = dr["FormID"].ToString();
				}
			}
			return formID;
		}

		public static bool checkForm(string form_ID)
		{
			string sql = "select * from QT_RequisitionForTest where Form_ID=@Form_ID";
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

		public static int addRequisitionForTest(QT_RequisitionForTest newTest)
		{
			string sql = "insert into QT_RequisitionForTest(Requester,Lab,Factory,R_F_TNO) values (@Requester,@Lab,@Factory,@R_F_TNO) select TOP 1 SCOPE_IDENTITY() AS returnName from QT_RequisitionForTest";
			SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@Requester",newTest.Requester),
				new SqlParameter("@Lab",newTest.Lab),
				new SqlParameter("@Factory",newTest.Factory),
				new SqlParameter("@R_F_TNO",newTest.R_F_TNO)
			};
			return DBHelp.ExecuteCommand(sql, sp);
		}

		public static void updateRequisitionForTest(QT_RequisitionForTest updateTest)
		{
			string sql = "update QT_RequisitionForTest set " +
				"Date_Of_Issue = @Date_Of_Issue,Requested_by=@Requested_by,Ext_No=@Ext_No,Department=@Department,Sample_Name=@Sample_Name," +
				"Desciption=@Desciption,Sample_QtyWt=@Sample_QtyWt,Date_Required=@Date_Required,Test_Content=@Test_Content,Raw_Material=@Raw_Material," +
				"Suplier=@Suplier,Goods_QtyWt=@Goods_QtyWt,Arrived_Date=@Arrived_Date,User_=@User_,Supervisor_Approval=@Supervisor_Approval," +
				" Desciption_of_Take_Sample=@Desciption_of_Take_Sample,Received_by=@Received_by,Received_Date=@Received_Date,Requester=@Requester,Lab=@Lab " +
				"where FormID=@FormID";
			SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@FormID",updateTest.FormID),
				//new SqlParameter("@R_F_TNO",updateTest.R_F_TNO),
				new SqlParameter("@Date_Of_Issue",updateTest.Date_Of_Issue),
				new SqlParameter("@Requested_by",updateTest.Requested_by),
				new SqlParameter("@Ext_No",updateTest.Ext_No),
				new SqlParameter("@Department",updateTest.Department),
				new SqlParameter("@Sample_Name",updateTest.Sample_Name),
				new SqlParameter("@Desciption",updateTest.Desciption),
				new SqlParameter("@Sample_QtyWt",updateTest.Sample_QtyWt),
				new SqlParameter("@Date_Required",updateTest.Date_Required),
				new SqlParameter("@Test_Content",updateTest.Test_Content),
				new SqlParameter("@Raw_Material",updateTest.Raw_Material),
				new SqlParameter("@Suplier",updateTest.Suplier),
				new SqlParameter("@Goods_QtyWt",updateTest.Goods_QtyWt),
				new SqlParameter("@Arrived_Date",updateTest.Arrived_Date),
				new SqlParameter("@User_",updateTest.User_),
				new SqlParameter("@Desciption_of_Take_Sample",updateTest.Desciption_of_Take_Sample),
				new SqlParameter("@Received_by",updateTest.Received_by),
				new SqlParameter("@Received_Date",updateTest.Received_Date),
				new SqlParameter("@Supervisor_Approval",updateTest.Supervisor_Approval),
				new SqlParameter("@Requester",updateTest.Requester),
				new SqlParameter("@Lab",updateTest.Lab)
			};
			DBHelp.ExecuteCommand(sql, sp);
		}

		public static void delRequisitionForTest(QT_RequisitionForTest delTest)
		{
			string sql = "delete from QT_RequisitionForTest where FormID=@FormID";
			SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("FormID",delTest.FormID)
			};

			DBHelp.ExecuteCommand(sql, sp);
		}

	}
}
