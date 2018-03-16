using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorCreation : System.Web.UI.Page
    {
        public static string FORM_NAME = "供应商信息表(建立)";
        public static string FORM_TYPE_ID = "019";
        private static string factory;
        private static string tempVendorID = "";
        private static string tempVendorName = "";
        private static string formID = "";
        private static string submit = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = true;//非show页面中不可操作
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();

                int check = VendorCreation_BLL.checkVendorCreation(formID);
                if (check == 0)
                {
                    As_Vendor_Creation vendorCreation = new As_Vendor_Creation();
                    vendorCreation.Temp_Vendor_ID = tempVendorID;
                    vendorCreation.Form_Type_ID = FORM_TYPE_ID;
                    vendorCreation.Vendor_Name = tempVendorName;
                    vendorCreation.Flag = 0;//将表格标志位信息改为0
                    vendorCreation.Factory_Name = Session["Factory_Name"].ToString();

                    //名字只读

                    int n = VendorCreation_BLL.addVendorCreation(vendorCreation);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        formID = VendorCreation_BLL.getVendorCreationFormID(tempVendorID, FORM_TYPE_ID, factory, n);
                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = tempVendorID;
                        forms.Temp_Vendor_Name = tempVendorName;
                        forms.Form_Type_ID = FORM_TYPE_ID;
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = factory;
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);
                        //向FormFile表中添加相应的文件、表格绑定信息
                        bindingFormWithFile();
                    }

                }
                else
                {
                    showVendorCreation();
                }
            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "removeKCI":
                        approveAssess(0);       //removeKCI
                        break;
                    case "addKCI":
                        approveAssess(1);       //addKCI
                        break;
                    default:
                        break;
                }
            }
        }

        private void bindingFormWithFile()
        {
            if (CheckFile_BLL.bindFormFile(FORM_TYPE_ID,tempVendorID,formID) == 0)
            {
                Response.Write("<script>window.alert('表格初始化错误（文件绑定失败）！')</script>");//若没有记录 返回文件不全
            }
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
        private void getSessionInfo()
        {
            //初始化常量（伪）
            FORM_TYPE_ID = Request.QueryString["type"];
            FORM_NAME = FormType_BLL.getFormNameByTypeID(FORM_TYPE_ID);

            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            factory = Session["Factory_Name"].ToString().Trim();
            try
            {
                formID = Request.QueryString["Form_ID"].ToString().Trim();
            }
            catch
            {
                formID = "";
            }
            submit = Request.QueryString["submit"];
        }

        private void showVendorCreation()
        {
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

                //动态签名的不需要在非show页面进行显示

                Image1.ImageUrl = vendor.Line_Manager;
                //Image2.ImageUrl = vendor.Purchasing_Manager;
                //Image3.ImageUrl = vendor.Ministry_Of_Law;
                //Image4.ImageUrl = vendor.Accounting_Dept;
                //Image5.ImageUrl = vendor.Chief_Inspector;
                TextBox32.Text = vendor.Comments;
            }
        }


        private As_Vendor_Creation saveForm(int flag, string manul)
        {
            As_Vendor_Creation vendor = new As_Vendor_Creation();
            vendor.Form_ID = formID;
            vendor.Form_Type_ID = FORM_TYPE_ID;
            vendor.Purpose = TextBox1.Text;
            vendor.Initiator_Name = TextBox2.Text;
            vendor.Initiator_Tel = TextBox3.Text;
            vendor.Company_Code = TextBox4.Text;
            vendor.Account_Group = TextBox5.Text;
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

            int join = VendorCreation_BLL.updateVendorCreation(vendor);
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
                    LocalScriptManager.createManagerScript(Page, "window.alert('保存成功！')", "save");
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
        public void approveAssess(int kci)
        {
            if (LocalApproveManager.doAddApprove(formID, FORM_NAME, FORM_TYPE_ID, tempVendorID,kci))
            {
                LocalScriptManager.createManagerScript(this.Page, string.Format("messageConfirm('{0}','{1}')", "提交成功", "EmployeeVendor.aspx"),"submited");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (submit == "yes")
            {
                saveForm(2, "提交表格");

                LocalScriptManager.createManagerScript(this.Page, "openKCIConfirm()", "kci");
                //approveAssess(formID);
            }
            else
            {
                LocalApproveManager.showPendingReason(Page,tempVendorID,true);
                //Response.Write("<script>window.alert('无法提交！')</script>");
            }
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
            string fileID = GridView2.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();//获取fileID
            if (e.CommandName == "view")
            {
                string filePath = VendorCreation_BLL.getFilePath(fileID);
                if (filePath != "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
                }
            }
        }

        protected void btnNewImage_Click(object sender, EventArgs e)
        {
            string[] temp = ImgExSrc.Value.ToString().Split(',');
            Control control = FindControl(temp[0]);
            if (control != null)
            {
                ((Image)control).ImageUrl = temp[1];
            }
        }
    }
}