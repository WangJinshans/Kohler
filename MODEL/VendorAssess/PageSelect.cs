using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public static class PageSelect
    {
        public static Dictionary<string, string> dcEditToShow = new Dictionary<string, string>();

        static PageSelect()
        {
            initEditToShow();
        }


        private static void initEditToShow()
        {
            dcEditToShow.Clear();
            dcEditToShow.Add("001", "VendorDiscovery.aspx");
            dcEditToShow.Add("002", "BiddingApprovalform.aspx");
            dcEditToShow.Add("003", "VendorRiskAnalysis.aspx");
            dcEditToShow.Add("004", "VendorDesignatedApply.aspx");
            dcEditToShow.Add("005", "ContractApprovalForm.aspx");
            dcEditToShow.Add("006", "ContractApprovalForm.aspx");
            dcEditToShow.Add("007", "ContractApprovalForm.aspx");
            dcEditToShow.Add("008", "ContractApprovalForm.aspx");
            dcEditToShow.Add("009", "ContractApprovalForm.aspx");
            dcEditToShow.Add("010", "ContractApprovalForm.aspx");
            dcEditToShow.Add("011", "ContractApprovalForm.aspx");
            dcEditToShow.Add("012", "ContractApprovalForm.aspx");
            dcEditToShow.Add("013", "BiddingApprovalform.aspx");
            dcEditToShow.Add("014", "BiddingApprovalform.aspx");
            dcEditToShow.Add("015", "BiddingApprovalform.aspx");
            dcEditToShow.Add("016", "BiddingApprovalform.aspx");
            dcEditToShow.Add("017", "BiddingApprovalform.aspx");
            dcEditToShow.Add("018", "VendorSelection.aspx");
            dcEditToShow.Add("019", "VendorCreation.aspx");
            dcEditToShow.Add("020", "VendorModify.aspx");
            dcEditToShow.Add("025", "VendorDesignatedApply.aspx");
        }
    }
}
