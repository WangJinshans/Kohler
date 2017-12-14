using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static IList<As_Approve> listApprove(string sql,string positionName)
        {
            IList<As_Approve> list = AssessFlow_DAL.listApprove(sql);
            if (list.Count>0 && list[0].Position_Name.Equals(positionName))
            {
                return list;
            }
            return null;
        }
        public static int updateApprove(string formid,string positionname)//更新供应商信息
        {
            return AssessFlow_DAL.updateApprove(formid,positionname);
        }
        public static int updateUserDepartmentApprove(string formid, string positionname)//更新供应商信息
        {
            return AssessFlow_DAL.updateUserDepartmentApprove(formid, positionname);
        }
        public static int updateApproveFail(string formid, string positionname)//更新供应商信息
        {
            return AssessFlow_DAL.updateApproveFail(formid, positionname);
        }

        public static As_Form_AssessFlow getFormAssessFlow(string formID)
        {
            return AssessFlow_DAL.getFormAssessFlow(formID);
        }

        public static int deleteFormAccess(string formID)
        {
            return AssessFlow_DAL.deleteFormAccess(formID);
        }

        public static void removeQuality(As_Assess_Flow assess_flow)
        {
            object value = null;
            foreach (PropertyInfo pi in assess_flow.GetType().GetProperties())
            {
                value = pi.GetValue(assess_flow, null);
                if (value is string && ((String)value).Contains("质量"))
                {
                    pi.SetValue(assess_flow, "", null);
                    break;
                }
            }
        }
    }
}
