using BLL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class ThirdPartySubmit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<QT_Inspection_Item> list = Inspection_Item_BLL.getInspectionList(0, "inspector");
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
            else
            {

            }
        }

        protected void imgaeRead_Click(object sender, EventArgs e)
        {
            //FileStream fs = new FileStream("D:\\timg.jpg", FileMode.Open , FileAccess.Read);
            //BinaryReader reader = new BinaryReader(fs);
            //StreamWriter writer = new StreamWriter("D:\\data.txt");
            //int length = (int)fs.Length;
            //while (length > 0)
            //{
            //    byte temp = reader.ReadByte();
            //    string tempStr = Convert.ToString(temp, 16);
            //    writer.WriteLine(tempStr);
            //    length--; 
            //}
            //fs.Close();
            //reader.Close();
            //writer.Close();



            //计算

            double a = Convert.ToDouble(one.Text);
            double b = a * (1 + 0.0226 * Math.Sqrt(a));
            double c = Math.Pow(b, -3 / 2);
            int x = Convert.ToInt32(two.Text);
            double result = 9.282 * Math.Pow(10, -15) * c / x;
            three.Text = Convert.ToString(result);
        }

        protected void dropList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<QT_Inspection_Item> list = Inspection_Item_BLL.getInspectionList(1, "clerk");
            GridView1.DataSource = list;
            GridView1.DataBind();
            UpdatePanel.Update();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}