﻿using BLL;
using Model;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowVendorCreation : System.Web.UI.Page
    {
        private string formID = null;
        private string positionName = null;
        /// <summary>
        /// formID怎么得到  通过表审批的formID确定每一张表
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //重新获取session
                getSessionInfo();

                int check = VendorCreation_BLL.checkVendorCreation(formID);
                if (check > 0)
                {
                    showVendorCreation();
                }
                else
                {
                    Image1.Visible = false;
                    Image2.Visible = false;
                    Image3.Visible = false;
                    Image4.Visible = false;
                    Image5.Visible = false;
                }
            }
            
        }

        private void showVendorCreation()
        {
            //session赋值
            As_Vendor_Creation vendor = VendorCreation_BLL.getVendorCreation(formID);
            if (vendor != null)
            {
                TextBox1.Text = vendor.Purpose;
                TextBox2.Text = vendor.Initiator_Name;
                TextBox3.Text = vendor.Initiator_Tel;
                TextBox4.Text = vendor.Company_Code;
                TextBox5.Text = vendor.Account_Group;
                TextBox6.Text = vendor.Vendor_Code;
                TextBox7.Text = vendor.Vendor_Name;
                TextBox8.Text = vendor.Street;
                TextBox9.Text = vendor.Postal_Code;
                TextBox10.Text = vendor.City;
                TextBox11.Text = vendor.Country;
                TextBox12.Text = vendor.Region;
                TextBox13.Text = vendor.Language;
                TextBox14.Text = vendor.Telephone_No;
                TextBox15.Text = vendor.Fax_No;
                TextBox16.Text = vendor.Email_Address_One;
                TextBox17.Text = vendor.Email_Address_Two;
                TextBox18.Text = vendor.Tax_Identification_Number;
                TextBox19.Text = vendor.Payment_Term;
                TextBox20.Text = vendor.Payment_Method;
                TextBox21.Text = vendor.Bank_Code;
                TextBox22.Text = vendor.Bank_Name;
                TextBox23.Text = vendor.Bank_Country;
                TextBox24.Text = vendor.Bank_Account;
                TextBox25.Text = vendor.Money_Type;
                TextBox26.Text = vendor.Trade_Onym;
                TextBox32.Text = vendor.Comments;
                hideImage(vendor.Line_Manager, Image1);
                hideImage(vendor.Purchasing_Manager, Image2);
                hideImage(vendor.Ministry_Of_Law, Image3);
                hideImage(vendor.Accounting_Dept, Image4);
                hideImage(vendor.Chief_Inspector, Image5);
            }
            showapproveform(formID);
            showfilelist(formID);
        }

        public void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql,positionName);
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
                if (selectPositionName.Equals(Session["Position_Name"].ToString()))
                {
                    int i = AssessFlow_BLL.updateApprove(formid, positionName);
                    if (i == 1)
                    {
                        Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowVendorCreation.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorCreation.aspx'</script>");
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
                    int i = AssessFlow_BLL.updateApproveFail(formid, positionName);
                    if (i == 1)
                    {
                        Response.Write("<script>window.alert('成功拒绝审批！');window.location.href='ShowVendorCreation.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorCreation.aspx'</script>");
                    }
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
            formID = Session["formID"].ToString();
            positionName = Session["Position_Name"].ToString();
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