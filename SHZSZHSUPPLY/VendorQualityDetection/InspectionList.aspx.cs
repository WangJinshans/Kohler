using BLL;
using BLL.QualityDetection;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class InspectionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取职位  只有检验员才有权限进入
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            if (!position_Name.Contains("检验员"))
            {
                return;
            }
            if (!IsPostBack)
            {
                GridView1.DataSource = Inspection_Item_BLL.getInspecctorItems(0, Session["Employee_ID"].ToString());
                GridView1.DataBind();
            }
            else
            {
                switch (Request["__EVENTTARGET"])
                {
                    case "WT":
                        startWT(Request["__EVENTARGUMENT"]);
                        break;
                    case "fresh":
                        fresh();
                        break;
                    default:
                        break;
                }
            }
        }

        private void fresh()
        {
            GridView1.DataSource = Inspection_Item_BLL.getInspecctorItems(0, Session["Employee_ID"].ToString());
            GridView1.DataBind();
        }

        /// <summary>
        /// 开始委托检验 batch_No 批次
        /// </summary>
        /// <param name="batch_No"></param>
        private void startWT(string batch_No)
        {
            bool ok = false;
            ok = InspectionList_BLL.startWT(batch_No, Session["Employee_ID"].ToString(), Session["Type"].ToString());


            //生成委托检验书 并发送给选择的实验  type区分实验室


            ConsignmentInspection inspection = new ConsignmentInspection();
            if (Session["Type"].ToString().Contains("铸铁"))
            {
                inspection.Lab_Name = "铸铁实验室";
            }
            else
            {
                inspection.Lab_Name = "亚克力实验室";
            }

            inspection.Batch_No = batch_No;
            inspection.Consignment_KO = Session["Employee_ID"].ToString();
            inspection.Product_Name = Convert.ToString(ViewState["product_name"]);
            inspection.Vendor_Name = TempVendor_BLL.getVendorNameByCode(Convert.ToString(ViewState["vendor_Code"]));
            inspection.SKU = Convert.ToString(ViewState["sku"]);
            inspection.Amount = Convert.ToString(ViewState["detection_Count"]);
            inspection.Factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());
            inspection.Arrave_Time = DateTime.Now.ToString();
            inspection.Status = "待检";
            LabInspectionList_BLL.addConsignmentInspection(inspection);

            //发送邮件 给实验室

            LocalScriptManager.CreateScript(Page, String.Format("QTtip('{0}')", "委托检验成功发出"), "QTtips");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string batch_no = GridView1.Rows[drv.RowIndex].Cells[0].Text;

            string sku = GridView1.Rows[drv.RowIndex].Cells[1].Text;
            string product_name = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            string vendor_Code = GridView1.Rows[drv.RowIndex].Cells[4].Text;
            string detection_Count = GridView1.Rows[drv.RowIndex].Cells[5].Text;

            ViewState["sku"] = sku;
            ViewState["product_name"] = product_name;
            ViewState["vendor_Code"] = vendor_Code;
            ViewState["detection_Count"] = detection_Count;


            if (e.CommandName == "go")
            {
                
                //获取报告form_ID
                string form_ID = SurveyReport_BLL.getReportFormID(batch_no);
                //获取KCI
                string kci = Material_Inspection_Item_BLL.getKCI(sku);

                string isLocked = "";
                isLocked = InspectionList_BLL.isLocked(batch_no);
                if (!isLocked.Equals(""))//已经锁定 提示后自动刷新一次
                {
                    LocalScriptManager.CreateScript(Page, String.Format("QTtip('{0}')", "有同事正在操作该批次"), "locktip");
                    return;
                }
                else
                {
                    //锁定该条记录 Employee_ID 方便历史查询 
                    InspectionList_BLL.LockItem(batch_no, Session["Employee_ID"].ToString());

                }

                //跳转到报告中
                Response.Redirect("SurveyReport.aspx?batch_No=" + batch_no + "&sku=" + sku + "&product_Name=" + product_name + "&vendor_Code=" + vendor_Code + "&Amount=" + detection_Count + "&time=" + DateTime.Now.ToString() + "&form_ID=" + form_ID + "&kci=" + kci);
            }
            else if (e.CommandName == "to")
            {
                //委托检验
                LocalScriptManager.CreateScript(Page, String.Format("wt({0})", batch_no), "weituo");
            }
        }
    }
}