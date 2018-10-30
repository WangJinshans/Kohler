using BLL.QualityDetection;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class ApplyInspection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化SKU列表
            if (!IsPostBack)
            {
                SKU.DataSource = Material_Inspection_Item_BLL.getSKUList();
                SKU.DataBind();
            }
            else
            {
                switch (Request["__EVENTTARGET"])
                {
                    case "Apply":
                        applyToInspection();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 需要仓库进行确认  并且更改待检列表为退货检验
        /// </summary>
        private void applyToInspection()
        {
            string batch_No = Convert.ToString(ViewState["Batch_No"]);
            
            RepertoryInspection_BLL.updateRepertoryInspection(batch_No);
            LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "已经上报实验室"), "deepTip");
        }

        protected void apply_Click(object sender, EventArgs e)
        {
            //检验员确认

            //是否进行仓库报验  如果仓库进行报验，那么仓库管理员需要在RepertoryInspection.aspx中进行确认
            //如果确认有问题  则进行重新检验


            //插入到QT_RepertoryInspection中  Type 用于区别 车间报验 还是 仓库报验
            QT_RepertoryInspection inspection = new QT_RepertoryInspection();
            if (ge.Checked)
            {
                inspection.Bad = amount.Text.Trim();
                inspection.Take_Out = takeout.Text.Trim();
                inspection.Unit = "piece";
            }
            else
            {
                inspection.Bad = "";
                inspection.Take_Out = "";
                inspection.Unit = "kg/L";
            }
            inspection.Type = "车间";
            inspection.Status = "NO";
            inspection.Batch_No = batchNo.Text.ToString().Trim();

            inspection.SKU = SKU.SelectedValue;
            inspection.Vendor_Code = InspectionList_BLL.getVendorCode(batchNo.Text);
            //添加对象
            ViewState.Add("Batch_No", inspection.Batch_No);
            RepertoryInspection_BLL.addRepertoryInspection(inspection);
            LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "已成功报验"), "makeSure");

        }
    }
}