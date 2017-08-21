using AendorAssess;
using BLL;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI.WebControls;

/*
 * 由于合同审批表的承诺影响审批提交，所以本页内均使用自定义approve过程函数，和LocalApproveManager中的提交过程无关
 */

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ContractApprovalForm : System.Web.UI.Page
    {
        public string FORM_NAME = "合同审批表";
        public string FORM_TYPE_ID = "008";
        private static string factory = "";
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";
        private string bar_Code = "PR-05-17-3";

        protected void Page_Load(object sender, EventArgs e)
        {
            Textbox79.Visible = false;
            
            Textbox83.Visible = false;
            Textbox84.Visible = false;
            Textbox85.Visible = false;
            Image1.Visible = false;
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            Image6.Visible = false;
            Image7.Visible = false;
            Image8.Visible = false;
            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();
                int check = ContractApproval_BLL.checkContractApproval(formID);
                if (check == 0)
                {
                    As_Contract_Approval vendorContract = new As_Contract_Approval();
                    vendorContract.Temp_Vendor_ID = tempVendorID;
                    vendorContract.Form_Type_ID = FORM_TYPE_ID;
                    vendorContract.Vendor_Name = tempVendorName;
                    vendorContract.Flag = 0;//将表格标志位信息改为0
                    vendorContract.Factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());


                    //名字只读

                    int n = ContractApproval_BLL.addContractApproval(vendorContract);
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
                        //bindingFormWithFile();
                    }

                }
                else
                {
                    showConstractApproval();
                }
            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "submitForm":
                        StandardContractSubmitForm();
                        break;
                    case "nonSubmitForm":
                        nonStandardContractSubmitForm();
                        break;
                    default:
                        break;
                }
            }

        }

        protected string StandardContractSubmitForm()
        {
            //读取session
            getSessionInfo();

            SelectDepartment.doSelect();

            //一旦提交就把表As_Vendor_FormType字段FLag置1.
            int updateFlag = UpdateFlag_BLL.updateFlag(FORM_TYPE_ID, tempVendorID);
            
            //插入到已提交表
            As_Form form = new As_Form();
            form.Form_ID = formID;
            form.Form_Type_Name = FORM_NAME;
            form.Form_Type_ID = FORM_TYPE_ID;
            form.Temp_Vendor_Name = tempVendorName;
            form.Form_Path = "";
            form.Temp_Vendor_ID = tempVendorID;
            form.Factory_Name = factory;
            int add = AddForm_BLL.addForm(form);

            Response.Redirect("EmployeeVendor.aspx");
            return "";
        }

        protected string nonStandardContractSubmitForm()//非标准合同的回掉函数
        {
            //读取session
            getSessionInfo();

            SelectDepartment.doSelect();
            
            //将该表的标准合同置为yes
            UpdateFlag_BLL.updateNonStandardConstractFlag(formID);
            //插入到已提交表
            As_Form form = new As_Form();
            form.Form_ID = formID;
            form.Form_Type_Name = FORM_NAME;
            form.Form_Type_ID = FORM_TYPE_ID;
            form.Temp_Vendor_Name = tempVendorName;
            form.Form_Path = "";
            form.Temp_Vendor_ID = tempVendorID;
            form.Factory_Name = factory;
            int add = AddForm_BLL.addForm(form);
            //一旦提交就把表As_Vendor_FormType字段FLag置1.
            int updateFlag = UpdateFlag_BLL.updateFlag(FORM_TYPE_ID, tempVendorID);

            Response.Redirect("EmployeeVendor.aspx");
            return "";
        }
        
        private void showConstractApproval()
        {
            As_Contract_Approval contractApproval = ContractApproval_BLL.getContractApproval(formID);
            if (contractApproval != null)
            {
                Textbox1.Text = contractApproval.Ref_No;
                Textbox2.Text = contractApproval.Sourcing_Specialist;
                Textbox3.Text = contractApproval.User_Dept;
                Textbox4.Text = contractApproval.Purchase_Description;
                Textbox5.Text = contractApproval.Contract_Subject;
                Textbox6.Text = contractApproval.Contract_Annual_Amount;
                Textbox7.Text = contractApproval.Contract_StartTime;
                Textbox86.Text = contractApproval.Contract_EndTime;
                Textbox8.Text = contractApproval.Vendor_Name;
                //hideImage(contractApproval.User_Dept_Head_One, Image8);
                Textbox11.Text = contractApproval.Payment_Terms_Page;
                Textbox9.Text = contractApproval.Payment_Terms_Clause;
                Textbox13.Text = contractApproval.Payment_Terms_Details;
                //Textbox14.Text = contractApproval.Fin_Leader;
                //hideImage(contractApproval.Fin_Leader, Image7);
                Textbox16.Text = contractApproval.Price_Adjustment_Page;
                Textbox17.Text = contractApproval.Price_Adjustment_Clause;
                Textbox19.Text = contractApproval.Price_Adjustment_Details;
                Textbox20.Text = contractApproval.Volume_Page;
                Textbox21.Text = contractApproval.Volume_Clause;
                Textbox23.Text = contractApproval.Volume_Details;
                Textbox24.Text = contractApproval.Period_Page;
                Textbox25.Text = contractApproval.Period_Clause;
                Textbox27.Text = contractApproval.Period_Details;
                Textbox28.Text = contractApproval.Rebate_Page;
                Textbox29.Text = contractApproval.Rebate_Clause;
                Textbox31.Text = contractApproval.Rebate_Details;
                Textbox32.Text = contractApproval.Work_Scope_Page;
                Textbox33.Text = contractApproval.Work_Scope_Clause;
                Textbox35.Text = contractApproval.Work_Scope_Details;
                Textbox36.Text = contractApproval.Acceptence_Criteria_Page;
                Textbox37.Text = contractApproval.Acceptence_Criteria_Clause;
                Textbox39.Text = contractApproval.Acceptence_Criteria_Details;
                Textbox40.Text = contractApproval.Warranty_Page;
                Textbox41.Text = contractApproval.Warranty_Clause;
                Textbox43.Text = contractApproval.Warranty_Details;
                Textbox44.Text = contractApproval.Termination_Page;
                Textbox45.Text = contractApproval.Termination_Clause;
                Textbox47.Text = contractApproval.Termination_Details;
                Textbox48.Text = contractApproval.Exclusivity_Page;
                Textbox49.Text = contractApproval.Exclusivity_Clause;
                Textbox51.Text = contractApproval.Exclusivity_Details;
                Textbox52.Text = contractApproval.Other_Terms_Page;
                Textbox53.Text = contractApproval.Other_Terms_Clause;
                Textbox55.Text = contractApproval.Other_Terms_Details;
                Textbox56.Text = contractApproval.Penalty_Detail_Page;
                Textbox57.Text = contractApproval.Penalty_Detail_Clause;
                Textbox59.Text = contractApproval.Penalty_Detail_Details;
                //Textbox87.Text = contractApproval.User_Dept_Head_Two;
                //hideImage(contractApproval.User_Dept_Head_Two, Image6);
                Textbox12.Text = contractApproval.Notice_Page;
                Textbox18.Text = contractApproval.Notice_Clause;
                Textbox22.Text = contractApproval.Notice_Details;
                Textbox30.Text = contractApproval.Confidentiality_Page;
                Textbox34.Text = contractApproval.Confidentiality_Clause;
                Textbox38.Text = contractApproval.Confidentiality_Details;
                Textbox46.Text = contractApproval.Announcement_Page;
                Textbox50.Text = contractApproval.Announcement_Clause;
                Textbox54.Text = contractApproval.Announcement_Details;
                Textbox60.Text = contractApproval.Waivers_Page;
                Textbox61.Text = contractApproval.Waivers_Clause;
                Textbox62.Text = contractApproval.Waivers_Details;
                Textbox64.Text = contractApproval.Severalbility_Page;
                Textbox65.Text = contractApproval.Severalbility_Clause;
                Textbox66.Text = contractApproval.Severalbility_Details;
                Textbox68.Text = contractApproval.Force_Majeure;
                Textbox69.Text = contractApproval.Force_Clause;
                Textbox70.Text = contractApproval.Force_Details;
                Textbox72.Text = contractApproval.Delegation_Page;
                Textbox73.Text = contractApproval.Delegation_Clause;
                Textbox74.Text = contractApproval.Delegation_Details;
                Textbox76.Text = contractApproval.Dispute_Resolution_Page;
                Textbox77.Text = contractApproval.Dispute_Resolution_Clause;
                Textbox78.Text = contractApproval.Dispute_Resolution_Details;
                Textbox80.Text = contractApproval.Other_Provisions_Page;
                Textbox81.Text = contractApproval.Other_Provisions_Clause;
                Textbox82.Text = contractApproval.Other_Provisions_Details;
                //Textbox26.Text = contractApproval.Legal_Head;
                //hideImage(contractApproval.Legal_Head, Image5);
                //Textbox42.Text = contractApproval.SourcingSpecialist_Signature;
                Textbox14.Text = contractApproval.SourcingSpecialist_Signature;//申请人自己填写
                //hideImage(contractApproval.User_Dept_Head_Signature, Image1);
                //hideImage(contractApproval.SC_Leader_Signature, Image2);
                //hideImage(contractApproval.Finance_Leader_Signature, Image3);
                //hideImage(contractApproval.General_Manager_Signature, Image4);
                //Image1.ImageUrl = contractApproval.User_Dept_Head_Signature;
                //Image2.ImageUrl = contractApproval.SC_Leader_Signature;
                //Image3.ImageUrl = contractApproval.Finance_Leader_Signature;
                //Image4.ImageUrl = contractApproval.General_Manager_Signature;
                Textbox75.Text = contractApproval.SourcingSpecialist_Date;
                Textbox79.Text = contractApproval.User_Dept_Head_Date;
                Textbox83.Text = contractApproval.SC_Leader_Date;
                Textbox84.Text = contractApproval.Finance_Leader_Date;
                Textbox85.Text = contractApproval.General_Manager_Date;
                checkBoxInit(contractApproval);

            }
        }

        //private void hideImage(string signature, Image image)
        //{
        //    if (signature != "")
        //    {
        //        image.ImageUrl = signature;
        //    }
        //    else
        //    {
        //        image.Visible = false;
        //    }
        //}

        private void checkBoxInit(As_Contract_Approval contractApproval)
        {
            if (contractApproval.Purchase_Type == "Direct")
            {
                CheckBox1.Checked = true;
            }
            else if (contractApproval.Purchase_Type == "Indirect")
            {
                CheckBox2.Checked = true;
            }
            else if (contractApproval.Purchase_Type == "Capital")
            {
                CheckBox3.Checked = true;
            }
            else if (contractApproval.Payment_Terms_Commitment == "1")
            {
                CheckBox6.Checked = true;
            }
            else if (contractApproval.Price_Adjustment_Commitment == "1")
            {
                CheckBox7.Checked = true;
            }
            else if (contractApproval.Volume_Commitment == "1")
            {
                CheckBox8.Checked = true;
            }
            else if (contractApproval.Period_Commitment == "1")
            {
                CheckBox9.Checked = true;
            }
            else if (contractApproval.Rebate_Commitment == "1")
            {
                CheckBox10.Checked = true;
            }
            else if (contractApproval.Work_Scope_Commitment == "1")
            {
                CheckBox11.Checked = true;
            }
            else if (contractApproval.Acceptence_Criteria_Commitment == "1")
            {
                CheckBox12.Checked = true;
            }
            else if (contractApproval.Warranty_Commitment == "1")
            {
                CheckBox13.Checked = true;
            }
            else if (contractApproval.Termination_Commitment == "1")
            {
                CheckBox14.Checked = true;
            }
            else if (contractApproval.Exclusivity_Commitment == "1")
            {
                CheckBox15.Checked = true;
            }
            else if (contractApproval.Other_Provisions_Commitment == "1")
            {
                CheckBox16.Checked = true;
            }
            else if (contractApproval.Changes == "1")
            {
                CheckBox18.Checked = true;
                if (contractApproval.Notice_Commitment == "1")
                {
                    CheckBox20.Checked = true;
                }
                else if (contractApproval.Confidentiality_Commitment == "1")
                {
                    CheckBox21.Checked = true;
                }
                else if (contractApproval.Announcement_Commitment == "1")
                {
                    CheckBox22.Checked = true;
                }
                else if (contractApproval.Waivers_Commitment == "1")
                {
                    CheckBox23.Checked = true;
                }
                else if (contractApproval.Severalbility_Commitment == "1")
                {
                    CheckBox24.Checked = true;
                }
                else if (contractApproval.Force_Commitment == "1")
                {
                    CheckBox25.Checked = true;
                }
                else if (contractApproval.Delegation_Commitment == "1")
                {
                    CheckBox26.Checked = true;
                }
                else if (contractApproval.Dispute_Resolution_Commitment == "1")
                {
                    CheckBox27.Checked = true;
                }
                else if (contractApproval.Other_Provisions_Commitment == "1")
                {
                    CheckBox28.Checked = true;
                }
            }
            else if (contractApproval.Safety_Manual == "1")
            {
                CheckBox29.Checked = true;
            }
            else if (contractApproval.Safety_Construction_Agreement == "1")
            {
                CheckBox30.Checked = true;
            }
            else if (contractApproval.Evaluation_Control == "1")
            {
                CheckBox31.Checked = true;
            }
            else if (contractApproval.Envouriment_Factory_List == "1")
            {
                CheckBox32.Checked = true;
            }
            else if (contractApproval.ACT == "1")
            {
                CheckBox33.Checked = true;
            }
            else if (contractApproval.Ergonomic_Confirmation == "1")
            {
                CheckBox34.Checked = true;
            }
            else if (contractApproval.EHS == "1")
            {
                CheckBox35.Checked = true;
            }
        }

        private void getSessionInfo()
        {
            //初始化常量（伪）
            FORM_TYPE_ID = Request.QueryString["type"];
            FORM_NAME = FormType_BLL.getFormNameByTypeID(FORM_TYPE_ID);

            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            factory = Session["Factory_Name"].ToString().Trim();
            submit = Request.QueryString["submit"];
            formID = ContractApproval_BLL.getFormID(tempVendorID, FORM_TYPE_ID, factory);//获取FormID
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            saveForm(1, "保存表格");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getSessionInfo();

            if (submit == "yes")
            {
                saveForm(2, "提交表格");
                newApproveAccess(FORM_TYPE_ID, formID);
            }
            else
            {
                Response.Write("<script>window.alert('无法提交！')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeVendor.aspx");
        }

        private void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        private As_Contract_Approval saveForm(int flag, string manul)
        {
            //读取session
            getSessionInfo();
            As_Contract_Approval contractApproval = new As_Contract_Approval();
            contractApproval = getContractApproval();
            int join = ContractApproval_BLL.updateContractApproval(contractApproval);
            if (join > 0)
            {
                As_Write write = new As_Write();//将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = formID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = tempVendorID;
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    Response.Write("<script>window.alert('保存成功！')</script>");
                }
                return contractApproval;
            }
            else
            {
                return null;
            }
        }
        
        private As_Contract_Approval getContractApproval()
        {
            As_Contract_Approval contractApproval = new As_Contract_Approval();
            contractApproval.Bar_Code = "PR-05-17-3";
            contractApproval.Form_ID = formID;
            contractApproval.Ref_No = Textbox1.Text;
            contractApproval.Sourcing_Specialist = Textbox2.Text;
            contractApproval.User_Dept = Textbox3.Text;
            contractApproval.Purchase_Description = Textbox4.Text;
            contractApproval.Contract_Subject = Textbox5.Text;
            contractApproval.Contract_Annual_Amount = Textbox6.Text;
            contractApproval.Contract_StartTime = Textbox7.Text;
            contractApproval.Vendor_Name = Textbox8.Text;
            contractApproval.Payment_Terms_Clause = Textbox9.Text;
            contractApproval.Years = Textbox10.Text;
            //contractApproval.User_Dept_Head_One = Textbox15.Text;
            contractApproval.Payment_Terms_Page = Textbox11.Text;
            contractApproval.Contract_EndTime = Textbox86.Text;
            contractApproval.Payment_Terms_Details = Textbox13.Text;
            //contractApproval.Fin_Leader = Textbox14.Text;xunlei
            contractApproval.Price_Adjustment_Page = Textbox16.Text;
            contractApproval.Price_Adjustment_Clause = Textbox17.Text;
            contractApproval.Price_Adjustment_Details = Textbox19.Text;
            contractApproval.Volume_Page = Textbox20.Text;
            contractApproval.Volume_Clause = Textbox21.Text;
            contractApproval.Volume_Details = Textbox23.Text;
            contractApproval.Period_Page = Textbox24.Text;
            contractApproval.Period_Clause = Textbox25.Text;
            contractApproval.Period_Details = Textbox27.Text;
            contractApproval.Rebate_Page = Textbox28.Text;
            contractApproval.Rebate_Clause = Textbox29.Text;
            contractApproval.Rebate_Details = Textbox31.Text;
            contractApproval.Work_Scope_Page = Textbox32.Text;
            contractApproval.Work_Scope_Clause = Textbox33.Text;
            contractApproval.Work_Scope_Details = Textbox35.Text;
            contractApproval.Acceptence_Criteria_Page = Textbox36.Text;
            contractApproval.Acceptence_Criteria_Clause = Textbox37.Text;
            contractApproval.Acceptence_Criteria_Details = Textbox39.Text;
            contractApproval.Warranty_Page = Textbox40.Text;
            contractApproval.Warranty_Clause = Textbox41.Text;
            contractApproval.Warranty_Details = Textbox43.Text;
            contractApproval.Termination_Page = Textbox44.Text;
            contractApproval.Termination_Clause = Textbox45.Text;
            contractApproval.Termination_Details = Textbox47.Text;
            contractApproval.Exclusivity_Page = Textbox48.Text;
            contractApproval.Exclusivity_Clause = Textbox49.Text;
            contractApproval.Exclusivity_Details = Textbox51.Text;
            contractApproval.Other_Terms_Page = Textbox52.Text;
            contractApproval.Other_Terms_Clause = Textbox53.Text;
            contractApproval.Other_Terms_Details = Textbox55.Text;
            contractApproval.Penalty_Detail_Page = Textbox56.Text;
            contractApproval.Penalty_Detail_Clause = Textbox57.Text;
            contractApproval.Penalty_Detail_Details = Textbox59.Text;
            //contractApproval.User_Dept_Head_Two = Textbox87.Text;
            contractApproval.Notice_Page = Textbox12.Text;
            contractApproval.Notice_Clause = Textbox18.Text;
            contractApproval.Notice_Details = Textbox22.Text;
            contractApproval.Confidentiality_Page = Textbox30.Text;
            contractApproval.Confidentiality_Clause = Textbox34.Text;
            contractApproval.Confidentiality_Details = Textbox38.Text;
            contractApproval.Announcement_Page = Textbox46.Text;
            contractApproval.Announcement_Clause = Textbox50.Text;
            contractApproval.Announcement_Details = Textbox54.Text;
            contractApproval.Waivers_Page = Textbox60.Text;
            contractApproval.Waivers_Clause = Textbox61.Text;
            contractApproval.Waivers_Details = Textbox62.Text;
            contractApproval.Severalbility_Page = Textbox64.Text;
            contractApproval.Severalbility_Clause = Textbox65.Text;
            contractApproval.Severalbility_Details = Textbox66.Text;
            contractApproval.Force_Majeure = Textbox68.Text;
            contractApproval.Force_Clause = Textbox69.Text;
            contractApproval.Force_Details = Textbox70.Text;
            contractApproval.Delegation_Page = Textbox72.Text;
            contractApproval.Delegation_Clause = Textbox73.Text;
            contractApproval.Delegation_Details = Textbox74.Text;
            contractApproval.Dispute_Resolution_Page = Textbox76.Text;
            contractApproval.Dispute_Resolution_Clause = Textbox77.Text;
            contractApproval.Dispute_Resolution_Details = Textbox78.Text;
            contractApproval.Other_Provisions_Page = Textbox80.Text;
            contractApproval.Other_Provisions_Clause = Textbox81.Text;
            contractApproval.Other_Provisions_Details = Textbox82.Text;
            contractApproval.SourcingSpecialist_Signature = Textbox14.Text;
            //contractApproval.Legal_Head = Textbox26.Text;
            //contractApproval.SourcingSpecialist_Signature = Textbox42.Text;
            //contractApproval.User_Dept_Head_Signature = Textbox58.Text;
            //contractApproval.SC_Leader_Signature = Textbox63.Text;
            //contractApproval.Finance_Leader_Signature = Textbox67.Text;
            //contractApproval.General_Manager_Signature = Textbox71.Text;

            contractApproval.SourcingSpecialist_Date = Textbox75.Text;
            contractApproval.User_Dept_Head_Date = Textbox79.Text;
            contractApproval.SC_Leader_Date = Textbox83.Text;
            contractApproval.Finance_Leader_Date = Textbox84.Text;
            contractApproval.General_Manager_Date = Textbox85.Text;

            contractApproval.Purchase_Type = "";
            contractApproval.Purchase_Type = "";
            contractApproval.Purchase_Type = "";
            contractApproval.Payment_Terms_Commitment = "";
            contractApproval.Price_Adjustment_Commitment = "";
            contractApproval.Volume_Commitment = "";
            contractApproval.Period_Commitment = "";
            contractApproval.Rebate_Commitment = "";
            contractApproval.Work_Scope_Commitment = "";
            contractApproval.Acceptence_Criteria_Commitment = "";
            contractApproval.Warranty_Commitment = "";
            contractApproval.Termination_Commitment = "";
            contractApproval.Exclusivity_Commitment = "";
            contractApproval.Other_Terms_Commitment = "";
            contractApproval.Changes = "";
            contractApproval.Notice_Commitment = "";
            contractApproval.Confidentiality_Commitment = "";
            contractApproval.Announcement_Commitment = "";
            contractApproval.Waivers_Commitment = "";
            contractApproval.Severalbility_Commitment = "";
            contractApproval.Force_Commitment = "";
            contractApproval.Delegation_Commitment = "";
            contractApproval.Dispute_Resolution_Commitment = "";

            contractApproval.Other_Provisions_Commitment = "";
            contractApproval.Safety_Manual = "";
            contractApproval.Safety_Construction_Agreement = "";
            contractApproval.Evaluation_Control = "";
            contractApproval.Envouriment_Factory_List = "";
            contractApproval.ACT = "";
            contractApproval.Ergonomic_Confirmation = "";
            contractApproval.EHS = "";
            contractApproval.Existing_Vendor = "";
            if (CheckBox4.Checked == true)
            {
                contractApproval.Existing_Vendor = "yes";
            }
            if (CheckBox5.Checked == true)
            {
                contractApproval.Existing_Vendor = "no";
            }
            if (CheckBox1.Checked == true)
            {
                contractApproval.Purchase_Type = "Direct";

            }
            if (CheckBox2.Checked == true)
            {
                contractApproval.Purchase_Type = "Indirect";

            }
            if (CheckBox3.Checked == true)
            {
                contractApproval.Purchase_Type = "Capital";
                
            }
            if (CheckBox6.Checked == true)
            {
                contractApproval.Payment_Terms_Commitment = "1";
                
            }
            if (CheckBox7.Checked == true)
            {
                contractApproval.Price_Adjustment_Commitment = "1";
                
            }
            if (CheckBox8.Checked == true)
            {
                contractApproval.Volume_Commitment = "1";
                
            }
            if (CheckBox9.Checked == true)
            {
                contractApproval.Period_Commitment = "1";
                
            }
            if (CheckBox10.Checked == true)
            {
                contractApproval.Rebate_Commitment = "1";
               
            }
            if (CheckBox11.Checked == true)
            {
                contractApproval.Work_Scope_Commitment = "1";
                
            }
            if (CheckBox12.Checked ==true)
            {
                contractApproval.Acceptence_Criteria_Commitment = "1";
                
            }
            if (CheckBox13.Checked == true)
            {
                contractApproval.Warranty_Commitment = "1";
                
            }
            if (CheckBox14.Checked == true)
            {
                contractApproval.Termination_Commitment = "1";
                
            }
            if (CheckBox15.Checked == true)
            {
                contractApproval.Exclusivity_Commitment = "1";
                
            }
            if (CheckBox16.Checked == true)
            {
                contractApproval.Other_Terms_Commitment = "1";
               
            }
            if (CheckBox18.Checked == true)
            {
                contractApproval.Changes = "1";
                
                if (CheckBox20.Checked == true)
                {
                    contractApproval.Notice_Commitment ="1";
                    
                }
                if (CheckBox21.Checked ==true)
                {
                    contractApproval.Confidentiality_Commitment = "1";
                    
                }
                if (CheckBox22.Checked == true)
                {
                    contractApproval.Announcement_Commitment = "1";
                  
                }
                if (CheckBox23.Checked == true)
                {
                    contractApproval.Waivers_Commitment = "1";
                   
                }
                if (CheckBox24.Checked == true)
                {
                    contractApproval.Severalbility_Commitment = "1";
                    
                }
                if (CheckBox25.Checked == true)
                {
                    contractApproval.Force_Commitment = "1";
                    
                }
                if (CheckBox26.Checked == true)
                {
                    contractApproval.Delegation_Commitment = "1";
                    
                }
                if (CheckBox27.Checked == true)
                {
                    contractApproval.Dispute_Resolution_Commitment = "1";
                   
                }
                if (CheckBox28.Checked == true)
                {
                    contractApproval.Other_Provisions_Commitment = "1";
                    
                }
            }
            if (CheckBox29.Checked == true)
            {
                contractApproval.Safety_Manual = "1";
               
            }
            if (CheckBox30.Checked == true)
            {
                contractApproval.Safety_Construction_Agreement = "1";
            }
            if (CheckBox31.Checked == true)
            {
                contractApproval.Evaluation_Control = "1";
               
            }
            if (CheckBox32.Checked == true)
            {
                contractApproval.Envouriment_Factory_List = "1";
               
            }
            if (CheckBox33.Checked == true)
            {
                contractApproval.ACT = "1";
                
            }
            if (CheckBox34.Checked == true)
            {
                contractApproval.Ergonomic_Confirmation = "1";
               
            }
            if (CheckBox35.Checked == true)
            {
                contractApproval.EHS = "1";
                
            }
            return contractApproval;
        }

        public void newApproveAccess(string formTypeID, string formID)
        {
            //形成参数
            As_Assess_Flow assess_flow = AssessFlow_BLL.getFirstAssessFlow(formTypeID);

            //写入session之后供SelectDepartment页面使用
            Session["AssessflowInfo"] = assess_flow;
            Session["tempVendorID"] = tempVendorID;
            //Session["Factory_Name"] = Session["Factory_Name"];
            Session["form_name"] = FORM_NAME;

            //通过tempvendorID判断是否是非承诺性供应商 如果是则后面点击否的时候需要KCI进行审批 否则不需要
            string promise = VendorType_BLL.selectVendorPromise(tempVendorID);//获取promise
            if (promise == "0")//非承诺性且是用户部门 走kci
            {
                if (assess_flow.User_Department_Assess == "1")
                {
                    LocalScriptManager.CreateScript(Page, "messageBox('" + "是否是标准合同？" + "','" + formID + "');", "StandardConstract");
                }
                else//非承诺性且非用户部门   暂时没有此类情况 不做处理
                {

                }
            }
            else if (assess_flow.User_Department_Assess == "1")
            {
                LocalScriptManager.CreateScript(Page, "popUp('" + formID + "','yes');", "SHOW");
            }
            else
            {
                //TODO::这里不能这样写，具体参考Creation的写法，这里暂时不改
                Session["tempvendorname"] = tempVendorName;
                Session["Employee_ID"] = Session["Employee_ID"];
                Response.Write("<script>window.alert('提交成功！');window.location.href='EmployeeVendor.aspx'</script>");
            }
        }
    }
}