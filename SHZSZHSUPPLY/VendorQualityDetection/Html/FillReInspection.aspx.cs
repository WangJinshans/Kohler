using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;


namespace SHZSZHSUPPLY.VendorQualityDetection.Html
{
    public partial class FillReInspection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSessionInfo();
                repeater.DataSource = Material_Inspection_Item_BLL.getInspectionItemsOnly("1120294");
                repeater.DataBind();
            }
            else
            {

            }
        }

        private void getSessionInfo()
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (RepeaterItem item in this.repeater.Items)
            {
                CheckBox box = item.FindControl("check") as CheckBox;
                if (box.Checked)
                {
                    items.Add(box.Text);
                }
            }
            //exsits
            if (items.Count > 0)
            {
                string result = string.Join(",", items.ToArray());
                LocalScriptManager.CreateScript(Page, String.Format("setReInspectionItems('{0}')", result), "setReInspectionItems");
            }
        }
    }
}