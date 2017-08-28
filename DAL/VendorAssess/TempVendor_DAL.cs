using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TempVendor_DAL
    {
        public static int addTempVendor(As_Temp_Vendor Temp_Vendor)
        {
            string sql = "INSERT INTO As_Temp_Vendor(Temp_Vendor_Name,Vendor_Type_ID,Temp_Vendor_ID,Purchase_Amount,SH,ZS,ZH)VALUES(@Temp_Vendor_Name,@Vendor_Type_ID,@Temp_Vendor_ID,@Purchase_Amount,@SH,@ZS,@ZH)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_Name",Temp_Vendor.Temp_Vendor_Name),
                new SqlParameter("@Vendor_Type_ID",Temp_Vendor.Vendor_Type_ID),
                new SqlParameter("@Temp_Vendor_ID",""),
                new SqlParameter("@Purchase_Amount",Temp_Vendor.Purchase_Amount),
                new SqlParameter("@SH",Temp_Vendor.SH),
                new SqlParameter("@ZS",Temp_Vendor.ZS),
                new SqlParameter("@ZH",Temp_Vendor.ZH)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static bool getUsed(string tempVendorID, string factoryName)
        {
            string sql = "select * From As_Temp_Vendor where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                if (dt.Rows[0]["SH"].ToString().Equals(factoryName)||
                    dt.Rows[0]["ZS"].ToString().Equals(factoryName)||
                    dt.Rows[0]["ZH"].ToString().Equals(factoryName))
                {
                    return true;
                }
            }
            return false;
        }

        public static string getTempVendorName(string tempVendorID)
        {
            string tempVendorName = "";
            string sql = "select Temp_Vendor_Name from As_Temp_Vendor where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Temp_Vendor_ID",tempVendorID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tempVendorName = Convert.ToString(dr["Temp_Vendor_Name"]);
                }
            }
            return tempVendorName;
        }

        public static string getTempVendorID(string TempVendorName)
        {
            string tempVendorID = "";
            string sql = "select Temp_Vendor_ID from As_Temp_Vendor where Temp_Vendor_Name=@Temp_Vendor_Name";
            //string sql = "select Temp_Vendor_ID from As_Employee_Vendor where Temp_Vendor_Name=@Temp_Vendor_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("Temp_Vendor_Name",TempVendorName)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tempVendorID = Convert.ToString(dr["Temp_Vendor_ID"]);
                }
            }
            return tempVendorID;
        }

        public static int addBindVendorFormAndFile(string tempVendorID, bool promise, bool assign, bool charge, string money,string factory)
        {
            SqlCommand cmd = new SqlCommand("newVendorProcedure", DBHelp.Connection);
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@temp_vendor_id",tempVendorID),
                new SqlParameter("@promise",promise.ToString()),
                new SqlParameter("@assign",assign.ToString()),
                new SqlParameter("@charge",charge.ToString()),
                new SqlParameter("@money",Convert.ToInt32(money)),
                new SqlParameter("@factory",factory.ToString())
            };
            SqlParameter paramReturn = new SqlParameter("@return", SqlDbType.Int);
            paramReturn.Direction = ParameterDirection.ReturnValue;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(sp);
            cmd.Parameters.Add(paramReturn);
            cmd.ExecuteNonQuery();
            DBHelp.Connection.Close();
            return Convert.ToInt32(paramReturn.Value);
        }
    }
}
