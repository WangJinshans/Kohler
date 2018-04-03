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
    public partial class ShowServiceComponentApplication : System.Web.UI.Page
    {
        private static string positionName = "";
        private static string tempVendorID = "";
        private static string FORM_TYPE_ID = "";
        private static string tempVendorName = "";
        private static string factory = "";
        private static string formID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = ServiceComponentApplication_BLL.checkVendorServiceComponent(formID);//检查是否存在这张表
                if (check > 0)//数据库中不存在这张表，则自动初始化
                {
                    showVendorServiceComponentApplication();
                }
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

        private void bindingFormWithFile()
        {
            
        }

        private void showVendorServiceComponentApplication()
        {
            As_ServiceComponentApplication serviceComponent = new As_ServiceComponentApplication();
            serviceComponent = ServiceComponentApplication_BLL.checkFlag(formID);
            if (serviceComponent != null)
            {
                if (serviceComponent.ComponentApplicationItem != null && serviceComponent.ComponentApplicationItem.Count > 0)
                {
                    textbox101.Text = serviceComponent.Remark;
                    #region
                    for (int i = 0; i < serviceComponent.ComponentApplicationItem.Count; i++)
                    {
                        if (i == 0)
                        {
                            textbox1.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox2.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox3.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox4.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox5.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox6.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox7.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox8.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox9.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox10.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 1)
                        {
                            textbox11.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox12.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox13.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox14.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox15.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox16.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox17.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox18.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox19.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox20.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 2)
                        {
                            textbox21.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox22.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox23.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox24.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox25.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox26.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox27.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox28.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox29.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox30.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 3)
                        {
                            textbox31.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox32.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox33.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox34.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox35.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox36.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox37.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox38.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox39.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox40.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 4)
                        {
                            textbox41.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox42.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox43.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox44.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox45.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox46.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox47.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox48.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox49.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox50.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 5)
                        {
                            textbox51.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox52.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox53.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox54.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox55.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox56.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox57.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox58.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox59.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox60.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 6)
                        {
                            textbox61.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox62.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox63.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox64.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox65.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox66.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox67.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox68.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox69.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox70.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 7)
                        {
                            textbox71.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox72.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox73.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox74.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox75.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox76.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox77.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox78.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox79.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox80.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 8)
                        {
                            textbox81.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox82.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox83.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox84.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox85.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox86.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox87.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox88.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox89.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox90.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 9)
                        {
                            textbox91.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox92.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox93.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox94.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox95.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox96.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox97.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox98.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox99.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox100.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                    }
                    #endregion
                    hideImage(serviceComponent.Initiator, image1);
                    hideImage(serviceComponent.Supply_Chain_Manager, image2);
                    hideImage(serviceComponent.Finance_Manager, image3);
                    hideImage(serviceComponent.GM, image4);
                }
            }
            showfilelist(formID);
            showapproveform(formID);
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

        //暂无文件绑定
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //重新读取session信息
            getSessionInfo();

            //参数
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
    }
}