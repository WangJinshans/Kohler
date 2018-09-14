using DAL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class GoodsReturned_BLL
    {
        public static int addGoodReturned(QT_Goods_Returned good)
        {
            return GoodsReturned_DAL.addGoodReturned(good);
        }

        public static int deleteGoodReturned(string batch_No)
        {
            return GoodsReturned_DAL.deleteGoodReturned(batch_No);
        }
    }
}
