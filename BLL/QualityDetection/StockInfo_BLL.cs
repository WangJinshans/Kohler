using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.QualityDetection;
using DAL.QualityDetection;

namespace BLL.QualityDetection
{
    public class StockInfo_BLL
    {
        /// <summary>
        /// 添加到进货信息库
        /// </summary>
        /// <param name="info"></param>
        public static int addStockInfo(StockInfo info)
        {
            return StockInfo_DAL.addStockInfo(info);
        }
    }
}
