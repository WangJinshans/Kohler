using DAL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class InspectionPlan_BLL
    {

        /// <summary>
        /// 获取抽样码
        /// </summary>
        /// <param name="classLeval"></param>
        /// <param name="amount"></param>
        public static string getSampleCode(string classLeval, string amount)
        {
            return InspectionPlan_DAL.getSampleCode(classLeval, amount);
        }

        /// <summary>
        /// 获取接受数量 拒收数量 以及样本数量
        /// </summary>
        /// <param name="sample_Code">样本码</param>
        /// <param name="aql">AQL等级</param>
        /// <param name="inspection_Leval">检验等级 加严 放宽 正常</param>
        /// <returns></returns>
        public static InspectionPlanResult getInspectionPlanResult(string sample_Code, string aql,string inspection_Leval)
        {
            return InspectionPlan_DAL.getInspectionPlanResult(sample_Code, aql, inspection_Leval);
        }
    }
}
