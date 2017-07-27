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

        public static int updateBiddingForm(As_Bidding_Approval vendorApproval)
        {
            return As_Bidding_Approval_DAL.updateVendorBiddingApprovalForm(vendorApproval);
        }

        public static string getFormID(string tempVendorID)
        {
            return As_Bidding_Approval_DAL.getFormID(tempVendorID);
        }

        public static As_Bidding_Approval getBiddingForm(string formID)
        {
            return As_Bidding_Approval_DAL.getVendorBiddingApprovalForm(formID);
        }
    }
}
