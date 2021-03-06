﻿using BLL;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace VendorAssess
{
    public partial class ShowVendorDesignatedApply : System.Web.UI.Page
    {
        private string formID = "";
        private string positionName = "";
        private string FORM_TYPE_ID = "";
        private string tempVendorID = "";
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //重新获取session
                getSessionInfo();

                int check = As_Vendor_Designated_Apply_BLL.checkVendorDesignatedApply(formID);
                if (check > 0)
                {
                    showThisForm();
                }
            }
        }

        private void showThisForm()
        {
            InitWholeForm();
            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");
            showapproveform(formID);
            showfilelist(formID);
        }

        private void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql,positionName);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        private void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            //string sql = "select * from As_Form_File where Form_ID='" + FormID + "' and Status='new'";
            string tempVendorID = AddForm_BLL.GetTempVendorID(formID);
            string sql = "select * from View_Form_File where Form_ID='" + FormID + "'  and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }
        private void InitWholeForm()//从数据库初始化整个数据表
        {
            As_Vendor_Designated_Apply form = As_Vendor_Designated_Apply_BLL.checkFlag(formID);
            if (form != null)
            {
                TextBox1.Text = form.VendorName;
                TextBox2.Text = form.SAPCode1;
                TextBox3.Text = form.BusinessCategory;
                TextBox4.Text = form.EffectiveTime.ToString();
                TextBox5.Text = form.PurchaseAmount;
                TextBox6.Text = form.Reason;
                TextBox7.Text = form.Initiator;
                TextBox8.Text = form.Date.ToString();
                //TextBox9.Text = form.Applicant;
                hideImage(form.Applicant, Image8);
                hideImage(form.RequestDeptHead, Image1);
                hideImage(form.FinManager, Image2);
                //Image1.ImageUrl = form.RequestDeptHead;
                //Image2.ImageUrl = form.FinManager;
                TextBox12.Text = form.ApplicantDate.ToString();
                TextBox13.Text = form.RequestDeptHeadDate.ToString();
                TextBox14.Text = form.FinManagerDate.ToString();
                hideImage(form.PurchasingManager, Image3);
                hideImage(form.GM, Image4);
                //Image3.ImageUrl = form.PurchasingManager;
                //Image4.ImageUrl = form.GM;
                TextBox17.Text = form.PurchasingManagerDtae.ToString();
                TextBox18.Text = form.GMDate1.ToString();
                hideImage(form.Director, Image5);
                hideImage(form.SupplyChainDirector, Image6);
                //Image5.ImageUrl = form.Director;
                //Image6.ImageUrl = form.SupplyChainDirector;
                TextBox21.Text = form.DirectorDtae.ToString();
                TextBox22.Text = form.SupplyChainDirectorDate.ToString();
                hideImage(form.Persident, Image7);
                //Image7.ImageUrl = form.Persident;
                TextBox24.Text = form.FinalDate.ToString();

                //补
                TextBox9.Text = form.VendorName1;
                TextBox10.Text = form.SAPCode_1;
                TextBox11.Text = form.BusinessCategory1;
                TextBox15.Text = form.EffectiveTime1.ToString();
                TextBox16.Text = form.PurchaseAmount1;
                TextBox19.Text = form.Reason1;
               
                TextBox20.Text = form.VendorName2;
                TextBox23.Text = form.SAPCode_2;
                TextBox25.Text = form.BusinessCategory2;
                TextBox26.Text = form.EffectiveTime2.ToString();
                TextBox27.Text = form.PurchaseAmount2;
                TextBox28.Text = form.Reason2;
          
                TextBox29.Text = form.VendorName3;
                TextBox30.Text = form.SAPCode_3;
                TextBox31.Text = form.BusinessCategory3;
                TextBox32.Text = form.EffectiveTime3.ToString();
                TextBox33.Text = form.PurchaseAmount3;
                TextBox34.Text = form.Reason3;
                                 
                TextBox35.Text = form.VendorName4;
                TextBox36.Text = form.SAPCode_4;
                TextBox37.Text = form.BusinessCategory4;
                TextBox38.Text = form.EffectiveTime4.ToString();
                TextBox39.Text = form.PurchaseAmount4;
                TextBox40.Text = form.Reason4;
            }
            else
            {
                Image1.Visible = false;//设置不可见
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = false;
                Image6.Visible = false;
                Image7.Visible = false;
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

            if (e.CommandName == "approvesuccess")
            {
                if (selectPositionName.Equals(Session["Position_Name"].ToString()))
                {

                    //int i = AssessFlow_BLL.updateApprove(formid, positionName);
                    if (LocalApproveManager.doSuccessApprove(formID, tempVendorID, FORM_TYPE_ID, positionName, Page))
                    {
                        //Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowVendorDesignatedApply.aspx'</script>");
                    }
                    else
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
                if (selectPositionName.Equals(Session["Position_Name"].ToString()))
                {
                    LocalScriptManager.CreateScript(Page, String.Format("openReasonDialog('{0}','{1}','{2}',{3})", formID, positionName, Session["Factory_Name"].ToString(), "null"), "reasonDialog");
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
            }
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
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
                btnPDF.ToolTip = Request.Url+"&outPutID=" + formID;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            getSessionInfo();
            //形成文件的ID 计划将简称保存到数据库的对应表中
            string fileTypeName = FormType_BLL.getFormNameByFormID(formID);
            string factory = AddForm_BLL.getFactoryByFormID(formID);
            string file = File_BLL.generateFileID(tempVendorID, fileTypeName, factory) + ".pdf";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>takeScreenshot('" + file + "','" + formID + "');</script>");
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
    }
}