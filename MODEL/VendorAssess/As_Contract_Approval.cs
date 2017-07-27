using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class As_Contract_Approval
    {

        private string form_ID;
        private string temp_Vendor_ID;
        private string temp_Vendor_Name;
        private string form_Type_ID;
        private string bar_Code;
        private int flag;

        private string ref_No;
        private string purchase_Type;
        private string sourcing_Specialist;
        private string user_Dept;
        private string contract_Subject;
        private string contract_Annual_Amount;
        private string contract_StartTime;
        private string contract_EndTime;
        private string vendor_Name;
        private string existing_Vendor;
        private string years;
        private string purchase_Description;
       

        private string payment_Terms_Page;
        private string payment_Terms_Clause;
        private string payment_Terms_Commitment;
        private string payment_Terms_Details;

        private string fin_Leader;
        private string user_Dept_Head_One;
        private string user_Dept_Head_Two;

        private string price_Adjustment_Page;
        private string price_Adjustment_Clause;
        private string price_Adjustment_Commitment;
        private string price_Adjustment_Details;

        private string volume_Page;
        private string volume_Clause;
        private string volume_Commitment;
        private string volume_Details;

        private string period_Page;
        private string period_Clause;
        private string period_Commitment;
        private string period_Details;

        private string rebate_Page;
        private string rebate_Clause;
        private string rebate_Commitment;
        private string rebate_Details;

        private string work_Scope_Page;
        private string work_Scope_Clause;
        private string work_Scope_Commitment;
        private string work_Scope_Details;

        private string acceptence_Criteria_Page;
        private string acceptence_Criteria_Clause;
        private string acceptence_Criteria_Commitment;
        private string acceptence_Criteria_Details;

        private string warranty_Page;
        private string warranty_Clause;
        private string warranty_Commitment;
        private string warranty_Details;

        private string termination_Page;
        private string termination_Clause;
        private string termination_Commitment;
        private string termination_Details;

        private string exclusivity_Page;
        private string exclusivity_Clause;
        private string exclusivity_Commitment;
        private string exclusivity_Details;

        private string other_Terms_Page;
        private string other_Terms_Clause;
        private string other_Terms_Commitment;
        private string other_Terms_Details;

        private string penalty_Detail_Page;
        private string penalty_Detail_Clause;
        private string penalty_Detail_Details;

        private string changes;//是否有改动
        private string standard_Contract;//是否标准合同
      
        private string notice_Page;
        private string notice_Clause;
        private string notice_Commitment;
        private string notice_Details;

        private string confidentiality_Page;
        private string confidentiality_Clause;
        private string confidentiality_Commitment;
        private string confidentiality_Details;

        private string announcement_Page;
        private string announcement_Clause;
        private string announcement_Commitment;
        private string announcement_Details;

        private string waivers_Page;
        private string waivers_Clause;
        private string waivers_Commitment;
        private string waivers_Details;

        private string severalbility_Page;
        private string severalbility_Clause;
        private string severalbility_Commitment;
        private string severalbility_Details;

        private string force_Majeure;
        private string force_Clause;
        private string force_Commitment;
        private string force_Details;

        private string delegation_Page;
        private string delegation_Clause;
        private string delegation_Commitment;
        private string delegation_Details;


        private string dispute_Resolution_Page;
        private string dispute_Resolution_Clause;
        private string dispute_Resolution_Commitment;
        private string dispute_Resolution_Details;

        private string other_Provisions_Page;
        private string other_Provisions_Clause;
        private string other_Provisions_Commitment;
        private string other_Provisions_Details;
        private string legal_Head;

        private string safety_Manual;
        private string safety_Construction_Agreement;
        private string evaluation_Control;
        private string envouriment_Factory_List;
        private string aCT;
        private string ergonomic_Confirmation;
        private string eHS;

        private string sourcingSpecialist_Signature;
        private string sourcingSpecialist_Date;

        private string user_Dept_Head_Signature;
        private string user_Dept_Head_Date;

        private string sC_Leader_Signature;
        private string sC_Leader_Date;

        private string finance_Leader_Signature;
        private string finance_Leader_Date;

        private string general_Manager_Signature;
        private string general_Manager_Date;

        public string Form_ID
        {
            get
            {
                return form_ID;
            }

            set
            {
                form_ID = value;
            }
        }

        public string Temp_Vendor_ID
        {
            get
            {
                return temp_Vendor_ID;
            }

            set
            {
                temp_Vendor_ID = value;
            }
        }

        public string Temp_Vendor_Name
        {
            get
            {
                return temp_Vendor_Name;
            }

            set
            {
                temp_Vendor_Name = value;
            }
        }

        public string Form_Type_ID
        {
            get
            {
                return form_Type_ID;
            }

            set
            {
                form_Type_ID = value;
            }
        }

        public int Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }

        public string Ref_No
        {
            get
            {
                return ref_No;
            }

            set
            {
                ref_No = value;
            }
        }

        public string Purchase_Type
        {
            get
            {
                return purchase_Type;
            }

            set
            {
                purchase_Type = value;
            }
        }

        public string Sourcing_Specialist
        {
            get
            {
                return sourcing_Specialist;
            }

            set
            {
                sourcing_Specialist = value;
            }
        }

        public string User_Dept
        {
            get
            {
                return user_Dept;
            }

            set
            {
                user_Dept = value;
            }
        }

        public string Contract_Subject
        {
            get
            {
                return contract_Subject;
            }

            set
            {
                contract_Subject = value;
            }
        }

        public string Contract_Annual_Amount
        {
            get
            {
                return contract_Annual_Amount;
            }

            set
            {
                contract_Annual_Amount = value;
            }
        }

        public string Contract_StartTime
        {
            get
            {
                return contract_StartTime;
            }

            set
            {
                contract_StartTime = value;
            }
        }

        public string Contract_EndTime
        {
            get
            {
                return contract_EndTime;
            }

            set
            {
                contract_EndTime = value;
            }
        }

        public string Vendor_Name
        {
            get
            {
                return vendor_Name;
            }

            set
            {
                vendor_Name = value;
            }
        }

        public string Existing_Vendor
        {
            get
            {
                return existing_Vendor;
            }

            set
            {
                existing_Vendor = value;
            }
        }

        public string Years
        {
            get
            {
                return years;
            }

            set
            {
                years = value;
            }
        }

        public string Purchase_Description
        {
            get
            {
                return purchase_Description;
            }

            set
            {
                purchase_Description = value;
            }
        }

        public string Payment_Terms_Page
        {
            get
            {
                return payment_Terms_Page;
            }

            set
            {
                payment_Terms_Page = value;
            }
        }

        public string Payment_Terms_Clause
        {
            get
            {
                return payment_Terms_Clause;
            }

            set
            {
                payment_Terms_Clause = value;
            }
        }

        public string Payment_Terms_Commitment
        {
            get
            {
                return payment_Terms_Commitment;
            }

            set
            {
                payment_Terms_Commitment = value;
            }
        }

        public string Payment_Terms_Details
        {
            get
            {
                return payment_Terms_Details;
            }

            set
            {
                payment_Terms_Details = value;
            }
        }

        public string Fin_Leader
        {
            get
            {
                return fin_Leader;
            }

            set
            {
                fin_Leader = value;
            }
        }

        public string User_Dept_Head_One
        {
            get
            {
                return user_Dept_Head_One;
            }

            set
            {
                user_Dept_Head_One = value;
            }
        }

        public string User_Dept_Head_Two
        {
            get
            {
                return user_Dept_Head_Two;
            }

            set
            {
                user_Dept_Head_Two = value;
            }
        }

        public string Price_Adjustment_Page
        {
            get
            {
                return price_Adjustment_Page;
            }

            set
            {
                price_Adjustment_Page = value;
            }
        }

        public string Price_Adjustment_Clause
        {
            get
            {
                return price_Adjustment_Clause;
            }

            set
            {
                price_Adjustment_Clause = value;
            }
        }

        public string Price_Adjustment_Commitment
        {
            get
            {
                return price_Adjustment_Commitment;
            }

            set
            {
                price_Adjustment_Commitment = value;
            }
        }

        public string Price_Adjustment_Details
        {
            get
            {
                return price_Adjustment_Details;
            }

            set
            {
                price_Adjustment_Details = value;
            }
        }

        public string Volume_Page
        {
            get
            {
                return volume_Page;
            }

            set
            {
                volume_Page = value;
            }
        }

        public string Volume_Clause
        {
            get
            {
                return volume_Clause;
            }

            set
            {
                volume_Clause = value;
            }
        }

        public string Volume_Commitment
        {
            get
            {
                return volume_Commitment;
            }

            set
            {
                volume_Commitment = value;
            }
        }

        public string Volume_Details
        {
            get
            {
                return volume_Details;
            }

            set
            {
                volume_Details = value;
            }
        }

        public string Period_Page
        {
            get
            {
                return period_Page;
            }

            set
            {
                period_Page = value;
            }
        }

        public string Period_Clause
        {
            get
            {
                return period_Clause;
            }

            set
            {
                period_Clause = value;
            }
        }

        public string Period_Commitment
        {
            get
            {
                return period_Commitment;
            }

            set
            {
                period_Commitment = value;
            }
        }

        public string Period_Details
        {
            get
            {
                return period_Details;
            }

            set
            {
                period_Details = value;
            }
        }

        public string Rebate_Page
        {
            get
            {
                return rebate_Page;
            }

            set
            {
                rebate_Page = value;
            }
        }

        public string Rebate_Clause
        {
            get
            {
                return rebate_Clause;
            }

            set
            {
                rebate_Clause = value;
            }
        }

        public string Rebate_Commitment
        {
            get
            {
                return rebate_Commitment;
            }

            set
            {
                rebate_Commitment = value;
            }
        }

        public string Rebate_Details
        {
            get
            {
                return rebate_Details;
            }

            set
            {
                rebate_Details = value;
            }
        }

        public string Work_Scope_Page
        {
            get
            {
                return work_Scope_Page;
            }

            set
            {
                work_Scope_Page = value;
            }
        }

        public string Work_Scope_Clause
        {
            get
            {
                return work_Scope_Clause;
            }

            set
            {
                work_Scope_Clause = value;
            }
        }

        public string Work_Scope_Commitment
        {
            get
            {
                return work_Scope_Commitment;
            }

            set
            {
                work_Scope_Commitment = value;
            }
        }

        public string Work_Scope_Details
        {
            get
            {
                return work_Scope_Details;
            }

            set
            {
                work_Scope_Details = value;
            }
        }

        public string Acceptence_Criteria_Page
        {
            get
            {
                return acceptence_Criteria_Page;
            }

            set
            {
                acceptence_Criteria_Page = value;
            }
        }

        public string Acceptence_Criteria_Clause
        {
            get
            {
                return acceptence_Criteria_Clause;
            }

            set
            {
                acceptence_Criteria_Clause = value;
            }
        }

        public string Acceptence_Criteria_Commitment
        {
            get
            {
                return acceptence_Criteria_Commitment;
            }

            set
            {
                acceptence_Criteria_Commitment = value;
            }
        }

        public string Acceptence_Criteria_Details
        {
            get
            {
                return acceptence_Criteria_Details;
            }

            set
            {
                acceptence_Criteria_Details = value;
            }
        }

        public string Warranty_Page
        {
            get
            {
                return warranty_Page;
            }

            set
            {
                warranty_Page = value;
            }
        }

        public string Warranty_Clause
        {
            get
            {
                return warranty_Clause;
            }

            set
            {
                warranty_Clause = value;
            }
        }

        public string Warranty_Commitment
        {
            get
            {
                return warranty_Commitment;
            }

            set
            {
                warranty_Commitment = value;
            }
        }

        public string Warranty_Details
        {
            get
            {
                return warranty_Details;
            }

            set
            {
                warranty_Details = value;
            }
        }

        public string Termination_Page
        {
            get
            {
                return termination_Page;
            }

            set
            {
                termination_Page = value;
            }
        }

        public string Termination_Clause
        {
            get
            {
                return termination_Clause;
            }

            set
            {
                termination_Clause = value;
            }
        }

        public string Termination_Commitment
        {
            get
            {
                return termination_Commitment;
            }

            set
            {
                termination_Commitment = value;
            }
        }

        public string Termination_Details
        {
            get
            {
                return termination_Details;
            }

            set
            {
                termination_Details = value;
            }
        }

        public string Exclusivity_Page
        {
            get
            {
                return exclusivity_Page;
            }

            set
            {
                exclusivity_Page = value;
            }
        }

        public string Exclusivity_Clause
        {
            get
            {
                return exclusivity_Clause;
            }

            set
            {
                exclusivity_Clause = value;
            }
        }

        public string Exclusivity_Commitment
        {
            get
            {
                return exclusivity_Commitment;
            }

            set
            {
                exclusivity_Commitment = value;
            }
        }

        public string Exclusivity_Details
        {
            get
            {
                return exclusivity_Details;
            }

            set
            {
                exclusivity_Details = value;
            }
        }

        public string Other_Terms_Page
        {
            get
            {
                return other_Terms_Page;
            }

            set
            {
                other_Terms_Page = value;
            }
        }

        public string Other_Terms_Clause
        {
            get
            {
                return other_Terms_Clause;
            }

            set
            {
                other_Terms_Clause = value;
            }
        }

        public string Other_Terms_Commitment
        {
            get
            {
                return other_Terms_Commitment;
            }

            set
            {
                other_Terms_Commitment = value;
            }
        }

        public string Other_Terms_Details
        {
            get
            {
                return other_Terms_Details;
            }

            set
            {
                other_Terms_Details = value;
            }
        }

        public string Penalty_Detail_Page
        {
            get
            {
                return penalty_Detail_Page;
            }

            set
            {
                penalty_Detail_Page = value;
            }
        }

        public string Penalty_Detail_Clause
        {
            get
            {
                return penalty_Detail_Clause;
            }

            set
            {
                penalty_Detail_Clause = value;
            }
        }

        public string Penalty_Detail_Details
        {
            get
            {
                return penalty_Detail_Details;
            }

            set
            {
                penalty_Detail_Details = value;
            }
        }

        public string Changes
        {
            get
            {
                return changes;
            }

            set
            {
                changes = value;
            }
        }

        public string Notice_Page
        {
            get
            {
                return notice_Page;
            }

            set
            {
                notice_Page = value;
            }
        }

        public string Notice_Clause
        {
            get
            {
                return notice_Clause;
            }

            set
            {
                notice_Clause = value;
            }
        }

        public string Notice_Commitment
        {
            get
            {
                return notice_Commitment;
            }

            set
            {
                notice_Commitment = value;
            }
        }

        public string Notice_Details
        {
            get
            {
                return notice_Details;
            }

            set
            {
                notice_Details = value;
            }
        }

        public string Confidentiality_Page
        {
            get
            {
                return confidentiality_Page;
            }

            set
            {
                confidentiality_Page = value;
            }
        }

        public string Confidentiality_Clause
        {
            get
            {
                return confidentiality_Clause;
            }

            set
            {
                confidentiality_Clause = value;
            }
        }

        public string Confidentiality_Commitment
        {
            get
            {
                return confidentiality_Commitment;
            }

            set
            {
                confidentiality_Commitment = value;
            }
        }

        public string Confidentiality_Details
        {
            get
            {
                return confidentiality_Details;
            }

            set
            {
                confidentiality_Details = value;
            }
        }

        public string Announcement_Page
        {
            get
            {
                return announcement_Page;
            }

            set
            {
                announcement_Page = value;
            }
        }

        public string Announcement_Clause
        {
            get
            {
                return announcement_Clause;
            }

            set
            {
                announcement_Clause = value;
            }
        }

        public string Announcement_Commitment
        {
            get
            {
                return announcement_Commitment;
            }

            set
            {
                announcement_Commitment = value;
            }
        }

        public string Announcement_Details
        {
            get
            {
                return announcement_Details;
            }

            set
            {
                announcement_Details = value;
            }
        }

        public string Waivers_Page
        {
            get
            {
                return waivers_Page;
            }

            set
            {
                waivers_Page = value;
            }
        }

        public string Waivers_Clause
        {
            get
            {
                return waivers_Clause;
            }

            set
            {
                waivers_Clause = value;
            }
        }

        public string Waivers_Commitment
        {
            get
            {
                return waivers_Commitment;
            }

            set
            {
                waivers_Commitment = value;
            }
        }

        public string Waivers_Details
        {
            get
            {
                return waivers_Details;
            }

            set
            {
                waivers_Details = value;
            }
        }

        public string Severalbility_Page
        {
            get
            {
                return severalbility_Page;
            }

            set
            {
                severalbility_Page = value;
            }
        }

        public string Severalbility_Clause
        {
            get
            {
                return severalbility_Clause;
            }

            set
            {
                severalbility_Clause = value;
            }
        }

        public string Severalbility_Commitment
        {
            get
            {
                return severalbility_Commitment;
            }

            set
            {
                severalbility_Commitment = value;
            }
        }

        public string Severalbility_Details
        {
            get
            {
                return severalbility_Details;
            }

            set
            {
                severalbility_Details = value;
            }
        }

        public string Force_Majeure
        {
            get
            {
                return force_Majeure;
            }

            set
            {
                force_Majeure = value;
            }
        }

        public string Force_Clause
        {
            get
            {
                return force_Clause;
            }

            set
            {
                force_Clause = value;
            }
        }

        public string Force_Commitment
        {
            get
            {
                return force_Commitment;
            }

            set
            {
                force_Commitment = value;
            }
        }

        public string Force_Details
        {
            get
            {
                return force_Details;
            }

            set
            {
                force_Details = value;
            }
        }

        public string Delegation_Page
        {
            get
            {
                return delegation_Page;
            }

            set
            {
                delegation_Page = value;
            }
        }

        public string Delegation_Clause
        {
            get
            {
                return delegation_Clause;
            }

            set
            {
                delegation_Clause = value;
            }
        }

        public string Delegation_Commitment
        {
            get
            {
                return delegation_Commitment;
            }

            set
            {
                delegation_Commitment = value;
            }
        }

        public string Delegation_Details
        {
            get
            {
                return delegation_Details;
            }

            set
            {
                delegation_Details = value;
            }
        }

        public string Dispute_Resolution_Page
        {
            get
            {
                return dispute_Resolution_Page;
            }

            set
            {
                dispute_Resolution_Page = value;
            }
        }

        public string Dispute_Resolution_Clause
        {
            get
            {
                return dispute_Resolution_Clause;
            }

            set
            {
                dispute_Resolution_Clause = value;
            }
        }

        public string Dispute_Resolution_Commitment
        {
            get
            {
                return dispute_Resolution_Commitment;
            }

            set
            {
                dispute_Resolution_Commitment = value;
            }
        }

        public string Dispute_Resolution_Details
        {
            get
            {
                return dispute_Resolution_Details;
            }

            set
            {
                dispute_Resolution_Details = value;
            }
        }

        public string Other_Provisions_Page
        {
            get
            {
                return other_Provisions_Page;
            }

            set
            {
                other_Provisions_Page = value;
            }
        }

        public string Other_Provisions_Clause
        {
            get
            {
                return other_Provisions_Clause;
            }

            set
            {
                other_Provisions_Clause = value;
            }
        }

        public string Other_Provisions_Commitment
        {
            get
            {
                return other_Provisions_Commitment;
            }

            set
            {
                other_Provisions_Commitment = value;
            }
        }

        public string Other_Provisions_Details
        {
            get
            {
                return other_Provisions_Details;
            }

            set
            {
                other_Provisions_Details = value;
            }
        }

        public string Safety_Manual
        {
            get
            {
                return safety_Manual;
            }

            set
            {
                safety_Manual = value;
            }
        }

        public string Safety_Construction_Agreement
        {
            get
            {
                return safety_Construction_Agreement;
            }

            set
            {
                safety_Construction_Agreement = value;
            }
        }

        public string Evaluation_Control
        {
            get
            {
                return evaluation_Control;
            }

            set
            {
                evaluation_Control = value;
            }
        }

        public string Envouriment_Factory_List
        {
            get
            {
                return envouriment_Factory_List;
            }

            set
            {
                envouriment_Factory_List = value;
            }
        }

        public string ACT
        {
            get
            {
                return aCT;
            }

            set
            {
                aCT = value;
            }
        }

        public string Ergonomic_Confirmation
        {
            get
            {
                return ergonomic_Confirmation;
            }

            set
            {
                ergonomic_Confirmation = value;
            }
        }

        public string EHS
        {
            get
            {
                return eHS;
            }

            set
            {
                eHS = value;
            }
        }

        public string SourcingSpecialist_Signature
        {
            get
            {
                return sourcingSpecialist_Signature;
            }

            set
            {
                sourcingSpecialist_Signature = value;
            }
        }

        public string SourcingSpecialist_Date
        {
            get
            {
                return sourcingSpecialist_Date;
            }

            set
            {
                sourcingSpecialist_Date = value;
            }
        }

        public string User_Dept_Head_Signature
        {
            get
            {
                return user_Dept_Head_Signature;
            }

            set
            {
                user_Dept_Head_Signature = value;
            }
        }

        public string User_Dept_Head_Date
        {
            get
            {
                return user_Dept_Head_Date;
            }

            set
            {
                user_Dept_Head_Date = value;
            }
        }

        public string SC_Leader_Signature
        {
            get
            {
                return sC_Leader_Signature;
            }

            set
            {
                sC_Leader_Signature = value;
            }
        }

        public string SC_Leader_Date
        {
            get
            {
                return sC_Leader_Date;
            }

            set
            {
                sC_Leader_Date = value;
            }
        }

        public string Finance_Leader_Signature
        {
            get
            {
                return finance_Leader_Signature;
            }

            set
            {
                finance_Leader_Signature = value;
            }
        }

        public string Finance_Leader_Date
        {
            get
            {
                return finance_Leader_Date;
            }

            set
            {
                finance_Leader_Date = value;
            }
        }

        public string General_Manager_Signature
        {
            get
            {
                return general_Manager_Signature;
            }

            set
            {
                general_Manager_Signature = value;
            }
        }

        public string General_Manager_Date
        {
            get
            {
                return general_Manager_Date;
            }

            set
            {
                general_Manager_Date = value;
            }
        }

        public string Legal_Head
        {
            get
            {
                return legal_Head;
            }

            set
            {
                legal_Head = value;
            }
        }

        public string Bar_Code
        {
            get
            {
                return bar_Code;
            }

            set
            {
                bar_Code = value;
            }
        }

        public string Standard_Contract
        {
            get
            {
                return standard_Contract;
            }

            set
            {
                standard_Contract = value;
            }
        }
    }
}
