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
    public partial class ShowSurveyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initAuthority();
            if (!IsPostBack)
            {
                getSessionInfo();
                //获取该报告
                initSurvey();
            }
            else
            {  

            }
        }

        private void initSurvey()
        {
            string form_ID = Convert.ToString(ViewState["form_ID"]);

            Repeater1.DataSource = SurveyReport_BLL.getInspectionAndDatas(form_ID);
            Repeater1.DataBind();

            QT_Survey survey = SurveyReport_BLL.getSurveyReport(form_ID);

            lb_batch.Text = survey.Batch_No;
            lb_product_name.Text = survey.Product_Name;
            lb_sku.Text = survey.SKU;
            lb_vendor_code.Text = survey.Vendor_Code;
            lb_purachseNo.Text = survey.Purchase_No;
            lb_amount.Text = survey.Amount;
            lb_arrivetime.Text = survey.Arrave_Time;
            lb_region.Text = "泰国";

            if (survey.Result.Equals("0"))
            {
                lb_result.Text = "退货";
            }
            else if (survey.Result.Equals("1"))
            {
                lb_result.Text = "让步接收";
            }
            else if (survey.Result.Equals("2"))
            {
                lb_result.Text = "返工";
            }
            else if (survey.Result.Equals("3"))
            {
                lb_result.Text = "挑选全检";
            }
            lb_unqualifiedType.Text = survey.Un_Inspection_Type;
            lb_rc.Text = survey.RC;
            lb_rj.Text = survey.RJ;

            lb_suitability_amount.Text = survey.Suitability_Amount;
            lb_suitability_bad.Text = survey.Suitability_Bad;
            lb_suitability_detail.Text = survey.Suitability_Details;

            lb_surface_amount.Text = survey.Sureface_Amount;
            lb_surface_bad.Text = survey.Sureface_Bad;
            lb_surface_detail.Text = survey.Sureface_Details;

            lb_remark.Text = survey.Remark;


            //初始化其他MBR的裁定结果
            MBRSingleChoice choice = MBR_BLL.getEveryOneChoice(form_ID);

            if (choice != null)
            {
                if (choice.Purchase_Manager != "")
                {
                    if (choice.Purchase_Manager.Equals("0"))
                    {
                        purchase_manager.Text = "退货";
                    }
                    else if (choice.Purchase_Manager.Equals("1"))
                    {
                        purchase_manager.Text = "让步接收";
                    }
                    else if (choice.Purchase_Manager.Equals("2"))
                    {
                        purchase_manager.Text = "返工";
                    }
                    else if (choice.Purchase_Manager.Equals("3"))
                    {
                        purchase_manager.Text = "挑选全检";
                    }
                    purchase_reason.Text = choice.Purchase_Reason;
                }

                if (choice.Logistics_Manager != "")
                {
                    if (choice.Logistics_Manager.Equals("0"))
                    {
                        logistics_manager.Text = "退货";
                    }
                    else if (choice.Logistics_Manager.Equals("1"))
                    {
                        logistics_manager.Text = "让步接收";
                    }
                    else if (choice.Logistics_Manager.Equals("2"))
                    {
                        logistics_manager.Text = "返工";
                    }
                    else if (choice.Logistics_Manager.Equals("3"))
                    {
                        logistics_manager.Text = "挑选全检";
                    }
                    logistics_reason.Text = choice.Logistics_Reason;
                }


                if (choice.Product_Manager != "")
                {
                    if (choice.Product_Manager.Equals("0"))
                    {
                        product_manager.Text = "退货";
                    }
                    else if (choice.Product_Manager.Equals("1"))
                    {
                        product_manager.Text = "让步接收";
                    }
                    else if (choice.Product_Manager.Equals("2"))
                    {
                        product_manager.Text = "返工";
                    }
                    else if (choice.Product_Manager.Equals("3"))
                    {
                        product_manager.Text = "挑选全检";
                    }
                    product_reason.Text = choice.Product_Reason;
                }


                if (choice.Market_Manager != "")
                {
                    if (choice.Market_Manager.Equals("0"))
                    {
                        market_manager.Text = "退货";
                    }
                    else if (choice.Market_Manager.Equals("1"))
                    {
                        market_manager.Text = "让步接收";
                    }
                    else if (choice.Market_Manager.Equals("2"))
                    {
                        market_manager.Text = "返工";
                    }
                    else if (choice.Market_Manager.Equals("3"))
                    {
                        market_manager.Text = "挑选全检";
                    }

                    market_reason.Text = choice.Market_Reason;
                }


                if (choice.Project_Manager != "")
                {
                    if (choice.Project_Manager.Equals("0"))
                    {
                        project_manager.Text = "退货";
                    }
                    else if (choice.Project_Manager.Equals("1"))
                    {
                        project_manager.Text = "让步接收";
                    }
                    else if (choice.Project_Manager.Equals("2"))
                    {
                        project_manager.Text = "返工";
                    }
                    else if (choice.Project_Manager.Equals("3"))
                    {
                        project_manager.Text = "挑选全检";
                    }

                    project_reason.Text = choice.Project_Reason;
                }


                if (choice.Quiltty_Manager != "")
                {
                    if (choice.Quiltty_Manager.Equals("0"))
                    {
                        quilty_manager.Text = "退货";
                    }
                    else if (choice.Quiltty_Manager.Equals("1"))
                    {
                        quilty_manager.Text = "让步接收";
                    }
                    else if (choice.Quiltty_Manager.Equals("2"))
                    {
                        quilty_manager.Text = "返工";
                    }
                    else if (choice.Quiltty_Manager.Equals("3"))
                    {
                        quilty_manager.Text = "挑选全检";
                    }
                    quilty_reason.Text = choice.Quiltty_Reason;
                }


                if (choice.General_Manager != "")
                {
                    if (choice.General_Manager.Equals("0"))
                    {
                        final_select.Text = "退货";
                    }
                    else if (choice.General_Manager.Equals("1"))
                    {
                        final_select.Text = "让步接收";
                    }
                    else if (choice.General_Manager.Equals("2"))
                    {
                        final_select.Text = "返工";
                    }
                    else if (choice.General_Manager.Equals("3"))
                    {
                        final_select.Text = "挑选全检";
                    }
                    final_reason.Text = choice.General_Reason;
                }


                if (choice.Chief_Manager != "")
                {
                    if (choice.Chief_Manager.Equals("0"))
                    {
                        final_select.Text = "退货";
                    }
                    else if (choice.Chief_Manager.Equals("1"))
                    {
                        final_select.Text = "让步接收";
                    }
                    else if (choice.Chief_Manager.Equals("2"))
                    {
                        final_select.Text = "返工";
                    }
                    else if (choice.Chief_Manager.Equals("3"))
                    {
                        final_select.Text = "挑选全检";
                    }
                    final_reason.Text = choice.Chief_Reason;
                }

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
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        protected void selected_Click(object sender, EventArgs e)
        {
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            string form_ID = Convert.ToString(ViewState["form_ID"]);
            string choice = "";
            string reason = "";

            if (position_Name.Equals("采购部经理")|| position_Name.Equals("供应链经理"))//采购经理
            {
                choice = Convert.ToString(purchase_manager.SelectedIndex);
                reason = Convert.ToString(purchase_reason.Text);
            }
            else if (position_Name.Equals("财务部经理"))//财务经理
            {
                choice = Convert.ToString(logistics_manager.SelectedIndex);
                reason = Convert.ToString(logistics_reason.Text);
            }
            else if (position_Name.Equals("生产部经理"))//采购经理
            {
                choice = Convert.ToString(product_manager.SelectedIndex);
                reason = Convert.ToString(product_reason.Text);
            }
            else if (position_Name.Equals("市场部经理"))//采购经理
            {
                choice = Convert.ToString(market_manager.SelectedIndex);
                reason = Convert.ToString(market_reason.Text);
            }
            else if (position_Name.Equals("项目部经理"))//采购经理
            {
                choice = Convert.ToString(product_manager.SelectedIndex);
                reason = Convert.ToString(product_reason.Text);
            }
            else if (position_Name.Equals("质量部经理"))//采购经理
            {
                choice = Convert.ToString(quilty_manager.SelectedIndex);
                reason = Convert.ToString(quilty_reason.Text);
            }
            else if (position_Name.Equals("总经理")||position_Name.Equals("总监"))
            {
                choice = Convert.ToString(final_select.SelectedIndex);
                reason = Convert.ToString(final_reason.Text);
            }


            makeChoice(choice, reason, Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString()), Convert.ToString(ViewState["form_ID"]));

            if (position_Name.Equals("总经理") || position_Name.Equals("总监"))
            {
                //总经理 总监 不需要判断意见是否统一

                string result = final_select.SelectedValue;

                //设置MBR 结论
                MBR_BLL.setMBRResult(form_ID, result);

                //显示MBR 结论
                lb_mbr_result.Text = result;

                makeChoice(choice, reason, Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString()), form_ID);

                //MBR 完成 更新 QT_MBR_Results的states状态标志
                MBR_BLL.updateMBRState(form_ID, "YES");
            }

            //判断是否意见已经统一
            if (MBR_BLL.isMeetAgrement(Convert.ToString(ViewState["form_ID"])))
            {
                //设置MBR的结论 

                //发送邮件 通知检验员 或者 质量部文员 去InspectionList.aspx中完成调查报告的提交

                //结束操作
                return;
            }

            //提示 操作成功  返回刷新
            LocalScriptManager.CreateScript(Page, String.Format("mytips_then_back('{0}','{1}')", "操作成功", "MBRList.aspx"), "back");
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
            else if (position_Name.Equals("采购部经理")|| position_Name.Equals("供应链经理"))//采购经理
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
            else if (position_Name.Equals("生产部经理"))//生产部经理
            {
                purchase_manager.Enabled = false;
                logistics_manager.Enabled = false;
                market_manager.Enabled = false;
                project_manager.Enabled = false;
                quilty_manager.Enabled = false;
                final_select.Enabled = false;
            }
            else if (position_Name.Equals("市场部经理"))//市场部经理
            {
                purchase_manager.Enabled = false;
                logistics_manager.Enabled = false;
                product_manager.Enabled = false;
                project_manager.Enabled = false;
                quilty_manager.Enabled = false;
                final_select.Enabled = false;
            }
            else if (position_Name.Equals("项目部经理"))//项目部经理
            {
                purchase_manager.Enabled = false;
                logistics_manager.Enabled = false;
                product_manager.Enabled = false;
                market_manager.Enabled = false;
                quilty_manager.Enabled = false;
                final_select.Enabled = false;
            }
            else if (position_Name.Equals("质量部经理"))//质量部经理
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
            lb_mbr_result.Text = result;
        }

        private void makeChoice(string choice,string reason,string position_Name,string form_ID)
        {
            MBR_BLL.makeChoice(choice, reason, position_Name, form_ID);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void final_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string result = Convert.ToString(final_select.SelectedIndex);

            //显示MBR 结论
            lb_mbr_result.Text = final_select.SelectedValue;

            MBR_BLL.setMBRResult(Convert.ToString(ViewState["form_ID"]), result);

            InspectionList_BLL.updateStatusByFormID(Convert.ToString(ViewState["form_ID"]), "MBR完成");

        }
    }
}