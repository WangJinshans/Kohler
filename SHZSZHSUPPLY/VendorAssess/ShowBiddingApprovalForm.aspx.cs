﻿using BLL;
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
    public partial class ShowBiddingApprovalForm : System.Web.UI.Page
    {
        private string formID = null;
        private string positionName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //重新获取session
                getSessionInfo();

                int check = As_Bidding_Approval_BLL.checkBiddingForm(formID);
                if (check > 0)
                {
                    showBiddingForm();
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
        /// <summary>
        /// 显示表格
        /// </summary>
        private void showBiddingForm()
        {
            As_Bidding_Approval biddingForm = As_Bidding_Approval_BLL.getBiddingForm(formID);
            if (biddingForm != null)
            {
                TextBox1.Text = biddingForm.Serial_No;
                TextBox2.Text = biddingForm.Date;
                TextBox3.Text = biddingForm.Product;
                TextBox4.Text = biddingForm.Purchase_Amount;
                TextBox5.Text = biddingForm.MOQ1;
                TextBox6.Text = biddingForm.MOQ2;
                TextBox7.Text = biddingForm.MOQ3;
                TextBox8.Text = biddingForm.Lead_Time1;
                TextBox9.Text = biddingForm.Lead_Time2;
                TextBox10.Text = biddingForm.Lead_Time3;
                TextBox11.Text = biddingForm.Payment_Term1;
                TextBox12.Text = biddingForm.Payment_Term2;
                TextBox13.Text = biddingForm.Payment_Term3;
                TextBox14.Text = biddingForm.Remark1;
                TextBox15.Text = biddingForm.Remark2;
                TextBox16.Text = biddingForm.Remark3;
                TextBox17.Text = biddingForm.Reason_One;
                TextBox18.Text = biddingForm.Reason_Two;
                //TODO::image

                hideImage(biddingForm.Supplier_Chain_Leader, Image2);
                hideImage(biddingForm.Initiator, Image1);
                hideImage(biddingForm.Business_Leader, Image4);
                hideImage(biddingForm.Finance_Leader, Image3);

                int[] arr = { 0, 0, 0, 0, 0 };
                for (int i = 0; i < biddingForm.ProjectList.Count; i++)
                {
                    arr[i] = 1;
                }
                //list
                if (arr[0] == 1)
                {
                    TextBox19.Text = biddingForm.ProjectList[0].Item;
                    TextBox20.Text = biddingForm.ProjectList[0].Description;
                    TextBox21.Text = biddingForm.ProjectList[0].Price1;
                    TextBox22.Text = biddingForm.ProjectList[0].Price2;
                    TextBox23.Text = biddingForm.ProjectList[0].Price3;
                    TextBox24.Text = biddingForm.ProjectList[0].Remark;
                }
                if (arr[1] == 1)
                {
                    TextBox25.Text = biddingForm.ProjectList[1].Item;
                    TextBox26.Text = biddingForm.ProjectList[1].Description;
                    TextBox27.Text = biddingForm.ProjectList[1].Price1;
                    TextBox28.Text = biddingForm.ProjectList[1].Price2;
                    TextBox29.Text = biddingForm.ProjectList[1].Price3;
                    TextBox30.Text = biddingForm.ProjectList[1].Remark;
                }
                if (arr[2] == 1)
                {
                    TextBox31.Text = biddingForm.ProjectList[2].Item;
                    TextBox32.Text = biddingForm.ProjectList[2].Description;
                    TextBox33.Text = biddingForm.ProjectList[2].Price1;
                    TextBox34.Text = biddingForm.ProjectList[2].Price2;
                    TextBox35.Text = biddingForm.ProjectList[2].Price3;
                    TextBox36.Text = biddingForm.ProjectList[2].Remark;
                }
                if (arr[3] == 1)
                {
                    TextBox37.Text = biddingForm.ProjectList[3].Item;
                    TextBox38.Text = biddingForm.ProjectList[3].Description;
                    TextBox39.Text = biddingForm.ProjectList[3].Price1;
                    TextBox40.Text = biddingForm.ProjectList[3].Price2;
                    TextBox41.Text = biddingForm.ProjectList[3].Price3;
                    TextBox42.Text = biddingForm.ProjectList[3].Remark;
                }
                if (arr[4] == 1)
                {
                    TextBox43.Text = biddingForm.ProjectList[4].Item;
                    TextBox44.Text = biddingForm.ProjectList[4].Description;
                    TextBox45.Text = biddingForm.ProjectList[4].Price1;
                    TextBox46.Text = biddingForm.ProjectList[4].Price2;
                    TextBox47.Text = biddingForm.ProjectList[4].Price3;
                    TextBox48.Text = biddingForm.ProjectList[4].Remark;
                }
            }
            //展示附件
            showfilelist(formID);
            showapproveform(formID);
        }


        public void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql, positionName);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }
        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //重新读取session信息
            getSessionInfo();

            //TODO::简单的审批权限控制，通过之后无法再拒绝，拒绝之后无法再通过，拒绝需要填写原因，三厂区分
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string selectPositionName = GridView1.Rows[drv.RowIndex].Cells[1].Text;

            if (e.CommandName == "approvesuccess")
            {
                if (selectPositionName.Equals(positionName))
                {
                    int i = AssessFlow_BLL.updateApprove(formid, positionName);
                    if (LocalApproveManager.doSuccessApprove(formID, Session["tempVendorID"].ToString(), "002", positionName))
                    {
                        Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowBiddingApprovalForm.aspx'</script>");
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

            }
            else if (e.CommandName == "fail")
            {
                if (selectPositionName.Equals(positionName))
                {
                    LocalScriptManager.CreateScript(Page, String.Format("openReasonDialog('{0}','{1}','{2}',{3})", formID, positionName, Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString()), "null"), "reasonDialog");
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
            }
            //TODO::如果是最后一个审批人，设置完成状态或者hold等待kci
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
        private void getSessionInfo()
        {
            formID = Session["formID"].ToString();
            positionName = Session["Position_Name"].ToString();
        }
    }
}