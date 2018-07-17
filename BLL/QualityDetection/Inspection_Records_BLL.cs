using DAL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    /// <summary>
    /// 供应商的历史送货记录 
    /// </summary>
    public class Inspection_Records_BLL
    {
        /// <summary>
        /// 查询该供应商是否有历史送货记录
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <returns></returns>
        public static bool hadRecords(string vendor_Code)
        {
            return Inspection_Records_DAL.hadRecords(vendor_Code);
        }
    }
}
