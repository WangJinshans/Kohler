using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ContractApproval_DAL
    {

        public static int checkContractApproval(string formID)
        {
            string sql = "select * from As_Contract_Approval where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            return dt.Rows.Count > 0 ? 1 : 0;//查找到有相应的记录后返回1
        }

        public static int getContractApprovalFlag(string formID)//获取标志位
        {
            string sql = "select Flag from As_Contract_Approval where Form_ID=@Form_ID";

            As_Contract_Approval vendorContract = null;
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorContract = new As_Contract_Approval();
                foreach (DataRow item in dt.Rows)
                {
                    vendorContract.Flag = Convert.ToInt32(item["Flag"]);
                }
            }
            return vendorContract.Flag;
        }

        public static int SubmitOk(string formID)
        {
            int submit = -1;
            string sql = "select Submit from As_Contract_Approval WHERE Form_ID='" + formID + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    submit = Convert.ToInt32(dr["Submit"]);
                }
            }
            return submit;
        }

        public static string getFormID(string tempVendorID,string form_Name,string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_Name=@Form_Type_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_Type_Name",form_Name),
                new SqlParameter("@Factory_Name",factory)

            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    formID = dr["Form_ID"].ToString();
                }
            }
            return formID;
        }

        public static int addContractApproval(As_Contract_Approval vendorContract)//添加表
        {
            string sql = "insert into As_Contract_Approval(Temp_Vendor_ID,Vendor_Name,Form_Type_ID,Flag,Factory_Name) values(@Temp_Vendor_ID,@Vendor_Name,@Form_Type_ID,@Flag,@Factory_Name) SELECT @@IDENTITY AS returnName";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",vendorContract.Temp_Vendor_ID),
                new SqlParameter("@Vendor_Name",vendorContract.Vendor_Name),
                new SqlParameter("@Form_Type_ID",vendorContract.Form_Type_ID),
                new SqlParameter("@Flag",vendorContract.Flag),
                new SqlParameter("@Factory_Name",vendorContract.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static int updateContractApproval(As_Contract_Approval vendorContract)
        {

            string sql = "update As_Contract_Approval set Ref_No=@Ref_No,Purchase_Type=@Purchase_Type,"

                + "Sourcing_Specialist=@Sourcing_Specialist,User_Dept=@User_Dept,Contract_Subject=@Contract_Subject,"

                + "Contract_Annual_Amount=@Contract_Annual_Amount,Contract_StartTime=@Contract_StartTime,"

                + "Contract_EndTime=@Contract_EndTime,Vendor_Name=@Vendor_Name,Existing_Vendor=@Existing_Vendor,"

                + "Years=@Years,Purchase_Description=@Purchase_Description,Payment_Terms_Page=@Payment_Terms_Page,"

                + "Payment_Terms_Clause=@Payment_Terms_Clause,Payment_Terms_Commitment=@Payment_Terms_Commitment,"

                + "Payment_Terms_Details=@Payment_Terms_Details,"

                + "Price_Adjustment_Page=@Price_Adjustment_Page,Price_Adjustment_Clause=@Price_Adjustment_Clause,"

                + "Price_Adjustment_Commitment=@Price_Adjustment_Commitment,Price_Adjustment_Details=@Price_Adjustment_Details,"

                + "Volume_Page=@Volume_Page,Volume_Clause=@Volume_Clause,Volume_Commitment=@Volume_Commitment,"

                + "Volume_Details=@Volume_Details,Period_Page=@Period_Page,Period_Clause=@Period_Clause,"

                + "Period_Commitment=@Period_Commitment,Period_Details=@Period_Details,Rebate_Page=@Rebate_Page,"

                + "Rebate_Clause = @Rebate_Clause,Rebate_Commitment = @Rebate_Commitment,Rebate_Details = @Rebate_Details,"

                + "Work_Scope_Page = @Work_Scope_Page,Work_Scope_Clause = @Work_Scope_Clause,Work_Scope_Commitment=Work_Scope_Commitment,"

                + "Work_Scope_Details=@Work_Scope_Details,Acceptence_Criteria_Page=@Acceptence_Criteria_Page,"

                + "Acceptence_Criteria_Clause=@Acceptence_Criteria_Clause,Acceptence_Criteria_Commitment=@Acceptence_Criteria_Commitment,"

                + "Acceptence_Criteria_Details=@Acceptence_Criteria_Details,Warranty_Page=@Warranty_Page,"

                + "Warranty_Clause=@Warranty_Clause,Warranty_Commitment=@Warranty_Commitment,Warranty_Details=@Warranty_Details,"

                + "Termination_Page=@Termination_Page,Termination_Clause=@Termination_Clause,Termination_Commitment=@Termination_Commitment,"

                + "Termination_Details=@Termination_Details,Exclusivity_Page=@Exclusivity_Page,Exclusivity_Clause=@Exclusivity_Clause,"

                + "Exclusivity_Commitment=@Exclusivity_Commitment,Exclusivity_Details=@Exclusivity_Details,"

                + "Other_Terms_Page=@Other_Terms_Page,Other_Terms_Clause=@Other_Terms_Clause,Other_Terms_Commitment=@Other_Terms_Commitment,"

                + "Other_Terms_Details=@Other_Terms_Details,Penalty_Detail_Page=@Penalty_Detail_Page,Penalty_Detail_Clause=@Penalty_Detail_Clause,"

                + "Penalty_Detail_Details=@Penalty_Detail_Details,Changes=@Changes,Notice_Page=@Notice_Page,"

                + "Notice_Clause=@Notice_Clause,Notice_Commitment=@Notice_Commitment,Notice_Details=@Notice_Details,"

                + "Confidentiality_Page=@Confidentiality_Page,Confidentiality_Clause=@Confidentiality_Clause,Confidentiality_Commitment=@Confidentiality_Commitment,"

                + "Confidentiality_Details=@Confidentiality_Details,Announcement_Page=@Announcement_Page,"

                + "Announcement_Clause=@Announcement_Clause,Announcement_Commitment=@Announcement_Commitment,Announcement_Details=@Announcement_Details,"

                + "Waivers_Page=@Waivers_Page,Waivers_Clause=@Waivers_Clause,Waivers_Commitment=@Waivers_Commitment,"

                + "Waivers_Details=@Waivers_Details,Severalbility_Page=@Severalbility_Page,Severalbility_Clause=@Severalbility_Clause,"

                + "Severalbility_Commitment = @Severalbility_Commitment,Severalbility_Details = @Severalbility_Details,Force_Majeure = @Force_Majeure,"

                + "Force_Clause = @Force_Clause,Force_Commitment = @Force_Commitment,Force_Details=Force_Details,"

                + "Delegation_Page=@Delegation_Page,Delegation_Clause=@Delegation_Clause,Delegation_Commitment=@Delegation_Commitment,"

                + "Delegation_Details=@Delegation_Details,Dispute_Resolution_Page=@Dispute_Resolution_Page,"

                + "Dispute_Resolution_Clause=@Dispute_Resolution_Clause,Dispute_Resolution_Commitment=@Dispute_Resolution_Commitment,"

                + "Dispute_Resolution_Details=@Dispute_Resolution_Details,Other_Provisions_Page=@Other_Provisions_Page,Other_Provisions_Clause=@Other_Provisions_Clause,"

                + "Other_Provisions_Commitment=@Other_Provisions_Commitment,Other_Provisions_Details=@Other_Provisions_Details,Safety_Manual=@Safety_Manual,"

                + "Safety_Construction_Agreement=@Safety_Construction_Agreement,Evaluation_Control=@Evaluation_Control,"

                + "Envouriment_Factory_List=@Envouriment_Factory_List,ACT=@ACT,Ergonomic_Confirmation=@Ergonomic_Confirmation,"

                + "EHS=@EHS,SourcingSpecialist_Signature=@SourcingSpecialist_Signature,SourcingSpecialist_Date=@SourcingSpecialist_Date "

                + "where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Ref_No",vendorContract.Ref_No),
                new SqlParameter("@Purchase_Type",vendorContract.Purchase_Type),
                new SqlParameter("@Sourcing_Specialist",vendorContract.Sourcing_Specialist),
                new SqlParameter("@User_Dept",vendorContract.User_Dept),
                new SqlParameter("@Contract_Subject",vendorContract.Contract_Subject),
                new SqlParameter("@Contract_Annual_Amount",vendorContract.Contract_Annual_Amount),
                new SqlParameter("@Contract_StartTime",vendorContract.Contract_StartTime),
                new SqlParameter("@Contract_EndTime",vendorContract.Contract_EndTime),
                new SqlParameter("@Vendor_Name",vendorContract.Vendor_Name),
                new SqlParameter("@Existing_Vendor",vendorContract.Existing_Vendor),
                new SqlParameter("@Years",vendorContract.Years),
                new SqlParameter("@Purchase_Description",vendorContract.Purchase_Description),
                new SqlParameter("@Payment_Terms_Page",vendorContract.Payment_Terms_Page),
                new SqlParameter("@Payment_Terms_Clause",vendorContract.Payment_Terms_Clause),
                new SqlParameter("@Payment_Terms_Commitment",vendorContract.Payment_Terms_Commitment),
                new SqlParameter("@Payment_Terms_Details",vendorContract.Payment_Terms_Details),
                //new SqlParameter("@Fin_Leader",vendorContract.Fin_Leader),
                //new SqlParameter("@User_Dept_Head_One",vendorContract.User_Dept_Head_One),
                //new SqlParameter("@User_Dept_Head_Two",vendorContract.User_Dept_Head_Two),
                new SqlParameter("@Price_Adjustment_Page",vendorContract.Price_Adjustment_Page),
                new SqlParameter("@Price_Adjustment_Clause",vendorContract.Price_Adjustment_Clause),
                new SqlParameter("@Price_Adjustment_Commitment",vendorContract.Price_Adjustment_Commitment),
                new SqlParameter("@Price_Adjustment_Details",vendorContract.Price_Adjustment_Details),
                new SqlParameter("@Volume_Page",vendorContract.Volume_Page),
                new SqlParameter("@Volume_Clause",vendorContract.Volume_Clause),
                new SqlParameter("@Volume_Commitment",vendorContract.Volume_Commitment),
                new SqlParameter("@Volume_Details",vendorContract.Volume_Details),
                new SqlParameter("@Period_Page",vendorContract.Period_Page),
                new SqlParameter("@Period_Clause",vendorContract.Period_Clause),
                new SqlParameter("@Period_Commitment",vendorContract.Period_Commitment),
                new SqlParameter("@Period_Details",vendorContract.Period_Details),
                new SqlParameter("@Rebate_Page",vendorContract.Rebate_Page),
                new SqlParameter("@Rebate_Clause",vendorContract.Rebate_Clause),
                new SqlParameter("@Rebate_Commitment",vendorContract.Rebate_Commitment),
                new SqlParameter("@Rebate_Details",vendorContract.Rebate_Details),
                new SqlParameter("@Work_Scope_Page",vendorContract.Work_Scope_Page),
                new SqlParameter("@Work_Scope_Clause",vendorContract.Work_Scope_Clause),
                new SqlParameter("@Work_Scope_Commitment",vendorContract.Work_Scope_Commitment),
                new SqlParameter("@Work_Scope_Details",vendorContract.Work_Scope_Details),
                new SqlParameter("@Acceptence_Criteria_Page",vendorContract.Acceptence_Criteria_Page),
                new SqlParameter("@Acceptence_Criteria_Clause",vendorContract.Acceptence_Criteria_Clause),
                new SqlParameter("@Acceptence_Criteria_Commitment",vendorContract.Acceptence_Criteria_Commitment),
                new SqlParameter("@Acceptence_Criteria_Details",vendorContract.Acceptence_Criteria_Details),
                new SqlParameter("@Warranty_Page",vendorContract.Warranty_Page),
                new SqlParameter("@Warranty_Clause",vendorContract.Warranty_Clause),
                new SqlParameter("@Warranty_Commitment",vendorContract.Warranty_Commitment),
                new SqlParameter("@Warranty_Details",vendorContract.Warranty_Details),
                new SqlParameter("@Termination_Page",vendorContract.Termination_Page),
                new SqlParameter("@Termination_Clause",vendorContract.Termination_Clause),
                new SqlParameter("@Termination_Commitment",vendorContract.Termination_Commitment),
                new SqlParameter("@Termination_Details",vendorContract.Termination_Details),
                new SqlParameter("@Exclusivity_Page",vendorContract.Exclusivity_Page),
                new SqlParameter("@Exclusivity_Clause",vendorContract.Exclusivity_Clause),
                new SqlParameter("@Exclusivity_Commitment",vendorContract.Exclusivity_Commitment),
                new SqlParameter("@Exclusivity_Details",vendorContract.Exclusivity_Details),
                new SqlParameter("@Other_Terms_Page",vendorContract.Other_Terms_Page),
                new SqlParameter("@Other_Terms_Clause",vendorContract.Other_Terms_Clause),
                new SqlParameter("@Other_Terms_Commitment",vendorContract.Other_Terms_Commitment),
                new SqlParameter("@Other_Terms_Details",vendorContract.Other_Terms_Details),
                new SqlParameter("@Penalty_Detail_Page",vendorContract.Penalty_Detail_Page),
                new SqlParameter("@Penalty_Detail_Clause",vendorContract.Penalty_Detail_Clause),
                new SqlParameter("@Penalty_Detail_Details",vendorContract.Penalty_Detail_Details),
                new SqlParameter("@Changes",vendorContract.Changes),
                new SqlParameter("@Notice_Page",vendorContract.Notice_Page),
                new SqlParameter("@Notice_Clause",vendorContract.Notice_Clause),
                new SqlParameter("@Notice_Commitment",vendorContract.Notice_Commitment),
                new SqlParameter("@Notice_Details",vendorContract.Notice_Details),
                new SqlParameter("@Confidentiality_Page",vendorContract.Confidentiality_Page),
                new SqlParameter("@Confidentiality_Clause",vendorContract.Confidentiality_Clause),
                new SqlParameter("@Confidentiality_Commitment",vendorContract.Confidentiality_Commitment),
                new SqlParameter("@Confidentiality_Details",vendorContract.Confidentiality_Details),
                new SqlParameter("@Announcement_Page",vendorContract.Announcement_Page),
                new SqlParameter("@Announcement_Clause",vendorContract.Announcement_Clause),
                new SqlParameter("@Announcement_Commitment",vendorContract.Announcement_Commitment),
                new SqlParameter("@Announcement_Details",vendorContract.Announcement_Details),
                new SqlParameter("@Waivers_Page",vendorContract.Waivers_Page),
                new SqlParameter("@Waivers_Clause",vendorContract.Waivers_Clause),
                new SqlParameter("@Waivers_Commitment",vendorContract.Waivers_Commitment),
                new SqlParameter("@Waivers_Details",vendorContract.Waivers_Details),
                new SqlParameter("@Severalbility_Page",vendorContract.Severalbility_Page),
                new SqlParameter("@Severalbility_Clause",vendorContract.Severalbility_Clause),
                new SqlParameter("@Severalbility_Commitment",vendorContract.Severalbility_Commitment),
                new SqlParameter("@Severalbility_Details",vendorContract.Severalbility_Details),
                new SqlParameter("@Force_Majeure",vendorContract.Force_Majeure),
                new SqlParameter("@Force_Clause",vendorContract.Force_Clause),
                new SqlParameter("@Force_Commitment",vendorContract.Force_Commitment),
                new SqlParameter("@Force_Details",vendorContract.Force_Details),
                new SqlParameter("@Delegation_Page",vendorContract.Delegation_Page),
                new SqlParameter("@Delegation_Clause",vendorContract.Delegation_Clause),
                new SqlParameter("@Delegation_Commitment",vendorContract.Delegation_Commitment),
                new SqlParameter("@Delegation_Details",vendorContract.Delegation_Details),
                new SqlParameter("@Dispute_Resolution_Page",vendorContract.Dispute_Resolution_Page),
                new SqlParameter("@Dispute_Resolution_Clause",vendorContract.Dispute_Resolution_Clause),
                new SqlParameter("@Dispute_Resolution_Commitment",vendorContract.Dispute_Resolution_Commitment),
                new SqlParameter("@Dispute_Resolution_Details",vendorContract.Dispute_Resolution_Details),
                new SqlParameter("@Other_Provisions_Page",vendorContract.Other_Provisions_Page),
                new SqlParameter("@Other_Provisions_Clause",vendorContract.Other_Provisions_Clause),
                new SqlParameter("@Other_Provisions_Commitment",vendorContract.Other_Provisions_Commitment),
                new SqlParameter("@Other_Provisions_Details",vendorContract.Other_Provisions_Details),
                new SqlParameter("@Safety_Manual",vendorContract.Safety_Manual),
                new SqlParameter("@Safety_Construction_Agreement",vendorContract.Safety_Construction_Agreement),
                new SqlParameter("@Evaluation_Control",vendorContract.Evaluation_Control),
                new SqlParameter("@Envouriment_Factory_List",vendorContract.Envouriment_Factory_List),
                new SqlParameter("@ACT",vendorContract.ACT),
                new SqlParameter("@Ergonomic_Confirmation",vendorContract.Ergonomic_Confirmation),
                new SqlParameter("@EHS",vendorContract.EHS),
                new SqlParameter("@SourcingSpecialist_Signature",vendorContract.SourcingSpecialist_Signature),
                new SqlParameter("@SourcingSpecialist_Date",vendorContract.SourcingSpecialist_Date),
                //new SqlParameter("@User_Dept_Head_Signature",vendorContract.User_Dept_Head_Signature),
                //new SqlParameter("@User_Dept_Head_Date",vendorContract.User_Dept_Head_Date),
                //new SqlParameter("@SC_Leader_Signature",vendorContract.SC_Leader_Signature),
                //new SqlParameter("@SC_Leader_Date",vendorContract.SC_Leader_Date),
                //new SqlParameter("@Finance_Leader_Signature",vendorContract.Finance_Leader_Signature),
                //new SqlParameter("@Finance_Leader_Date",vendorContract.Finance_Leader_Date),
                //new SqlParameter("@General_Manager_Signature",vendorContract.General_Manager_Signature),
                //new SqlParameter("@General_Manager_Date",vendorContract.General_Manager_Date),
                //new SqlParameter("@Legal_Head",vendorContract.Legal_Head),
                new SqlParameter("@Form_ID",vendorContract.Form_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int setNonStandardContract(string Form_ID)
        {
            string sql = "update As_Contract_Approval set Standard_Contract=@Standard_Contract where Form_ID=@Form_ID";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Standard_Contract","no"),
                new SqlParameter("@Form_ID",Form_ID)
               
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static As_Contract_Approval getContractApproval(string formID)
        {
            As_Contract_Approval vendorContract = null;
            string sql = "select * from As_Contract_Approval where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorContract = new As_Contract_Approval();
                foreach (DataRow item in dt.Rows)
                {
                    vendorContract.Ref_No = item["Ref_No"].ToString().Trim();
                    vendorContract.Purchase_Type = item["Purchase_Type"].ToString().Trim();
                    vendorContract.Sourcing_Specialist = item["Sourcing_Specialist"].ToString().Trim();
                    vendorContract.User_Dept = item["User_Dept"].ToString().Trim();
                    vendorContract.Contract_Subject = item["Contract_Subject"].ToString().Trim();
                    vendorContract.Contract_Annual_Amount = item["Contract_Annual_Amount"].ToString().Trim();
                    vendorContract.Contract_StartTime = item["Contract_StartTime"].ToString().Trim(); //TODO::???英文名？？？
                    vendorContract.Contract_EndTime = item["Contract_EndTime"].ToString().Trim();
                    vendorContract.Vendor_Name = item["Vendor_Name"].ToString().Trim();
                    vendorContract.Existing_Vendor = item["Existing_Vendor"].ToString().Trim();
                    vendorContract.Years = item["Years"].ToString().Trim();
                    vendorContract.Purchase_Description = item["Purchase_Description"].ToString().Trim();
                    vendorContract.Payment_Terms_Page = item["Payment_Terms_Page"].ToString().Trim();
                    vendorContract.Payment_Terms_Clause = item["Payment_Terms_Clause"].ToString().Trim();
                    vendorContract.Payment_Terms_Commitment = item["Payment_Terms_Commitment"].ToString().Trim();
                    vendorContract.Payment_Terms_Details = item["Payment_Terms_Details"].ToString().Trim();
                    vendorContract.Fin_Leader = item["Finance_Leader_One"].ToString().Trim();
                    vendorContract.User_Dept_Head_One = item["User_Department_Manager_One"].ToString().Trim();
                    vendorContract.User_Dept_Head_Two = item["User_Department_Manager_Two"].ToString().Trim();
                    vendorContract.Price_Adjustment_Page = item["Price_Adjustment_Page"].ToString().Trim();
                    vendorContract.Price_Adjustment_Clause = item["Price_Adjustment_Clause"].ToString().Trim();
                    vendorContract.Price_Adjustment_Commitment = item["Price_Adjustment_Commitment"].ToString().Trim();
                    vendorContract.Price_Adjustment_Details = item["Price_Adjustment_Details"].ToString().Trim();
                    vendorContract.Volume_Page = item["Volume_Page"].ToString().Trim();
                    vendorContract.Volume_Clause = item["Volume_Clause"].ToString().Trim();
                    vendorContract.Volume_Commitment = item["Volume_Commitment"].ToString().Trim();
                    vendorContract.Volume_Details = item["Volume_Details"].ToString().Trim();
                    vendorContract.Period_Page = item["Period_Page"].ToString().Trim();
                    vendorContract.Period_Clause = item["Period_Clause"].ToString().Trim();
                    vendorContract.Period_Commitment = item["Period_Commitment"].ToString().Trim();
                    vendorContract.Period_Details = item["Period_Details"].ToString().Trim();
                    vendorContract.Rebate_Page = item["Rebate_Page"].ToString().Trim();
                    vendorContract.Rebate_Clause = item["Rebate_Clause"].ToString().Trim();
                    vendorContract.Rebate_Commitment = item["Rebate_Commitment"].ToString().Trim(); 
                    vendorContract.Rebate_Details = item["Rebate_Details"].ToString().Trim();
                    vendorContract.Work_Scope_Page = item["Work_Scope_Page"].ToString().Trim();
                    vendorContract.Work_Scope_Clause = item["Work_Scope_Clause"].ToString().Trim();
                    vendorContract.Work_Scope_Commitment = item["Work_Scope_Commitment"].ToString().Trim();
                    vendorContract.Work_Scope_Details = item["Work_Scope_Details"].ToString().Trim();
                    vendorContract.Acceptence_Criteria_Page = item["Acceptence_Criteria_Page"].ToString().Trim();
                    vendorContract.Acceptence_Criteria_Clause = item["Acceptence_Criteria_Clause"].ToString().Trim(); //TODO::???英文名？？？
                    vendorContract.Acceptence_Criteria_Commitment = item["Acceptence_Criteria_Commitment"].ToString().Trim();
                    vendorContract.Acceptence_Criteria_Details = item["Acceptence_Criteria_Details"].ToString().Trim();
                    vendorContract.Warranty_Page = item["Warranty_Page"].ToString().Trim();
                    vendorContract.Warranty_Clause = item["Warranty_Clause"].ToString().Trim();
                    vendorContract.Warranty_Commitment = item["Warranty_Commitment"].ToString().Trim();
                    vendorContract.Warranty_Details = item["Warranty_Details"].ToString().Trim();
                    vendorContract.Termination_Page = item["Termination_Page"].ToString().Trim();
                    vendorContract.Termination_Clause = item["Termination_Clause"].ToString().Trim();
                    vendorContract.Termination_Commitment = item["Termination_Commitment"].ToString().Trim();
                    vendorContract.Termination_Details = item["Termination_Details"].ToString().Trim();
                    vendorContract.Exclusivity_Page = item["Exclusivity_Page"].ToString().Trim();
                    vendorContract.Exclusivity_Clause = item["Exclusivity_Clause"].ToString().Trim();
                    vendorContract.Exclusivity_Commitment = item["Exclusivity_Commitment"].ToString().Trim();
                    vendorContract.Exclusivity_Details = item["Exclusivity_Details"].ToString().Trim();
                    vendorContract.Other_Terms_Page = item["Other_Terms_Page"].ToString().Trim();
                    vendorContract.Other_Terms_Clause = item["Other_Terms_Clause"].ToString().Trim();
                    vendorContract.Other_Terms_Commitment = item["Other_Terms_Commitment"].ToString().Trim();
                    vendorContract.Other_Terms_Details = item["Other_Terms_Details"].ToString().Trim();
                    vendorContract.Penalty_Detail_Page = item["Penalty_Detail_Page"].ToString().Trim();
                    vendorContract.Penalty_Detail_Clause = item["Penalty_Detail_Clause"].ToString().Trim();
                    vendorContract.Penalty_Detail_Details = item["Penalty_Detail_Details"].ToString().Trim();
                    vendorContract.Changes = item["Changes"].ToString().Trim();
                    vendorContract.Notice_Page = item["Notice_Page"].ToString().Trim();
                    vendorContract.Notice_Clause = item["Notice_Clause"].ToString().Trim();
                    vendorContract.Notice_Commitment = item["Notice_Commitment"].ToString().Trim();
                    vendorContract.Confidentiality_Page = item["Confidentiality_Page"].ToString().Trim();
                    vendorContract.Confidentiality_Clause = item["Confidentiality_Clause"].ToString().Trim(); 
                    vendorContract.Confidentiality_Commitment = item["Confidentiality_Commitment"].ToString().Trim();
                    vendorContract.Confidentiality_Details = item["Confidentiality_Details"].ToString().Trim();
                    vendorContract.Announcement_Page = item["Announcement_Page"].ToString().Trim();
                    vendorContract.Announcement_Clause = item["Announcement_Clause"].ToString().Trim();
                    vendorContract.Announcement_Commitment = item["Announcement_Commitment"].ToString().Trim();
                    vendorContract.Announcement_Details = item["Announcement_Details"].ToString().Trim();
                    vendorContract.Waivers_Page = item["Waivers_Page"].ToString().Trim(); //TODO::???英文名？？？
                    vendorContract.Waivers_Clause = item["Waivers_Clause"].ToString().Trim();
                    vendorContract.Waivers_Commitment = item["Waivers_Commitment"].ToString().Trim();
                    vendorContract.Waivers_Details = item["Waivers_Details"].ToString().Trim();
                    vendorContract.Severalbility_Page = item["Severalbility_Page"].ToString().Trim();
                    vendorContract.Severalbility_Clause = item["Severalbility_Clause"].ToString().Trim();
                    vendorContract.Severalbility_Commitment = item["Severalbility_Commitment"].ToString().Trim();
                    vendorContract.Severalbility_Details = item["Severalbility_Details"].ToString().Trim();
                    vendorContract.Force_Majeure = item["Force_Majeure"].ToString().Trim();
                    vendorContract.Force_Clause = item["Force_Clause"].ToString().Trim();
                    vendorContract.Force_Commitment = item["Force_Commitment"].ToString().Trim();
                    vendorContract.Force_Details = item["Force_Details"].ToString().Trim();
                    vendorContract.Delegation_Page = item["Delegation_Page"].ToString().Trim();
                    vendorContract.Delegation_Clause = item["Delegation_Clause"].ToString().Trim();
                    vendorContract.Delegation_Commitment = item["Delegation_Commitment"].ToString().Trim();
                    vendorContract.Delegation_Details = item["Delegation_Details"].ToString().Trim();
                    vendorContract.Dispute_Resolution_Page = item["Dispute_Resolution_Page"].ToString().Trim();
                    vendorContract.Dispute_Resolution_Clause = item["Dispute_Resolution_Clause"].ToString().Trim();
                    vendorContract.Dispute_Resolution_Commitment = item["Dispute_Resolution_Commitment"].ToString().Trim();
                    vendorContract.Dispute_Resolution_Details = item["Dispute_Resolution_Details"].ToString().Trim();
                    vendorContract.Other_Provisions_Page = item["Other_Provisions_Page"].ToString().Trim();
                    vendorContract.Other_Provisions_Clause = item["Other_Provisions_Clause"].ToString().Trim();
                    vendorContract.Other_Provisions_Commitment = item["Other_Provisions_Commitment"].ToString().Trim();
                    vendorContract.Other_Provisions_Details = item["Other_Provisions_Details"].ToString().Trim();
                    vendorContract.Safety_Manual = item["Safety_Manual"].ToString().Trim();
                    vendorContract.Safety_Construction_Agreement = item["Safety_Construction_Agreement"].ToString().Trim();
                    vendorContract.Evaluation_Control = item["Evaluation_Control"].ToString().Trim();
                    vendorContract.Envouriment_Factory_List = item["Envouriment_Factory_List"].ToString().Trim();
                    vendorContract.ACT = item["ACT"].ToString().Trim();
                    vendorContract.Ergonomic_Confirmation = item["Ergonomic_Confirmation"].ToString().Trim();
                    vendorContract.EHS = item["EHS"].ToString().Trim();
                    vendorContract.SourcingSpecialist_Signature = item["SourcingSpecialist_Signature"].ToString().Trim();
                    vendorContract.SourcingSpecialist_Date = item["SourcingSpecialist_Date"].ToString().Trim();
                    vendorContract.User_Dept_Head_Signature = item["User_Department_Manager"].ToString().Trim();
                    vendorContract.User_Dept_Head_Date = item["User_Department_Manager_Date"].ToString().Trim(); //TODO::???英文名？？？
                    vendorContract.SC_Leader_Signature = item["Purchasing_Manager"].ToString().Trim();
                    vendorContract.SC_Leader_Date = item["Purchasing_Manager_Date"].ToString().Trim();
                    vendorContract.Finance_Leader_Signature = item["Finance_Leader"].ToString().Trim();
                    vendorContract.Finance_Leader_Date = item["Finance_Leader_Date"].ToString().Trim();
                    vendorContract.General_Manager_Signature = item["General_Manager"].ToString().Trim();
                    vendorContract.General_Manager_Date = item["General_Manager_Date"].ToString().Trim();
                    vendorContract.Legal_Head = item["Legal_Affair_Department"].ToString().Trim();
                    vendorContract.Form_ID = item["Form_ID"].ToString().Trim();
                    vendorContract.Standard_Contract = item["Standard_Contract"].ToString().Trim();
                    vendorContract.Temp_Vendor_ID= item["Temp_Vendor_ID"].ToString().Trim();
                    vendorContract.Factory_Name= item["Factory_Name"].ToString().Trim();
                }
                return vendorContract;
            }
            else
            {
                return null;//返回空
            }
        }
    }
}
