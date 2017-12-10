using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddForm_DAL
    {
        public static int addForm(As_Form form)
        {
            string sql = "INSERT INTO As_Form(Form_ID,Form_Type_Name,Form_Path,Form_Type_ID,Temp_Vendor_Name,Temp_Vendor_ID,Factory_Name) VALUES(@Form_ID,@Form_Type_Name,@Form_Path,@Form_Type_ID,@Temp_Vendor_Name,@Temp_Vendor_ID,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",form.Form_ID),
                new SqlParameter("Form_Type_Name",form.Form_Type_Name),
                new SqlParameter("Form_Path",form.Form_Path),
                new SqlParameter("Form_Type_ID",form.Form_Type_ID),
                new SqlParameter("Temp_Vendor_Name",form.Temp_Vendor_Name),
                new SqlParameter("Temp_Vendor_ID",form.Temp_Vendor_ID),
                new SqlParameter("Factory_Name",form.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static string GetTempVendorID(string formID)
        {
            string sql = "select Temp_Vendor_ID from As_Form where Form_ID='" + formID + "'";
            DataTable dt = new DataTable();
            string vendorID = "";
            dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                vendorID = dt.Rows[0]["Temp_Vendor_ID"].ToString().Trim();
                return vendorID;
            }
            return vendorID;
        }

        public static DataTable getFactoryByFormID(string sql)
        {
            return DBHelp.GetDataSet(sql);
        }

        public static int upDateFormPath(string sql)
        {
            return DBHelp.ExecuteCommand(sql);
        }


        /// <summary>
        /// 在As_Form中获取对应的formID的表的存储路径
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string getFormPathByFormID(string sql)
        {
            DataTable table = DBHelp.GetDataSet(sql);
            string formPath = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formPath = dr["Form_Path"].ToString().Trim();
                }
            }
            return formPath;
        }

        public static bool deleteForm(string formID)
        {
            string sql = "delete from As_Form where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",formID)
               
            };
            if (DBHelp.ExecuteCommand(sql, sp)>0)
            {
                return true;
            }
            return false;
        }

        public static string GetVendorName(string formID)
        {
            string sql = "select Temp_Vendor_Name from As_Form where Form_ID='" + formID + "'";
            DataTable dt = new DataTable();
            dt = DBHelp.GetDataSet(sql);
            string vendorname = dt.Rows[0]["Temp_Vendor_Name"].ToString().Trim();
            return vendorname;
        }

        public static string GetForm_Type_ID(string formID)
        {
            string sql = "select Form_Type_ID from View_Vendor_FormType where Form_ID='" + formID + "'";
            DataTable dt = new DataTable();
            dt = DBHelp.GetDataSet(sql);
            string formid = dt.Rows[0]["Form_Type_ID"].ToString().Trim();
            return formid;
        }
    }
}
