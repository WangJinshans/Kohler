using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class KCIApproval_DAL
    {
        public static int addKCIApproval(As_KCI_Approval kciApproval)//是KCI审批 则需要在插入到该表
        {
            string sql = "insert into As_KCI_Approval(Temp_Vendor_ID,Form_ID,Position_Name) values(@Temp_Vendor_ID,@Form_ID,@Position_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",kciApproval.Temp_Vendor_ID),
                new SqlParameter("@Form_ID",kciApproval.Form_ID),
                new SqlParameter("@Position_Name",kciApproval.Position_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static int updateKCIApproval(string Form_ID, int approval)//在KCI界面进行的操作
        {
            string sql = "update As_KCI_Approval SET Flag=@Flag where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Flag",approval),
                new SqlParameter("@Form_ID",Form_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static bool deleteKCIApproval(string formID)
        {
            string sql = "delete from As_KCI_Approval where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            if (DBHelp.ExecuteCommand(sql,sp)>0)
            {
                return true;
            }
            return false;
        }

        public static int rejectKCIApproval(string Form_ID)//在KCI界面进行的操作
        {
            string sql = "delete from As_KCI_Approval where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",Form_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }


        public static int setApprovalFinished(string Form_Type_ID, int approval,string Temp_Vendor_ID,string factoryName)//需要KCI审批的在KCI审批完成之后标志该表的审批完成
        {
            string sql = "update As_Vendor_FormType SET flag=@flag where Form_Type_ID=@Form_Type_ID and Temp_Vendor_ID=@Temp_Vendor_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@flag",approval),
                new SqlParameter("@Form_Type_ID",Form_Type_ID),//As_Vendor_FormType中通过Form_Type_ID 和TempVendorID来唯一确认
                new SqlParameter("@Temp_Vendor_ID",Temp_Vendor_ID),
                new SqlParameter("@Factory_Name",factoryName)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static As_KCI_Approval getKCIApproval(string position)//获取没有处理过的KCI结果
        {
            As_KCI_Approval kciApproval = null;
            string sql = "select * from As_KCI_Approval where Position=@Position and Flag=@Flag";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Position", position),
                new SqlParameter("@Flag", 0)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                kciApproval = new As_KCI_Approval();
                foreach (DataRow item in dt.Rows)
                {
                    kciApproval.Form_ID = item["Form_ID"].ToString().Trim();
                    kciApproval.Flag = Convert.ToInt32(item["Flag"].ToString().Trim());
                    kciApproval.Temp_Vendor_ID = item["Temp_Vendor_ID"].ToString().Trim();
                    kciApproval.Position_Name = item["Position_Name"].ToString().Trim();
                }
                return kciApproval;
            }
            else
            {
                return null;//返回空
            }
        }
        public static IList<As_KCI_Approval> selectKCIApproval(string sql)
        {
            IList<As_KCI_Approval> list = new List<As_KCI_Approval>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_KCI_Approval kciApproval = new As_KCI_Approval();
                    kciApproval.Form_ID = dr["Form_ID"].ToString().Trim();
                    kciApproval.Flag = Convert.ToInt32(dr["Flag"].ToString().Trim());
                    kciApproval.Temp_Vendor_ID = dr["Temp_Vendor_ID"].ToString().Trim();
                    kciApproval.Position_Name = dr["Position_Name"].ToString().Trim();
                    list.Add(kciApproval);
                }

            }
            return list;
        }
    }
}
