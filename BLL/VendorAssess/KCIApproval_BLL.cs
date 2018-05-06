using DAL;
using MODEL;
using System.Collections.Generic;
using System.Web;
using System;

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

        public static int rejectKCIApproval(string formID)
        {
            return KCIApproval_DAL.rejectKCIApproval(formID);
        }

        public static int setApprovalFinished(string Form_ID, int approval,string Temp_Vendor_ID)//需要KCI审批的在KCI审批完成之后标志该表的审批完成
        {
            return KCIApproval_DAL.setApprovalFinished(Form_ID, approval, Temp_Vendor_ID,Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static bool isKCIApproveFinished(string formID)
        {
            return KCIApproval_DAL.isKCIApproveFinished(formID);
        }

        public static As_KCI_Approval getKCIApproval(string position)
        {
            return KCIApproval_DAL.getKCIApproval(position);
        }
        public static IList<As_KCI_Approval> selectKCIApproval(string sql,string factory)//获取所有需要KCI审批的列表
        {
            return KCIApproval_DAL.selectKCIApproval(sql,factory);
        }

        public static bool deleteKCIApproval(string formID)
        {
            return KCIApproval_DAL.deleteKCIApproval(formID);
        }

        /// <summary>
        /// 获取KCI文件路径  相对
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static string getKCIApprovalFileID(string formID)
        {
            return KCIApproval_DAL.getKCIApprovalFileID(formID);
        }
    }
}
