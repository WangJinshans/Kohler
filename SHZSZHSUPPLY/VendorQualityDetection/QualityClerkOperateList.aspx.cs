using BLL;
using BLL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class QualityClerkOperateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //只有质量部文员 可以进入
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());

            if (position_Name.Equals("质量部文员"))
            {
                GridView1.DataSource = Inspection_Item_BLL.getQualityClerkItems(0, Session["Employee_ID"].ToString());
                GridView1.DataBind();
            }


            // list 提供进入表格机会


            //不合格的报告页面提供 完成检验 以及 复检 选项

            //复检  添加附件记录 并生成一份新的报告  复制一些不变的数据

            //检验员 以及质量部文员可以提交报告  实验室收到委托检验单 可以发送报告 但是并不填写
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string batch_no = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string sku = GridView1.Rows[drv.RowIndex].Cells[1].Text;
            string product_name = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            string vendor_Code = GridView1.Rows[drv.RowIndex].Cells[4].Text;
            string detection_Count = GridView1.Rows[drv.RowIndex].Cells[5].Text;
            string inspection_Type = GridView1.Rows[drv.RowIndex].Cells[7].Text;

            if (e.CommandName == "fill")
            {
                string isLocked = "";
                isLocked = InspectionList_BLL.isLocked(batch_no);
                if (!isLocked.Equals(""))
                {
                    if (!isLocked.Equals(Session["Employee_ID"].ToString()))
                    {
                        LocalScriptManager.CreateScript(Page, String.Format("QTtip('{0}')", "有同事正在操作该批次"), "locktip");
                        return;
                    }
                }
                else
                {
                    //锁定该条记录  Employee_ID  方便历史查询 
                    InspectionList_BLL.LockItem(batch_no, Session["Employee_ID"].ToString());

                }
                string form_ID = SurveyReport_BLL.getReportFormID(batch_no);
                //获取KCI
                string kci = Material_Inspection_Item_BLL.getKCI(sku);
                //跳转到报告中
                Response.Redirect("SurveyReport.aspx?batch_No=" + batch_no + "&sku=" + sku + "&product_Name=" + product_name + "&vendor_Code=" + vendor_Code + "&Amount=" + detection_Count + "&time=" + DateTime.Now.ToString() + "&form_ID=" + form_ID + "&kci=" + kci + "&inspection_Type=" + inspection_Type);
            }
        }
    }
}