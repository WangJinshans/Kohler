using DAL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace BLL.QualityDetection
{
    public class SurveyReport_BLL
    {

        private const int STRICT_INSPECTION = 3;//加严
        private const int LOOSE_INSPECTION = 1;//放宽
        private const int NORMAL_INSPECTION = 2;//正常

        /// <summary>
        /// 检验完成后 设置报告的结果 
        /// </summary>
        /// <param name="onePointFive">AQL1.5的检验结果</param>
        /// <param name="twoPointFive">AQL2.5的检验结果</param>
        public static void setInspectResult(string onePointFive, string twoPointFive, string batch_No)
        {
            SurveyReport_DAL.setInspectResult(onePointFive, twoPointFive, batch_No);
        }

        public static DataTable getInspectionAndDatas(string form_ID)
        {
            return SurveyReport_DAL.getInspectionAndDatas(form_ID);
        }

        public static QT_Survey getSurveyReport(string form_ID)
        {
            return SurveyReport_DAL.getSurveyReport(form_ID);
        }

        /// <summary>
        /// 获取检验方式 加严 放宽  正常
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <param name="batch_No"></param>
        /// <returns></returns>
        public static int getInspectionMethod(string vendor_Code, string SKU)
        {
            //查询SKU 如果是新的SKU 则默认正常检验
            bool isNewSKU = false;
            isNewSKU = SurveyReport_DAL.isNewSKU(SKU);

            //新物料 第一次 默认正常检验
            if (isNewSKU)
            {
                return NORMAL_INSPECTION;
            }
            else
            {
                //加严成立
                if (beStrict(vendor_Code))
                {
                    return STRICT_INSPECTION;
                }
                else if (beLoose(vendor_Code))//放宽成立
                {
                    return LOOSE_INSPECTION;
                }
                else
                {
                    return NORMAL_INSPECTION;
                }
            }
        }

        /// <summary>
        /// 获取检验结果
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static DataTable showInspectionResults(string form_ID)
        {
            return SurveyReport_DAL.showInspectionResults(form_ID);
        }

        private static bool beStrict(string vendor_Code)
        {
            //连续两批 不可接收  加严
            bool strict = false;
            strict = SurveyReport_DAL.StrictAvaliable(vendor_Code);
            return strict;
        }


        private static bool beLoose(string vendor_Code)
        {
            //连续十批AQL1.5 可接收  放宽
            bool loose = false;
            loose = SurveyReport_DAL.LooseAvaliable(vendor_Code);
            return loose;
        }

        public static string getReportBatchNo(string form_ID)
        {
            return SurveyReport_DAL.getReportBatchNo(form_ID);
        }


        /// <summary>
        /// 查询该表是否属于KCI 
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static bool isKCINeeded(string form_ID)
        {
            return SurveyReport_DAL.isKCINeeded(form_ID);
        }

        /// <summary>
        /// 获取数据库中对应Form_ID的指定职位的 结果 
        /// 
        /// 用于 MBR 意见不一致的时候 非KCI显示 总经理的 结果   KCI显示总监的 结果
        /// </summary>
        /// <param name="position_Name"></param>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static string getDecision(string position_Name,string form_ID)
        {
            return SurveyReport_DAL.getDecision(position_Name, form_ID);
        }

     

        /// <summary>
        /// 该报告已经完成
        /// </summary>
        /// <param name="form_ID"></param>
        public static void setFinished(string form_ID)
        {
            SurveyReport_DAL.setFinished(form_ID);
        }

        /// <summary>
        /// 判断是否已经存在该表
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static int checkServeyReport(string form_ID)
        {
            return SurveyReport_DAL.checkServeyReport(form_ID);
        }


        /// <summary>
        /// 插入新纪录
        /// </summary>
        /// <param name="batch_No"></param>
        /// <returns></returns>
        public static int addServeyReport(string batch_No, string vendor_Code)
        {
            return SurveyReport_DAL.addServeyReport(batch_No, vendor_Code);
        }

        /// <summary>
        /// 获取Form_ID
        /// </summary>
        /// <param name="batch_No"></param>
        /// <returns></returns>
        public static string getReportFormID(string batch_No)
        {
            return SurveyReport_DAL.getReportFormID(batch_No);
        }

        public static bool isReInspection(string form_ID)
        {
            return SurveyReport_DAL.isReInspection(form_ID);
        }


        /// <summary>
        /// 复检的时候更新form_ID
        /// </summary>
        /// <param name="batch_No"></param>
        /// <param name="newFormID"></param>
        /// <returns></returns>
        public static int upDateFormID(string batch_No, string newFormID)
        {
            return SurveyReport_DAL.upDateFormID(batch_No, newFormID);
        }


        public static DataTable getInsectionItems(string sku)
        {
            return SurveyReport_DAL.getInsectionItems(sku);
        }

        public static void saveInspectionValue(string sku, string form_ID, List<string> values)
        {
            if (values == null && values.Count <= 0)
            {
                return;
            }
            string[] itmeValue = values.ToArray();

            //通过SKU获取 Item  以及  Standard
            DataTable table = SurveyReport_DAL.getInsectionItems(sku);
            if (table.Rows.Count > 0)
            {
                //先删除所有
                SurveyReport_DAL.deleteAllInspectionValue(form_ID);

                foreach (DataRow dr in table.Rows)
                {
                    int index = table.Rows.IndexOf(dr);
                    int itemNum = index * 2;
                    int standardNum = itemNum + 1;
                    SurveyReport_DAL.addInspectionValue(form_ID, Convert.ToString(dr["Item"]), Convert.ToString(dr["Standard"]), itmeValue[itemNum], itmeValue[standardNum]);
                }
            }   
        }


        /// <summary>
        /// 更新报告
        /// </summary>
        /// <param name="survey"></param>
        public static void updateSurvey(QT_Survey survey)
        {
            SurveyReport_DAL.updateSurvey(survey);
        }

        /// <summary>
        /// 更新该报告的状态
        /// </summary>
        /// <param name="form_ID"></param>
        public static void updateSurveyStatus(string form_ID, string status)
        {
            SurveyReport_DAL.updateSurveyStatus(form_ID, status);
        }



        /// <summary>
        /// 修改检测项
        /// </summary>
        /// <param name="SKU"></param>
        /// <param name="Item"></param>
        /// <param name="Standard"></param>
        /// <param name="IS_First"></param>
        /// <returns></returns>
        public static void updateInspectionItem(string SKU,string Item,string Standard,string IS_First)
        {
            SurveyReport_DAL.updateInspectionItem(SKU, Item, Standard,IS_First);
        }

        public static string getReMark(string formID)
        {
            return SurveyReport_DAL.getReMark(formID);
        }

        public static void alterInspectionItem(string SKU, string Item, string Standard)
        {
            SurveyReport_DAL.alterInspectionItem(SKU, Item, Standard);
        }

        public static int addNewInspectionItem(string SKU, string Item, string Standard, string IS_First)
        {
            return SurveyReport_DAL.addNewInspectionItem(SKU,Item,Standard,IS_First);
        }

        public static void deleteInspectionItem(string SKU,string Item)
        {
             SurveyReport_DAL.deleteInspectionItem(SKU, Item);
        }

        public static bool isNewInspectionItem(string SKU)
        {
            return SurveyReport_DAL.isNewSKU(SKU);
        }

        public static void setAddPermission(string permission,string form_ID)
        {
            SurveyReport_DAL.setAddPermission(permission, form_ID);
        }


        public static bool haveInspectionItem(string SKU,string Item)
        {
            return SurveyReport_DAL.haveInsectionItem(SKU, Item);
        }

        public static string getAddPermission(string form_ID)
        {
            return SurveyReport_DAL.getAddPermission(form_ID);
        }

        /// <summary>
        /// 复检更新form_ID的时候 复制添加权限
        /// </summary>
        /// <param name="form_ID"></param>
        /// <param name="newFormID"></param>
        public static void updateAddPermission(string form_ID, string newFormID)
        {
            SurveyReport_DAL.updateAddPermission(form_ID, newFormID);
        }
        public static DataTable getSKUList()
        {
            return SurveyReport_DAL.getSKUList();
        }
    }
}
