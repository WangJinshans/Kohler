using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Vendor_Modify
    {
        private string form_ID;
        private string form_Type_ID;
        private string purpose;
        private string initiator_Name;
        private string initiator_Tel;
        private string company_Code;

        private string account_Group;//
        private string postal_Code;

        private string vendor_Code;//供应商编码
        private string vendor_Name;
        private string street;//地址
        private string city;
        private string country;
        private string region;
        private string language;
        private string telephone_No;
        private string fax_No;
        private string email_Address_One;//(FOR PO)*
        private string email_Address_Two;//(FOR PAYMENT ADVICE用于付款信息)*
        private string tax_Identification_Number; //税务登记证号码*
        private string payment_Term;//账期
        private string payment_Method;
        private string bank_Code;//银行代码
        private string bank_Name;
        private string bank_Country;
        private string bank_Account;//账户
        private string money_Type;
        private string trade_Onym;//贸易术语
        private string line_Manager;
        private string purchasing_Manager;
        private string ministry_Of_Law;//法务部
        private string accounting_Dept;
        private string chief_Inspector;//总监
        private string comments;//评论
        private int flag;//标志位
        private string temp_Vendor_ID;
        private string bar_Code;
        private string factory_Name;

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

        public string Purpose
        {
            get
            {
                return purpose;
            }

            set
            {
                purpose = value;
            }
        }

        public string Initiator_Name
        {
            get
            {
                return initiator_Name;
            }

            set
            {
                initiator_Name = value;
            }
        }

        public string Initiator_Tel
        {
            get
            {
                return initiator_Tel;
            }

            set
            {
                initiator_Tel = value;
            }
        }

        public string Company_Code
        {
            get
            {
                return company_Code;
            }

            set
            {
                company_Code = value;
            }
        }

        public string Account_Group
        {
            get
            {
                return account_Group;
            }

            set
            {
                account_Group = value;
            }
        }

        public string Postal_Code
        {
            get
            {
                return postal_Code;
            }

            set
            {
                postal_Code = value;
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

        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                street = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public string Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }

        public string Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }

        public string Telephone_No
        {
            get
            {
                return telephone_No;
            }

            set
            {
                telephone_No = value;
            }
        }

        public string Fax_No
        {
            get
            {
                return fax_No;
            }

            set
            {
                fax_No = value;
            }
        }

        public string Email_Address_One
        {
            get
            {
                return email_Address_One;
            }

            set
            {
                email_Address_One = value;
            }
        }

        public string Email_Address_Two
        {
            get
            {
                return email_Address_Two;
            }

            set
            {
                email_Address_Two = value;
            }
        }

        public string Tax_Identification_Number
        {
            get
            {
                return tax_Identification_Number;
            }

            set
            {
                tax_Identification_Number = value;
            }
        }

        public string Payment_Term
        {
            get
            {
                return payment_Term;
            }

            set
            {
                payment_Term = value;
            }
        }

        public string Payment_Method
        {
            get
            {
                return payment_Method;
            }

            set
            {
                payment_Method = value;
            }
        }

        public string Bank_Code
        {
            get
            {
                return bank_Code;
            }

            set
            {
                bank_Code = value;
            }
        }

        public string Bank_Name
        {
            get
            {
                return bank_Name;
            }

            set
            {
                bank_Name = value;
            }
        }

        public string Bank_Country
        {
            get
            {
                return bank_Country;
            }

            set
            {
                bank_Country = value;
            }
        }

        public string Bank_Account
        {
            get
            {
                return bank_Account;
            }

            set
            {
                bank_Account = value;
            }
        }

        public string Money_Type
        {
            get
            {
                return money_Type;
            }

            set
            {
                money_Type = value;
            }
        }

        public string Trade_Onym
        {
            get
            {
                return trade_Onym;
            }

            set
            {
                trade_Onym = value;
            }
        }

        public string Line_Manager
        {
            get
            {
                return line_Manager;
            }

            set
            {
                line_Manager = value;
            }
        }

        public string Purchasing_Manager
        {
            get
            {
                return purchasing_Manager;
            }

            set
            {
                purchasing_Manager = value;
            }
        }

        public string Ministry_Of_Law
        {
            get
            {
                return ministry_Of_Law;
            }

            set
            {
                ministry_Of_Law = value;
            }
        }

        public string Accounting_Dept
        {
            get
            {
                return accounting_Dept;
            }

            set
            {
                accounting_Dept = value;
            }
        }

        public string Chief_Inspector
        {
            get
            {
                return chief_Inspector;
            }

            set
            {
                chief_Inspector = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
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
    }
}
