using BLL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class ScarList : System.Web.UI.Page
    {
        private Dictionary<string, string[]> info = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取内联的两个下来列表的值 vendor_Code,Batch_No
            if (!IsPostBack)
            {
                info = SCAR_BLL.readScarVendorInfo(Convert.ToString(Session["Factory_Name"]));
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string json = jss.Serialize(info);
                LocalScriptManager.CreateScript(Page, String.Format("setParm('{0}')", json), "setParm");
            }
            else
            {
                switch (Request.Form["__EVENTTARGET"])
                {
                    case "initGridView":
                        initGridView(Request.Form["__EVENTARGUMENT"]);
                        break;
                    default:
                        break;
                }
            }
        }

        protected void initGridView(string args)
        {
            GridView1.DataSource = SCAR_BLL.getScarList(args);
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string batch_No = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            string vendor_Code = GridView1.Rows[drv.RowIndex].Cells[0].Text;

            if (e.CommandName.Equals("finishScar"))
            {
                //弹窗上传文件
                LocalScriptManager.CreateScript(Page, String.Format("uploadScar('{0}','{1}')", batch_No, vendor_Code), "uploadScar");
            }
        }
    }
}