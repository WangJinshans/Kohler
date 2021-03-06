﻿using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class As_Bidding_Approval_BLL
    {
        public static int checkBiddingForm(string formID)
        {
            return As_Bidding_Approval_DAL.checkVendorBiddingApprovalForm(formID);
        }
        public static int getBiddingFormFlag(string tempVendorID)//获取标志位
        {
            return As_Bidding_Approval_DAL.getVendorBiddingApprovalFormFlag(tempVendorID);
        }
        public static int addBiddingForm(As_Bidding_Approval vendorApproval)//添加表
        {
            return As_Bidding_Approval_DAL.addVendorBiddingApprovalForm(vendorApproval);
        }
        public static string over_NewBiddingForm(As_Bidding_Approval vendorApproval)//添加表
        {
            return null;
            //return As_Bidding_Approval_DAL.over_NewBiddingForm(vendorApproval);
        }

        public static int updateBiddingForm(As_Bidding_Approval vendorApproval)
        {
            return As_Bidding_Approval_DAL.updateVendorBiddingApprovalForm(vendorApproval);
        }

        public static List<SelectionForm> listApprovedZhidingform(string tempVendorID, string factory_Name)
        {
            return As_Bidding_Approval_DAL.listApprovedZhidingform(tempVendorID, factory_Name);
        }

        public static string getFormID(string tempVendorID,string Form_Type_ID, string factory)
        {
            return As_Bidding_Approval_DAL.getFormID(tempVendorID, Form_Type_ID, factory);
        }

        public static As_Bidding_Approval getBiddingForm(string formID)
        {
            return As_Bidding_Approval_DAL.getVendorBiddingApprovalForm(formID);
        }
        public static As_Bidding_Approval getBiddingForm(string formID,int times)
        {
            return As_Bidding_Approval_DAL.getVendorBiddingApprovalForm(formID);
        }

        public static int SubmitOk(string formID)
        {
            return As_Bidding_Approval_DAL.SubmitOk(formID);
        }

        public static List<SelectionForm> listApprovedSelectionform(string tempVendorID, string factory_Name)
        {
            return As_Bidding_Approval_DAL.listApprovedSelectionform(tempVendorID, factory_Name);
        }

        public static string getFilePath(string fileID)
        {
            DataTable table = new DataTable();
            string filePath = "";
            table = File_Transform_DAL.getFilePath(fileID);
            if(table.Rows.Count>0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    filePath = dr["File_Path"].ToString().Trim();
                }
            }
            return filePath;
        }

        public static bool checkBiddingForm(string formID, int flag)
        {
            return As_Bidding_Approval_DAL.checkVendorBiddingApprovalForm(formID,flag);
        }

        public static string getVendorBiddingFormID(string tempVendorID, string form_Type_ID, string factory_Name, int n)
        {
            return As_Bidding_Approval_DAL.getVendorBiddingFormID(tempVendorID, form_Type_ID, factory_Name, n);
        }


        public static List<SelectionForm> listApprovedBiddingform(string tempVendorID, string factory_Name)
        {
            return As_Bidding_Approval_DAL.listApprovedBiddingform(tempVendorID, factory_Name);
        }

        /// <summary>
        /// 获取真正的formTypeID
        /// </summary>
        /// <param name="money"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static string getRealFlag(double money, string promise)
        {
            money /= 10000;
            string fileTypeName = As_Bidding_Approval_DAL.getFileTypeName(money, promise);

            if (fileTypeName == "")
            {
                if (promise.Equals("no"))
                {
                    if (money < 150 && money > 0)
                    {
                        fileTypeName = "bidding form比价资料/会议纪要(非承诺<=RMB1.5M)";
                    }
                    else if (money > 150)
                    {
                        fileTypeName = "bidding form比价资料/ 会议纪要(非承诺 > RMB3M)";
                    }
                }
                else
                {
                    if (money > 0 && money < 60)
                    {
                        fileTypeName = "bidding form比价资料/会议纪要(承诺<=0.6M)";
                    }
                    else if (money > 150)
                    {
                        fileTypeName = "bidding form比价资料/ 会议纪要(承诺 > RMB1.5M)";
                    }
                }
            }

            string formTypeID = As_Bidding_Approval_DAL.getFormTypeID(fileTypeName);

            return formTypeID;
        }
    }
}
