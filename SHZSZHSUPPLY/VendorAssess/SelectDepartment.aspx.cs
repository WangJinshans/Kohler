using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class SelectDepartment : System.Web.UI.Page
    {
        private static As_Form_AssessFlow Form_AssessFlow;
        private static As_Approve approve;


        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM As_Employee";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = Employee_BLL.selectEmployee(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();

            GridView1.SelectedIndex = 0;
            GridView1_SelectedIndexChanged(null, null);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //实例化审批流程
            string positionName = this.GridView1.SelectedRow.Cells[2].Text.ToString();
            Form_AssessFlow = new As_Form_AssessFlow();
            As_Assess_Flow assess_flow = Session["AssessflowInfo"] as As_Assess_Flow;
            Form_AssessFlow.Form_ID= Request.QueryString["formid"];
            Form_AssessFlow.First = positionName;
            Form_AssessFlow.Second = assess_flow.Assess_Two_ID;
            Form_AssessFlow.Third = assess_flow.Assess_Three_ID;
            Form_AssessFlow.Four = assess_flow.Assess_Four_ID;
            Form_AssessFlow.Five = assess_flow.Assess_Five_ID;
            Form_AssessFlow.Kci = assess_flow.Assess_Six_ID;

            
            approve = new As_Approve();
            approve.Form_ID= Request.QueryString["formid"];
            approve.Assess_Flag = "0";  //0为未通过
            approve.Assess_Reason = "";
            approve.Assess_Time = DateTime.Now;
        }

        public static void doSelect()
        {
            //添加此表的审批流程到动态写入表
            AssessFlow_BLL.addFormAssessFlow(Form_AssessFlow); 

            //TODO 2017-7-6::判断审批顺序，截留越界的批准,预防重复插入，最好先检查是否已经存在
            //添加员工所要审批的表格
            if (Form_AssessFlow.First == null) { }
            else
            {
                approve.Position_Name = Form_AssessFlow.First;
                AssessFlow_BLL.addApprove(approve);
            }

            if (Form_AssessFlow.Second == null) { }
            else
            {
                approve.Position_Name = Form_AssessFlow.Second;
                AssessFlow_BLL.addApprove(approve);
            }

            if (Form_AssessFlow.Third == null) { }
            else
            {
                approve.Position_Name = Form_AssessFlow.Third;
                AssessFlow_BLL.addApprove(approve);
            }

            if (Form_AssessFlow.Four == null) { }
            else
            {
                approve.Position_Name = Form_AssessFlow.Four;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Five == null) { }
            else
            {
                approve.Position_Name = Form_AssessFlow.Five;
                AssessFlow_BLL.addApprove(approve);
            }
            //Response.Write("<script>window.alert('选择成功！');'</script>");
            //Response.Write("<script>window.alert('选择成功！');window.location.href='EmployeeVendor.aspx'</script>");

        }
    }
}