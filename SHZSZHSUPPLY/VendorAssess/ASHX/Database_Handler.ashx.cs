﻿using BLL;
using BLL.VendorAssess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace SHZSZHSUPPLY.VendorAssess.ASHX
{
    /// <summary>
    /// Database_Handler 的摘要说明
    /// </summary>
    public class Database_Handler : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request.Params["requestType"])
            {
                case "approveReason":
                    approveReason(context);
                    break;
                default:
                    context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false, message = "default fail!" }));
                    break;
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
            As_Employee ae = Employee_BLL.getEmolyeeById(HttpContext.Current.Session["Employee_ID"].ToString());
            As_Write aw = new As_Write();
            aw.Employee_ID = ae.Employee_ID;
            aw.Form_ID = formID;
            aw.Form_Fill_Time = DateTime.Now.ToString();
            aw.Manul = ae.Positon_Name + ae.Employee_Name + ":审批拒绝    时间:" + aw.Form_Fill_Time+ "<br/>&nbsp&nbsp&nbsp&nbsp原因:" + reason;
            aw.Manul_Type = As_Write.APPROVE_FAIL;
            aw.Temp_Vendor_ID = tempVendorID;
            Write_BLL.addWrite(aw);

            //更新状态为fail(可写可不写，归零后自动清空)
            int i = AssessFlow_BLL.updateApproveFail(formID, position);

            //TODO::状态归零
            LocalApproveManager.resetFormStatus(formID, formTypeID, tempVendorID);


            //返回结果
            if (Approve_BLL.updateReason(formID, position, factory, reason) && i>0)
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true,status=1, message = "success!" }));
            }
            else
            {
                context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = false,status=0, message = "fail!" }));
            }
        }
    }

}