using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class FormOverDue_BLL
    {
        public static IList<As_Form_OverDue> getOverDueForm(string temp_Vendor_ID,string factory)
        {
            As_Form_OverDue form = new As_Form_OverDue();
            List<As_Form_OverDue> list = new List<As_Form_OverDue>();
            //string sql = "select As_VendorForm_OverDue.Form_ID,As_VendorForm_OverDue.Temp_Vendor_ID,As_Form_Type.Form_Type_Is_Optional,As_VendorForm_OverDue.Status from As_VendorForm_OverDue,As_Vendor_FormType,As_Form_Type where As_Vendor_FormType.Temp_Vendor_ID=As_VendorForm_OverDue.Temp_Vendor_ID and As_Vendor_FormType.Form_Type_ID=As_Form_Type.Form_Type_ID and As_VendorForm_OverDue.Temp_Vendor_ID ='" + temp_Vendor_ID + "'";
            string sql = "select Form_ID,Temp_Vendor_ID,Form_Type_Is_Optional,Status from As_VendorForm_OverDue where Temp_Vendor_ID ='" + temp_Vendor_ID + "' and Factory_Name='" + factory + "'";
            DataTable table = new DataTable();
            table = FormOverDue_DAL.getOverDueForm(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    form.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    form.Form_ID = Convert.ToString(dr["Form_ID"]);
                    form.Form_Type_Is_Optional = Convert.ToString(dr["Form_Type_Is_Optional"]);
                    form.Status = Convert.ToString(dr["Status"]);
                    //form.Position = Convert.ToString(dr["Position"]);
                    list.Add(form);
                }
            }
            return list;
        }

        public static int addVendorFormType(As_Vendor_Form_Type vendor)
        {
            return FormOverDue_DAL.addVendorFormType(vendor);
        }

        public static int reAccessForm(string formID, string temp_Vendor_ID)
        {
            return FileOverDue_DAL.reAccessForm(formID, temp_Vendor_ID);
        }



        public static int getLastedForm(string formID)
        {
            string sql = "";
            int max = -1;
            DataTable table = new DataTable();
            List<int> numbers = new List<int>();
            string form = switchForm(formID);
            if (form != "")
            {
                sql = "select Number from " + form + " where Form_ID='" + formID + "'";
                table = FormOverDue_DAL.getFormnumber(sql);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        int number = Convert.ToInt32(dr["Number"]);
                        numbers.Add(number);
                    }
                    foreach (int number in numbers)
                    {
                        if (max < number)
                        {
                            max = number;//max代表当前正在使用的表 默认从0开始 更新一次+1;
                        }
                    }
                    return max;
                }
            }
            return -1;//出错
        }

        private static string switchForm(string formID)
        {
            string form = "";
            if (formID.Contains("BiddingForm"))
            {
                form = "As_Bidding_Approval_Form";
            }
            else if (formID.Contains("VendorDesignated"))
            {
                form = "As_Vendor_Designated_Apply";
            }
            else if (formID.Contains("ContractApproval"))
            {
                form = "As_Contract_Approval";
            }
            else if (formID.Contains("VendorDiscovery"))
            {
                form = "As_Vendor_Discovery";
            }
            else if (formID.Contains("VendorBlock"))
            {
                form = "As_Vendor_Block_Or_UnBlock";
            }
            else if (formID.Contains("VendorExtend"))
            {
                form = "As_Vendor_Extend";
            }
            else if (formID.Contains("VendorRisk"))
            {
                form = "As_Vendor_Risk";
            }
            else if (formID.Contains("VendorSelection"))
            {
                form = "As_Vendor_Selection";
            }
            else if (formID.Contains("VendorCreation"))
            {
                form = "As_VendorCreation";
            }
            return form;
        }
    }
}
