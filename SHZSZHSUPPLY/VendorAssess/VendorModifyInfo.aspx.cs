using BLL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class Vendor_ModifyInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string temp_Vendor_ID = Request.QueryString["ID"].ToString();
            string factory= Request.QueryString["Factory"].ToString();
            List<As_Modify_CheckResult> list= VendorCheckResult_BLL.getData(temp_Vendor_ID, factory);
            GridView1.DataSource = list;
            GridView1.DataBind();
            if (list.Count == 0)
            {
                Response.Write("<script>window.alert('没有其他新文件需要更新');window.location.href='/VendorAssess/EmployeeVendor.aspx';</script>");
            }
        }
    }
}