using BLL;
using BLL.QualityDetection;
using SHZSZHSUPPLY.QualityDetection.Utils;
using System;
using System.Web.UI.WebControls;
using MODEL.QualityDetection;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class LoadInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }
            else
            {
                switch (Request["__EVENTTARGET"])
                {
                    case "insertItem": { apply_Click1(); break; }
                    default:
                        break;
                }
            }
            // HTTP 连接超时60s 响应超时30s 
        }

        //添加检验项

        protected void apply_Click1()
        {
            QT_Inspection_Item item = null;
            item = new QT_Inspection_Item();

            //补全即可
            item.Batch_No = Convert.ToString(BatchNo.Text);
            item.Product_Describes = Convert.ToString(Material.Text);
            item.SKU = Convert.ToString(SKUInput.Text);
            item.Vendor_Code = Convert.ToString(VendorCode.Text);
            item.Detection_Count = Convert.ToString(Quantity.Text);

            item.Status = "待检";
            //item.Factory_Name = Convert.ToString(Session["Factory_Name"]);
            item.Factory_Name = Convert.ToString("上海科勒");
            item.Add_Time = Convert.ToString(DateTime.Now.ToString());

            item.Import_KO = Convert.ToString(InputKO.Text);

            Inspection_Item_BLL.addInspection(item);
        }
    }
}