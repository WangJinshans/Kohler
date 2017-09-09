using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class KCI : System.Web.UI.Page
    {
        private string position_Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                position_Name = Session["Position_Name"].ToString().Trim();
                if (position_Name == "采购部经理")//限制只有采购才有权限进入此页面
                {
                    string sql = "select * from As_KCI_Approval where Position_Name='" + position_Name + "' and Flag='0'";
                    PagedDataSource objpds = new PagedDataSource();
                    objpds.DataSource = KCIApproval_BLL.selectKCIApproval(sql);
                    GridView1.DataSource = objpds;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string formID = e.CommandArgument.ToString().Trim();
            //获取Form_Type_ID
            string Form_Type_ID = AddForm_BLL.GetForm_Type_ID(formID);
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string temp_vendor_ID = GridView1.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();
            if (e.CommandName == "success")//确认通过了KCI审批
            {
                if (formID.Contains("BiddingForm"))//比价表的KCI处理 有权限的动态签名问题在同意的时候修改
                {
                    KCIApproval_BLL.updateKCIApproval(formID, 1);//KCI审批完成
                    KCIApproval_BLL.setApprovalFinished(Form_Type_ID, 4, temp_vendor_ID);//整张表的审批完成
                    if (isFormOverDue(formID))//过期重申表
                    {
                        string oldFormID = FormOverDue_BLL.getOldFormID(formID);//对于已经在重新审批中的表 oldFormID 在As_Vendor_FormType_History一定存在 在过期表中也一定存在
                        UpdateFlag_BLL.updateReAccessFormStatus(oldFormID, temp_vendor_ID);//成功返回2 失败返回-1
                    }
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
                        KCIApproval_BLL.setApprovalFinished(Form_Type_ID, 4, temp_vendor_ID);//整张表的审批完成
                    }
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

                if (isFormOverDue(formID))//过期重申表
                {
                    string oldFormID = FormOverDue_BLL.getOldFormID(formID);//对于已经在重新审批中的表 oldFormID 在As_Vendor_FormType_History一定存在 在过期表中也一定存在
                    UpdateFlag_BLL.updateReAccessFormStatus(oldFormID, temp_vendor_ID);//成功返回2 失败返回-1
                }

                /*
                 * 因为合同审批表是整个审批流程中的最后一个环节 一旦合同审批表通过
                 * 之后 就表示是该供应商在进行文件转移之后将成为正式供应商
                 * 
                 * 开始进行文件转移（独立出来一个文件转移的模块）
                 * 
                 * 
                 * 
                 * 
                 */

                //写出日志
                LocalLog.writeLog(formID, String.Format("KCI审批成功    时间{0}",DateTime.Now.ToString()), As_Write.APPROVE_SUCCESS, temp_vendor_ID);

            }
            else if (e.CommandName == "fail")//KCI审批不过
            {
                //KCIApproval_BLL.rejectKCIApproval(formID);//KCI审批完成 但是失败 直接删掉该记录
                //需要删除As_Form 避免主键重复
                //AddForm_BLL.deleteForm(formID);
                //AssessFlow_BLL.deleteFormAccess(formID);//让表可以重新实例一个审批流程
                ////KCIApproval_BLL.updateKCIApproval(formID, 2);//KCI审批完成  2表示需要再次进行KCI审批
                //KCIApproval_BLL.deleteKCIApproval(formID);
                //KCIApproval_BLL.setApprovalFinished(Form_Type_ID, 0, temp_vendor_ID);//整张表的审批完成  该表需要在修改之后重新进行审批
                Approve_BLL.resetFormStatus(formID, Form_Type_ID, temp_vendor_ID);


                //写出日志
                LocalLog.writeLog(formID, String.Format("KCI审批失败，表格审批状态重置,请重新填写后再次提交审批    时间{0}", DateTime.Now.ToString()), As_Write.APPROVE_SUCCESS, temp_vendor_ID);

                /*
                 * 重新审批的时候  需要将该表的整个流程重新走过 需要删除As_Form_AccessFlow  
                 * 修改提交的flag为0 否则无法再次提交
                 * 
                 * 将该功能独立出来   方便后面修改后再次提交 进行多次审批
                 * 
                 */
            }
            string requestType = "kciUpload";
            string fileTypeID = formID;//暂时为form_ID
            string tempVendorName = TempVendor_BLL.getTempVendorName(temp_vendor_ID);
            LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}')", requestType, temp_vendor_ID, tempVendorName, fileTypeID), "upload");
            //上传KCI审批结果文件
        }


        private void ApprovalFinished(string formID, string Form_Type_ID, string temp_vendor_ID)
        {
            KCIApproval_BLL.updateKCIApproval(formID, 1);//KCI审批完成
            KCIApproval_BLL.setApprovalFinished(Form_Type_ID, 4, temp_vendor_ID);//整张表的审批完成
        }
        private bool isFormOverDue(string formID)
        {
            bool isOverDue = false;
            isOverDue = FormOverDue_BLL.isOverDue(formID);
            return isOverDue;
        }
    }
}