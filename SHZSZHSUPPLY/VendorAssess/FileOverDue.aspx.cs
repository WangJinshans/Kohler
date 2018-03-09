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

        private static string temp_Vendor_ID;
        private static string submit = "";

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //showVendorOverDue();
            if (!IsPostBack)
            {
                //readVendorInfo();
                //权限检查
                string position = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
                string factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());
                bool isAuthority = false;
                if (position.Equals("采购部经理") && factory_Name.Equals("上海科勒"))
                {
                    isAuthority = true;
                }
                else if (position.Equals("供应链经理") && factory_Name.Equals("珠海科勒"))
                {
                    isAuthority = true;
                }



                //有权限操作过期
                if (isAuthority)
                {
                    readOverDueForms();
                }

            }
            else
            {
                //重新读取供应商列表
                LocalScriptManager.CreateScript(Page, "getParams()", "getparams");
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "refreshVendor":
                        readOverDueForms(/*Request.Form["__EVENTARGUMENT"]*/);
                        break;
                    default:
                        break;
                }
            }
        }

        private void readOverDueForms()
        {
            PagedDataSource source = new PagedDataSource();
            source.DataSource = FormOverDue_BLL.listOverDueForms();
            GridView2.DataSource = source;
            GridView2.DataBind();
        }

        private void refreshVendor()
        {
            //showVendorFiles();
            //showVendorRelatedForms(Session["overdue_tempVendorID"].ToString());

            //显示所有过期的表格 
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

        private string canSubmit(string vendorType, string tempVendorID)
        {
            if (withOutAccess(vendorType, tempVendorID))
            {
                return "yes";
            }
            return "no";
        }

        /// <summary>
        /// 分为存在FormID和不存在FormID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formID = GridView2.Rows[drv.RowIndex].Cells[0].Text;
            string form_Type_ID = GridView2.Rows[drv.RowIndex].Cells[1].Text;
            string vendrType = GridView2.Rows[drv.RowIndex].Cells[3].ToString();
            temp_Vendor_ID = GridView2.Rows[drv.RowIndex].Cells[4].Text;
            string tempVendorName = TempVendor_BLL.getTempVendorName(temp_Vendor_ID);

            string optional = GridView2.Rows[drv.RowIndex].Cells[2].Text;//可选与必选
            string status = GridView2.Rows[drv.RowIndex].Cells[3].Text;//状态标志 
           
            string aimPageName = "";
            string submit = canSubmit(vendrType, temp_Vendor_ID);//提交的顺序控制
            if (e.CommandName == "refill")
            {
                //更改flag 进入页面就会该表就会跳转到待提交表格中去
                #region
                if (formID.Contains("BiddingForm"))//比价表
                {
                    As_Bidding_Approval biddingApproval = new As_Bidding_Approval();
                    biddingApproval.Form_Type_ID = form_Type_ID;
                    biddingApproval.Temp_Vendor_Name = tempVendorName;
                    biddingApproval.Temp_Vendor_ID = temp_Vendor_ID;
                    //TODO:: 申请人自己选择？
                    //biddingApproval.Initiator = String.Format(Signature_BLL.urlPath, Session["Employee_ID"]);

                    biddingApproval.Flag = 0;//将表格标志位信息改为已填写
                    biddingApproval.Factory_Name = Session["Factory_Name"].ToString();

                    int n = As_Bidding_Approval_BLL.addBiddingForm(biddingApproval);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        formID = As_Bidding_Approval_BLL.getVendorBiddingFormID(temp_Vendor_ID, form_Type_ID, factory, n);

                        //添加单独绑定的文件
                        VendorSingleFile_BLL.addSingleFile(formID, form_Type_ID, temp_Vendor_ID, tempVendorName, factory);
                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = temp_Vendor_ID;
                        forms.Temp_Vendor_Name = tempVendorName;
                        forms.Form_Type_ID = form_Type_ID;
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = factory;
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);
                        aimPageName = "BiddingApprovalForm.aspx";
                    }
                }
                #endregion
                #region
                if (formID.Contains("VendorDesignated"))//指定供应商申请表
                {
                    As_Vendor_Designated_Apply vendorDesignatedApply = new As_Vendor_Designated_Apply();
                    vendorDesignatedApply.Form_Type_ID = form_Type_ID;
                    vendorDesignatedApply.VendorName = tempVendorName;
                    vendorDesignatedApply.Temp_Vendor_ID = temp_Vendor_ID;
                    vendorDesignatedApply.Flag = 0;//将表格标志位信息改为初始
                    vendorDesignatedApply.Factory_Name = Session["Factory_Name"].ToString();

                    int n = As_Vendor_Designated_Apply_BLL.addForm(vendorDesignatedApply);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        formID = As_Vendor_Designated_Apply_BLL.getVendorDesignatedFormID(temp_Vendor_ID, form_Type_ID, factory, n);

                        //添加单独绑定的文件
                        VendorSingleFile_BLL.addSingleFile(formID, form_Type_ID, temp_Vendor_ID, tempVendorName, factory);

                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = temp_Vendor_ID;
                        forms.Temp_Vendor_Name = tempVendorName;
                        forms.Form_Type_ID = form_Type_ID;
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = factory;
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);
                        aimPageName = "VendorDesignatedApply.aspx";
                    }
                }
                #endregion
                #region
                if (formID.Contains("ContractApproval"))//合同审批表
                {
                    As_Contract_Approval vendorContract = new As_Contract_Approval();
                    vendorContract.Temp_Vendor_ID = temp_Vendor_ID;
                    vendorContract.Form_Type_ID = form_Type_ID;
                    vendorContract.Vendor_Name = tempVendorName;
                    vendorContract.Flag = 0;//将表格标志位信息改为0
                    vendorContract.Factory_Name = Session["Factory_Name"].ToString();


                    //名字只读

                    int n = ContractApproval_BLL.addContractApproval(vendorContract);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        formID = ContractApproval_BLL.getVendorContractApprovalFormID(temp_Vendor_ID, form_Type_ID, factory, n);

                        VendorSingleFile_BLL.addSingleFile(formID, form_Type_ID, temp_Vendor_ID, tempVendorName, factory);

                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = temp_Vendor_ID;
                        forms.Temp_Vendor_Name = tempVendorName;
                        forms.Form_Type_ID = form_Type_ID;
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = factory;
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);
                        aimPageName = "ContractApprovalForm.aspx";
                    }
                    #endregion
                    Response.Redirect(aimPageName + "?submit=" + submit + "&type=" + form_Type_ID + "&Form_ID=" + formID);
                }
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
        //只检查该供应商是否还存在审批
        private bool withOutAccess(string vendorType, string temp_vendor_ID)
        {
            return FormType_BLL.withOutAccess(vendorType, temp_vendor_ID);
        }
        private string getFormTypeIDByItemCategory(string itemCategory, string tempVendorID, string factory)
        {
            return FileOverDue_BLL.getFormTypeIDByItemCategory(itemCategory, tempVendorID, factory);
        }
    }
}