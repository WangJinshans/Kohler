﻿using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;
using WebLearning.BLL;
using WebLearning.Model;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorModify : System.Web.UI.Page
    {
        public static string FORM_NAME = "供应商信息表(修改)";
        public static string FORM_TYPE_ID = "020";
        private static string factory;
        private static string tempVendorID = "";
        private static string tempVendorName = "";
        private static string formID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = false;//非show页面中不可操作
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            if (!IsPostBack)
            {
                getSessionInfo();

                int check = VendorModify_BLL.checkVendorModification(formID);
                if (check == 0)
                {
                    As_Vendor_Modify vendorModify = new As_Vendor_Modify();
                    vendorModify.Temp_Vendor_ID = tempVendorID;
                    vendorModify.Form_Type_ID = FORM_TYPE_ID;
                    vendorModify.Vendor_Name = tempVendorName;
                    vendorModify.Flag = 0;//将表格标志位信息改为0
                    vendorModify.Factory_Name = Session["Factory_Name"].ToString();


                    int n = VendorModify_BLL.addVendorModification(vendorModify);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        //获取formID信息上海标准件公司沪西销售部
                        //向FormFile表中添加相应的文件、表格绑定信息
                        //bindingFormWithFile();

                        formID = VendorModify_BLL.getVendorModifyFormID(tempVendorID, "020", factory, n);

                        showfilelist(tempVendorID,factory);
                    }

                }
                else
                {
                    showVendorModify();
                }
            }
            else
            {
                
            }
        }

        private void bindingFormWithFile()
        {
            if (CheckFile_BLL.bindFormFile(FORM_TYPE_ID, tempVendorID, formID) == 0)
            {
                Response.Write("<script>window.alert('表格初始化错误（文件绑定失败）！')</script>");//若没有记录 返回文件不全
            }
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
        private void getSessionInfo()
        {
            FORM_NAME = FormType_BLL.getFormNameByTypeID(FORM_TYPE_ID);
            tempVendorID = Request.QueryString["temp_Vendor_ID"].ToString().Trim();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            factory = Session["Factory_Name"].ToString();
            formID = VendorModify_BLL.getFormID(tempVendorID, FORM_TYPE_ID, factory);
        }

        private void showVendorModify()
        {
            As_Vendor_Modify vendor = VendorModify_BLL.getVendorModification(formID);
            if (vendor != null)
            {
                TextBox1.Text = vendor.Purpose;
                TextBox2.Text = vendor.Initiator_Name;
                TextBox3.Text = vendor.Initiator_Tel;
                TextBox4.Text = vendor.Company_Code;
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
            }

            //展示附件
            showfilelist(tempVendorID,factory);
        }


        /// <summary>
        /// 显示这个修改表需要的所有附件 并提供显示连接
        /// </summary>
        /// <param name="temp_Vendor_Name"></param>
        /// <param name="factory_Name"></param>
        private void showfilelist(string temp_Vendor_ID,string factory_Name)
        {
            Vendor_Modify_File modify = new Vendor_Modify_File();
            string sql = "select * from As_Vendor_Modify_File where Temp_Vendor_ID='" + temp_Vendor_ID + "' and factory_Name='" + factory + "' and Status='new'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = Vendor_Modify_File_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        private As_Vendor_Modify saveForm(int flag, string manul)
        {
            As_Vendor_Modify vendor = new As_Vendor_Modify();
            vendor.Form_ID = formID;
            vendor.Form_Type_ID = FORM_TYPE_ID;
            vendor.Purpose = TextBox1.Text;
            vendor.Initiator_Name = TextBox2.Text;
            vendor.Initiator_Tel = TextBox3.Text;
            vendor.Company_Code = TextBox4.Text;
            vendor.Vendor_Name = TextBox6.Text;
            vendor.Vendor_Code = TextBox7.Text;
            vendor.Street = TextBox8.Text;
            vendor.Postal_Code = TextBox9.Text;
            vendor.City = TextBox10.Text;
            vendor.Country = TextBox11.Text;
            vendor.Region = TextBox12.Text;
            vendor.Language = TextBox13.Text;
            vendor.Telephone_No = TextBox14.Text;
            vendor.Fax_No = TextBox15.Text;
            vendor.Email_Address_One = TextBox16.Text;
            vendor.Email_Address_Two = TextBox17.Text;
            vendor.Tax_Identification_Number = TextBox18.Text;
            vendor.Payment_Term = TextBox19.Text;
            vendor.Payment_Method = TextBox20.Text;
            vendor.Bank_Code = TextBox21.Text;
            vendor.Bank_Name = TextBox22.Text;
            vendor.Bank_Country = TextBox23.Text;
            vendor.Bank_Account = TextBox24.Text;
            vendor.Money_Type = TextBox25.Text;
            vendor.Trade_Onym = TextBox26.Text;
            vendor.Line_Manager = Image1.ImageUrl.ToString().Trim();
            vendor.Purchasing_Manager = Image2.ImageUrl.ToString().Trim();
            vendor.Ministry_Of_Law = Image3.ImageUrl.ToString().Trim();
            vendor.Accounting_Dept = Image4.ImageUrl.ToString().Trim();
            vendor.Chief_Inspector = Image5.ImageUrl.ToString().Trim();
            vendor.Comments = TextBox32.Text;
            vendor.Temp_Vendor_ID = tempVendorID;
            vendor.Flag = flag;

            int join = VendorModify_BLL.updateVendorModification(vendor);
            if (join > 0)
            {
                As_Write write = new As_Write();//将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = vendor.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = tempVendorID;
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    Response.Write("<script>window.alert('保存成功！')</script>");
                }
                return vendor;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 确定审批流程
        /// </summary>
        /// <param name="formTypeID"></param>
        /// <param name="formId"></param>
        public void approveAssess(string formID)
        {
            if (LocalApproveManager.AddModifyAssess(formID, FORM_NAME, FORM_TYPE_ID, tempVendorID,factory))
            {
                Response.Write("<script>window.alert('提交成功！您可能还有一些文件需要更新');window.location.href='/VendorAssess/VendorModifyInfo.aspx?ID="+tempVendorID+"&Factory="+factory+"';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            saveForm(2, "提交表格");
            approveAssess(formID);
            Response.Write("<script>window.alert('提交成功！')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            saveForm(1, "保存表格");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeVendor.aspx");
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string fileTypeName = GridView2.Rows[drv.RowIndex].Cells[0].Text.ToString().Trim();
            string fileID= File_BLL.getFileID(tempVendorID, Session["Factory_Name"].ToString(), fileTypeName);
            if (e.CommandName == "view")
            {
                string filePath = "../files/" + fileID + ".pdf";/*VendorModify_BLL.getFilePath(fileID);*/
                if (fileID != "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}