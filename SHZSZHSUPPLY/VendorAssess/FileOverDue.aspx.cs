using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class FileOverDue : System.Web.UI.Page
    {
        public Dictionary<string, Dictionary<string, string[]>> info;
        private string serializedJson;
        private static string factory;
        private static Dictionary<string, string> fileWithForm = new Dictionary<string, string>();

        private string temp_Vendor_ID;

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            showVendorOverDue();
            if (!IsPostBack)
            {
                //readVendorInfo();
            }
            else
            {
                //重新读取供应商列表
                LocalScriptManager.CreateScript(Page, "getParams()", "getparams");
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "refreshVendor":
                        refreshVendor(/*Request.Form["__EVENTARGUMENT"]*/);
                        break;
                    default:
                        break;
                }
            }
        }

        private void refreshVendor()
        {
            //string tempVendor = "TempVendor29";
            //factory = "上海科勒";
            ////获取该供应商所有应文件过期而需要重新审批的表
            ////factory = Request.Form["quiz1"];
            //if (Temp_Vendor_ID != null)//通过VendorID来加载数据库中该供应商的过期文件
            //{                //先获取该供应商所有过期的文件
            //    PagedDataSource dataSource = new PagedDataSource();
            //    dataSource.DataSource = FileOverDue_BLL.getOverDueForm(Temp_Vendor_ID, factory);
            //    GridView2.DataSource = dataSource;
            //    GridView2.DataBind();
            //    Session["tempVendorID"] = Temp_Vendor_ID;
            //}
            showVendorFiles();
            showVendorRelatedForms(Session["overdue_tempVendorID"].ToString());
        }

        /// <summary>
        /// 显示该职位需要处理的所有过期文献 
        /// </summary>
        /// <param name="tempVendor"></param>
        /// <param name="factory"></param>
        private void showVendorFiles()
        {
            PagedDataSource source = new PagedDataSource();
            source.DataSource = FileOverDue_BLL.getOverDueFile();
            GridView1.DataSource = source;
            GridView1.DataBind();
        }


        /// <summary>
        /// 过期的供应商列表
        /// </summary>
        private void showVendorOverDue()
        {
            PagedDataSource source = new PagedDataSource();
            source.DataSource = FileOverDue_BLL.getVendorOverDue();
            GridView3.DataSource = source;
            GridView3.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //只负责文件的上传
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string tempVendorID = GridView1.Rows[drv.RowIndex].Cells[1].Text;
            string tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            string itemCategory = HttpUtility.HtmlDecode(GridView1.Rows[drv.RowIndex].Cells[0].Text);
            string fileTypeID = File_Type_BLL.selectFileTypeID(GridView1.Rows[drv.RowIndex].Cells[0].Text.ToString().Trim(), tempVendorID);//获取file_Type_ID
            string requestType = "overDueUpload";
            if (e.CommandName == "upload")
            {
                LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}')", requestType, tempVendorID, tempVendorName, fileTypeID), "upload");
            }
        }

        /// <summary>
        /// 检查是否已经创建了最新的表格
        /// </summary>
        /// <returns></returns>
        private bool hasNewForm(string formid)
        {
            int result = 0;
            if (formid.Contains("BiddingForm"))//比价表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Bidding_Approval_Form");
            }
            if (formid.Contains("VendorDesignated"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Vendor_Designated_Apply");
            }
            if (formid.Contains("VendorCreation"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_VendorCreation");
            }
            if (formid.Contains("VendorExtend"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Vendor_Extend");
            }
            if (formid.Contains("VendorBlock"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Vendor_Block_Or_UnBlock");
            }
            if (formid.Contains("VendorDiscovery"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Vendor_Discovery");
            }
            if (formid.Contains("VendorRisk"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Vendor_Risk");
            }
            if (formid.Contains("ContractApproval"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Contract_Approval");
            }
            if (formid.Contains("VendorSelection"))//指定供应商申请表
            {
                result = FileOverDue_BLL.checkForm(formid, "As_Vendor_Selection");
            }

            return result>=1;
        }

        /// <summary>
        /// redirect
        /// </summary>
        /// <param name="commandArgument"></param>
        /// <param name="tempVendorID"></param>
        private string switchPage(string formTypeID)
        {
            string url = "";
            switch (formTypeID)
            {
                case "001":
                    url = "VendorDiscovery.aspx";
                    break;
                case "002":
                    url = "BiddingApprovalform.aspx";
                    break;
                case "013":
                    url = "BiddingApprovalform.aspx";
                    break;
                case "014":
                    url = "BiddingApprovalform.aspx";
                    break;
                case "015":
                    url = "BiddingApprovalform.aspx";
                    break;
                case "016":
                    url = "BiddingApprovalform.aspx";
                    break;
                case "017":
                    url = "BiddingApprovalform.aspx";
                    break;
                case "003":
                    url = "VendorRiskAnalysis.aspx";
                    break;
                case "004":
                    url = "VendorDesignatedApply.aspx";
                    break;
                case "025":
                    url = "VendorDesignatedApply.aspx";
                    break;
                case "005":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "006":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "007":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "008":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "009":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "010":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "011":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "012":
                    url = "ContractApprovalForm.aspx";
                    break;
                case "018":
                    url = "VendorSelection.aspx";
                    break;
                case "019":
                    url = "VendorCreation.aspx";
                    break;
                default:
                    break;
            }
            return url;
        }

        private string canSubmit(string formID,string formTypeID)
        {
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(formTypeID);
            if (withOutAccess(selectedFormPriorityNumber, Session["tempVendorID"].ToString()) && isOptionalMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()) && isRequiredMinimum(selectedFormPriorityNumber, Session["tempVendorID"].ToString()))
            {
                return "yes";
            }
            return "no";
        }

        /// <summary>
        /// GridView1中需要上传文件 并且文件上传成功之后回掉回初始化GridView2
        /// GridView2 负责与该文件有绑定关系的所有表的处理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView2.Rows[drv.RowIndex].Cells[0].Text;
            string temp_Vendor_ID = GridView2.Rows[drv.RowIndex].Cells[1].Text;
            string optional = GridView2.Rows[drv.RowIndex].Cells[2].Text;//可选与必选
            string status = GridView2.Rows[drv.RowIndex].Cells[3].Text;//状态标志 

            string form_Type_ID = AddForm_BLL.GetForm_Type_ID(formid);
            string aimPageName = "";
            string submit = canSubmit(formid,form_Type_ID);//提交的顺序控制

            if (e.CommandName == "refill")
            {
                if (hasNewForm(formid))
                {
                    aimPageName = switchPage(form_Type_ID);
                    Response.Redirect(aimPageName + "?submit=" + submit + "&type=" + form_Type_ID);
                    return;
                }

                if (formid.Contains("BiddingForm"))//比价表
                {
                    //获取最新表的所有值
                    As_Bidding_Approval bidding = new As_Bidding_Approval();
                    As_Bidding_Approval newbidding = new As_Bidding_Approval();
                    bidding = As_Bidding_Approval_BLL.getBiddingForm(formid);
                    newbidding.Form_ID = bidding.Form_ID;
                    newbidding.Form_Type_ID = bidding.Form_Type_ID;
                    newbidding.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    newbidding.Factory_Name = bidding.Factory_Name;
                    newbidding.Temp_Vendor_Name = bidding.Temp_Vendor_Name;
                    newbidding.Flag = 0;
                    As_Bidding_Approval_BLL.addBiddingForm(newbidding);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newbidding.Form_Type_ID);
                    news.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, bidding.Temp_Vendor_ID, bidding.Form_ID);//这一步 在进入表的时候会自动绑定一次
                    Response.Redirect("BiddingApprovalForm.aspx");//跳进去session的问题暂时没有处理
                }
                if (formid.Contains("VendorDesignated"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Vendor_Designated_Apply vendor = new As_Vendor_Designated_Apply();
                    As_Vendor_Designated_Apply newvendor = new As_Vendor_Designated_Apply();
                    vendor = As_Vendor_Designated_Apply_BLL.checkFlag(formid);
                    newvendor.Form_id = vendor.Form_id;
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.VendorName = vendor.VendorName;
                    newvendor.Flag = 0;
                    As_Vendor_Designated_Apply_BLL.addForm(newvendor);

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_id);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorDesignatedApply.aspx";
                }
                if (formid.Contains("VendorCreation"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Vendor_Creation vendor = new As_Vendor_Creation();
                    As_Vendor_Creation newvendor = new As_Vendor_Creation();
                    vendor = VendorCreation_BLL.getVendorCreation(formid);
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.Vendor_Name = TempVendor_BLL.getTempVendorName(newvendor.Temp_Vendor_ID);
                    newvendor.Form_ID = vendor.Form_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.Vendor_Name = vendor.Vendor_Name;
                    newvendor.Flag = 0;
                    VendorCreation_BLL.addVendorCreation(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorCreation.aspx";
                }
                if (formid.Contains("VendorExtend"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Vendor_Extend vendor = new As_Vendor_Extend();
                    As_Vendor_Extend newvendor = new As_Vendor_Extend();
                    vendor = VendorExtend_BLL.getVendorExtend(formid);
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Form_ID = vendor.Form_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.Temp_Vendor_Name = vendor.Temp_Vendor_Name;
                    newvendor.Flag = 0;
                    VendorExtend_BLL.addVendorExtend(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorExtend.aspx";
                }
                if (formid.Contains("VendorBlock"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Vendor_Block_Or_UnBlock vendor = new As_Vendor_Block_Or_UnBlock();
                    As_Vendor_Block_Or_UnBlock newvendor = new As_Vendor_Block_Or_UnBlock();
                    vendor = VendorBlockOrUnBlock_BLL.getVendorBlock(formid);
                    newvendor.Form_ID = vendor.Form_ID;
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.Temp_Vendor_Name = vendor.Temp_Vendor_Name;
                    newvendor.Flag = 0;
                    VendorBlockOrUnBlock_BLL.addVendorBlock(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorBlockOrUnBlock.aspx";
                }
                if (formid.Contains("VendorDiscovery"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Vendor_Discovery vendor = new As_Vendor_Discovery();
                    As_Vendor_Discovery newvendor = new As_Vendor_Discovery();
                    vendor = VendorDiscovery_BLL.checkFlag(formid);
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Form_ID = vendor.Form_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.Temp_Vendor_Name = vendor.Temp_Vendor_Name;
                    newvendor.Flag = 0;
                    VendorDiscovery_BLL.addVendorDiscovery(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorDiscovery.aspx";
                }
                if (formid.Contains("VendorRisk"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Vendor_Risk vendor = new As_Vendor_Risk();
                    As_Vendor_Risk newvendor = new As_Vendor_Risk();
                    vendor = VendorRiskAnalysis_BLL.checkFlag(formid);
                    newvendor.Form_ID = vendor.Form_ID;
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Flag = 0;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor = vendor;
                    VendorRiskAnalysis_BLL.addVendorRisk(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorRiskAnalysis.aspx";
                }
                if (formid.Contains("ContractApproval"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Contract_Approval vendor = new As_Contract_Approval();
                    As_Contract_Approval newvendor = new As_Contract_Approval();
                    vendor = ContractApproval_BLL.getContractApproval(formid);
                    newvendor.Form_ID = vendor.Form_ID;
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.Temp_Vendor_Name = vendor.Temp_Vendor_Name;
                    newvendor.Vendor_Name = vendor.Vendor_Name;
                    newvendor.Flag = 0;
                    ContractApproval_BLL.addContractApproval(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "ContractApprovalForm.aspx";
                }
                if (formid.Contains("VendorSelection"))//指定供应商申请表
                {
                    //获取最新表的所有值
                    As_Vendor_Selection vendor = new As_Vendor_Selection();
                    As_Vendor_Selection newvendor = new As_Vendor_Selection();
                    vendor = VendorSelection_BLL.checkFlag(formid);
                    newvendor.Form_ID = vendor.Form_ID;
                    newvendor.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Factory_Name = vendor.Factory_Name;
                    newvendor.Temp_Vendor_Name = vendor.Temp_Vendor_Name;
                    newvendor.Flag = 0;
                    VendorSelection_BLL.addVendorSelection(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Session["Factory_Name"].ToString();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorSelection.aspx";
                }
                Response.Redirect(aimPageName + "?submit=" + submit + "&type=" + form_Type_ID);
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string temp_Vendor_ID = GridView3.Rows[drv.RowIndex].Cells[0].Text;
            Session["overdue_tempVendorID"] = temp_Vendor_ID;
            if (e.CommandName == "showDetails")
            {
                showVendorFiles();
                showVendorRelatedForms(temp_Vendor_ID);
            }
        }




        private void showVendorRelatedForms(string Temp_Vendor_ID)
        {
            factory = Session["Factory_Name"].ToString();
            //获取该供应商所有应文件过期而需要重新审批的表
            if (Temp_Vendor_ID != null)//通过VendorID来加载数据库中该供应商的过期文件
            {                //先获取该供应商所有过期的文件
                PagedDataSource dataSource = new PagedDataSource();
                //插入到表过期中
                IList<As_Form_OverDue> lists = FileOverDue_BLL.getOverDueForm(Temp_Vendor_ID, factory);
                if (lists == null)
                {
                    return;
                }
                if (lists.Count > 0)
                {
                    foreach (As_Form_OverDue overDue in lists)
                    {
                        //FormOverDue_BLL.addOverDueForm(overDue);
                        if (overDue.Status != "Hold")
                        {
                            FormOverDue_BLL.addOverDueForm(overDue);
                        }
                    }
                }
                dataSource.DataSource = FileOverDue_BLL.getVendorFormOverDue(factory, Temp_Vendor_ID);
                GridView2.DataSource = dataSource;
                GridView2.DataBind();
                Session["tempVendorID"] = Temp_Vendor_ID;
            }
        }


        /// <summary>
        /// 获取此用户所管理的供应商列表
        /// </summary>
        private void readVendorInfo()
        {
            info = TempVendor_BLL.readVendorInfo(Session["Employee_ID"].ToString(), true);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            serializedJson = jss.Serialize(info);
            LocalScriptManager.CreateScript(Page, String.Format("setParams('{0}')", serializedJson), "params");
        }


        private bool withOutAccess(int number, string temp_vendor_ID)
        {
            return FormType_BLL.withOutAccess(number, temp_vendor_ID);
        }
        private bool isOptionalMinimum(int number, string temp_Vendor_ID)
        {
            return FormType_BLL.isOptionalMinimum(number, temp_Vendor_ID);
        }
        private bool isRequiredMinimum(int number, string temp_Vendor_ID)//可选表前面的必须表都已经审完
        {
            return FormType_BLL.isRequiredMinimum(number, temp_Vendor_ID);
        }
        private int getSelectedFormPriorityNumber(string formTypeID)
        {
            return FormType_BLL.getSelectedFormPriorityNumber(formTypeID);
        }
        private bool isMinimum(int number, string temp_Vendor_ID)
        {
            bool ok = withOutAccess(number, temp_Vendor_ID);
            if (ok)
            {
                return FormType_BLL.isMinimumFormPriorityNumber(number, temp_Vendor_ID);
            }
            else
            {
                return false;
            }

        }
        private string getFormTypeIDByItemCategory(string itemCategory, string tempVendorID, string factory)
        {
            return FileOverDue_BLL.getFormTypeIDByItemCategory(itemCategory, tempVendorID, factory);
        }
        private void showForms(string tempVendorID,string factory)
        {
            if (tempVendorID != null)//通过VendorID来加载数据库中该供应商的过期文件
            {
                PagedDataSource dataSource = new PagedDataSource();
                dataSource.DataSource = FormOverDue_BLL.getOverDueForm(tempVendorID, factory);
                GridView3.DataSource = dataSource;
                GridView3.DataBind();
                Session["tempVendorID"] = tempVendorID;
            }
        }
    }
}








