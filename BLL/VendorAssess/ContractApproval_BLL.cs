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

        public static string getFormID(string tempVendorID,string Form_Type_ID, string factory)
        {

            return ContractApproval_DAL.getFormID(tempVendorID, Form_Type_ID, factory);
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

        public static bool isKCIOK(string formID)
        {
            return ContractApproval_DAL.isKCIOK(formID);
        }

        public static string getVendorContractApprovalFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            return ContractApproval_DAL.getVendorContractApprovalFormID(tempVendorID, fORM_TYPE_ID, factory, n);
        }

        public static string getRealFlag(double money, string isPromise)
        {
            money /= 10000;
            string fileTypeName = ContractApproval_DAL.getFileTypeName(money, isPromise);

            if (fileTypeName == "")
            {
                if (isPromise.Equals("no"))
                {
                    if (money > 0 && money < 300)
                    {
                        fileTypeName = "合同审批表(非承诺<=RMB3M)";
                    }
                }
                else
                {
                    if (money > 1500)
                    {
                        fileTypeName = "合同审批表(承诺RMB>15M)";
                    }
                }
            }

            string formTypeID = ContractApproval_DAL.getFormTypeID(fileTypeName);

            return formTypeID;
        }
    }
}
