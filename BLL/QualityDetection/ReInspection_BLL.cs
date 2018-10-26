using DAL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class ReInspection_BLL
    {

        /// <summary>
        /// 添加到复检记录中
        /// </summary>
        /// <param name="form_ID"></param>
        /// <param name="new_Form_ID"></param>
        /// <returns></returns>
        public static int addReInspection(string new_Form_ID, string form_ID,string batch_No)
        {
            return ReInspection_DAL.addReInspection(new_Form_ID, form_ID, batch_No);
        }

        public static int addReInspectionServeyReport(string batch_No)
        {
            return ReInspection_DAL.addReInspectionServeyReport(batch_No);
        }

        public static string getReInspectionSurveyFormID(string batch_No, int n)
        {
            return ReInspection_DAL.getReInspectionSurveyFormID(batch_No, n);
        }


        /// <summary>
        /// 查询是否属于复检表
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static bool isReInspection(string form_ID)
        {
            return ReInspection_DAL.isReInspection(form_ID);
        }


        /// <summary>
        /// 查询是否需要复检 属于委托检验
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static bool isReInspectionNeeded(string form_ID)
        {
            return ReInspection_DAL.isReInspectionNeeded(form_ID);
        }
    }
}
