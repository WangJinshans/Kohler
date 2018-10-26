using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.QualityDetection;
using MODEL.QualityDetection;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class RequisitionForTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				QT_RequisitionForTest newTest = new QT_RequisitionForTest();
				newTest.R_F_TNO = "2221313";           //用来判断是否有该表格
				ViewState.Add("factory", "上海科勒");
				newTest.Factory = Convert.ToString(ViewState["factory"]);
				newTest.Requester = "啦啦啦啦啦";
				newTest.Lab = "上海某LAB";
				int n = RequisitionForTest_BLL.addRequisitionForTest(newTest);
				if (n == 0)
				{
					Response.Write("<script>window.alert('表格新建error！')</script>");
					return;
				}
				else
				{
					string formID = RequisitionForTest_BLL.getRequisitionForTestFormID("2221313", "上海科勒");
					ViewState.Add("form_ID", formID);
				}
			}
			else
			{

			}
        }


		private QT_RequisitionForTest getNewTest()
		{
			QT_RequisitionForTest newTest = new QT_RequisitionForTest();
			
			newTest.Date_Of_Issue = TextBox2.Text.ToString().Trim();
			newTest.Requested_by = TextBox3.Text.ToString().Trim();
			newTest.Ext_No = TextBox4.Text.ToString().Trim();
			newTest.Department = TextBox5.Text.ToString().Trim();
			newTest.Sample_Name = TextBox6.Text.ToString().Trim();
			newTest.Desciption = TextBox7.Text.ToString().Trim();
			newTest.Sample_QtyWt = TextBox8.Text.ToString().Trim();
			newTest.Date_Required = TextBox9.Text.ToString().Trim();
			newTest.Test_Content = TextBox10.Text.ToString().Trim();
			newTest.Raw_Material = TextBox11.Text.ToString().Trim();
			newTest.Suplier = TextBox12.Text.ToString().Trim();
			newTest.Goods_QtyWt = TextBox13.Text.ToString().Trim();
			newTest.Arrived_Date = TextBox14.Text.ToString().Trim();
			newTest.User_ = TextBox15.Text.ToString().Trim();
			newTest.Desciption_of_Take_Sample = TextBox16.Text.ToString().Trim();
			newTest.Received_by = TextBox17.Text.ToString().Trim();
			newTest.Received_Date = TextBox18.Text.ToString().Trim();
			newTest.Supervisor_Approval = TextBox19.Text.ToString().Trim();
			newTest.Requester = TextBox20.Text.ToString().Trim();
			newTest.Lab = TextBox21.Text.ToString().Trim();

			return newTest;

		}

		protected void Submit(object sender, EventArgs e)
		{
			QT_RequisitionForTest newTest = new QT_RequisitionForTest();
			newTest = getNewTest();
			newTest.FormID = Convert.ToString(ViewState["form_ID"]);
			
			string i = newTest.FormID;
			RequisitionForTest_BLL.updateRequisitionForTest(newTest);
			Response.Write("<script>window.alert('已写入数据库！')</script>");
		}

		
	}
}