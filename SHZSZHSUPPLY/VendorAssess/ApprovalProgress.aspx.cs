using BLL;
using BLL.VendorAssess;
using Model;
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
    public partial class ApprovalProgress : System.Web.UI.Page
    {
        public Dictionary<string, Dictionary<string, string[]>> info;
        private string serializedJson;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    case "refreshNewVendor":
                        refreshNewVendor(Request.Form["__EVENTARGUMENT"]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void readVendorInfo()
        {
            info = ApprovalProgress_BLL.readVendorInfo();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            serializedJson = jss.Serialize(info);
            LocalScriptManager.CreateScript(Page, String.Format("setParams('{0}')", serializedJson), "params");
        }

        private void bindGridData(string tempVendorID)
        {
            string sql2 = "SELECT * FROM View_Vendor_FormType WHERE Temp_Vendor_ID='" + tempVendorID + "'";
            PagedDataSource objpds2 = new PagedDataSource();
            objpds2.DataSource = SelectForm_BLL.selectAllForm(sql2);
            //获取数据源
            GridView3.DataSource = objpds2;
            //绑定数据源
            GridView3.DataBind();
        }

        private void refreshNewVendor(string tempVendorID)
        {
            bindGridData(tempVendorID);

            vendorName.InnerText = TempVendor_BLL.getTempVendorName(tempVendorID);

            formName.InnerText = "表格名称";

            normalInfoDetail.InnerText = "";

            exceptionInfoDetail.InnerText = "";

            //LocalScriptManager.CreateScript(Page, String.Format("setVendorName('{0}')", TempVendor_BLL.getTempVendorName(tempVendorID)), "setvendorname");

            LocalScriptManager.CreateScript(Page, String.Format("setFormProgress('{0}')", 0), "setformprogress");
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showDetails")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                formName.InnerText = GridView3.Rows[drv.RowIndex].Cells[1].Text;

                string normal = ApprovalProgress_BLL.readFormNormalInfo(e.CommandArgument.ToString());
                string exception = ApprovalProgress_BLL.readFormExceptionInfo(e.CommandArgument.ToString());

                normalInfoDetail.InnerHtml = normal;
                exceptionInfoDetail.InnerHtml = exception;

                Random rd = new Random();
                LocalScriptManager.CreateScript(Page, String.Format("setFormProgress('{0}')", rd.Next(10, 101)), "setformprogress");
            }
        }
    }
}