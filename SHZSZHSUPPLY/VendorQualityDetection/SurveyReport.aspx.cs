using BLL;
using BLL.QualityDetection;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    /// <summary>
    /// QT_Inspection_Records 记录供应商的所有进货记录 
    /// 
    /// 先判断 供应商的进货记录  根据物料编号生成 水平抽样计划 
    /// </summary>
    public partial class SurveyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //需要MRB的检验报告 在MRB完成后 需要显示 MRB的结论部分
            //不需要 MRB的检验报告 不需要显示
            //最开始 进入的时候也不需要显示 

            if (!IsPostBack)
            {
                getSessionInfo();
                initSurveryReport();
                showReport();

                //绩效评估部分的免检

            }
            else
            {
                //操作填表数据
                ViewState["itemValue"] = Request.Form["_itemValue"].ToString();

                switch (Request.Form["__EVENTTARGET"])
                {
                    case "MBR_Change":
                        MBR_Change();
                        break;
                    case "check_noneed":
                        //免检
                        noCheck();
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// 暂时免检 直接入库   接收数量为收到
        /// </summary>
        private void noCheck()
        {
            //
        }

        /// <summary>
        /// UI 复检按钮 显示与隐藏  质量部文员 form_ID是复检的form_ID的时候 不能显示复检申请 需要显示MRB
        /// </summary>
        private void showReInspectionButton()
        {
            string formID = SurveyReport_BLL.getReportFormID(Convert.ToString(ViewState["batch_No"]));
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            if (position_Name.Contains("检验员"))
            {
                //检验员 隐藏 复检 按钮
                reInspection.Visible = false;
            }
            else if (ReInspection_BLL.isReInspection(formID))//复检
            {
                reInspection.Visible = false;
            }
        }


        /// <summary>
        /// 默认该部分 display为 none
        /// 需要MBR 并且 MBR已经完成的 display为block
        /// </summary>
        private void showMRBpart()
        {
            string form_ID = Convert.ToString(ViewState["form_ID"]);
            if (MBR_BLL.isMBRNeeded(form_ID) && MBR_BLL.isMBRFinished(form_ID))
            {
                //设置display 为block
                LocalScriptManager.CreateScript(Page, "showMRB()", "showMRB");
            }

        }

        private void MBR_Change()
        {
            if (mbr_result.Text.Equals("挑选全检"))
            {
                LocalScriptManager.CreateScript(Page, "checkAll()", "checkAll");
            }
            else
            {
                LocalScriptManager.CreateScript(Page, "notCheckAll()", "notCheckAll");
            }
        }


        /// <summary>
        /// 初始化整个页面
        /// </summary>
        private void initSurveryReport()
        {
            //根据物料编号 确定需要的检测项
            DataTable source= SurveyReport_BLL.getInsectionItems(Convert.ToString(ViewState["sku"]));
            if (source == null)
            {

                Repeater1.DataSource = source;
                Repeater1.DataBind();
            }
            Repeater1.DataSource = source;
            Repeater1.DataBind();


            TextBox1.Text = Convert.ToString(ViewState["batch_No"]);
            TextBox2.Text = Convert.ToString(ViewState["product_Name"]);
            TextBox3.Text = Convert.ToString(ViewState["sku"]);
            TextBox4.Text = Convert.ToString(ViewState["vendor_Code"]);
            TextBox5.Text = Convert.ToString(ViewState["batch_No"]);
            TextBox6.Text = Convert.ToString(ViewState["Amount"]);


            showMRBpart();
            showReInspectionButton();
        }


        /// <summary>
        /// 显示页面
        /// </summary>
        private void showReport()
        {
            string formID = Convert.ToString(ViewState["form_ID"]);
            int check = SurveyReport_BLL.checkServeyReport(formID);
            if (check == 0)//不存在
            {
                //插入记录Form_ID 
                SurveyReport_BLL.addServeyReport(Convert.ToString(ViewState["batch_No"]));
                formID = SurveyReport_BLL.getReportFormID(Convert.ToString(ViewState["batch_No"]));
                ViewState["form_ID"] = formID;

                //更新QT_Inspection_List绑定的form_ID
                InspectionList_BLL.updateFormID(Convert.ToString(ViewState["batch_No"]), formID);
            }
            //显示各个Item
            InspectionPlanResult plan = makePlans(Convert.ToString(ViewState["vendor_Code"]), Convert.ToString(ViewState["batch_No"]), Convert.ToString(ViewState["sku"]), Convert.ToString(ViewState["Amount"]));
            if (plan != null)//计划成功产出
            {
                appearance_amount.Text = plan.Sample_Amount;
            }

        }

        private void getSessionInfo()
        {
            ViewState["sku"]= Request.QueryString["sku"].ToString();
            ViewState["batch_No"] = Request.QueryString["batch_No"].ToString();
            ViewState["vendor_Code"] = Request.QueryString["vendor_Code"].ToString();
            ViewState["Amount"] = Request.QueryString["Amount"].ToString();
            ViewState["product_Name"] = Request.QueryString["product_Name"].ToString();
            ViewState["time"] = Request.QueryString["time"].ToString();

            // 区别是否 KCI
            ViewState["kci"] = Request.QueryString["kci"].ToString();

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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    TextBox textbox = (TextBox)e.Item.FindControl("loop_text");
            //    textbox.Text = "";
            //}
        }


        /// <summary>
        /// 保存表格
        /// </summary>
        private void save()
        {
            string values = Convert.ToString(ViewState["itemValue"]);
            string sku= Convert.ToString(ViewState["sku"]);
            string form_ID = Convert.ToString(ViewState["form_ID"]);

            //保存到数据库
            SurveyReport_BLL.addInspectionValue(sku, form_ID, values);

            QT_Survey survey = new QT_Survey();
            survey.Form_ID = form_ID;
            survey.SKU = sku;
            //survey.Sureface_Amount=

            //保存其他地方
            SurveyReport_BLL.updateSurvey(survey);
        }


        #region 检查计划
        /// <summary>
        /// 生成抽样检查计划 
        /// </summary>
        private InspectionPlanResult makePlans(string vendor_Code,string batch_No,string SKU,string amount)
        {
            //获取检验方式 加严 放宽  正常
            int result = SurveyReport_BLL.getInspectionMethod(vendor_Code, SKU);

            //AQL
            string aql = Material_Inspection_Item_BLL.getAQL(SKU);

            //检验水平
            string class_Leval = Material_Inspection_Item_BLL.getClassLeval(SKU);

            //获取计划
            InspectionPlanResult plan = getInspectionPlan(class_Leval, amount, aql, result);

            //返回计划 
            return plan;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="class_Leval">检验水平 一般检验 OR 特殊检验</param>
        /// <param name="amount"></param>
        /// <param name="aql"></param>
        /// <param name="inspection_Leval">加严 正常 放宽 </param>
        private InspectionPlanResult getInspectionPlan(string class_Leval, string amount, string aql,int inspection_Leval)
        {
            InspectionPlanResult plan = new InspectionPlanResult();
            string sample_Code = InspectionPlan_BLL.getSampleCode(class_Leval, amount);
            if (!sample_Code.Equals(""))//获取到了 样本码
            {
                switch (inspection_Leval)
                {
                    case 1://放宽检验
                        plan = InspectionPlan_BLL.getInspectionPlanResult(sample_Code, aql, "Loose");
                        break;
                    case 2://正常检验
                        plan = InspectionPlan_BLL.getInspectionPlanResult(sample_Code, aql, "Normal");
                        break;
                    case 3://加严检验
                        plan = InspectionPlan_BLL.getInspectionPlanResult(sample_Code, aql, "Strict");
                        break;
                    default:
                        break;
                }
            }
            return plan;

        }
        #endregion

        //返回 禁止浏览器的自动回退
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("InspectionList.aspx");
        }


        /// <summary>
        /// 保存检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void saveReport_Click(object sender, EventArgs e)
        {
            //检验结果不能保存 
            save();
        }



        /// <summary>
        /// 完成检验  判断该报告是否是属于合格 只有合格的报告 检验员 以及质量部文员才有权利直接提交
        /// 
        /// 质量部文员在判断不合格之后 需要进行复检申请
        /// 
        /// 检验员判断不合格之后 进入退货队列 默认时间 申请复检则从该队列中删除该项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitReport_Click(object sender, EventArgs e)
        {
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            string form_ID = Convert.ToString(ViewState["form_ID"]);

            //不合格 能不能不复检

            //第一次检验不合格 MBR已经出结果了 也可以提交
            if (MBR_BLL.isMBRNeeded(form_ID) && MBR_BLL.isMBRFinished(form_ID))//需要MRB 并且 MRB已经完成
            {
                //获取MBR的结论 退货 挑选全检需要统计接收与拒收
                string mbrResult = MBR_BLL.getMBRResult(form_ID);
                if (mbrResult.Equals("挑选全检"))
                {
                    StockInfo info = new StockInfo();

                    info.Add_Time = DateTime.Now.ToString();
                    info.Source_From = Convert.ToString(ViewState["form_ID"]);

                    if (SurveyReport_BLL.isReInspection(Convert.ToString(ViewState["form_ID"])))
                    {
                        info.Status = "复检";
                    }
                    else
                    {
                        info.Status = "";
                    }
                    //备注 暂时为空
                    info.Remark = "";
                    info.Batch_No = Convert.ToString(ViewState["batch_No"]);

                    //接收 拒收
                    info.RJ = "";
                    info.RC = "";

                    //插入到进货信息库
                    StockInfo_BLL.addStockInfo(info);
                    SurveyReport_BLL.updateSurveyStatus(form_ID, "完成");
                }
                else if (mbrResult.Equals("退货"))
                {
                    //
                }
                
            }

            //是否合格 
            bool isQualified = false;

            //合格
            if (isQualified)
            {
                //更新报告的检验完成 QT_Inspection_List
                SurveyReport_BLL.setFinished(Convert.ToString(ViewState["form_ID"]));

                // 如果 接收  接收数量  拒收数量  接收的 入库 并记录

                StockInfo info = new StockInfo();

                info.Add_Time = DateTime.Now.ToString();
                info.Source_From = Convert.ToString(ViewState["form_ID"]);

                if (SurveyReport_BLL.isReInspection(Convert.ToString(ViewState["form_ID"])))
                {
                    info.Status = "复检";
                }
                else
                {
                    info.Status = "";
                }

                //备注 暂时为空
                info.Remark = "";
                info.Batch_No = Convert.ToString(ViewState["batch_No"]);

                //接收 拒收
                info.RJ = "";
                info.RC = "";

                //插入到进货信息库
                StockInfo_BLL.addStockInfo(info);

                //更新检验状态
                SurveyReport_BLL.updateSurveyStatus(form_ID, "完成");

                LocalScriptManager.CreateScript(Page, String.Format("addStock('{0}','{1}')", "进货信息储存成功 完成检验", position_Name), "addStock");
            }
            else
            {
                //暂时完成检验  如果在退货队列中不申请MBR的话 默认时间后就自动完成

                //如果是实验室检验，是否需要申请复检
                //如果是检验员检验，不合格直接放到退货队列
                if (ReInspection_BLL.isReInspectionNeeded(form_ID))
                {
                    //提示 是否需要复检 
                }
                else
                {
                    QT_Goods_Returned goods = new QT_Goods_Returned();
                    goods.Batch_No = Convert.ToString(ViewState["batch_No"]);
                    goods.Form_ID = form_ID;
                    goods.Reject = "";
                    goods.Total = "";
                    goods.Vendor_Code = "";
                    goods.Reason = "";
                    goods.Scar_ID = "";
                    goods.Factory_Name = Session["Factory_Name"].ToString();
                    goods.Status = "退货";
                    //插入到退货表中
                    GoodsReturned_BLL.addGoodReturned(goods);

                    SurveyReport_BLL.updateSurveyStatus(form_ID, "完成");
                }
            }
        }


        /// <summary>
        /// 只有质量部文员才可见 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void reInspection_Click(object sender, EventArgs e)
        {

            //判断是否 不合格 只有在不合格的情况下才能复检
            string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            if(position_Name.Equals("质量部文员"))
            {
                //开始复检申请 
                startReInspection();
            }
        }


        /// <summary>
        /// 复检
        /// </summary>
        private void startReInspection()
        {
            //ViewState暂不可用  原因不详

            //string form_ID = Convert.ToString(ViewState["form_ID"]);
            string form_ID = SurveyReport_BLL.getReportFormID(Convert.ToString(ViewState["batch_No"]));
            string batch_No = Convert.ToString(ViewState["batch_No"]);
            //先生成一个新的表
            int n = ReInspection_BLL.addReInspectionServeyReport(Convert.ToString(ViewState["batch_No"]));
            string newFormID = ReInspection_BLL.getReInspectionSurveyFormID(Convert.ToString(ViewState["batch_No"]), n);
            //插入到复检表
            ReInspection_BLL.addReInspection(newFormID, form_ID, batch_No);

            //更新待建列表里面的form_ID?
            int result = SurveyReport_BLL.upDateFormID(batch_No, newFormID);

            if (result == 1)
            {
                //发送邮件 通知实验室

                //更改实验室检验的Status 并标识Remark 为复检

                LocalScriptManager.CreateScript(Page, String.Format("reInspectionTips('{0}')", "复检申请成功 静待结果"), "reInspectionTips");
            }
            //回退
        }

        protected void addItem_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}