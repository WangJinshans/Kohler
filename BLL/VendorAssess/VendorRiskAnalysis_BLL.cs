using DAL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class VendorRiskAnalysis_BLL
    {
        /// <summary>
        /// 添加风险分析表
        /// </summary>
        /// <param name="vendorRisk"></param>
        /// <returns></returns>
        public static int addVendorRisk(As_Vendor_Risk vendorRisk)
        {
            return VendorRiskAnalysis_DAL.addVendorRisk(vendorRisk);
        }

        /// <summary>
        /// 检查是否有记录
        /// </summary>
        /// <param name="FormId"></param>
        /// <returns></returns>
        public static int checkVendorRiskAnalysis(string FormId)
        {
            return VendorRiskAnalysis_DAL.checkVendorRiskAnalysis(FormId);
        }

        /// <summary>
        /// get edit flag
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static As_Vendor_Risk checkFlag(string formID)
        {
            int flag = VendorRiskAnalysis_DAL.getVendorRiskAnalysisFlag(formID);
            if (flag == 1)
            {
                return VendorRiskAnalysis_DAL.getVendorRiskAnalysis(formID);
            }
            return null;
        }

        /// <summary>
        /// update risk table
        /// </summary>
        /// <param name="vendorRisk"></param>
        /// <returns></returns>
        public static int updateVendorRisk(As_Vendor_Risk vendorRisk)
        {
            return VendorRiskAnalysis_DAL.updateVendorRisk(vendorRisk);
        }
    }
}
