using DAL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using BLL.VendorAssess;

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
            //int flag = VendorRiskAnalysis_DAL.getVendorRiskAnalysisFlag(formID);
            //if (flag == 1)
            //{
            //    return VendorRiskAnalysis_DAL.getVendorRiskAnalysis(formID);
            //}
            return VendorRiskAnalysis_DAL.getVendorRiskAnalysis(formID);
        }

        /// <summary>
        /// update risk table
        /// </summary>
        /// <param name="vendorRisk"></param>
        /// <returns></returns>
        public static int updateVendorRisk(As_Vendor_Risk vendorRisk,IList<As_Vendor_Risk_Notes> list)
        {
            return VendorRiskAnalysis_DAL.updateVendorRisk(vendorRisk,list);
        }

        public static string getFormID(string tempVendorID,string formTypeID,string factory)
        {
            return VendorRiskAnalysis_DAL.getFormID(tempVendorID, formTypeID, factory);
        }

        public static Dictionary<string, string> checkNotes(string formID)
        {
            List<As_Vendor_Risk_Notes> list = Vendor_Risk_Analysis_Notes_DAL.getNotes(formID);
            Dictionary<string, string> dc = new Dictionary<string, string>();
            foreach (As_Vendor_Risk_Notes item in list)
            {
                dc.Add(item.Property_Name, item.Notes);
            }
            return dc;
        }

        public static int SubmitOk(string formID)
        {
            return VendorRiskAnalysis_DAL.SubmitOk(formID);
        }
    }
}
