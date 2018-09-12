using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL.QualityDetection;
using System.Data.SqlClient;
using DAL.QualityDetection;

namespace BLL.QualityDetection
{
	public class RequisitionForTest_BLL
	{
		public static string getRequisitionForTestFormID(string R_F_TNO, string Factory)
		{
			return RequisitionForTest_DAL.getRequisitionForTestFormID(R_F_TNO, Factory);
		}

		public static bool checkForm(string form_ID)
		{
			return RequisitionForTest_DAL.checkForm(form_ID);

		}

		public static int addRequisitionForTest(QT_RequisitionForTest newTest)
		{
			return RequisitionForTest_DAL.addRequisitionForTest(newTest);
		}

		public static void updateRequisitionForTest(QT_RequisitionForTest updateTest)
		{
			RequisitionForTest_DAL.updateRequisitionForTest(updateTest);
		}

		public static void delRequisitionForTest(QT_RequisitionForTest delTest)
		{
			RequisitionForTest_DAL.delRequisitionForTest(delTest);
		}
	}

	
}
