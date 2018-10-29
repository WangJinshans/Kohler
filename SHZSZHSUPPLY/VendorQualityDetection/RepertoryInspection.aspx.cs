using BLL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class RepertoryInspection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //仓库报验  情况确认  确认的需要重新检验

            RepertoryInspection_BLL.getRepertoryInspection();
        }




        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string batch_No = GridView1.Rows[drv.RowIndex].Cells[0].Text;

            if (e.CommandName.Equals("sure"))
            {
                RepertoryInspection_BLL.checkRepertoryInspection(batch_No);
                RepertoryInspection_BLL.copyInspection(batch_No);
                LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "退货检验确认成功"), "goodReturnTip");
            }
            
        }
    }
}