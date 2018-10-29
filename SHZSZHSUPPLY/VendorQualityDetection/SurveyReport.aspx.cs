using BLL;
using BLL.QualityDetection;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
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
                showInspectionValues(Convert.ToString(ViewState["form_ID"]));
                if (Session["Factory_Name"].Equals("上海科勒"))
                {
                    map.HRef = "I:\\ShanghaiKohlerManagementSystem-All-needed\\system\\daily maintenance\\drawings link.htm";
                }
                else
                {

                }
                //绩效评估部分的免检

            }
            else
            {
                //操作填表数据
                ViewState["itemValue"] = Request.Form["_itemValue"].ToString();

                switch (Request.Form["__EVENTTARGET"])
                {
                    case "check_noneed":
                        //免检
                        noCheck();
                        break;
                    case "addItem":
                        //添加检验项目 并且刷新 重新加载检验项
                        addInspectionItem(Request.Form["__EVENTARGUMENT"]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void showInspectionValues(string form_ID)
        {
            DataTable table = SurveyReport_BLL.showInspectionResults(form_ID);
            List<InspectionResult> list = new List<InspectionResult>();
            InspectionResult result = null;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    result = new InspectionResult();
                    result.Result = Convert.ToString(dr["Result"]);
                    result.Judgement = Convert.ToString(dr["Judgement"]);
                    list.Add(result);
                }
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string serializedJson = jss.Serialize(list);
            LocalScriptManager.CreateScript(Page, String.Format("showInspectionResults('{0}')", serializedJson), "showResults");
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
        private void showMRBpart(string form_ID)
        {

            if (MBR_BLL.isMBRNeeded(form_ID) && MBR_BLL.isMBRFinished(form_ID))
            {

                //获取结论
                string result = MBR_BLL.getMBRResult(form_ID);

                //显示
                LocalScriptManager.CreateScript(Page, String.Format("showMRB('{0}')", result), "showMRB");
            }

        }


        /// <summary>
        /// 初始化整个页面
        /// </summary>
        private void initSurveryReport()
        {
            //根据物料编号 确定需要的检测项
            DataTable source = SurveyReport_BLL.getInsectionItems(Convert.ToString(ViewState["sku"]));
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

            //Text 补全
            string form_ID = Convert.ToString(ViewState["form_ID"]);

            showMRBpart(form_ID);
            showReInspectionButton();

            //如果该SKU不是第一次检验  则直接添加权限为false
            if (Material_Inspection_Item_BLL.IsOld(Convert.ToString(ViewState["sku"])))
            {
                addItem.Visible = false;
                SurveyReport_BLL.setAddPermission("false", form_ID);
            }

            //添加检验项按钮可见性
            string permission = SurveyReport_BLL.getAddPermission(Convert.ToString(ViewState["form_ID"]));
            if (permission.Equals("false"))
            {
                addItem.Visible = false;
            }
            else
            {
                //第一次的提示
                LocalScriptManager.CreateScript(Page, String.Format("MRBtip('{0}')", "由于是第一次检验该物料，请先添加检验项目，第一次保存之后不可添加！"), "AddInspectionTip");
            }
            //图纸链接初始化
            //LocalScriptManager.CreateScript(Page, String.Format("initMap('{0}')", Session["Factory_Name"].ToString()), "maps");
            
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

            remark.Text = SurveyReport_BLL.getReMark(formID);

            //表面检验
            InspectionPlanResult plan = makePlans(0, Convert.ToString(ViewState["vendor_Code"]), Convert.ToString(ViewState["batch_No"]), Convert.ToString(ViewState["sku"]), Convert.ToString(ViewState["Amount"]));
            if (plan != null)//计划成功产出
            {
                appearance_amount.Text = plan.Sample_Amount;
            }
            //适配性检验
            InspectionPlanResult plans = makePlans(0, Convert.ToString(ViewState["vendor_Code"]), Convert.ToString(ViewState["batch_No"]), Convert.ToString(ViewState["sku"]), Convert.ToString(ViewState["Amount"]));
            if (plan != null)//计划成功产出
            {
                suitability_amount.Text = plans.Sample_Amount;
            }


            //检验类型初始化 inspection_Type

        }

        private void getSessionInfo()
        {
            ViewState["sku"] = Request.QueryString["sku"].ToString();
            ViewState["batch_No"] = Request.QueryString["batch_No"].ToString();
            ViewState["vendor_Code"] = Request.QueryString["vendor_Code"].ToString();
            ViewState["Amount"] = Request.QueryString["Amount"].ToString();
            ViewState["product_Name"] = Request.QueryString["product_Name"].ToString();
            ViewState["time"] = Request.QueryString["time"].ToString();
            ViewState["inspection_Type"] = Request.QueryString["inspection_Type"].ToString();

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

        }


        /// <summary>
        /// 保存表格
        /// </summary>
        private void save()
        {
            string values = Convert.ToString(ViewState["itemValue"]);
            string sku = Convert.ToString(ViewState["sku"]);
            string form_ID = Convert.ToString(ViewState["form_ID"]);

            //保存到数据库
            SurveyReport_BLL.saveInspectionValue(sku, form_ID, values);

            QT_Survey survey = new QT_Survey();
            survey.Form_ID = form_ID;
            survey.SKU = sku;

            //检验数量
            survey.Sureface_Amount = appearance_amount.Text;
            survey.Suitability_Amount = suitability_amount.Text;
            survey.Sureface_Bad = appearance_bad.Text;
            survey.Suitability_Bad = suitability_bad.Text;
            survey.Sureface_Details = appearance_detail.Text;
            survey.Suitability_Details = suitability_detail.Text;

            //备注
            survey.Remark = remark.Text;

            //结果
            survey.Result = qualified_list.SelectedIndex.ToString();
            //是否合格
            survey.Un_Inspection_Type = unqualified_type_list.SelectedIndex.ToString();

            //检验最终接收拒收数量
            survey.RC = rcm.Text;
            survey.RJ = rjm.Text;

            survey.PPAP_Result = lb_ppap.Text;
            survey.Broken_Detection_Result = lb_broken.Text;
            survey.SKU = sku;
            survey.Batch_No = Convert.ToString(ViewState["batch_No"]);
            survey.Product_Name = Convert.ToString(ViewState["product_Name"]);
            survey.Vendor_Code= Convert.ToString(ViewState["vendor_Code"]);

            survey.Purchase_No = TextBox5.Text;
            survey.Arrave_Time = TextBox7.Text;
            survey.Amount = TextBox6.Text;
            survey.Region_Market = Convert.ToString(lb_region.Text);


            //保存该表其他地方
            SurveyReport_BLL.updateSurvey(survey);


            //让质量部文员以及检验员失去添加功能
            SurveyReport_BLL.setAddPermission("false", form_ID);
            //更新检验
            if (Material_Inspection_Item_BLL.IsOld(Convert.ToString(ViewState["sku"])))
            {
                Material_Inspection_Item_BLL.setOld(form_ID);
            }
            //提示 保存成功

            LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "保存成功"), "saveTip");

            showInspectionValues(Convert.ToString(ViewState["form_ID"]));
        }


        #region 检查计划
        /// <summary>
        /// 生成抽样检查计划 
        /// </summary>
        private InspectionPlanResult makePlans(int inspetionType, string vendor_Code, string batch_No, string SKU, string amount)
        {
            //获取检验方式 加严 放宽  正常
            int result = SurveyReport_BLL.getInspectionMethod(vendor_Code, SKU);

            //AQL
            string aql = Material_Inspection_Item_BLL.getAQL(SKU);

            //检验水平
            string class_Leval = "";
            if (inspetionType == 0)
            {
                class_Leval = Material_Inspection_Item_BLL.getSurfaceClassLeval(SKU);
            }
            else
            {
                class_Leval = Material_Inspection_Item_BLL.getSuitabilityClassLeval(SKU);
            }
            

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
        private InspectionPlanResult getInspectionPlan(string class_Leval, string amount, string aql, int inspection_Leval)
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

            string inspection_Type = Convert.ToString(ViewState["inspection_Type"]);

            //判断是否是退货检验
            if (inspection_Type.Equals("tuihuo"))
            {
                bool tuihuo = false;
                tuihuo = Convert.ToString(qualified_list.SelectedIndex).Equals("0") ? true : false;

                if (!tuihuo)//不合格
                {
                    //插入到退货信息中
                }
                else
                {
                    //合格不需要退货  ？  
                }
            }

            //委托检验不合格必须要复检 不合格直接进行MBR

            //第一次检验不合格 MBR已经出结果了 也可以提交
            if (MBR_BLL.isMBRNeeded(form_ID))//需要MRB 并且 MRB已经完成
            {
                int flag = 0;//0 进货信息库  1 退货信息库
                if (MBR_BLL.isMBRFinished(form_ID))
                {
                    //获取MBR的结论 
                    //退货     接收为零
                    //挑选全检 需要统计接收与拒收
                    //返工     暂定全部接收 拒收为零
                    //让步接收 全部接收 拒收为零
                    StockInfo info = null;
                    string mbrResult = MBR_BLL.getMBRResult(form_ID);
                    if (mbrResult.Equals("挑选全检"))
                    {
                        info = new StockInfo();

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
                        info.Remark = remark.Text;
                        info.Batch_No = Convert.ToString(ViewState["batch_No"]);

                        //接收 拒收
                        info.RJ = rjm.Text;
                        info.RC = rcm.Text;


                    }
                    else if (mbrResult.Equals("让步接收") || mbrResult.Equals("返工"))
                    {
                        info = new StockInfo();
                        info.RJ = "";
                        info.RC = Convert.ToString(ViewState["Amount"]);
                        info.Batch_No = Convert.ToString(ViewState["batch_No"]);
                        info.Remark = "";
                        info.Source_From = form_ID;
                        if (SurveyReport_BLL.isReInspection(Convert.ToString(ViewState["form_ID"])))
                        {
                            info.Status = "复检";
                        }
                        else
                        {
                            info.Status = "";
                        }
                        info.Add_Time = DateTime.Now.ToString();
                    }
                    else if (mbrResult.Equals("退货"))
                    {
                        //接收为零 加入到退货信息列表中
                        flag = 1;

                        //插入到退货信息表中
                        QT_Goods_Returned goods = new QT_Goods_Returned();
                        goods.Batch_No= Convert.ToString(ViewState["batch_No"]);
                        goods.Form_ID = form_ID;
                        goods.Factory_Name = Convert.ToString(Session["Factory_Name"]);
                        goods.Vendor_Code= Convert.ToString(ViewState["Vendor_Code"]);
                        goods.Total = Convert.ToString(ViewState["Amount"]);
                        goods.Reason = remark.Text;
                        
                        //全部拒收
                        goods.Reject = Convert.ToString(ViewState["Amount"]);
                        
                        //SCARE_ID 暂时无法获取
                        goods.Scar_ID = "";


                        GoodsReturned_BLL.addGoodReturned(goods);


                        //判断是否触发scar
                        if (SCAR_BLL.isSCARQuilifited(Convert.ToString(ViewState["Vendor_Code"]), Convert.ToString(Session["Factory_Name"])) != 0)
                        {
                            //触发Scar
                            QT_SCAR newSCAR = new QT_SCAR();
                            newSCAR.Factory = Session["Factory_Name"].ToString();
                            newSCAR.Batch_No = Request.QueryString["batch_no"];
                            newSCAR.Vendor_Code = Request.QueryString["vendor_code"];

                            newSCAR.Flag = 0;

                            SCAR_BLL.addSCAR(newSCAR);

                        }


                    }

                    if (flag == 0)
                    {
                        //插入到进货信息库
                        StockInfo_BLL.addStockInfo(info);
                        SurveyReport_BLL.updateSurveyStatus(form_ID, "完成");
                        SurveyReport_BLL.setFinished(form_ID);
                        LocalScriptManager.CreateScript(Page, String.Format("mytips_then_back('{0}','{1}')", "检验完成", "InspectionList.aspx"), "operateFinished");
                    }
                }
                else
                {
                    //MBR未出结果  请等待
                    LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "请等待MRB的裁定结果"), "waitMRBResultTip");
                }
                return;
            }

            //是否合格 
            bool isQualified = false;
            isQualified = Convert.ToString(qualified_list.SelectedIndex).Equals("0") ? true : false;
            
            //合格
            if (isQualified)
            {

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
                info.Remark = remark.Text;
                info.Batch_No = Convert.ToString(ViewState["batch_No"]);

                //接收 拒收
                info.RJ = Convert.ToString(ViewState["Amount"]);
                if (appearance_bad.Text.Equals(""))
                {
                    appearance_bad.Text = "0";
                }
                if (suitability_bad.Text.Equals(""))
                {
                    suitability_bad.Text = "0";
                }
                info.RC = Convert.ToString(Convert.ToInt32(appearance_bad.Text) + Convert.ToInt32(suitability_bad.Text));

                //插入到进货信息库
                StockInfo_BLL.addStockInfo(info);

                //更新报告的检验完成 QT_Inspection_List
                SurveyReport_BLL.setFinished(Convert.ToString(ViewState["form_ID"]));

                //更新检验状态
                SurveyReport_BLL.updateSurveyStatus(form_ID, "完成");

                LocalScriptManager.CreateScript(Page, String.Format("addStock('{0}','{1}')", "进货信息储存成功 完成检验", position_Name), "addStock");
            }
            else
            {
                //暂时完成检验  进入MBR队列 默认时间后就自动 退货

                //如果是实验室检验，需要申请复检

                //如果是检验员检验，不合格直接申请MBR
                //如果是委托检验的复检，不合格直接MBR

                int mbr_flag = 1;//需要MBR
                
                //属于复检（第二次） 不合格 开始MBR 属于委托检验
                if (ReInspection_BLL.isReInspection(form_ID))
                {
                    mbr_flag = 1;
                }
                else
                {
                    //是否属于委托检验 
                    if (ReInspection_BLL.isReInspectionNeeded(form_ID))
                    {
                        //提示 需要复检 请点击复检按钮进行申请 
                        LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "请申请复检"), "reInspectionTip");
                        return;
                    }
                }
                if (mbr_flag == 1)
                {
                    //进入MBR 队列  默认时间到后就直接退货
                    //开始MBR 
                    MBR_BLL.startMBR(form_ID, Convert.ToString(ViewState["kci"]));

                    //申请成功
                    LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "已经自动申请MRB"), "MRBTip");

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
            if (position_Name.Equals("质量部文员"))
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
            //复检时需要将原来的表的 检验项目添加的权限复制过来

            //ViewState暂不可用  原因不详

            //string form_ID = Convert.ToString(ViewState["form_ID"]);
            string form_ID = SurveyReport_BLL.getReportFormID(Convert.ToString(ViewState["batch_No"]));
            string batch_No = Convert.ToString(ViewState["batch_No"]);
            //先生成一个新的表
            int n = ReInspection_BLL.addReInspectionServeyReport(Convert.ToString(ViewState["batch_No"]));
            string newFormID = ReInspection_BLL.getReInspectionSurveyFormID(Convert.ToString(ViewState["batch_No"]), n);

            //更新检验员等的添加权限
            SurveyReport_BLL.updateAddPermission(form_ID, newFormID);

            //插入到复检表
            ReInspection_BLL.addReInspection(newFormID, form_ID, batch_No);

            //更新待建列表里面的form_ID?
            int result = SurveyReport_BLL.upDateFormID(batch_No, newFormID);

            if (result == 1)
            {
                //发送邮件 通知实验室

                //更改实验室检验的Status 并标识Remark 为复检
                LabInspectionList_BLL.updateStatus(batch_No, "未完成", "复检");


                LocalScriptManager.CreateScript(Page, String.Format("reInspectionTips('{0}')", "复检申请成功 静待结果"), "reInspectionTips");
            }
            //回退
        }

        /// <summary>
        /// 弹窗 弹出添加 检验项 以及 检验标准
        /// </summary>
        /// <param name="princple">item 与 standard连接</param>
        private void addInspectionItem(string princple)
        {
            string[] data = princple.Split(',');
            string item = data[0];
            string standard = data[1];
            SurveyReport_BLL.addNewInspectionItem(Convert.ToString(ViewState["sku"]), item, standard, "YES");
            initSurveryReport();
        }


        protected void addItem_Click(object sender, EventArgs e)
        {
            LocalScriptManager.CreateScript(Page, "addNewInspectionItem()", "addNewInspectionItem");
        }
    }
}