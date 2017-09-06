using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class FileOverDue : System.Web.UI.Page
    {
        public Dictionary<string, Dictionary<string, string[]>> info;
        private string serializedJson;
        private static string factory;

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
             * 
             * 需要上传文件  并将上传的文件进行处理 类似于审批的时候的文件上传
             * 要是因为文件不过  需要提供一个文件覆盖的功能
             * 
             */
            if (!IsPostBack)
            {
                readVendorInfo();
            }
            else
            {
                //重新读取供应商列表
                LocalScriptManager.CreateScript(Page, "getParams()", "getparams");

                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "refreshVendor":
                        refreshVendor(Request.Form["__EVENTARGUMENT"]);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 获取此用户所管理的供应商列表
        /// </summary>
        private void readVendorInfo()
        {
            info = TempVendor_BLL.readVendorInfo(Session["Employee_ID"].ToString(),true);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            serializedJson = jss.Serialize(info);
            LocalScriptManager.CreateScript(Page, String.Format("setParams('{0}')", serializedJson), "params");
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "upload")
            {
                //只负责上传文件  保存的时候由于原来的文件已经存在  但是不能删除 需要进行控制
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempVendorID = GridView1.Rows[drv.RowIndex].Cells[1].Text;
                string tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
                string fileTypeID = File_Type_BLL.selectFileTypeID(GridView1.Rows[drv.RowIndex].Cells[0].Text.ToString().Trim(),tempVendorID);//获取file_Type_ID
                string requestType = "fileUpload";
                string factory = Request.Form["quiz1"];//厂
                LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}','{4}')", requestType, tempVendorID, tempVendorName, fileTypeID, factory), "upload");
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView2.Rows[drv.RowIndex].Cells[0].Text;
            string temp_Vendor_ID = GridView2.Rows[drv.RowIndex].Cells[1].Text;
            string optional = GridView2.Rows[drv.RowIndex].Cells[2].Text;//可选与必选
            string status = GridView2.Rows[drv.RowIndex].Cells[3].Text;//状态标志  如果为审批中 无法再次重填
            string submit = "";//提交的顺序控制
            string aimPageName = "";

            /*
             *获取gridview中的所有表的优先级  
             */
            //if (status == "审批中")
            //{
            //    //弹窗提示
            //    //LocalScriptManager.CreateScript(Page, "messageBox('已经在审批中，不能重新填写！');", "test");
            //    return;
            //}
            string form_Type_ID = AddForm_BLL.GetForm_Type_ID(formid);
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(form_Type_ID);
            //string form_Type_ID = "004";
            //int selectedFormPriorityNumber = 4;
            if (optional == "可选")
            {
                if (withOutAccess(selectedFormPriorityNumber, temp_Vendor_ID) && isOptionalMinimum(selectedFormPriorityNumber, temp_Vendor_ID) && isRequiredMinimum(selectedFormPriorityNumber, temp_Vendor_ID))
                {
                    submit = "yes";
                }
                else
                {
                    submit = "no";
                }
            }
            if (optional == "必选")
            {
                if (isMinimum(selectedFormPriorityNumber, temp_Vendor_ID))
                {
                    submit = "yes";
                }
                else
                {
                    submit = "no";
                }
            }

            if (e.CommandName == "refill")
            {
                /*
                 * 需要进行文件检查 查看文件是否已经上传
                 * 
                 */
                if (formid.Contains("BiddingForm"))//比价表
                {
                    //获取最新表的所有值
                    As_Bidding_Approval bidding = new As_Bidding_Approval();
                    As_Bidding_Approval newbidding = new As_Bidding_Approval();
                    bidding = As_Bidding_Approval_BLL.getBiddingForm(formid);
                    newbidding.Form_ID = bidding.Form_ID;
                    newbidding.Form_Type_ID = bidding.Form_Type_ID;
                    newbidding.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    newbidding.Flag = 0;
                    As_Bidding_Approval_BLL.addBiddingForm(newbidding);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newbidding.Form_Type_ID);
                    news.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, bidding.Temp_Vendor_ID, bidding.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    ////添加到As_Vendor_Form_Type;
                    //As_Vendor_Form_Type vendor = new As_Vendor_Form_Type();
                    //vendor.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    //vendor.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(bidding.Temp_Vendor_ID);
                    //vendor.Factory_Name = DropDownList1.SelectedValue;
                    //vendor.Form_Type_ID = newbidding.Form_Type_ID;
                    //vendor.Form_Type_Name = news.Form_Name;
                    //vendor.Form_ID = form_ID;
                    //vendor.Flag = 0;
                    //FormOverDue_BLL.addVendorFormType(vendor);//触发器会将原来的插入到history中

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
                    newvendor.Flag = 0;
                    As_Vendor_Designated_Apply_BLL.addForm(newvendor);

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
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
                    newvendor.Flag = 0;
                    VendorCreation_BLL.addVendorCreation(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
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
                    newvendor.Flag = 0;
                    VendorExtend_BLL.addVendorExtend(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
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
                    newvendor.Flag = 0;
                    VendorBlockOrUnBlock_BLL.addVendorBlock(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
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
                    newvendor.Flag = 0;
                    VendorDiscovery_BLL.addVendorDiscovery(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
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
                    VendorRiskAnalysis_BLL.addVendorRisk(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
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
                    newvendor.Flag = 0;
                    ContractApproval_BLL.addContractApproval(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
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
                    newvendor.Flag = 0;
                    VendorSelection_BLL.addVendorSelection(newvendor);//添加纪录 当查找的时候会找到最新的这张表

                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = Request.Form["quiz1"];
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    aimPageName = "VendorSelection.aspx";
                }
                Response.Redirect(aimPageName + "?submit=" + submit + "&type=" + form_Type_ID);
            }
        }

        private void refreshVendor(string Temp_Vendor_ID)
        {
            //获取该供应商所有应文件过期而需要重新审批的表
            factory = Request.Form["quiz1"];
            if (Temp_Vendor_ID != null)//通过VendorID来加载数据库中该供应商的过期文件
            {                //先获取该供应商所有过期的文件
                PagedDataSource dataSource = new PagedDataSource();
                dataSource.DataSource = FileOverDue_BLL.getOverDueFile(Temp_Vendor_ID, factory);
                //只显示未上传的文件
                GridView1.DataSource = dataSource;
                GridView1.DataBind();//只负责新文件的上传
                dataSource.DataSource = FileOverDue_BLL.getOverDueForm(Temp_Vendor_ID, factory);
                GridView2.DataSource = dataSource;
                GridView2.DataBind();
                Session["tempVendorID"] = Temp_Vendor_ID;
            }
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

    }
}
