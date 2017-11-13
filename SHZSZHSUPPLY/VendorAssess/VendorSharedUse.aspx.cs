using BLL;
using BLL.VendorAssess;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorSharedUse : System.Web.UI.Page
    {
        public Dictionary<string, Dictionary<string, string[]>> info;
        private string serializedJson;
        private string tempVendorID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                readVendorInfo();
            }
            else
            {
                //重新读取供应商列表（网页缓存）
                LocalScriptManager.CreateScript(Page, "getParams()", "getparams");

                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "showExistVendor":
                        showExistVendor(Request.Form["__EVENTARGUMENT"]);
                        break;
                    default:
                        break;
                }
            }
        }
        
        /// <summary>
        /// 读取下拉框所有的信息并进行格式处理
        /// </summary>
        private void readVendorInfo()
        {
            info = TempVendor_BLL.readVendorInfo();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            serializedJson = jss.Serialize(info);
            LocalScriptManager.CreateScript(Page, String.Format("setParams('{0}')", serializedJson), "params");
        }

        /// <summary>
        /// 为Gridview绑定数据
        /// </summary>
        /// <param name="tempVendorID"></param>
        private void bindGridData(string tempVendorID)
        {
            string sql = "Select * From View_File Where Temp_Vendor_ID='" + tempVendorID + "' And Is_Shared='TRUE'";
            PagedDataSource source = new PagedDataSource();
            source.DataSource = SelectForm_BLL.selectFile(sql);
            File_GridView.DataSource = source;
            File_GridView.DataBind();
        }

        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="tempVendorID"></param>
        private void showExistVendor(string tempVendorID)
        {
            bindGridData(tempVendorID);
            this.tempVendorID = tempVendorID;
        }

        /// <summary>
        /// RowCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void File_GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //查看
            if (e.CommandName == "showDetails")
            {
                //参数
                string fileName = e.CommandArgument.ToString();

                //跳转
                Response.Write(String.Format("<script>window.open('{0}');</script>", LSetting.File_Reltive_Path + fileName));
            }
        }

        /// <summary>
        /// 复用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            string factory = Session["Factory_Name"].ToString();
            string employee_ID = Session["Employee_ID"].ToString();
            string tempVendorID = Request.Form["quiz3"];

            //检查是否已经完成审批
            if (File_Transform_BLL.checkFormSubmit(tempVendorID, Request.Form["quiz1"]) && File_Transform_BLL.FormAccessSuccessFul(tempVendorID, Request.Form["quiz1"]) && File_Transform_BLL.checkFileSubmit(tempVendorID, Request.Form["quiz1"]))
            {
                //如果本工厂已经在使用此供应商
                if (TempVendor_BLL.checkUsed(tempVendorID, Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString())))
                {
                    LocalScriptManager.CreateScript(Page, String.Format("message('{0}')", "此供应商已经在您所在的工厂中使用"), "vendorIsUsed");
                    return;
                }
                else //供应商复用
                {
                    if (TempVendor_BLL.vendorSharedUse(tempVendorID, Request.Form["quiz1"], factory, employee_ID))
                    {
                        LocalScriptManager.CreateScript(Page, String.Format("messageFunc('{0}', {1})", "供应商信息复制成功，即将转至文件管理界面", "function(){window.location.href='./EmployeeVendor.aspx'}"), "successReUse");
                    }
                    else
                    {
                        LocalScriptManager.CreateScript(Page, "message('复用失败')", "failReUse");
                    }
                }
            }
            else //如果此供应商尚未完成审批
            {
                LocalScriptManager.CreateScript(Page, String.Format("message('{0}')", "此供应商尚未完成审批流程或未在使用状态，无法进行复用"), "vendorNotUse");
                return;
            }
            
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='./index.aspx'</script>");
        }
    }
}