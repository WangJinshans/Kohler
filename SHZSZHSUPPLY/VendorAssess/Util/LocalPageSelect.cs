using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class LocalPageSelect
    {
        public static string switchFormID(string formID)//未完待续。。。
        {
            string table = "";
            if (formID.Contains("ContractApproval"))
            {
                table = "As_Contract_Approval";
            }
            else if (formID.Contains("VendorExtend"))
            {
                table = "As_Vendor_Extend";
            }
            else if (formID.Contains("VendorBlock"))
            {
                table = "As_Vendor_Block_Or_UnBlock";
            }
            else if (formID.Contains("VendorCreation"))
            {
                table = "As_VendorCreation";
            }
            else if (formID.Contains("VendorDesignated"))
            {
                table = "As_Vendor_Designated_Apply";
            }
            else if (formID.Contains("VendorDiscovery"))
            {
                table = "As_Vendor_Discovery";
            }
            else if (formID.Contains("BiddingForm"))
            {
                table = "As_Bidding_Approval_Form";
            }
            else if (formID.Contains("VendorSelection"))
            {
                table = "As_Vendor_Selection";
            }
            else if (formID.Contains("VendorRisk"))
            {
                table = "As_Vendor_Risk";
            }
            return table;
        }
        public static string switchPage(string formID)//未完待续。。。
        {
            string table = "";
            if (formID.Contains("ContractApproval"))
            {
                table = "ShowContractApprovalForm";
            }
            else if (formID.Contains("VendorExtend"))
            {
                table = "ShowVendorExtend";
            }
            else if (formID.Contains("VendorBlock"))
            {
                table = "ShowVendorBlockOrUnBlock";
            }
            else if (formID.Contains("VendorCreation"))
            {
                table = "ShowVendorCreation";
            }
            else if (formID.Contains("VendorDesignated"))
            {
                table = "ShowVendorDesignatedApply";
            }
            else if (formID.Contains("VendorDiscovery"))
            {
                table = "ShowVendorDiscovery";
            }
            else if (formID.Contains("BiddingForm"))
            {
                table = "ShowBiddingApprovalForm";
            }
            else if (formID.Contains("VendorSelection"))
            {
                table = "ShowVendorSelection";
            }
            else if (formID.Contains("VendorRisk"))
            {
                table = "ShowVendorRiskAnalysis";
            }
            return table + ".aspx";
        }
    }
}