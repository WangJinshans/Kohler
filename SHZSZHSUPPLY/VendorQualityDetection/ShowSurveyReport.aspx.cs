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
    public partial class ShowSurveyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initAuthority();
            if (!IsPostBack)
            {
                getSessionInfo();
            }
            else
            {

            }
        }



        private void getSessionInfo()
        {
            //form_ID的生成 
            try
            {
                ViewState["form_ID"] = Request.QueryString["form_ID"].ToString().Trim();
            }
            catch
            {
                ViewState["form_ID"] = "";
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {

        }

        protected void selected_Click(object sender, EventArgs e)
        {
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            string form_ID = Convert.ToString(ViewState["form_ID"]);
            string choice = "";

            if (position_Name.Equals("采购部经理"))//采购经理
            {
                choice = Convert.ToString(purchase_manager.SelectedIndex);
            }
            else if (position_Name.Equals("财务部经理"))//财务经理
            {
                choice = Convert.ToString(logistics_manager.SelectedIndex);
            }
            else if (position_Name.Equals("生产部经理"))//采购经理
            {
                choice = Convert.ToString(product_manager.SelectedIndex);
            }
            else if (position_Name.Equals("市场部经理"))//采购经理
            {
                choice = Convert.ToString(market_manager.SelectedIndex);
            }
            else if (position_Name.Equals("项目部经理"))//采购经理
            {
                choice = Convert.ToString(product_manager.SelectedIndex);
            }
            else if (position_Name.Equals("质量部经理"))//采购经理
            {
                choice = Convert.ToString(quilty_manager.SelectedIndex);
            }
            else if (position_Name.Equals("总经理")||position_Name.Equals("总监"))
            {
                choice = Convert.ToString(final_select.SelectedIndex);
            }


            makeChoice(choice,Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString()), Convert.ToString(ViewState["form_ID"]));

            if (position_Name.Equals("总经理") || position_Name.Equals("总监"))
            {
                //总经理 总监 不需要判断意见是否统一

                string result = final_select.SelectedValue;

                //设置MBR 结论
                MBR_BLL.setMBRResult(form_ID, result);

                //显示MBR 结论
                mbr_result.Text = result;

                makeChoice(choice, Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString()), form_ID);

                //MBR 完成 更新 QT_MBR_Results的states状态标志
                MBR_BLL.updateMBRState(form_ID, "YES");
            }

            //判断是否意见已经统一
            if (MBR_BLL.isMeetAgrement(Convert.ToString(ViewState["form_ID"])))
            {
                //设置报告完成

                //设置MBR的结论 

                //发送邮件 通知检验员 或者 质量部文员

                //结束操作
                return;
            }

            //提示 操作成功  返回刷新
        }

        /// <summary>
        /// 权限 检验员 无法操作MBR 中的任意一项 当前职位只可操作MBR中与本职位有关的部分
        /// </summary>
        private void initAuthority()
        {
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());

            if (position_Name.Equals("检验员"))
            {
                purchase_manager.Enabled = false;
                logistics_manager.Enabled = false;
                product_manager.Enabled = false;
                market_manager.Enabled = false;
                project_manager.Enabled = false;
                quilty_manager.Enabled = false;
                final_select.Enabled = false;
            }
            else if (position_Name.Equals("采购部经理"))//采购经理
            {
                logistics_manager.Enabled = false;
                product_manager.Enabled = false;
                market_manager.Enabled = false;
                project_manager.Enabled = false;
                quilty_manager.Enabled = false;
                final_select.Enabled = false;
            }
            else if (position_Name.Equals("财务部经理"))//财务经理
            {
                purchase_manager.Enabled = false;
                product_manager.Enabled = false;
                market_manager.Enabled = false;
                project_manager.Enabled = false;
                quilty_manager.Enabled = false;
                final_select.Enabled = false;
            }
            else if (position_Name.Equals("生产部经理"))//采购经理
            {

            }
            else if (position_Name.Equals("市场部经理"))//采购经理
            {

            }
            else if (position_Name.Equals("项目部经理"))//采购经理
            {

            }
            else if (position_Name.Equals("质量部经理"))//采购经理
            {
                purchase_manager.Enabled = false;
                logistics_manager.Enabled = false;
                product_manager.Enabled = false;
                market_manager.Enabled = false;
                project_manager.Enabled = false;
                final_select.Enabled = false;
            }
            else //任何无关人员
            {
                purchase_manager.Enabled = false;
                logistics_manager.Enabled = false;
                product_manager.Enabled = false;
                market_manager.Enabled = false;
                project_manager.Enabled = false;
                quilty_manager.Enabled = false;
                final_select.Enabled = false;
            }
        }


        /// <summary>
        /// 需要MBR  判断是否达成一至
        /// </summary>
        /// <returns></returns>
        private void MBR()
        {
            //根据Form_ID 判断是否KCI 因为KCI需要市场等等
            string form_ID = Convert.ToString(ViewState["form_ID"]);
            bool isKCINeeded = false;
            isKCINeeded = SurveyReport_BLL.isKCINeeded(form_ID);
            if (isKCINeeded)
            {
                //UI展示部分 属于KCI MBR的显示不部分

                //如果未达成一致 需要显示 总监的决定
                if (!MBR_BLL.isMeetAgrement(form_ID))
                {
                    final_decision.Text = "总监";
                    string result = SurveyReport_BLL.getDecision("General_Manager", form_ID);
                    final_select.Text = result;
                }
            }
            else
            {
                //UI展示部分 不属于KCI MBR的显示不部分

                //不需要市场部 和 工厂部  如果未达成一致 需要显示 总经理 的决定
                if (!MBR_BLL.isMeetAgrement(form_ID))
                {
                    final_decision.Text = "总经理";
                    string result = SurveyReport_BLL.getDecision("General_Manager", form_ID);
                    final_select.Text = result;
                }
            }
        }

        /// <summary>
        /// 最后决定人的选择事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void final_SelectedIndexChanged(object sender, EventArgs e)
        {
            string result = final_select.SelectedValue;

            //显示MBR 结论
            mbr_result.Text = result;
        }

        private void makeChoice(string choice,string position_Name,string form_ID)
        {
            MBR_BLL.makeChoice(choice, position_Name, form_ID);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}