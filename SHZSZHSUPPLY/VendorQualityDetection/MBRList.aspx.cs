using BLL;
using BLL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class MBRList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //投票大佬 可以进入

            //职位
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());

            if (position_Name.Equals("采购部经理") || position_Name.Equals("物流部经理") || position_Name.Equals("生产部经理") || position_Name.Equals("质量部经理") || position_Name.Equals("市场部经理") || position_Name.Equals("工程部经理"))
            {
                //MBR裁定 职位筛选 并且刷新
                GridView1.DataSource = MBR_BLL.getMBRList(position_Name, "YES");
                GridView1.DataBind();
            }
        }


        /// <summary>
        /// 跳转进入show
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string batch_no = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            if (e.CommandName == "deal")
            {
                string form_ID = SurveyReport_BLL.getReportFormID(batch_no);

                //跳转到报告中
                Response.Redirect("ShowSurveyReport.aspx?form_ID=" + form_ID);
            }
        }
    }
}