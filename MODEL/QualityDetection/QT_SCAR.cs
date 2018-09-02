using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_SCAR
    {
        private string factory;
        private int flag;
        private string approved_by2;
        private string approved_by4;
        private string p_C_A_Approved_by;
        private string i_C_A_Approved_by;
        private string i_C_A_Approved_Date;
        private string v_E_Approved_by;
        private string p_R_Approved_by;
        private string p_C_A_Approved_Date;
        private string v_E_Approved_Date;
        private string p_R_Approved_Date;
        private string batch_No;
        private string business_Team_Member;
        private string completed_Date2;
        private string completed_Date4;
        private string customer;
        private string customer_satisfaction_degree;
        private string date_Raised;
        private string define_and_Verify_Root_Causes;
        private string deverlop_Team_Member;
        private string due_Date;
        private string form_ID;
        private int iD;
        private List<QT_SCAR_Immediate_Containment_Actions> immediate_Containment_Actions;   
        private string iQC_Team_Member; 
        private string memo;
        private string occurred_Qty;
        private string occurred_Site;
        private string occurred_Time;
        private string part_Name;
        private string part_Number;
        private List<QT_SCAR_Permanent_Corrective_Actions> permanent_Corrective_Actions;
        private string prepared_by2;
        private string prepared_by4;
        private List<QT_SCAR_Prevent_Recurrence> prevent_Recurrence;
        private string problem_Description;
        private string produce_Team_Member;
        private string project_Team_Member;
        private string purchasing_Team_Member;
        private string qA_Team_Member;
        private string qtv_Ins;
        private string qtv_Rei;
        private string raised_by;
        private string rea_For_CA;
        private string subject;
        private string supplier;
        private string vendor_Code;
        private List<QT_SCAR_Verification_of_Effectiveness> verification_of_Effectiveness;
        private string person_Pro;
        private string machine_Pro;
        private string material_Pro;
        private string law_Pro;
        private string environment_Pro;
        private string measure_Pro;

        public string V_E_Approved_by
        {
            get
            {
                return v_E_Approved_by;
            }

            set
            {
                v_E_Approved_by = value;
            }
        }
        public string V_E_Approved_Date
        {
            get
            {
                return v_E_Approved_Date;
            }

            set
            {
                v_E_Approved_Date = value;
            }
        }
        public string Environment_Pro
        {
            get
            {
                return environment_Pro;
            }

            set
            {
                environment_Pro = value;
            }
        }
        public string Measure_Pro
        {
            get
            {
                return measure_Pro;
            }

            set
            {
                measure_Pro = value;
            }
        }
        public string Person_Pro
        {
            get
            {
                return person_Pro;
            }

            set
            {
                person_Pro = value;
            }
        }
        public string Machine_Pro
        {
            get
            {
                return machine_Pro;
            }

            set
            {
                machine_Pro = value;
            }
        }
        public string Material_Pro
        {
            get
            {
                return material_Pro;
            }

            set
            {
                material_Pro = value;
            }
        }
        public string Law_Pro
        {
            get
            {
                return law_Pro;
            }

            set
            {
                law_Pro = value;
            }
        }
        public string Factory
        {
            get
            {
                return factory;
            }

            set
            {
                factory = value;
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
        public string Batch_No
        {
            get
            {
                return batch_No;
            }

            set
            {
                batch_No = value;
            }
        }
        public string Business_Team_Member
        {
            get
            {
                return business_Team_Member;
            }

            set
            {
                business_Team_Member = value;
            }
        }
        public string Qtv_Ins
        {
            get
            {
                return qtv_Ins;
            }

            set
            {
                qtv_Ins = value;
            }
        }
        public string Approved_by2
        {
            get
            {
                return approved_by2;
            }

            set
            {
                approved_by2 = value;
            }
        }
        public string Approved_by4
        {
            get
            {
                return approved_by4;
            }

            set
            {
                approved_by4 = value;
            }
        }
        public string I_C_A_Approved_by
        {
            get
            {
                return i_C_A_Approved_by;
            }

            set
            {
                i_C_A_Approved_by = value;
            }
        }
        public string I_C_A_Approved_Date
        {
            get
            {
                return i_C_A_Approved_Date;
            }

            set
            {
                i_C_A_Approved_Date = value;
            }
        }
        public string P_C_A_Approved_by
        {
            get
            {
                return p_C_A_Approved_by;
            }

            set
            {
                p_C_A_Approved_by = value;
            }
        }
        public string P_C_A_Approved_Date
        {
            get
            {
                return p_C_A_Approved_Date;
            }

            set
            {
                p_C_A_Approved_Date = value;
            }
        }
        public string P_R_Approved_by
        {
            get
            {
                return p_R_Approved_by;
            }

            set
            {
                p_R_Approved_by = value;
            }
        }
        public string P_R_Approved_Date
        {
            get
            {
                return p_R_Approved_Date;
            }

            set
            {
                p_R_Approved_Date = value;
            }
        }
        
        public string Completed_Date2
        {
            get
            {
                return completed_Date2;
            }

            set
            {
                completed_Date2 = value;
            }
        }
        public string Completed_Date4
        {
            get
            {
                return completed_Date4;
            }

            set
            {
                completed_Date4 = value;
            }
        }
        public string Customer
        {
            get
            {
                return customer;
            }

            set
            {
                customer = value;
            }
        }
        public string Customer_satisfaction_degree
        {
            get
            {
                return customer_satisfaction_degree;
            }

            set
            {
                customer_satisfaction_degree = value;
            }
        }
        public string Date_Raised
        {
            get
            {
                return date_Raised;
            }

            set
            {
                date_Raised = value;
            }
        }
        
        public string Define_and_Verify_Root_Causes
        {
            get
            {
                return define_and_Verify_Root_Causes;
            }

            set
            {
                define_and_Verify_Root_Causes = value;
            }
        }
        public string Deverlop_Team_Member
        {
            get
            {
                return deverlop_Team_Member;
            }

            set
            {
                deverlop_Team_Member = value;
            }
        }
        public string Due_Date
        {
            get
            {
                return due_Date;
            }

            set
            {
                due_Date = value;
            }
        }
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
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }
        public List<QT_SCAR_Immediate_Containment_Actions> Immediate_Containment_Actions
        {
            get
            {
                return immediate_Containment_Actions;
            }

            set
            {
                immediate_Containment_Actions = value;
            }
        }
        
        public string IQC_Team_Member
        {
            get
            {
                return iQC_Team_Member;
            }

            set
            {
                iQC_Team_Member = value;
            }
        }
        
        public string Memo
        {
            get
            {
                return memo;
            }

            set
            {
                memo = value;
            }
        }
        public string Occurred_Qty
        {
            get
            {
                return occurred_Qty;
            }

            set
            {
                occurred_Qty = value;
            }
        }
        public string Occurred_Site
        {
            get
            {
                return occurred_Site;
            }

            set
            {
                occurred_Site = value;
            }
        }
        public string Occurred_Time
        {
            get
            {
                return occurred_Time;
            }

            set
            {
                occurred_Time = value;
            }
        }
        public string Part_Name
        {
            get
            {
                return part_Name;
            }

            set
            {
                part_Name = value;
            }
        }
        public string Part_Number
        {
            get
            {
                return part_Number;
            }

            set
            {
                part_Number = value;
            }
        }
        public List<QT_SCAR_Permanent_Corrective_Actions> Permanent_Corrective_Actions
        {
            get
            {
                return permanent_Corrective_Actions;
            }

            set
            {
                permanent_Corrective_Actions = value;
            }
        }
        
        public string Prepared_by2
        {
            get
            {
                return prepared_by2;
            }

            set
            {
                prepared_by2 = value;
            }
        }
        public string Prepared_by4
        {
            get
            {
                return prepared_by4;
            }

            set
            {
                prepared_by4 = value;
            }
        }
        public List<QT_SCAR_Prevent_Recurrence> Prevent_Recurrence
        {
            get
            {
                return prevent_Recurrence;
            }

            set
            {
                prevent_Recurrence = value;
            }
        }
        public string Problem_Description
        {
            get
            {
                return problem_Description;
            }

            set
            {
                problem_Description = value;
            }
        }
        public string Produce_Team_Member
        {
            get
            {
                return produce_Team_Member;
            }

            set
            {
                produce_Team_Member = value;
            }
        }
        public string Project_Team_Member
        {
            get
            {
                return project_Team_Member;
            }

            set
            {
                project_Team_Member = value;
            }
        }
        public string Purchasing_Team_Member
        {
            get
            {
                return purchasing_Team_Member;
            }

            set
            {
                purchasing_Team_Member = value;
            }
        }
        public string Qtv_Rei
        {
            get
            {
                return qtv_Rei;
            }

            set
            {
                qtv_Rei = value;
            }
        }
        public string QA_Team_Member
        {
            get
            {
                return qA_Team_Member;
            }

            set
            {
                qA_Team_Member = value;
            }
        }

        public string Raised_by
        {
            get
            {
                return raised_by;
            }

            set
            {
                raised_by = value;
            }
        }
        public string Rea_For_CA
        {
            get
            {
                return rea_For_CA;
            }

            set
            {
                rea_For_CA = value;
            }
        }
        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }
        public string Supplier
        {
            get
            {
                return supplier;
            }

            set
            {
                supplier = value;
            }
        }
        public string Vendor_Code
        {
            get
            {
                return vendor_Code;
            }

            set
            {
                vendor_Code = value;
            }
        }
        public List<QT_SCAR_Verification_of_Effectiveness> Verification_of_Effectiveness
        {
            get
            {
                return verification_of_Effectiveness;
            }

            set
            {
                verification_of_Effectiveness = value;
            }
        }
       


    }
}
