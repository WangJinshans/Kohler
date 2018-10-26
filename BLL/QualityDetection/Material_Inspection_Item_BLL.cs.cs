using DAL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static bool IsOld(string SKU)
        {
            return Material_Inspection_Item_DAL.IsOld(SKU);
        }

        public static List<string> getSKUList()
        {
            return Material_Inspection_Item_DAL.getSKUList();
        }
        public static DataTable getSKUTable(string sku)
        {
            return Material_Inspection_Item_DAL.getSKUTable(sku);
        }

        /// <summary>
        /// 表面检验 
        /// </summary>
        /// <param name="SKU"></param>
        /// <returns></returns>
        public static string getSurfaceClassLeval(string SKU)
        {
            return Material_Inspection_Item_DAL.getSurfaceClassLeval(SKU);
        }

        /// <summary>
        /// 适配性检验
        /// </summary>
        /// <param name="SKU"></param>
        /// <returns></returns>
        public static string getSuitabilityClassLeval(string SKU)
        {
            return Material_Inspection_Item_DAL.getSuitabilityClassLeval(SKU);
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
