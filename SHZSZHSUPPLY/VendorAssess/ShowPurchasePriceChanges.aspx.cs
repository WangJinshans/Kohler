using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowPurchasePriceChanges : System.Web.UI.Page
    {
        private string formID = "";
        private string positionName = "";
        private string FORM_TYPE_ID = "";
        private string tempVendorID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = PurchaseChanges_BLL.check(formID);
                if (check > 0)
                {
                    show();
                }
            }
        }

        private void show()
        {
            As_Purchase_Changes asPurchaseChanges = PurchaseChanges_BLL.get(formID);
            List<As_Purchase_Changes_Item> list = PurchaseChanges_BLL.getItems(formID);

            if (asPurchaseChanges != null)
            {
                TextBox1.Text = asPurchaseChanges.Vendor_Code;
                TextBox2.Text = asPurchaseChanges.Vendor;
                TextBox3.Text = asPurchaseChanges.Currency;
                TextBox4.Text = asPurchaseChanges.Date;
                Image1.ImageUrl = asPurchaseChanges.Initiator;
                Image2.ImageUrl = asPurchaseChanges.Purchasing_Manager;
                Image3.ImageUrl = asPurchaseChanges.Finance_Leader;
                Image4.ImageUrl = asPurchaseChanges.GM;
                Image5.ImageUrl = asPurchaseChanges.Associated_Director_Sourcin;
                //Show Page Images
            }
            else
            {
                Response.Write("<script>window.alert('数据查询失败！');window.location.href='EmployeeVendor.aspx'</script>");
            }

            if (list.Count > 0)
            {
                int index = 4;
                foreach (var item in list)
                {
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 1))).Text = item.SKU;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 2))).Text = item.Description;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 3))).Text = item.Unit;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 4))).Text = item.Last_PO_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 5))).Text = item.Last_6_Months_Average_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 6))).Text = item.Required_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 7))).Text = item.STD_cost;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 8))).Text = item.Request_Price_VS_Last_PO_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 9))).Text = item.STD_Cost_VS_Request_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 10))).Text = item.Yearly_Forecast;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 11))).Text = item.Yearly_Amount;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 12))).Text = item.PPV;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 13))).Text = item.Current_Stock;
                    if (!item.Main_Material_Cost_Change.Equals("<EOF>"))
                    {
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 14))).Text = item.Main_Material_Cost_Change;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 15))).Text = item.Main_Material_Cost_VS_Total_Cost;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 16))).Text = item.Required_Cost_Change;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 17))).Text = item.Effective_Date;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 18))).Text = item.Remark;
                        index += 18;
                    }
                    else
                    {
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 14))).Text = item.Main_Material_Cost_VS_Total_Cost;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 15))).Text = item.Required_Cost_Change;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 16))).Text = item.Effective_Date;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 17))).Text = item.Remark;
                        index += 17;
                    }

                }
            }
            showapproveform(formID);
            showfilelist(formID);
        }


        public void showfilelist(string FormID)
        {
            string sql = "select * from View_Form_File where Form_ID='" + FormID + "'  and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            PagedDataSource objpds = new PagedDataSource {DataSource = FormFile_BLL.listFile(sql)};
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        public void showapproveform(string FormID)
        {
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource {DataSource = AssessFlow_BLL.listApprove(sql, positionName)};
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }


        private void getSessionInfo()
        {
            if (Request.QueryString["outPutID"] != null && Request.QueryString["outPutID"] != "")
            {
                formID = Request.QueryString["outPutID"];
                FORM_TYPE_ID = Request.QueryString["type"];
            }
            else
            {
                formID = Session["formID"].ToString();
                positionName = Session["Position_Name"].ToString();
                FORM_TYPE_ID = Request.QueryString["type"];
                tempVendorID = AddForm_BLL.GetTempVendorID(formID);//获取tempvendorID
                btnPDF.ToolTip = Request.Url + "&outPutID=" + formID;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Session
            getSessionInfo();

            //Do
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formID = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string positionName = GridView1.Rows[drv.RowIndex].Cells[1].Text;
            if (e.CommandName == "approvesuccess")
            {
                if (positionName.Equals(Session["Position_Name"].ToString()))
                {
                    if (LocalApproveManager.doSuccessApprove(formID, tempVendorID, FORM_TYPE_ID, positionName, Page))
                    {
                        //Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowVendorDesignatedApply.aspx'</script>");
                    }
                    else if (e.CommandName == "fail")
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorDesignatedApply.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
            }
            else if (e.CommandName == "fail")
            {
                if (positionName.Equals(Session["Position_Name"].ToString()))
                {
                    LocalScriptManager.CreateScript(Page, String.Format("openReasonDialog('{0}','{1}','{2}',{3})", formID, positionName, Session["Factory_Name"].ToString(), "null"), "reasonDialog");
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string fileID = GridView2.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();//获取fileID
            if (e.CommandName == "view")
            {
                string filePath = LSetting.File_Reltive_Path + fileID + ".pdf";
                if (filePath != "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
                }
            }
        }

        private void hideImage(string signature, Image image)
        {
            if (signature != "")
            {
                image.ImageUrl = signature;
            }
            else
            {
                image.Visible = false;
            }
        }
    }
}