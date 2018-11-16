using BLL;
using BLL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class LabInspectionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //委托检验单列表
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            //仅仅实验室主管 可用 
            string factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());
            if (position_Name.Equals("亚克力实验室主管"))
            {
                //区分实验室 不同实验室
                GridView1.DataSource = LabInspectionList_BLL.getConsignmentInspectionList(1, factory_Name);
                GridView1.DataBind();
            }
            else if (position_Name.Equals("铸铁实验室主管"))
            {
                GridView1.DataSource = LabInspectionList_BLL.getConsignmentInspectionList(0, factory_Name);
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string batch_no = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string inspection_Type = GridView1.Rows[drv.RowIndex].Cells[8].Text;

            if (e.CommandName == "done")
            {
                LabInspectionList_BLL.updateStatus(batch_no, "已完成");
                InspectionList_BLL.updateStatus(batch_no, inspection_Type, "实验室已确认");

                //发送邮件 到 质量部文员 进行通知

                LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "操作成功"), "labInspectionDone");
            }
        }
    }
}