using DAL.QualityDetection;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class SelectLab_BLL
    {

        /// <summary>
        /// 获取当前厂的所有实验主管的信息
        /// </summary>
        /// <returns></returns>
        public static List<As_Employee> getAllReseracher(string factory_Name)
        {
            return SelectLab_DAL.getAllReseracher(factory_Name);
        }
    }
}
