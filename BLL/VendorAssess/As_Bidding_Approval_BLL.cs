using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
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

        public static string getFormID(string tempVendorID,string form_name,string factory)
        {
            return As_Bidding_Approval_DAL.getFormID(tempVendorID, form_name, factory);
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
    }
}
