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
    public partial class MBRAppliy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //列表显示出来  区分厂 
            string factory_Name = Convert.ToString(Session["Factory_Name"]);

            //物流 申请该物料的MBR
            List<QT_Goods_Returned> list = MBR_BLL.getGoodReturnedList(factory_Name, "退货");

            GridView1.DataSource = list;
            GridView1.DataBind();



        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());

            //form_ID获取  不确定是否需要以Form_ID为基础 来发起 MBR
            string form_ID= GridView1.Rows[drv.RowIndex].Cells[0].Text;

            if (e.CommandName.Equals("startMBR"))
            {
                if (position_Name.Equals("采购部经理"))
                {
                    //物流部申请MRB  暂定采购经理
                    MRB_Application(form_ID, position_Name);
                }
                else
                {
                    LocalScriptManager.CreateScript(Page, String.Format("MRBtip('{0}')", "您没有MBR的申请权限"), "MRBtip");
                }
            }
        }



        /// <summary>
        /// 是否采用Form_ID 标识MBR 有待考察  
        /// 
        /// 申请后 大佬可以开始票圈
        /// </summary>
        /// <param name="form_ID"></param>
        private void MRB_Application(string form_ID,string position_Name)
        {
            //开始MBR 
            MBR_BLL.startMBR(form_ID, Convert.ToString(ViewState["kci"]));

            //更新报告状态为 未完成
            SurveyReport_BLL.updateSurveyStatus(form_ID, "待检");

            //删除退货消息
            string batch_No = SurveyReport_BLL.getReportBatchNo(form_ID);
            GoodsReturned_BLL.deleteGoodReturned(batch_No);

            //申请成功
            LocalScriptManager.CreateScript(Page, String.Format("MRBfinish('{0}','{1}')", "已经成功申请MRB", position_Name), "MRBfinish");
        }
    }
}