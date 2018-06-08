using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowPurchasePriceApplication : System.Web.UI.Page
    {
        public static string FORM_NAME = "供应商调查表";
        public static string FORM_TYPE_ID = "026";
        private static string positionName = "";
        private static string tempVendorID = "";
        private static string tempVendorName = "";
        private static string factory = "";
        private static string formID = "";
        private static string submit = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = PurchasePriceApplication_BLL.checkVendorPurchasePriceApplication(formID);//检查是否存在这张表
                if (check > 0)//数据库中不存在这张表，则自动初始化
                {
                    showVendorPurchasePriceApplication();
                }
            }
            else
            {

            }
        }

        private void showfilelist(string formID)
        {
            string sql = "select * from View_Form_File where Form_ID='" + formID + "'  and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        private void showVendorPurchasePriceApplication()
        {
            As_PurchasePriceApplication purchasePrice = new As_PurchasePriceApplication();
            purchasePrice = PurchasePriceApplication_BLL.checkFlag(formID);
            if (purchasePrice != null)
            {
                if (purchasePrice.PurchasePriceItem != null && purchasePrice.PurchasePriceItem.Count > 0)
                {
                    textbox121.Text = purchasePrice.ReMark;
                    #region
                    for (int i = 0; i < purchasePrice.PurchasePriceItem.Count; i++)
                    {
                        if (i == 0)
                        {
                            textbox1.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox2.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox3.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox4.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox5.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox6.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox7.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox8.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox9.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox10.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox11.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox12.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 1)
                        {
                            textbox13.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox14.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox15.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox16.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox17.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox18.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox19.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox20.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox21.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox22.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox23.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox24.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 2)
                        {
                            textbox25.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox26.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox27.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox28.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox29.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox30.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox31.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox32.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox33.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox34.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox35.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox36.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 3)
                        {
                            textbox37.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox38.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox39.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox40.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox41.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox42.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox43.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox44.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox45.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox46.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox47.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox48.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 4)
                        {
                            textbox49.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox50.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox51.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox52.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox53.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox54.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox55.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox56.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox57.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox58.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox59.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox60.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 5)
                        {
                            textbox61.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox62.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox63.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox64.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox65.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox66.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox67.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox68.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox69.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox70.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox71.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox72.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 6)
                        {
                            textbox73.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox74.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox75.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox76.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox77.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox78.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox79.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox80.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox81.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox82.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox83.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox84.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 7)
                        {
                            textbox85.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox86.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox87.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox88.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox89.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox90.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox91.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox92.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox93.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox94.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox95.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox96.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 8)
                        {
                            textbox97.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox98.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox99.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox100.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox101.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox102.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox103.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox104.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox105.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox106.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox107.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox108.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 9)
                        {
                            textbox109.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox110.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox111.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox112.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox113.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox114.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox115.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox116.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox117.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox118.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox119.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox120.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                    }
                    #endregion
                    hideImage(purchasePrice.Initiator, image1);
                    hideImage(purchasePrice.Supply_Chain_Manager, image2);
                    hideImage(purchasePrice.Finance_Manager, image3);
                    hideImage(purchasePrice.GM, image4);
                    hideImage(purchasePrice.Director_Sourcing_KCI, image5);
                    hideImage(purchasePrice.Finance_Director_KCI, image6);
                }
            }
            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");
            showfilelist(formID);
            showapproveform(formID);
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //重新读取session信息
            getSessionInfo();

            //参数
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string selectPositionName = GridView1.Rows[drv.RowIndex].Cells[1].Text;

            //如果是通过
            if (e.CommandName == "approvesuccess")
            {
                if (selectPositionName.Equals(positionName))
                {
                    if (LocalApproveManager.doSuccessApprove(formID, tempVendorID, FORM_TYPE_ID, positionName, Page))
                    {
                        //Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowBiddingApprovalForm.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowBiddingApprovalForm.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }

            }//如果拒绝
            else if (e.CommandName == "fail")
            {
                if (selectPositionName.Equals(positionName))
                {//填写原因
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
            //重新读取session信息
            getSessionInfo();

            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string fileID = GridView2.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();//获取fileID
            string selectPositionName = GridView2.Rows[drv.RowIndex].Cells[1].Text;

            if (e.CommandName == "view")
            {
                string filePath = LSetting.File_Reltive_Path + fileID + ".pdf";
                if (filePath != "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
                }
            }
        }


        private void showapproveform(string formID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + formID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql, positionName);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
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

        private void getSessionInfo()
        {
            if (Request.QueryString["outPutID"] != null && Request.QueryString["outPutID"] != "")
            {
                formID = Request.QueryString["outPutID"];
                FORM_TYPE_ID = Request.QueryString["type"];
                LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextboxs");
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
    }
}