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
            factory = Session["Factory_Name"].ToString();
            if (!IsPostBack)
            {
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
                    readOverDueForms(factory);
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
                        readOverDueForms(factory);
                        break;
                    default:
                        break;
                }
            }
        }

        private void readOverDueForms(string factory_Name)
        {
            PagedDataSource source = new PagedDataSource();
            source.DataSource = FormOverDue_BLL.listOverDueForms(factory_Name);
            GridView2.DataSource = source;
            GridView2.DataBind();
        }

        private string canSubmit(string factory, string tempVendorID)
        {
            if (!withOutAccess(factory, tempVendorID))
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
            Session["tempVendorID"] = temp_Vendor_ID;
            string tempVendorName = TempVendor_BLL.getTempVendorName(temp_Vendor_ID);

            string optional = GridView2.Rows[drv.RowIndex].Cells[2].Text;//可选与必选
            string status = GridView2.Rows[drv.RowIndex].Cells[3].Text;//状态标志 
           
            string aimPageName = "";

            //过期状态更新

            FileOverDue_BLL.upDateStatus(formID);

            submit = canSubmit(Session["Factory_Name"].ToString(), temp_Vendor_ID);//提交的顺序控制
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
                        formID = As_Bidding_Approval_BLL.getVendorBiddingFormID(temp_Vendor_ID, form_Type_ID, Session["Factory_Name"].ToString(), n);

                        //添加单独绑定的文件
                        VendorSingleFile_BLL.addSingleFile(formID, form_Type_ID, temp_Vendor_ID, tempVendorName, Session["Factory_Name"].ToString(), "012");
                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = temp_Vendor_ID;
                        forms.Temp_Vendor_Name = tempVendorName;
                        forms.Form_Type_ID = form_Type_ID;
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = Session["Factory_Name"].ToString(); ;
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
                        formID = As_Vendor_Designated_Apply_BLL.getVendorDesignatedFormID(temp_Vendor_ID, form_Type_ID, Session["Factory_Name"].ToString(), n);

                        //添加单独绑定的文件
                        VendorSingleFile_BLL.addSingleFile(formID, form_Type_ID, temp_Vendor_ID, tempVendorName, Session["Factory_Name"].ToString(), "065");

                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = temp_Vendor_ID;
                        forms.Temp_Vendor_Name = tempVendorName;
                        forms.Form_Type_ID = form_Type_ID;
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = Session["Factory_Name"].ToString();
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
                        formID = ContractApproval_BLL.getVendorContractApprovalFormID(temp_Vendor_ID, form_Type_ID, Session["Factory_Name"].ToString(), n);

                        VendorSingleFile_BLL.addSingleFile(formID, form_Type_ID, temp_Vendor_ID, tempVendorName, Session["Factory_Name"].ToString(), "001");

                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = temp_Vendor_ID;
                        forms.Temp_Vendor_Name = tempVendorName;
                        forms.Form_Type_ID = form_Type_ID;
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = Session["Factory_Name"].ToString();
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);
                        aimPageName = "ContractApprovalForm.aspx";
                    }
                    #endregion
                    Response.Redirect(aimPageName + "?submit=" + submit + "&type=" + form_Type_ID + "&Form_ID=" + formID);
                }
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
        private bool withOutAccess(string factory, string temp_vendor_ID)
        {
            return FormType_BLL.withOutAccess(factory, temp_vendor_ID);
        }
    }
}