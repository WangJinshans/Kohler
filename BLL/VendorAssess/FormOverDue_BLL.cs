using DAL;
using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        /// <summary>
        /// 根据新的formID查出tempvendorID，formTypeID，factory
        /// 再到历史表中查找是否有记录 若有记录则说明是过期重新审批
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static bool isOverDue(string formID)
        {
            bool isOverDue = false;
            DataTable table = new DataTable();
            string tempvendorID, formTypeID, factory;
            table = FormOverDue_DAL.getFormInfo(formID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    tempvendorID = dr["Temp_Vendor_ID"].ToString().Trim();
                    formTypeID= dr["Form_Type_ID"].ToString().Trim();
                    factory= dr["Factory_Name"].ToString().Trim();
                    isOverDue = isFormOverDue(tempvendorID, formTypeID, factory);
                    if (isOverDue)//在历史表中查到记录
                    {
                        return true;
                    }
                }
            }
            return isOverDue;
        }

        /// <summary>
        /// 根据这三个参数查找是否属于过期表 如果在history中查到了记录则表明该表是一张过期表
        /// </summary>
        /// <param name="tempvendorID"></param>
        /// <param name="formTypeID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static bool isFormOverDue(string tempvendorID, string formTypeID, string factory)
        {
            string sql = "select * from As_Vendor_FormType_History where Temp_Vendor_ID='" + tempvendorID + "' and Form_Type_ID='" + formTypeID + "' and Factory_Name='" + factory + "'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public static string getOldFormID(string formID)
        {
            string oldFormID = "";
            DataTable table = new DataTable();
            string tempvendorID, formTypeID, factory;
            table = FormOverDue_DAL.getFormInfo(formID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    tempvendorID = dr["Temp_Vendor_ID"].ToString().Trim();
                    formTypeID = dr["Form_Type_ID"].ToString().Trim();
                    factory = dr["Factory_Name"].ToString().Trim();
                    oldFormID = getFormID(tempvendorID, formTypeID, factory);
                    if (oldFormID!="")//在历史表中查到记录
                    {
                        return oldFormID;
                    }
                }
            }
            return "";
        }

        private static string getFormID(string tempvendorID, string formTypeID, string factory)
        {
            string sql = "select Form_ID from As_Vendor_FormType_History where Temp_Vendor_ID='" + tempvendorID + "' and Form_Type_ID='" + formTypeID + "' and Factory_Name='" + factory + "' and Status='new'";
            string oldFormID = "";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    oldFormID = dr["Form_ID"].ToString().Trim();
                }
            }
            return oldFormID;
        }
    }
}
