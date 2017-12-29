using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Bidding_Approval
    {
        private string serial_No;
        private string date;
        private string product;
        private string purchase_Amount;
        private List<As_Bidding_Approval_Item> projectList;
        private string mOQ1;
        private string mOQ2;
        private string mOQ3;
        private string lead_Time1;
        private string lead_Time2;
        private string lead_Time3;
        private string payment_Term1;
        private string payment_Term2;
        private string payment_Term3;
        private string remark1;
        private string remark2;
        private string remark3;
        private string reason_One;
        private string reason_Two;
        private string initiator;
        private string supplier_Chain_Leader;
        private string finance_Leader;
        private string business_Leader;
        private int flag;
        private string form_ID;
        private string temp_Vendor_ID;
        private string temp_Vendor_Name;
        private string form_Type_ID;
        private string factory_Name;
        private string user_Department_Manager;

        public string Serial_No
        {
            get
            {
                return serial_No;
            }

            set
            {
                serial_No = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
            }
        }

        public string Purchase_Amount
        {
            get
            {
                return purchase_Amount;
            }

            set
            {
                purchase_Amount = value;
            }
        }

        public List<As_Bidding_Approval_Item> ProjectList
        {
            get
            {
                return projectList;
            }

            set
            {
                projectList = value;
            }
        }

        public string Reason_One
        {
            get
            {
                return reason_One;
            }

            set
            {
                reason_One = value;
            }
        }

        public string Reason_Two
        {
            get
            {
                return reason_Two;
            }

            set
            {
                reason_Two = value;
            }
        }

        public string Initiator
        {
            get
            {
                return initiator;
            }

            set
            {
                initiator = value;
            }
        }

        public string Supplier_Chain_Leader
        {
            get
            {
                return supplier_Chain_Leader;
            }

            set
            {
                supplier_Chain_Leader = value;
            }
        }

        public string Finance_Leader
        {
            get
            {
                return finance_Leader;
            }

            set
            {
                finance_Leader = value;
            }
        }

        public string Business_Leader
        {
            get
            {
                return business_Leader;
            }

            set
            {
                business_Leader = value;
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

        public string MOQ1
        {
            get
            {
                return mOQ1;
            }

            set
            {
                mOQ1 = value;
            }
        }

        public string MOQ2
        {
            get
            {
                return mOQ2;
            }

            set
            {
                mOQ2 = value;
            }
        }

        public string MOQ3
        {
            get
            {
                return mOQ3;
            }

            set
            {
                mOQ3 = value;
            }
        }

        public string Lead_Time1
        {
            get
            {
                return lead_Time1;
            }

            set
            {
                lead_Time1 = value;
            }
        }

        public string Lead_Time2
        {
            get
            {
                return lead_Time2;
            }

            set
            {
                lead_Time2 = value;
            }
        }

        public string Lead_Time3
        {
            get
            {
                return lead_Time3;
            }

            set
            {
                lead_Time3 = value;
            }
        }

        public string Payment_Term1
        {
            get
            {
                return payment_Term1;
            }

            set
            {
                payment_Term1 = value;
            }
        }

        public string Payment_Term2
        {
            get
            {
                return payment_Term2;
            }

            set
            {
                payment_Term2 = value;
            }
        }

        public string Payment_Term3
        {
            get
            {
                return payment_Term3;
            }

            set
            {
                payment_Term3 = value;
            }
        }

        public string Remark1
        {
            get
            {
                return remark1;
            }

            set
            {
                remark1 = value;
            }
        }

        public string Remark2
        {
            get
            {
                return remark2;
            }

            set
            {
                remark2 = value;
            }
        }

        public string Remark3
        {
            get
            {
                return remark3;
            }

            set
            {
                remark3 = value;
            }
        }

        public string Factory_Name
        {
            get
            {
                return factory_Name;
            }

            set
            {
                factory_Name = value;
            }
        }

        public string User_Department_Manager
        {
            get
            {
                return user_Department_Manager;
            }

            set
            {
                user_Department_Manager = value;
            }
        }

        public string Vendor_Recommend { get; set; }
        public string Rank1 { get; set; }
        public string Rank2 { get; set; }
        public string Rank3 { get; set; }
        public string Rank_Remark { get; set; }
    }
}