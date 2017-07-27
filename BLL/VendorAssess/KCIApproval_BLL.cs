using DAL;
using MODEL;
using System.Collections.Generic;

namespace BLL.VendorAssess
{
    public class KCIApproval_BLL
    {
        public static int addKCIApproval(As_KCI_Approval kciApproval)//是KCI审批 则需要在插入到该表
        {
            return KCIApproval_DAL.addKCIApproval(kciApproval);
        }

        public static int updateKCIApproval(string Form_ID,int approval)//在KCI界面进行的操作
        {
            return KCIApproval_DAL.updateKCIApproval(Form_ID, approval);
        }


        public static int setApprovalFinished(string Form_ID, int approval,string Temp_Vendor_ID)//需要KCI审批的在KCI审批完成之后标志该表的审批完成
        {
            return KCIApproval_DAL.setApprovalFinished(Form_ID, approval, Temp_Vendor_ID);
        }

        public static As_KCI_Approval getKCIApproval(string position)
        {
            return KCIApproval_DAL.getKCIApproval(position);
        }
        public static IList<As_KCI_Approval> selectKCIApproval(string sql)//获取所有需要KCI审批的列表
        {
            return KCIApproval_DAL.selectKCIApproval(sql);
        }
    }
}
