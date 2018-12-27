using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.QualityDetection;
using MODEL.QualityDetection;
using System.Data;
using System.Data.SqlClient;

namespace BLL.QualityDetection
{
    public class ComponentList_BLL
    {
        //判断是否有对应的SKU然后进行查询
        public static bool hasSKU(string sku)
        {
            return ComponentList_DAL.hasSKU(sku);
        }

        //更新对应SKU的Component信息
        public static void updateComponent(string sku, QT_Component_List item)
        {
            ComponentList_DAL.updateComponent(sku,item);
        }

        //手动添加Component信息
        public static bool addComponent(QT_Component_List item)
        {
            return ComponentList_DAL.addComponent(item);
        }

        //根据SKU查询信息
        public static DataTable selectComponentBySKU(string SKU)
        {
            return ComponentList_DAL.selectComponentBySKU(SKU);
        }

        
    }
}
