using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;            
using System.Data.SqlClient;  
using System.Configuration;
using Model;
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
                getSKUList();
            }
            else
            {
                
                switch (Request["__EVENTTARGET"])
                {
					case "Button1":
						{
							Button1_Click();
							break;
						}
                    case "Button2":
                        {
                            Button2_Click();   
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void getInspectionData()
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            DataTable InspectionItems;
            InspectionItems = SurveyReport_BLL.getInsectionItems(sku);
            GridView1.DataSource = InspectionItems.DefaultView;
            GridView1.DataBind();
        }

        private void getSKUList()
        {
            DataTable SKUList;
            SKUList = SurveyReport_BLL.getSKUList();
            DropDownList1.Items.Clear();
            DropDownList1.DataSource = SKUList.DefaultView;
            DropDownList1.DataBind();

        }

        protected void Button1_Click()
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            string item = TextBox1.Text.ToString().Trim();
            string standard = TextBox2.Text.ToString().Trim();
            SurveyReport_BLL.addNewInspectionItem(sku,item,standard,"YES");
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

        protected void Button2_Click()
        {
            
            string sku = Convert.ToString(ViewState["SKU"]);
            string item = TextBox1.Text.ToString().Trim();
            string standard = TextBox2.Text.ToString().Trim();
            SurveyReport_BLL.deleteInspectionItem(sku, item);
            Response.Write("<script>window.alert('删除成功')</script>");

            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            string item = TextBox1.Text.ToString().Trim();
            string standard = TextBox2.Text.ToString().Trim();
            SurveyReport_BLL.alterInspectionItem(sku,item,standard);
            UpdatePanel1.Update();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("InspectionList.aspx");
        }
    }
}