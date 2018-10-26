using System;
using System.Data;
using BLL.QualityDetection;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class InspectionItemIorD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager1.RegisterAsyncPostBackControl(this.Button1);
            ScriptManager1.RegisterAsyncPostBackControl(this.Button2);
            ScriptManager1.RegisterAsyncPostBackControl(this.Button3);
            TextBox1.Attributes.Add("Value", "请输入检验项");
            TextBox1.Attributes.Add("OnFocus", "if(this.value=='请输入检验项'){this.value='';this.style.color='black';}");
            TextBox1.Attributes.Add("OnBlur", "if(this.value==''){this.style.color='grey';this.value='请输入检验项';}");
            TextBox2.Attributes.Add("Value", "请输入标准");
            TextBox2.Attributes.Add("OnFocus", "if(this.value=='请输入标准'){this.value='';this.style.color='black';}");
            TextBox2.Attributes.Add("OnBlur", "if(this.value==''){this.style.color='grey';this.value='请输入标准';}");
            ViewState.Add("SKU", "8599T-CP");
            if (!IsPostBack)
            {
                getInspectionData();
            }
            else
            {
                getInspectionData();
            }

            SKU_List.DataSource = Material_Inspection_Item_BLL.getSKUList();
            SKU_List.DataBind();
        }

        private void getInspectionData()
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            DataTable InspectionItems;
            InspectionItems = SurveyReport_BLL.getInsectionItems(sku);
            GridView1.DataSource = InspectionItems.DefaultView;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            string item = TextBox1.Text.ToString().Trim();
            string standard = TextBox2.Text.ToString().Trim();
            SurveyReport_BLL.addNewInspectionItem(sku, item, standard, "YES");
            if (SurveyReport_BLL.haveInspectionItem(sku, item))
            {
                Response.Write("<script>window.alert('添加成功')</script>");

            }
            else
            {
                Response.Write("<script>window.alert('添加失败')</script>");

            }
            UpdatePanel1.Update();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string sku = Convert.ToString(ViewState["SKU"]);
            string item = TextBox1.Text.ToString().Trim();
            string standard = TextBox2.Text.ToString().Trim();
            if (standard == "请输入标准" || standard == "")
            {
                SurveyReport_BLL.deleteInspectionItem(sku, item);
                Response.Write("<script>window.alert('删除成功')</script>");

            }
            else
            {
                Response.Write("<script>window.alert('删除不需要填写标准')</script>");
            }
            UpdatePanel1.Update();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            string item = TextBox1.Text.ToString().Trim();
            string standard = TextBox2.Text.ToString().Trim();
            SurveyReport_BLL.alterInspectionItem(sku, item, standard);
            UpdatePanel1.Update();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("InspectionList.aspx");
        }
    }
}