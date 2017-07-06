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
    public class VendorForm_DAL
    {
        public static int addVendorFormType(As_Vendor_FormType Vendor_FormType)
        {
            string sql = "INSERT INTO As_Vendor_FormType(Temp_Vendor_ID,Form_Type_ID,Temp_Vendor_Name,Form_Type_Name)VALUES(@Temp_Vendor_ID,@Form_Type_ID,@Temp_Vendor_Name,@Form_Type_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",Vendor_FormType.Temp_Vendor_ID),
                new SqlParameter("@Form_Type_ID",Vendor_FormType.Form_Type_ID),
                new SqlParameter("@Temp_Vendor_Name",Vendor_FormType.Temp_Vendor_Name),
                new SqlParameter("@Form_Type_Name",Vendor_FormType.Form_Type_Name),

            };
            return DBHelp.GetScalar(sql, sp);
        }
        //通过表格类型编号查询表格类型对象
        public static IList<As_Vendor_FormType> listVendorFormType(string sql)
        {
            IList<As_Vendor_FormType> list = new List<As_Vendor_FormType>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Vendor_FormType Vendor_FormType = new As_Vendor_FormType();
                    Vendor_FormType.Id = Convert.ToInt32(dr["id"]);
                    Vendor_FormType.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    Vendor_FormType.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    Vendor_FormType.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    Vendor_FormType.Form_Type_Name = Convert.ToString(dr["Form_Type_Name"]);
                    list.Add(Vendor_FormType);
                }
            }
            return list;
        }
    }
}
