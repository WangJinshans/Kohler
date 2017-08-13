using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class SelectDepartment : System.Web.UI.Page
    {
        private static As_Form_AssessFlow Form_AssessFlow;
        private static As_Approve approve;
        public static Dictionary<string, string> paramInfo;
        public static Page originPage;

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
            string kci= Request.QueryString["kci"];
            //string kci = Request.QueryString["ss"]; null
            Form_AssessFlow.Form_ID= Request.QueryString["formid"];
            Form_AssessFlow.First = positionName;
            Form_AssessFlow.Second = assess_flow.Assess_Two_ID;
            Form_AssessFlow.Third = assess_flow.Assess_Three_ID;
            Form_AssessFlow.Four = assess_flow.Assess_Four_ID;
            Form_AssessFlow.Five = assess_flow.Assess_Five_ID;
            if (kci == "1")//kci判断是否需要更改
            {
                Form_AssessFlow.Kci = "1";
            }
            else if (kci == null)
            {
                Form_AssessFlow.Kci = assess_flow.Assess_Six_ID;
            }

            Form_AssessFlow.Temp_Vendor_ID = Session["tempVendorID"].ToString();
            Form_AssessFlow.Factory_Name = Session["factory"].ToString();

            
            approve = new As_Approve();
            approve.Form_ID= Request.QueryString["formid"];
            approve.Assess_Flag = "0";  //0为未通过
            approve.Assess_Reason = "";
            approve.Assess_Time = DateTime.Now.ToString();
            approve.Temp_Vendor_ID = Session["tempVendorID"].ToString();
            approve.Factory_Name = Session["factory"].ToString();
            approve.Form_Type_Name = Session["form_name"].ToString();
            approve.Temp_Vendor_Name = Session["tempVendorName"].ToString();
        }

        public static void doSelect()
        {
            //添加此表的审批流程到动态写入表
            AssessFlow_BLL.addFormAssessFlow(Form_AssessFlow);

            //TODO 2017-7-6::判断审批顺序，截留越界的批准,预防重复插入，最好先检查是否已经存在
            //添加员工所要审批的表格

            if (Form_AssessFlow.First != "")
            {
                approve.Position_Name = Form_AssessFlow.First;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Second != "")
            {
                approve.Position_Name = Form_AssessFlow.Second;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Third!= "")
            {
                approve.Position_Name = Form_AssessFlow.Third;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Four != "")
            {
                approve.Position_Name = Form_AssessFlow.Four;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Five != "")
            {
                approve.Position_Name = Form_AssessFlow.Five;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Kci == "1")//最终确认需要KCI审批
            {
                As_KCI_Approval kci = new As_KCI_Approval();
                kci.Form_ID = Form_AssessFlow.Form_ID;//获取Form_ID
                kci.Temp_Vendor_ID = Form_AssessFlow.Temp_Vendor_ID;//获取Temp_Vendor_ID
                kci.Position_Name = "采购部经理";
                KCIApproval_BLL.addKCIApproval(kci);
            }
            //Response.Write("<script>window.alert('选择成功！');'</script>");
            //Response.Write("<script>window.alert('选择成功！');window.location.href='EmployeeVendor.aspx'</script>");

        }

        public static void doSelect(string kci)
        {
            if (kci == "1")
            {
                Form_AssessFlow.Kci = "1";
            }
            //添加此表的审批流程到动态写入表
            AssessFlow_BLL.addFormAssessFlow(Form_AssessFlow);

            //TODO 2017-7-6::判断审批顺序，截留越界的批准,预防重复插入，最好先检查是否已经存在
            //添加员工所要审批的表格

            if (Form_AssessFlow.First != "")
            {
                approve.Position_Name = Form_AssessFlow.First;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Second != "")
            {
                approve.Position_Name = Form_AssessFlow.Second;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Third != "")
            {
                approve.Position_Name = Form_AssessFlow.Third;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Four != "")
            {
                approve.Position_Name = Form_AssessFlow.Four;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Five != "")
            {
                approve.Position_Name = Form_AssessFlow.Five;
                AssessFlow_BLL.addApprove(approve);
            }
            //Response.Write("<script>window.alert('选择成功！');'</script>");
            //Response.Write("<script>window.alert('选择成功！');window.location.href='EmployeeVendor.aspx'</script>");

        }
    }
}