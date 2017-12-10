using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;
using MODEL.VendorAssess;

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


        /// <summary>
        /// 获取该供应商的详细信息
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static As_Vendor_Modify_Info getTempVendorByVendorCode(string temVendorID)
        {
            As_Vendor_Modify_Info tempVendor = null;
            string sql = "Select As_Temp_Vendor.Temp_Vendor_Name,As_Temp_Vendor.Vendor_Type_ID,As_Temp_Vendor.Temp_Vendor_ID,As_Temp_Vendor.Normal_Vendor_ID,As_Temp_Vendor.Purchase_Amount,As_Temp_Vendor.SH,As_Temp_Vendor.ZS,As_Temp_Vendor.ZH,As_Vendor_Type.Promise,As_Vendor_Type.Vendor_Type,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Vendor_Assign From As_Temp_Vendor,As_Vendor_Type Where As_Temp_Vendor.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendor.Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",temVendorID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                tempVendor = new As_Vendor_Modify_Info();
                foreach (DataRow dr in dt.Rows)
                {
                    tempVendor.Temp_Vendor_Name = dr["Temp_Vendor_Name"].ToString();
                    tempVendor.Vendor_Type_ID = dr["Vendor_Type_ID"].ToString();
                    tempVendor.Normal_Vendor_ID = dr["Normal_Vendor_ID"].ToString().Trim();
                    tempVendor.Temp_Vendor_ID = temVendorID;
                    tempVendor.Purchase_Amount = Convert.ToInt32(dr["Purchase_Amount"]);
                    tempVendor.Vendor_Type= dr["Vendor_Type"].ToString();
                    tempVendor.Advance_Charge = dr["Advance_Charge"].ToString();
                    tempVendor.Promise = dr["Promise"].ToString();
                    tempVendor.Vendor_Assign = dr["Vendor_Assign"].ToString();
                    tempVendor.SH = dr["SH"].ToString();
                    tempVendor.ZS = dr["ZS"].ToString();
                    tempVendor.ZH = dr["ZH"].ToString();
                }
            }
            return tempVendor;
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


        public static string getTempVendorIDFixed(string TempVendorName,string vendorType)
        {
            string tempVendorID = "";
            string sql = "select As_Temp_Vendor.Temp_Vendor_ID from As_Temp_Vendor,As_Vendor_Type where As_Temp_Vendor.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendor.Temp_Vendor_Name=@Temp_Vendor_Name and As_Vendor_Type.Vendor_Type='" + vendorType + "'";
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

        public static int addMultiTypeVendor(string tempVendorID, bool promise, bool assign, bool charge, string money, string factory)
        {
            SqlCommand cmd = new SqlCommand("addMultiTypeVendor", DBHelp.Connection);
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

        public static string getNormalCode(string tempVendorID)
        {
            string sql = "select Normal_Vendor_ID from As_Temp_Vendor Where Temp_Vendor_ID=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ID",tempVendorID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Normal_Vendor_ID"].ToString();
            }
            return "";
        }

        public static As_Temp_Vendor getTempVendor(string tempVendorID)
        {
            As_Temp_Vendor tempVendor = null;
            string sql = "Select * From As_Temp_Vendor Where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Temp_Vendor_ID",tempVendorID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                tempVendor = new As_Temp_Vendor();
                foreach (DataRow dr in dt.Rows)
                {
                    tempVendor.Temp_Vendor_Name = dr["Temp_Vendor_Name"].ToString();
                    tempVendor.Vendor_Type_ID = dr["Vendor_Type_ID"].ToString();
                    tempVendor.Normal_Vendor_ID = dr["Normal_Vendor_ID"].ToString();
                    tempVendor.Temp_Vendor_ID = tempVendorID;
                    tempVendor.Purchase_Amount = Convert.ToInt32(dr["Purchase_Amount"]);
                    tempVendor.SH = dr["SH"].ToString();
                    tempVendor.ZS = dr["ZS"].ToString();
                    tempVendor.ZH = dr["ZH"].ToString();
                }
            }
            return tempVendor;
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




        public static int checkVendor(string tempVendorID, string type, bool promise, bool assign, bool charge, string money, string factory)
        {
            SqlCommand cmd = new SqlCommand("vendor_Modify_exist", DBHelp.Connection);
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@temp_vendor_id",tempVendorID),
                new SqlParameter("@type",type),
                new SqlParameter("@promise",promise.ToString()),
                new SqlParameter("@assign",assign.ToString()),
                new SqlParameter("@charge",charge.ToString()),
                new SqlParameter("@money",Convert.ToDecimal(money)),
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


        public static string getTempVendorFactory(string sql)
        {
            DataTable table = DBHelp.GetDataSet(sql);
            string factory = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    factory = dr["Factory_Name"].ToString().Trim();
                }
            }
            return factory;
        }

        /// <summary>
        /// 读取供应商列表信息
        /// </summary>
        /// <param name="factory">null读取全部</param>
        /// <returns></returns>
        public static DataTable readVendor(string[] factory)
        {
            string sql = "";
            if (factory == null)
            {
                sql = "select distinct * from View_Temp_Vendor";
            }
            else
            {
                sql = "select distinct * from View_Temp_Vendor where Factory_Name in ({0})";
                string temp = "";
                foreach (string item in factory)
                {
                    temp += ("'"+item+"',");
                }
                temp = temp.Substring(0, temp.Length - 1);
                sql = String.Format(sql, temp);
            }

            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public static int vendorSharedUse(string tempVendorID, string sourceFactory, string factory, string employee_ID)
        {
            SqlCommand cmd = new SqlCommand("oldVendorReUse", DBHelp.Connection);
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@temp_vendor_id",tempVendorID),
                new SqlParameter("@source_factory",sourceFactory),
                new SqlParameter("@factory",factory),
                new SqlParameter("@employee_id",employee_ID)
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

        public static bool vendorTypeExist(string name, string vendorTypeName)
        {
            string sql = "Select count(*) From View_Temp_Vendor Where Temp_Vendor_Name=@Name And Vendor_Type=@Type";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@Type",vendorTypeName)
            };
            if (DBHelp.GetScalarFix(sql, sp) > 0)
            {
                return true;
            }
            return false;
        }

        public static bool vendorNameExist(string name)
        {
            string sql = "Select count(*) From As_Temp_Vendor Where Temp_Vendor_Name=@Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Name",name)
            };
            if (DBHelp.GetScalarFix(sql,sp)>0)
            {
                return true;
            }
            return false;

        }
    }
}
