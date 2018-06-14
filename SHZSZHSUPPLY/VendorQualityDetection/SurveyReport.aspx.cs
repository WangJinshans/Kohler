using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class SurveyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<QT_Material_Inspection_Item> list = new List<QT_Material_Inspection_Item>();
            QT_Material_Inspection_Item item = null;
            for (int i = 1; i < 10; i++)
            {
                item = new QT_Material_Inspection_Item();
                item.Item = "中心测距";
                item.Standard = "100" + Convert.ToString(i);
                list.Add(item);
            }
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}