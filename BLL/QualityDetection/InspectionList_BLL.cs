using DAL;
using DAL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL.QualityDetection
{
    public class InspectionList_BLL
    {
        /// <summary>
        /// 开始进行委托检验 type判断不同的实验室  插入委托检验记录表
        /// Go默认值 YES 默认检验员自己检验
        /// 
        /// 
        /// 发送委托检验单 给实验室  同时将该条记录的处理权限给质量部文员
        /// </summary>
        /// <param name="batch_NO"></param>
        /// <param name="employeeID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool startWT(string batch_NO,string employeeID,string type)
        {
            string go = "NO";
            string to = "";

            bool ok = false;
            if (type.Contains("铸铁"))
            {
                to = "铸铁";
            }
            else
            {
                to = "亚克力";
            }
            string sql = "update QT_Inspection_List set Go=@Go,[To]=@To where Batch_No=@Batch_No";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Go",go),
                new SqlParameter("@To",to),
                new SqlParameter("@Batch_No",batch_NO)
            };

            int n = DBHelp.ExecuteCommand(sql, sp);
            if (n == 1)
            {
                //插入 待机物料记录表
                return true;
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        public static int LockItem(string batch_no,string employee_ID)
        {
            return InspectionList_DAL.LockItem(batch_no,employee_ID);
        }

        /// <summary>
        /// 判断是否已经锁定该批次
        /// </summary>
        /// <param name="batch_no"></param>
        /// <returns></returns>
        public static string isLocked(string batch_no)
        {
            return InspectionList_DAL.isLocked(batch_no);
        }

        public static int updateFormID(string batch_no,string form_ID)
        {
            return InspectionList_DAL.updateFormID(batch_no, form_ID);
        }

        public static int updateChargeMan(string batch_no,string clerk)
        {
            return InspectionList_DAL.updateChargeMan(batch_no, clerk);
        }


		/// <summary>
		///按照添加时间来进行数据的查询
		/// </summary>
		/// <param name="addtime"></param>
		/// <returns></returns>
		public static DataTable selectListItem(string addtime)          
		{
			return InspectionList_DAL.selectListItem(addtime);
		}

		public static void selectListItem1(string addtime)
		{
			InspectionList_DAL.selectListItem2(addtime);
		}

		

	}
}
