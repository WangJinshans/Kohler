using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAL.VendorAssess;
using DAL;
using Model;

namespace BLL.VendorAssess
{
    public class ApprovalProgress_BLL
    {
        /// <summary>
        /// 此功能暂时无法使用
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone();  // 复制DataRow的表结构
            foreach (DataRow row in rows)
                tmp.Rows.Add(row);  // 将DataRow添加到DataTable中
            return tmp;
        }

        /// <summary>
        /// 读取审批失败相关信息
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static string readFormExceptionInfo(string formID)
        {
            string result = "";
            if (formID.Equals("") || formID == null)
            {
                return result;
            }
            DataTable dt = Write_DAL.getHistory(new string[] { As_Write.APPROVE_FAIL,As_Write.MAIL_ERROR,As_Write.FIND_NEXT_APPROVE_FAIL }, formID, true);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    result += item["Manul"];
                    result += "<br/>";
                }
            }
            return result;
        }

        /// <summary>
        /// 读取审批成功相关信息
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static string readFormNormalInfo(string formID)
        {
            string result = "";
            if (formID.Equals("") || formID==null)
            {
                return result;
            }
            DataTable dt = Write_DAL.getHistory(new string[] { As_Write.APPROVE_SUCCESS,As_Write.FORM_EDIT,As_Write.FORM_MULTI_EDIT,As_Write.FIND_NEXT_APPROVE_FAIL }, formID, true);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    result += item["Manul"];
                    result += "<br/>";
                }
            }
            return result;
        }
    }
}