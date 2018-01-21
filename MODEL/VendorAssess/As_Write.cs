using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class As_Write
    {
        public const string APPROVE_SUCCESS = "审批通过";
        public const string APPROVE_FAIL = "审批失败";
        public const string FORM_EDIT = "表格动作";
        public const string NORMAL_ACTION = "常规";
        public const string FORM_MULTI_EDIT = "多人填写";
        public const string MAIL_CANCELLED = "邮件取消";
        public const string MAIL_SUCCESS = "邮件发送";
        public const string MAIL_ERROR = "邮件错误";
        public const string FIND_NEXT_APPROVE_FAIL = "查询失败";

        private int id;
        private string employee_ID;
        private string form_ID;
        private string form_Fill_Time;
        private string manul;
        private string temp_Vendor_ID;
        private string manul_Type;

        public As_Write()
        {
            manul_Type = NORMAL_ACTION;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Employee_ID
        {
            get
            {
                return employee_ID;
            }

            set
            {
                employee_ID = value;
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

        public string Form_Fill_Time
        {
            get
            {
                return form_Fill_Time;
            }

            set
            {
                form_Fill_Time = value;
            }
        }

        public string Manul
        {
            get
            {
                return manul;
            }

            set
            {
                manul = value;
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

        public string Manul_Type
        {
            get
            {
                return manul_Type;
            }

            set
            {
                manul_Type = value;
            }
        }
    }
}
