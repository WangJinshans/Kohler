using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowContractApprovalForm : System.Web.UI.Page
    {
        private static string positionName = "";
        private static string FORM_TYPE_ID = "";
        private static string formID = "";
        private static string tempVendorID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //重新获取session
                getSessionInfo();
                int check = ContractApproval_BLL.checkContractApproval(formID);
                if (check > 0)
                {
                    showConstractApproval();
                }
            }

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
                //Textbox15.Text = contractApproval.User_Dept_Head_One;
                hideImage(contractApproval.User_Dept_Head_One, Image8);
                Textbox11.Text = contractApproval.Payment_Terms_Page;
                Textbox9.Text = contractApproval.Payment_Terms_Clause;
                Textbox13.Text = contractApproval.Payment_Terms_Details;
                //Textbox14.Text = contractApproval.Fin_Leader;
                hideImage(contractApproval.Fin_Leader, Image7);
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
                hideImage(contractApproval.User_Dept_Head_Two, Image6);
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
                Textbox42.Text = contractApproval.SourcingSpecialist_Signature;
                hideImage(contractApproval.Legal_Head, Image5);
                hideImage(contractApproval.User_Dept_Head_Signature, Image1);
                hideImage(contractApproval.SC_Leader_Signature, Image2);
                hideImage(contractApproval.Finance_Leader_Signature, Image3);
                hideImage(contractApproval.General_Manager_Signature, Image4);
                hideImage(contractApproval.Supplier_Chain_Leader, Image9);

                Textbox75.Text = contractApproval.SourcingSpecialist_Date;
                Textbox79.Text = contractApproval.User_Dept_Head_Date;
                Textbox83.Text = contractApproval.SC_Leader_Date;
                Textbox84.Text = contractApproval.Finance_Leader_Date;
                Textbox85.Text = contractApproval.General_Manager_Date;
                checkBoxInit(contractApproval);
            }
            else
            {
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = false;
                Image6.Visible = false;
                Image7.Visible = false;
                Image8.Visible = false;
            }

            ////KCI完成后显示   文本提示linda已经签名
            //if (KCIApproval_BLL.isKCIApproveFinished(formID))
            //{
            //    approveState.Text = "Linda已完成审批";
            //    getKCIResult.Visible = true;
            //}
            //else
            //{
            //    getKCIResult.Visible = false;
            //}


            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");
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
                btnPDF.ToolTip = Request.Url+"&outPutID=" + formID;
            }
        }

        private void checkBoxInit(As_Contract_Approval contractApproval)
        {
            if (contractApproval.Purchase_Type == "Direct")
            {
                CheckBox1.Checked = true;
            }
            if (contractApproval.Purchase_Type == "Indirect")
            {
                CheckBox2.Checked = true;
            }
            if (contractApproval.Purchase_Type == "Capital")
            {
                CheckBox3.Checked = true;
            }
            if (contractApproval.Existing_Vendor == "yes")
            {
                CheckBox4.Checked = true;
            }
            if (contractApproval.Existing_Vendor == "no")
            {
                CheckBox5.Checked = true;
            }
            if (contractApproval.Payment_Terms_Commitment == "1")
            {
                CheckBox6.Checked = true;
            }
            if (contractApproval.Price_Adjustment_Commitment == "1")
            {
                CheckBox7.Checked = true;
            }
            if (contractApproval.Volume_Commitment == "1")
            {
                CheckBox8.Checked = true;
            }
            if (contractApproval.Period_Commitment == "1")
            {
                CheckBox9.Checked = true;
            }
            if (contractApproval.Rebate_Commitment == "1")
            {
                CheckBox10.Checked = true;
            }
            if (contractApproval.Work_Scope_Commitment == "1")
            {
                CheckBox11.Checked = true;
            }
            if (contractApproval.Acceptence_Criteria_Commitment == "1")
            {
                CheckBox12.Checked = true;
            }
            if (contractApproval.Warranty_Commitment == "1")
            {
                CheckBox13.Checked = true;
            }
            if (contractApproval.Termination_Commitment == "1")
            {
                CheckBox14.Checked = true;
            }
            if (contractApproval.Exclusivity_Commitment == "1")
            {
                CheckBox15.Checked = true;
            }
            if (contractApproval.Other_Provisions_Commitment == "1")
            {
                CheckBox16.Checked = true;
            }
            if (contractApproval.Changes == "1")
            {
                CheckBox18.Checked = true;
                if (contractApproval.Notice_Commitment == "1")
                {
                    CheckBox20.Checked = true;
                }
                if (contractApproval.Confidentiality_Commitment == "1")
                {
                    CheckBox21.Checked = true;
                }
                if (contractApproval.Announcement_Commitment == "1")
                {
                    CheckBox22.Checked = true;
                }
                if (contractApproval.Waivers_Commitment == "1")
                {
                    CheckBox23.Checked = true;
                }
                if (contractApproval.Severalbility_Commitment == "1")
                {
                    CheckBox24.Checked = true;
                }
                if (contractApproval.Force_Commitment == "1")
                {
                    CheckBox25.Checked = true;
                }
                if (contractApproval.Delegation_Commitment == "1")
                {
                    CheckBox26.Checked = true;
                }
                if (contractApproval.Dispute_Resolution_Commitment == "1")
                {
                    CheckBox27.Checked = true;
                }
                if (contractApproval.Other_Provisions_Commitment == "1")
                {
                    CheckBox28.Checked = true;
                }
            }
            if (contractApproval.Safety_Manual == "1")
            {
                CheckBox29.Checked = true;
            }
            if (contractApproval.Safety_Construction_Agreement == "1")
            {
                CheckBox30.Checked = true;
            }
            if (contractApproval.Evaluation_Control == "1")
            {
                CheckBox31.Checked = true;
            }
            if (contractApproval.Envouriment_Factory_List == "1")
            {
                CheckBox32.Checked = true;
            }
            if (contractApproval.ACT == "1")
            {
                CheckBox33.Checked = true;
            }
            if (contractApproval.Ergonomic_Confirmation == "1")
            {
                CheckBox34.Checked = true;
            }
            if (contractApproval.EHS == "1")
            {
                CheckBox35.Checked = true;
            }
            showapproveform(formID);
            showfilelist(formID);
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

        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            IList<As_Form_File> data_list = new List<As_Form_File>();
            string tempVendorID = AddForm_BLL.GetTempVendorID(formID);
            string sql = "select * from View_Form_File where Form_ID='" + FormID + "'  and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            PagedDataSource objpds = new PagedDataSource();
            data_list = FormFile_BLL.listFile(sql);


            //绑定比价表
            As_Form_File form_file = new As_Form_File();
            sql = "select * from As_Form_File where Form_ID='" + FormID + "' and File_ID like '%BJZL%'";
            

            foreach (As_Form_File formfile in FormFile_BLL.listformFile(sql))
            {
                data_list.Add(formfile);
            }

            objpds.DataSource = data_list;
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //重新读取session信息
            getSessionInfo();

            //参数
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string positionName = GridView1.Rows[drv.RowIndex].Cells[1].Text;

            //如果是通过
            if (e.CommandName == "approvesuccess")
            {
                if (positionName.Equals(Session["Position_Name"].ToString()))
                {
                    //int i = AssessFlow_BLL.updateApprove(formid, positionName);
                    if (LocalApproveManager.doSuccessApprove(formid, tempVendorID, FORM_TYPE_ID, positionName, Page))
                    {
                        //Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowContractApprovalForm.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowContractApprovalForm.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }

            }//如果拒绝
            else if (e.CommandName == "fail")
            {
                if (positionName.Equals(Session["Position_Name"].ToString()))
                {//填写原因
                    LocalScriptManager.CreateScript(Page, String.Format("openReasonDialog('{0}','{1}','{2}',{3})", formID, positionName, Session["Factory_Name"].ToString(), "null"), "reasonDialog");
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
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

        protected void getKCIResult_Click(object sender, EventArgs e)
        {
            string fileID = KCIApproval_BLL.getKCIApprovalFileID(formID);//获取fileID
            string filePath = LSetting.File_Reltive_Path + fileID + ".pdf";
            if (filePath != "")
            {
                LocalScriptManager.createManagerScript(Page, "viewFile('" + filePath + "')", "save");
            }
        }


        protected void tips()
        {
            bool ok = ContractApproval_BLL.isKCIOK(formID);
            if (ok)
            {
                this.Lable1.Text = "KCI审批已通过！";
            }
        }

        //protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //比价表的绑定 以及其他绑定表的查看
        //    GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        //    string fileID = GridView3.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();//获取fileID
        //    if (e.CommandName == "view")
        //    {
        //        string filePath = LSetting.File_Reltive_Path + fileID + ".pdf";
        //        if (filePath != "")
        //        {
        //            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
        //        }
        //    }
        //}
    }
}