using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AssessFlow_BLL
    {
        public static As_Assess_Flow getFirstAssessFlow(string formtypeid)
        {
            return AssessFlow_DAL.getFirstAssessFlow(formtypeid);
        }
        public static int addFormAssessFlow(As_Form_AssessFlow Form_AssessFlow)
        {
            return AssessFlow_DAL.addFormAssessFlow(Form_AssessFlow);
        }
        public static int addApprove(As_Approve approve)
        {
            return AssessFlow_DAL.addApprove(approve);
        }
        public static IList<As_Approve> listApprove(string sql)
        {
            return AssessFlow_DAL.listApprove(sql);
        }
        public static int updateApprove(string formid,string positionname)//更新供应商信息
        {
            return AssessFlow_DAL.updateApprove(formid,positionname);
        }
        public static int updateApproveFail(string formid, string positionname)//更新供应商信息
        {
            return AssessFlow_DAL.updateApproveFail(formid, positionname);
        }
    }
}
