﻿using DAL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class MBR_BLL
    {

        /// <summary>
        ///  需要MBR
        ///  将记录添加到 QT_MBR_Results 
        /// </summary>
        /// <param name="form_ID"></param>
        public static void startMBR(string form_ID,string KCI)
        {
            MBR_DAL.startMBR(form_ID, KCI);
        }

        public static List<QT_Goods_Returned> getGoodReturnedList(string factory_Name,string status)
        {
            return MBR_DAL.getGoodReturnedList(factory_Name, status);
        }

        /// <summary>
        /// 根据form_ID 判断每一份需要MBR的报告 各个经理是否达成一致 KCI的区分已经在数据库中区分
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static bool isMeetAgrement(string form_ID)
        {
            return MBR_DAL.isMeetAgrement_NotKCI(form_ID);
        }


        /// <summary>
        /// 更新MBR的状态
        /// </summary>
        /// <param name="form_ID"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static int updateMBRState(string form_ID, string state)
        {
            return MBR_DAL.updateMBRState(form_ID, state);
        }


        /// <summary>
        /// 设置MBR的最终结果
        /// </summary>
        /// <param name="form_ID"></param>
        /// <param name="result"></param>
        public static int setMBRResult(string form_ID, string result)
        {
            return MBR_DAL.setMBRResult(form_ID, result);
        }

        /// <summary>
        /// 获取MBR的结果
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static string getMBRResult(string form_ID)
        {
            return MBR_DAL.getMBRResult(form_ID);
        }

        public static MBRSingleChoice getEveryOneChoice(string form_ID)
        {
            return MBR_DAL.getEveryOneChoice(form_ID);
        }

        /// <summary>
        /// 查询是否需要MBR
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static bool isMBRNeeded(string form_ID)
        {
            return MBR_DAL.isMBRNeeded(form_ID);
        }

        /// <summary>
        /// 查询MBR是否已经完成
        /// </summary>
        /// <param name="form_ID"></param>
        /// <returns></returns>
        public static bool isMBRFinished(string form_ID)
        {
            return MBR_DAL.isMBRFinished(form_ID);
        }
        /// <summary>
        /// 获取当前职位的MRB记录中的所有项  职位与数据库中的字段 不符合 返回 null
        /// </summary>
        /// <param name="position_Name"></param>
        /// <returns></returns>
        public static List<MBR_Item> getMBRList(string position_Name)
        {
            string position_Field = getFieldName(position_Name);
            if (position_Field.Equals(""))
            {
                return null;
            }
            return MBR_DAL.getMBRList(position_Field);
        }

        private static string getFieldName(string position_Name)
        {
            if (position_Name.Equals("采购部经理")|| position_Name.Equals("供应链经理"))
            {
                return "Purchase_Manager";
            }
            else if (position_Name.Equals("物流部经理"))
            {
                return "Logistics_Manager";
            }
            else if (position_Name.Equals("生产部经理"))
            {
                return "Product_Manager";
            }
            else if (position_Name.Equals("市场部经理"))
            {
                return "Market_Manager";
            }
            else if (position_Name.Equals("项目部经理"))
            {
                return "Project_Manager";
            }
            else if (position_Name.Equals("质量部经理"))
            {
                return "Quiltty_Manager";
            }
            else if (position_Name.Equals("总经理"))
            {
                return "General_Manager";
            }
            else if (position_Name.Equals("总监"))
            {
                return "Chief_Manager";
            }
            return "";
        }

        public static void makeChoice(string choice, string reason, string position_Name,string form_ID)
        {
            string position_Field = getFieldName(position_Name);
            string position_Reason_Field = getFieldReasonName(position_Name);
            if (position_Field.Equals(""))
            {
                return;
            }
            MBR_DAL.makeChoice(choice, reason, position_Field, position_Reason_Field, form_ID);
        }

        private static string getFieldReasonName(string position_Name)
        {
            if (position_Name.Equals("采购部经理")|| position_Name.Equals("供应链经理"))
            {
                return "Purchase_Reason";
            }
            else if (position_Name.Equals("物流部经理"))
            {
                return "Logistics_Reason";
            }
            else if (position_Name.Equals("生产部经理"))
            {
                return "Product_Reason";
            }
            else if (position_Name.Equals("市场部经理"))
            {
                return "Market_Reason";
            }
            else if (position_Name.Equals("项目部经理"))
            {
                return "Project_Reason";
            }
            else if (position_Name.Equals("质量部经理"))
            {
                return "Quiltty_Reason";
            }
            else if (position_Name.Equals("总经理"))
            {
                return "General_Reason";
            }
            else if (position_Name.Equals("总监"))
            {
                return "Chief_Reason";
            }
            return "";
        }
    }
}
