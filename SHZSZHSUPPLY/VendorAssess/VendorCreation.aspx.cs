using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorCreation : System.Web.UI.Page
    {
        public string FORM_NAME = "供应商信息表(建立)";
        public string FORM_TYPE_ID = "019";
        private static string factory;
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = false;//非show页面中不可操作
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
                    vendorCreation.Factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());

                    //名字只读
                    
                    int n = VendorCreation_BLL.addVendorCreation(vendorCreation);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        //获取formID信息
                        getSessionInfo();

                        //向FormFile表中添加相应的文件、表格绑定信息
                        bindingFormWithFile();
                        showfilelist(formID);
                    }

                }
                else
                {
                    showVendorCreation();
                }
            }
            else
            {
                //非用户部门，无submit回调
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
            formID = VendorCreation_BLL.getFormID(tempVendorID,FORM_TYPE_ID,factory);
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

                //Image1.ImageUrl = vendor.Line_Manager;
                //Image2.ImageUrl = vendor.Purchasing_Manager;
                //Image3.ImageUrl = vendor.Ministry_Of_Law;
                //Image4.ImageUrl = vendor.Accounting_Dept;
                //Image5.ImageUrl = vendor.Chief_Inspector;
                TextBox32.Text = vendor.Comments;
            }

            //展示附件
            showfilelist(formID);
        }

        /// <summary>
        /// 显示文件
        /// </summary>
        /// <param name="FormID"></param>
        private void showfilelist(string FormID)
        {
            return;
            getSessionInfo();
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "' and [File_ID] in (select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='"+tempVendorID+ "') and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        private As_Vendor_Creation saveForm(int flag, string manul)
        {
            //读取session
            getSessionInfo();

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
        public void approveAssess(string formId)
        {
            if (LocalApproveManager.doAddApprove(formId, FORM_NAME, FORM_TYPE_ID, tempVendorID))
            {
                Response.Write("<script>window.alert('提交成功！');window.location.href='EmployeeVendor.aspx';</script>");
                //Response.Write("<script>window.alert('提交成功！');window.location.href='~/VendorAssess/EmployeeVendor.aspx</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getSessionInfo();
            
            if (submit == "yes")
            {
                saveForm(2, "提交表格");

                approveAssess(formID);
            }
            else
            {
                Response.Write("<script>window.alert('无法提交！')</script>");
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
    }
}