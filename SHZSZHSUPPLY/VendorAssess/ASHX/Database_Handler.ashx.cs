using BLL;
using BLL.VendorAssess;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace SHZSZHSUPPLY.VendorAssess.ASHX
{
    /// <summary>
    /// Database_Handler1 的摘要说明
    /// </summary>
    public class Database_Handler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request.Params["requestType"])
            {
                case "approveReason":
                    approveRe(context);
                    //approveReason(context);
                    break;
                case "modifyApproveReason":
                    modifyApproveReason(context);
                    break;
                default:
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, message = "default fail!" }));
                    break;
            }
        }

        //TODO::这里要改成存储过程调用 2017年12月14日18:25:33
        /// <summary>
        /// 供应商修改流程的拒绝
        /// </summary>
        /// <param name="context"></param>
        private void modifyApproveReason(HttpContext context)
        {
            //获取参数
            string formID = context.Request.Params["formID"];
            string position = context.Request.Params["positionName"];
            string factory = context.Request.Params["factoryName"];
            string reason = context.Request.Params["reason"];
            string formTypeID = HttpContext.Current.Session["formTypeID"].ToString();
            string tempVendorID = HttpContext.Current.Session["tempVendorID"].ToString();


            //写出日志
            As_Employee ae = Employee_BLL.getEmolyeeById(AddEmployeeVendor_BLL.getEmployeeID(tempVendorID));
            As_Write aw = new As_Write();
            aw.Employee_ID = ae.Employee_ID;
            aw.Form_ID = formID;
            aw.Form_Fill_Time = DateTime.Now.ToString();
            aw.Manul = ae.Positon_Name + ae.Employee_Name + ":审批拒绝，表格已返回为可编辑状态    时间:" + aw.Form_Fill_Time + "<br/>&nbsp&nbsp&nbsp&nbsp原因:" + reason;
            aw.Manul_Type = As_Write.APPROVE_FAIL;
            aw.Temp_Vendor_ID = tempVendorID;
            Write_BLL.addWrite(aw);

            //Mail
            LocalMail.backToast(ae.Employee_Email, ae.Employee_Name, ae.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), FormType_BLL.getFormNameByTypeID(formTypeID), "审批失败", DateTime.Now.ToString(), "表格审批被拒绝，原因如下：" + reason + ";请登录系统修改后重新提交审批");

            //更新状态为fail(可写可不写，归零后自动清空)
            int i = AssessFlow_BLL.updateApproveFail(formID, position);

            //状态归零
            LocalApproveManager.resetFormStatus(formID, formTypeID, tempVendorID);
            //删除供应商信息修改表
            FillVendorInfo_BLL.deleteVendorFormType(formID);
            //返回结果
            if (Approve_BLL.updateReason(formID, position, factory, reason) && i > 0)
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, status = 1, message = "success!" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, status = 0, message = "fail!" }));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void approveReason(HttpContext context)
        {
            //获取参数
            string formID = context.Request.Params["formID"];
            string position = context.Request.Params["positionName"];
            string factory = context.Request.Params["factoryName"];
            string reason = context.Request.Params["reason"];
            string formTypeID = HttpContext.Current.Session["formTypeID"].ToString();
            string tempVendorID = HttpContext.Current.Session["tempVendorID"].ToString();


            //写出日志
            As_Employee ae = Employee_BLL.getEmolyeeById(AddEmployeeVendor_BLL.getEmployeeID(tempVendorID));
            As_Write aw = new As_Write();
            aw.Employee_ID = ae.Employee_ID;
            aw.Form_ID = formID;
            aw.Form_Fill_Time = DateTime.Now.ToString();
            aw.Manul = ae.Positon_Name + ae.Employee_Name + ":审批拒绝，表格已返回为可编辑状态    时间:" + aw.Form_Fill_Time + "<br/>&nbsp&nbsp&nbsp&nbsp原因:" + reason;
            aw.Manul_Type = As_Write.APPROVE_FAIL;
            aw.Temp_Vendor_ID = tempVendorID;
            Write_BLL.addWrite(aw);

            //Mail
            ae = Employee_BLL.getEmolyeeById(AddEmployeeVendor_BLL.getEmployeeID(tempVendorID));
            LocalMail.backToast(ae.Employee_Email, ae.Employee_Name, ae.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), FormType_BLL.getFormNameByTypeID(formTypeID), "审批失败", DateTime.Now.ToString(), "表格审批被拒绝，原因如下：" + reason + ";请登录系统修改后重新提交审批");

            //更新状态为fail(可写可不写，归零后自动清空)
            int i = AssessFlow_BLL.updateApproveFail(formID, position);

            //状态归零
            LocalApproveManager.resetFormStatus(formID, formTypeID, tempVendorID);
            //Approve_BLL.resetForm(formID, formTypeID, tempVendorID);

            if (formID.Contains("VendorModify"))
            {
                FillVendorInfo_BLL.deleteVendorFormType(formID);
            }
            //返回结果
            if (Approve_BLL.updateReason(formID, position, factory, reason) && i > 0)
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, status = 1, message = "success!" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, status = 0, message = "fail!" }));
            }
        }


        private void approveRe(HttpContext context)
        {
            //获取参数
            string formID = context.Request.Params["formID"];
            string position = context.Request.Params["positionName"];
            string factory = context.Request.Params["factoryName"];
            string reason = context.Request.Params["reason"];
            string formTypeID = HttpContext.Current.Session["formTypeID"].ToString();
            string tempVendorID = HttpContext.Current.Session["tempVendorID"].ToString();
            string tableName = Signature_BLL.switchFormID(formID);

            int i = Approve_BLL.refuseAssess(formID, position, factory, reason, formTypeID, tempVendorID, HttpContext.Current.Session["Employee_ID"].ToString(),tableName);

            //返回结果
            if (i == 1)
            {
                //Mail
                As_Employee ae = Employee_BLL.getEmolyeeById(AddEmployeeVendor_BLL.getEmployeeID(tempVendorID));
                LocalMail.backToast(ae.Employee_Email, ae.Employee_Name, ae.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), FormType_BLL.getFormNameByTypeID(formTypeID), "审批失败", DateTime.Now.ToString(), "表格审批被拒绝，原因如下：" + reason + ";请登录系统修改后重新提交审批");

                //状态归零
                //Approve_BLL.resetForm(formID, formTypeID, tempVendorID);

                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true, status = 1, message = "success!" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, status = 0, message = "fail!" }));
            }
        }
    }
}