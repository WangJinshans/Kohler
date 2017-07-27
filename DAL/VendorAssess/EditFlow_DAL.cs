using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data;

namespace DAL.VendorAssess
{
    public class EditFlow_DAL
    {
        public static int checkFormEditFlow(string formID)
        {
            string sql = "select * from As_Form_EditFlow where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            return 0;
        }

        public static As_Edit_Flow getEditFlow(string fORM_TYPE_ID)
        {
            string sql = "select * from As_Edit_Flow where Form_Type_ID=@Form_Type_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_Type_ID",fORM_TYPE_ID)
            };
            DataTable tb = DBHelp.GetDataSet(sql, sp);
            if (tb.Rows.Count > 0)
            {
                As_Edit_Flow editFlow = new As_Edit_Flow();
                foreach (DataRow item in tb.Rows)
                {
                    editFlow.Form_Type_ID = item["Form_Type_ID"].ToString();
                    editFlow.Edit_One_Department = item["Edit_One_Department"].ToString();
                    editFlow.Edit_Two_Department = item["Edit_Two_Department"].ToString();
                    editFlow.Edit_Three_Department = item["Edit_Three_Department"].ToString();
                    editFlow.Multi_Edit = Convert.ToInt32(item["Multi_Edit"]);
                }
                return editFlow;
            }
            return null;
        }


        public static int addFormEditFlow(As_Form_EditFlow formEditFlow)
        {
            string sql = "insert into As_Form_EditFlow(Form_ID, One, Two, Three, Multi_Edit, Temp_Vendor_ID, Factory_Name) VALUES (@Form_ID,@One,@Two,@Three,@Multi_Edit,@Temp_Vendor_ID,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formEditFlow.Form_ID),
                new SqlParameter("@One",formEditFlow.One),
                new SqlParameter("@Two",formEditFlow.Two),
                new SqlParameter("@Three",formEditFlow.Three),
                new SqlParameter("@Multi_Edit",formEditFlow.Multi_Edit),
                new SqlParameter("@Temp_Vendor_ID",formEditFlow.Temp_Vendor_ID),
                new SqlParameter("@Factory_Name",formEditFlow.Factory_Name)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }
    }
}
