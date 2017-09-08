﻿using BLL;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class VendorInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee_ID"] == null || Session["Employee_ID"].ToString() == "")
            {
                Response.Redirect("~/login.aspx");
            }

            if (!IsPostBack)
            {

            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "addVendorMultiType":addVendorMultiType();break;
                    default:break;
                }
            }
        }

        /// <summary>
        /// 页面数据检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool checkPageData()
        {
            if (Temp_Vendor_Name.Text.Equals("") || Purchase_Money.Text.Equals(""))
            {
                LocalScriptManager.CreateScript(Page, "messageBox('" + "请输入供应商信息" + "');", "VendorInfo");
                return false;
            }

            try
            {
                if (Convert.ToInt32(Purchase_Money.Text.Trim())<=0)
                {
                    LocalScriptManager.CreateScript(Page, "messageBox('" + "金额错误" + "');", "Purchase_Money");
                    return false;
                }
            }
            catch (Exception)
            {
                LocalScriptManager.CreateScript(Page, "messageBox('" + "请输入正确的金额" + "');", "Purchase_Money");
                return false;
            }
            if (!Promise.Checked && !Advance_Charge.Checked && !Vendor_Assign.Checked)
            {
                LocalScriptManager.CreateScript(Page, "messageBox('" + "请选择承诺、预付款、指定选项" + "');", "Purchase_Money");
                return false;
            }
            return true;
        }

        private void addVendorMultiType()
        {
            //给供应商基本信息赋值
            string vendorType = DropDownList1.SelectedValue.Trim();

            //查询供应商类型编号
            string vendorTypeID = FillVendorInfo_BLL.selectVendorTypeId(Promise.Checked, Advance_Charge.Checked, Vendor_Assign.Checked, vendorType);

            //创建
            createVendorInfo(vendorTypeID,true);
        }

        //提交表单数据
        protected void button1_click(object sender, EventArgs e)
        {
            if (!checkPageData())
            {
                return;
            }
            //给供应商基本信息赋值
            string vendorType = DropDownList1.SelectedValue.Trim();
            
            //查询供应商类型编号
            string vendorTypeID = FillVendorInfo_BLL.selectVendorTypeId(Promise.Checked,Advance_Charge.Checked,Vendor_Assign.Checked,vendorType);

            //查询此组合的供应商是否存在
            int result = TempVendor_BLL.vendorExisted(Temp_Vendor_Name.Text.Trim(), vendorType);
            if (result == TempVendor_BLL.EXISTED)   //已经存在，提示无法重复创建
            {
                LocalScriptManager.CreateScript(Page, "message('供应商已存在，请勿重复创建')", "vendorExisted");
            }
            else if (result == TempVendor_BLL.NO_TYPE) //无此类型，跳转询问，确认后跳转addVendorMultiType（）函数
            {
                LocalScriptManager.CreateScript(Page, "openConfirmDialog()", "vendorNoType");
            }
            else //无此供应商信息，创建
            {
                createVendorInfo(vendorTypeID,false);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        /// <summary>
        /// 创建供应商信息
        /// </summary>
        /// <param name="vendorTypeID"></param>
        /// <param name="addType"></param>
        private void createVendorInfo(string vendorTypeID,bool addType)
        {
            //表单信息
            string purchaseMoney = Purchase_Money.Text.Trim();

            //添加临时供应商信息
            As_Temp_Vendor Temp_Vendor = new As_Temp_Vendor();
            Temp_Vendor.Temp_Vendor_Name = Temp_Vendor_Name.Text.Trim();
            Temp_Vendor.Vendor_Type_ID = vendorTypeID;
            Temp_Vendor.Purchase_Amount = Convert.ToInt32(purchaseMoney);
            int joinTempVendor = FillVendorInfo_BLL.addTempVendor(Temp_Vendor);

            //获取临时供应商编号
            string tempVendorID = TempVendor_BLL.getTempVendorID(Temp_Vendor.Temp_Vendor_Name);

            //添加提交审批信息（员工-供应商表）
            As_Employee_Vendor Employee_Vendor = new As_Employee_Vendor();
            Employee_Vendor.Employee_ID = Session["Employee_ID"].ToString();
            Employee_Vendor.Temp_Vendor_ID = tempVendorID;// Temp_Vendor_ID.Text.Trim();
            Employee_Vendor.Temp_Vendor_Name = Temp_Vendor_Name.Text.Trim();
            Employee_Vendor.Vendor_Type_ID = vendorTypeID;
            Employee_Vendor.Type = As_Employee_Vendor.NEW_VENDOR;
            int addEmployeeVendor = AddEmployeeVendor_BLL.addEmployeeVendor(Employee_Vendor);

            int bindResult = 0;
            if (addType)
            {
                bindResult = FillVendorInfo_BLL.addMultiTypeVendor(tempVendorID, Promise.Checked, Vendor_Assign.Checked, Advance_Charge.Checked, Purchase_Money.Text.Trim(), Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString()));
            }
            else
            {
                bindResult = FillVendorInfo_BLL.addNewVendorFormAndFile(tempVendorID, Promise.Checked, Vendor_Assign.Checked, Advance_Charge.Checked, Purchase_Money.Text.Trim(), Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString()));
            }

            //alert
            if (bindResult == 1)
            {
                Response.Redirect("EmployeeVendor.aspx");
            }
            else
            {
                Response.Write("<script>window.alert('供应商创建失败');window.location.href='index.aspx'</script>");
            }
        }
    }
}