using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class KCI : System.Web.UI.Page
    {
        private static string position_Name;
        private static string formID;

        private static string Form_Type_ID;
        private static string temp_vendor_ID;


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                string sql = "";
                position_Name = Session["Position_Name"].ToString().Trim();
                if (position_Name.Equals("采购部经理"))//限制只有采购才有权限进入此页面
                {
                    sql = "select * from As_KCI_Approval where Position_Name='" + "采购部经理" + "' and Flag='0'";
                    PagedDataSource objpds = new PagedDataSource();
                    objpds.DataSource = KCIApproval_BLL.selectKCIApproval(sql, Session["Factory_Name"].ToString());
                    GridView1.DataSource = objpds;
                    GridView1.DataBind();
                }
                else if (position_Name.Equals("供应链经理"))
                {
                    sql = "select * from As_KCI_Approval where Position_Name='" + "供应链经理" + "' and Flag='0'";
                    PagedDataSource objpds = new PagedDataSource();
                    objpds.DataSource = KCIApproval_BLL.selectKCIApproval(sql, Session["Factory_Name"].ToString());
                    GridView1.DataSource = objpds;
                    GridView1.DataBind();
                }
            }
            else
            {
                switch (Request["__EVENTTARGET"])
                {
                    case "operation":
                        kciAssessStart(Request.Form["__EVENTARGUMENT"].ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            formID = e.CommandArgument.ToString().Trim();
            Form_Type_ID = AddForm_BLL.GetForm_Type_ID(formID);
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            temp_vendor_ID = GridView1.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();

            string requestType = "kciUpload";
            string fileTypeID = formID;//TODO::暂时为form_ID
            string tempVendorName = TempVendor_BLL.getTempVendorName(temp_vendor_ID);
            LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}')", requestType, temp_vendor_ID, tempVendorName, fileTypeID), "upload");

            //localstore 保存操作
            LocalScriptManager.CreateScript(Page, String.Format("setOperation('{0}')", e.CommandName.ToString()));
        }

        /// <summary>
        /// 开始KCI审批  operation 代表 不同操作 同意或者拒绝
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        private bool kciAssessStart(string operation)
        {
            if (operation.Equals("success"))//确认通过了KCI审批
            {
                if (formID.Contains("BiddingForm"))//比价表的KCI处理 有权限的动态签名问题在同意的时候修改
                {
                    KCIApproval_BLL.updateKCIApproval(formID, 1);//KCI审批完成
                    KCIApproval_BLL.setApprovalFinished(Form_Type_ID, 4, temp_vendor_ID);//整张表的审批完成
                    //if (isFormOverDue(formID))//过期重申表
                    //{
                    //    string oldFormID = FormOverDue_BLL.getOldFormID(formID);//对于已经在重新审批中的表 oldFormID 在As_Vendor_FormType_History一定存在 在过期表中也一定存在
                    //    UpdateFlag_BLL.updateReAccessFormStatus(oldFormID, temp_vendor_ID);//成功返回2 失败返回-1
                    //}
                }
                else if (formID.Contains("ContractApproval"))//合同审批表的KCI处理
                {
                    As_Contract_Approval contract = new As_Contract_Approval();
                    //先获取该合同是否标准合同  如果是标准合同  那么不需要对表中的法务进行动态签名
                    contract = ContractApproval_BLL.getContractApproval(formID);
                    if (contract.Standard_Contract == "yes")//标准合同 不需要对 法务附加签名
                    {
                        ApprovalFinished(formID, Form_Type_ID, temp_vendor_ID);
                    }
                    else//非标准合同
                    {
                        KCIApproval_BLL.updateKCIApproval(formID, 1);//KCI审批完成
                        /*
                         * 需要进行法务部的动态签名
                         * 建立一张数据表  Position 和 URL(签名文件)
                         */
                        //添加法务部的签名
                        Signature_BLL.setSignature(formID, "法务部", "Legal_Affair_Department");
                        //KCIApproval_BLL.setApprovalFinished(Form_Type_ID, 4, temp_vendor_ID);//整张表的审批完成
                        UpdateFlag_BLL.updateFlagAsApproved(formID, Form_Type_ID, temp_vendor_ID, Session["Factory_Name"].ToString().Trim());
                    }
                }
                else if (formID.Contains("PurchasePriceApplication"))//采购价格审批表的KCI处理
                {
                    KCIApproval_BLL.updateKCIApproval(formID, 1);//KCI审批完成
                    KCIApproval_BLL.setApprovalFinished(Form_Type_ID, 4, temp_vendor_ID);//整张表的审批完成
                }
                else if (formID.Contains("VendorExtend"))//供应商扩展表的KCI处理
                {
                    ApprovalFinished(formID, Form_Type_ID, temp_vendor_ID); //表的审批完成
                }
                else if (formID.Contains("VendorBlock"))//供应商恢复删除表的KCI处理
                {
                    ApprovalFinished(formID, Form_Type_ID, temp_vendor_ID);
                }
                else if (formID.Contains("VendorCreation"))//供应商建立表的KCI处理
                {
                    ApprovalFinished(formID, Form_Type_ID, temp_vendor_ID);
                }
                else if (formID.Contains("VendorDesignated"))//指定供应商申请表的KCI处理
                {
                    ApprovalFinished(formID, Form_Type_ID, temp_vendor_ID);
                }
                else if (formID.Contains("Selection"))
                {
                    ApprovalFinished(formID, Form_Type_ID, temp_vendor_ID);
                }
                ////写出日志
                LocalLog.writeLog(formID, String.Format("KCI审批成功    时间{0}", DateTime.Now.ToString()), As_Write.APPROVE_SUCCESS, temp_vendor_ID);

            }
            else if (operation.Equals("fail"))//KCI审批不过
            {
                //流程回滚
                string tableName = Signature_BLL.switchFormID(formID);
                int i = Approve_BLL.refuseAssess(formID, "", Session["Factory_Name"].ToString(), "kci审批失败", Form_Type_ID, temp_vendor_ID, Session["Employee_ID"].ToString(), tableName);
                if (i == 1)
                {
                    //写出日志
                    LocalLog.writeLog(formID, String.Format("KCI审批失败，表格审批状态重置,请重新填写后再次提交审批    时间{0}", DateTime.Now.ToString()), As_Write.APPROVE_SUCCESS, temp_vendor_ID);
                }
                else
                {   //否则是存储过程执行失败
                    Response.Write("<script>messageConfirmNone('KCI拒绝失败！数据库响应错误！');</script>");
                }
            }
            LocalScriptManager.CreateScript(Page, "reloadPage()", "reLoad");
            return true;
        }


        private void ApprovalFinished(string formID, string formTypeID, string temp_vendor_ID)
        {
            KCIApproval_BLL.updateKCIApproval(formID, 1);//KCI审批完成
            UpdateFlag_BLL.updateFlagAsApproved(formID, formTypeID, temp_vendor_ID, Session["Factory_Name"].ToString());
        }
        private bool isFormOverDue(string formID)
        {
            bool isOverDue = false;
            isOverDue = FormOverDue_BLL.isOverDue(formID);
            return isOverDue;
        }
    }
}