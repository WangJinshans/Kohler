using DAL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class RepertoryInspection_BLL
    {
        /// <summary>
        /// 添加检验
        /// </summary>
        /// <param name="inspection"></param>
        /// <returns></returns>
        public static int addRepertoryInspection(QT_RepertoryInspection inspection)
        {
            return RepertoryInspection_DAL.addRepertoryInspection(inspection);
        }

        public static void updateRepertoryInspection(string batch_No)
        {
            RepertoryInspection_DAL.updateRepertoryInspection(batch_No);
        }


        /// <summary>
        /// copy检验 并设置检验为未完成 退货检验 
        /// </summary>
        /// <param name="batch_No"></param>
        public static void copyInspection(string batch_No)
        {
            RepertoryInspection_DAL.copyInspection(batch_No);
        }

        public static DataTable getRepertoryInspection()
        {
            return RepertoryInspection_DAL.getRepertoryInspection();
        }

        public static int checkRepertoryInspection(string batch_No)
        {
            return RepertoryInspection_DAL.checkRepertoryInspection(batch_No);
        }
    }
}
