using BLL;
using Model;
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
        }
        //提交表单数据
        protected void button1_click(object sender, EventArgs e)
        {
            //给供应商基本信息赋值
            string vendorType = DropDownList1.SelectedValue.Trim();
            string purchaseMoney= Purchase_Money.Text.Trim();
            string promise="0";
            string advanceCharge="0";
            string vendorAssign="0";
            if (Promise.Checked == true)
            {
                promise = "1";
            }
            if (Advance_Charge.Checked == true)
            {
                advanceCharge = "1";
            }
            if (Vendor_Assign.Checked == true)
            {
                vendorAssign = "1";
            }       
            //查询供应商类型编号
            string vendorTypeID = FillVendorInfo_BLL.selectVendorTypeId(promise, purchaseMoney, advanceCharge, vendorAssign, vendorType);

            //添加临时供应商信息
            As_Temp_Vendor Temp_Vendor = new As_Temp_Vendor();
            Temp_Vendor.Temp_Vendor_Name = Temp_Vendor_Name.Text.Trim();
            Temp_Vendor.Vendor_Type_ID = vendorTypeID;
            int joinTempVendor = FillVendorInfo_BLL.addTempVendor(Temp_Vendor);

            //添加提交审批信息（员工-供应商表）
            As_Employee_Vendor Employee_Vendor = new As_Employee_Vendor();
            Employee_Vendor.Employee_ID = Session["Employee_ID"].ToString();
            Employee_Vendor.Temp_Vendor_ID = Temp_Vendor_ID.Text.Trim();
            Employee_Vendor.Temp_Vendor_Name= Temp_Vendor_Name.Text.Trim();
            Employee_Vendor.Vendor_Type_ID = vendorTypeID;
            int addEmployeeVendor = AddEmployeeVendor_BLL.addEmployeeVendor(Employee_Vendor);

            //根据供应商类型编号查询所需表格类型编号
            string sql = "SELECT * FROM As_VendorType_FormType WHERE Vendor_Type_ID='" + vendorTypeID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FillVendorInfo_BLL.listVendorTypeFormType(sql);


            //添加供应商的所有表格
            As_Vendor_FormType Vendor_FormType = new As_Vendor_FormType();
            Vendor_FormType.Temp_Vendor_ID = Temp_Vendor_ID.Text.Trim();
            Vendor_FormType.Temp_Vendor_Name = Temp_Vendor_Name.Text.Trim();
            for (int i = 0; i < FillVendorInfo_BLL.listVendorTypeFormType(sql).Count; i++)
            {
                Vendor_FormType.Form_Type_Name = FillVendorInfo_BLL.listVendorTypeFormType(sql)[i].Form_Type_Name;
                Vendor_FormType.Form_Type_ID = FillVendorInfo_BLL.listVendorTypeFormType(sql)[i].Form_Type_ID;
                int addVendorFormType = FillVendorInfo_BLL.addVendorFormType(Vendor_FormType);
            }

            //根据供应商类型编号查询所需文件类型编号
            string sql1= "select * from As_VendorType_FileType where VendorType_ID='"+ vendorTypeID + "'";
            PagedDataSource objpds1 = new PagedDataSource();
            objpds1.DataSource = FillVendorInfo_BLL.listVendorTypeFileType(sql1);


            //添加供应商的所有文件
            As_Vendor_FileType Vendor_FileType = new As_Vendor_FileType();
            Vendor_FileType.Temp_Vendor_ID = Temp_Vendor_ID.Text.Trim();

            for (int i = 0; i < FillVendorInfo_BLL.listVendorTypeFileType(sql1).Count; i++)
            {
                Vendor_FileType.FileType_ID = FillVendorInfo_BLL.listVendorTypeFileType(sql1)[i].FileType_ID;
                Vendor_FileType.FileType_Name = File_Type_BLL.selectFileTypeName(Vendor_FileType.FileType_ID);
                int addVendorFileType = FillVendorInfo_BLL.addVendorFileType(Vendor_FileType);
            }


            Response.Write("<script>window.alert('新建成功')</script>");
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}