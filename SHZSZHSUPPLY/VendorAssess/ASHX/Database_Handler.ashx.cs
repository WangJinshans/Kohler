using BLL;
using BLL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SHZSZHSUPPLY.VendorAssess.ASHX
{
    /// <summary>
    /// Database_Handler 的摘要说明
    /// </summary>
    public class Database_Handler : IHttpHandler
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
            string formID = context.Request.Params["formID"];
            string position = context.Request.Params["positionName"];
            string factory = context.Request.Params["factoryName"];
            string reason = context.Request.Params["reason"];

            int i = AssessFlow_BLL.updateApproveFail(formID, position);

            //TODO::状态归零

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