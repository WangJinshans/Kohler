using System;
using BLL.VendorAssess;
using DAL;
using MODEL;

namespace BLL
{
    public class ContractApproval_BLL
    {

        public static int checkContractApproval(string formID)
        {

            return ContractApproval_DAL.checkContractApproval(formID);
        }

        public static int getContractApprovalFlag(string formID)//获取标志位
        {

            return ContractApproval_DAL.getContractApprovalFlag(formID);
        }

        public static string getFormID(string tempVendorID,string form_Name,string factory)
        {

            return ContractApproval_DAL.getFormID(tempVendorID,form_Name,factory);
        }

        public static int addContractApproval(As_Contract_Approval vendorContract)//添加表
        {

            return ContractApproval_DAL.addContractApproval(vendorContract);
        }

        public static int updateContractApproval(As_Contract_Approval vendorContract)
        {
            return ContractApproval_DAL.updateContractApproval(vendorContract);
        }

        public static As_Contract_Approval getContractApproval(string formID)
        {
            return ContractApproval_DAL.getContractApproval(formID);
        }

        public static int SubmitOk(string formID)
        {
            return ContractApproval_DAL.SubmitOk(formID);
        }
    }
}
