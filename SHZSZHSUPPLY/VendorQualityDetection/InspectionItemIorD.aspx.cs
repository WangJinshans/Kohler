﻿using System;
using System.Data;
using BLL.QualityDetection;
using System.Web.UI.WebControls;

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

            if (!IsPostBack)
            {
                getSKUList();

            }
            else
            {

                if (DropDownList1.SelectedValue == "---请选择---" || DropDownList1.SelectedValue == "")
                {
                    Response.Write("<script>window.alert('请先选择SKU再进行操作!')</script>");
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
                        case "DropDownList1":
                            {

                                DropDownList1_SelectedValueChanged();
                                getInspectionData();
                                break;
                            }

                        default:
                            break;
                    }
                }
            }

            GridView1.DataSource = Material_Inspection_Item_BLL.getSKUTable(Convert.ToString(ViewState["SKU"]));
            GridView1.DataBind();
        }

        private void DropDownList1_SelectedValueChanged()
        {
            string sku = DropDownList1.SelectedValue.ToString().Trim();
            ViewState.Add("SKU", sku);
        }

        private void getInspectionData()
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            DataTable InspectionItems;
            InspectionItems = SurveyReport_BLL.getInsectionItems(sku);
            if (InspectionItems.Rows.Count != 0)
            {
                GridView1.DataSource = InspectionItems.DefaultView;
                GridView1.DataBind();
            }
        }

        private void getSKUList()
        {
            DataTable SKUList;
            SKUList = SurveyReport_BLL.getSKUList();
            this.DropDownList1.Items.Add(new ListItem("---请选择---", ""));
            if (SKUList.Rows.Count > 0)
            {
                foreach (DataRow dr in SKUList.Rows)
                {
                    this.DropDownList1.Items.Add(new ListItem(dr["SKU"].ToString(), dr["SKU"].ToString()));

                }
            }
        }

        private void Button2_Click()
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

        private void Button1_Click()
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sku = Convert.ToString(ViewState["SKU"]);
            string item = TextBox1.Text.ToString().Trim();
            string standard = TextBox2.Text.ToString().Trim();

            SurveyReport_BLL.alterInspectionItem(sku, item, standard);
            UpdatePanel1.Update();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("InspectionList.aspx");
        }
    }



}