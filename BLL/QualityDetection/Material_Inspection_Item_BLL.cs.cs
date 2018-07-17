using DAL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class Material_Inspection_Item_BLL
    {


        /// <summary>
        /// 所有物料第一次检验默认正常检验 已经生成了检验标准
        /// </summary>
        /// <param name="SKU"></param>
        /// <returns></returns>
        public static int setOld(string SKU)
        {
            return Material_Inspection_Item_DAL.setOld(SKU);
        }


        /// <summary>
        /// 获取当前物料的检验水平 一般 OR 特殊 
        /// </summary>
        /// <param name="SKU"></param>
        /// <returns></returns>
        public static string getClassLeval(string SKU)
        {
            return Material_Inspection_Item_DAL.getClassLeval(SKU);
        }

        /// <summary>
        /// 更具物料编号获取 AQL值
        /// </summary>
        /// <param name="SKU"></param>
        /// <returns></returns>
        public static string getAQL(string SKU)
        {
            return Material_Inspection_Item_DAL.getAQL(SKU);
        }

        /// <summary>
        /// 获取KCI
        /// </summary>
        /// <param name="SKU"></param>
        /// <returns></returns>
        public static string getKCI(string SKU)
        {
            return Material_Inspection_Item_DAL.getKCI(SKU);
        }
    }
}
