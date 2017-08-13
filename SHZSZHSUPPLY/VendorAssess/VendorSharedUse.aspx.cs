using BLL;
using BLL.VendorAssess;
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

                bindGridData("TempVendor1027");
            }
            else
            {
                //重新读取供应商列表（网页缓存）
                LocalScriptManager.CreateScript(Page, "getParams()", "getparams");

                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "showExistVendor":
                        //tempVendorID = Request.Form["quiz3"];
                        showExistVendor(Request.Form["__EVENTARGUMENT"]);
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
            string sql = "Select * From View_File Where Temp_Vendor_ID='" + tempVendorID + "' And Is_Shared='TRUE'";
            PagedDataSource source = new PagedDataSource();
            source.DataSource = SelectForm_BLL.selectFile(sql);
            File_GridView.DataSource = source;
            File_GridView.DataBind();
        }

        private void showExistVendor(string tempVendorID)
        {
            bindGridData(tempVendorID);
            this.tempVendorID = tempVendorID;
        }

        protected void File_GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (TempVendor_BLL.checkUsed(Request.Form["quiz3"], Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString())))
            {
                LocalScriptManager.CreateScript(Page, String.Format("message('{0}')", "此供应商已经在您所在的工厂中使用"), "vendorIsUsed");
                return;
            }
            else
            {

            }
        }
    }
}