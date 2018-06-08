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
            string sql = "INSERT INTO As_Temp_Vendorchange(Temp_Vendor_Name,Vendor_Type_ID,Temp_Vendor_ID,Purchase_Amount,Factory_Name)VALUES(@Temp_Vendor_Name,@Vendor_Type_ID,@Temp_Vendor_ID,@Purchase_Amount,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_Name",Temp_Vendor.Temp_Vendor_Name),
                new SqlParameter("@Vendor_Type_ID",Temp_Vendor.Vendor_Type_ID),
                new SqlParameter("@Temp_Vendor_ID",""),
                new SqlParameter("@Purchase_Amount",Temp_Vendor.Purchase_Amount),
                new SqlParameter("@Factory_Name",Temp_Vendor.Factory_Name),
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static bool getUsed(string tempVendorID, string factoryName)
        {
            string sql = "select Factory_Name From As_Temp_Vendorchange where Temp_Vendor_ID=@Temp_Vendor_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Factory_Name",factoryName)
            };
            using (SqlDataReader reader = DBHelp.GetReader(sql, sp))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 获取该供应商的详细信息
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static As_Vendor_Modify_Info getTempVendorByVendorCode(string temVendorID,string factory)
        {
            bool sh = false;
            bool zh = false;
            bool zs = false;
            As_Vendor_Modify_Info tempVendor = null;
            string sql = "Select As_Temp_Vendorchange.Temp_Vendor_Name,As_Temp_Vendorchange.Vendor_Type_ID,As_Temp_Vendorchange.Temp_Vendor_ID,As_Temp_Vendorchange.Normal_Vendor_ID,As_Temp_Vendorchange.Purchase_Amount,As_Temp_Vendorchange.Factory_Name,As_Vendor_Type.Promise,As_Vendor_Type.Vendor_Type,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Vendor_Assign From As_Temp_Vendorchange,As_Vendor_Type Where As_Temp_Vendorchange.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendorchange.Temp_Vendor_ID=@Temp_Vendor_ID and Factory_Name=@Factory_Name";
            string sqlsh= "Select As_Temp_Vendorchange.Temp_Vendor_Name,As_Temp_Vendorchange.Vendor_Type_ID,As_Temp_Vendorchange.Temp_Vendor_ID,As_Temp_Vendorchange.Normal_Vendor_ID,As_Temp_Vendorchange.Purchase_Amount,As_Temp_Vendorchange.Factory_Name,As_Vendor_Type.Promise,As_Vendor_Type.Vendor_Type,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Vendor_Assign From As_Temp_Vendorchange,As_Vendor_Type Where As_Temp_Vendorchange.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendorchange.Temp_Vendor_ID=@Temp_Vendor_ID and As_Temp_Vendorchange.Factory_Name='上海科勒'";
            string sqlzs = "Select As_Temp_Vendorchange.Temp_Vendor_Name,As_Temp_Vendorchange.Vendor_Type_ID,As_Temp_Vendorchange.Temp_Vendor_ID,As_Temp_Vendorchange.Normal_Vendor_ID,As_Temp_Vendorchange.Purchase_Amount,As_Temp_Vendorchange.Factory_Name,As_Vendor_Type.Promise,As_Vendor_Type.Vendor_Type,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Vendor_Assign From As_Temp_Vendorchange,As_Vendor_Type Where As_Temp_Vendorchange.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendorchange.Temp_Vendor_ID=@Temp_Vendor_ID and As_Temp_Vendorchange.Factory_Name='中山科勒'";
            string sqlzh = "Select As_Temp_Vendorchange.Temp_Vendor_Name,As_Temp_Vendorchange.Vendor_Type_ID,As_Temp_Vendorchange.Temp_Vendor_ID,As_Temp_Vendorchange.Normal_Vendor_ID,As_Temp_Vendorchange.Purchase_Amount,As_Temp_Vendorchange.Factory_Name,As_Vendor_Type.Promise,As_Vendor_Type.Vendor_Type,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Advance_Charge,As_Vendor_Type.Vendor_Assign From As_Temp_Vendorchange,As_Vendor_Type Where As_Temp_Vendorchange.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendorchange.Temp_Vendor_ID=@Temp_Vendor_ID and As_Temp_Vendorchange.Factory_Name='珠海科勒'";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",temVendorID),
                new SqlParameter("@Factory_Name",factory)
            };

            SqlParameter[] spsh = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",temVendorID)
            };

            SqlParameter[] spzh = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",temVendorID)
            };

            SqlParameter[] spzs = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",temVendorID)
            };


            using (SqlDataReader reader = DBHelp.GetReader(sqlsh, spsh))
            {
                if (reader.Read())
                {
                    sh = true;
                }
            }
            using (SqlDataReader reader = DBHelp.GetReader(sqlzs, spzs))
            {
                if (reader.Read())
                {
                    zs = true;
                }
            }
            using (SqlDataReader reader = DBHelp.GetReader(sqlzh, spzh))
            {
                if (reader.Read())
                {
                    zh = true;
                }
            }


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
                    tempVendor.SH = "";
                    tempVendor.ZS = "";
                    tempVendor.ZH = "";
                    if (zh)
                    {
                        tempVendor.ZH = "珠海科勒";
                    }
                    if (sh)
                    {
                        tempVendor.SH = "上海科勒";
                    }
                    if (zs)
                    {
                        tempVendor.ZS = "中山科勒";
                    }
                }
            }
            
            return tempVendor;
        }

        public static string getTempVendorID_MultiType(string tempVendorName,string vendorTypeID)
        {
            string tempVendorID = "";
            string sql = "select Temp_Vendor_ID from As_Temp_Vendorchange where Temp_Vendor_Name=@Temp_Vendor_Name and Vendor_Type_ID=@VendorTypeID";
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("Temp_Vendor_Name",tempVendorName),
                 new SqlParameter("@VendorTypeID",vendorTypeID)
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

        public static string getNormalCode_MultiType(string v)
        {
            string sql = "select distinct Normal_Vendor_ID From As_Temp_Vendorchange Where Temp_Vendor_Name=@Temp_Vendor_Name";
            string result = "";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_Name",v)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result = Convert.ToString(dr["Normal_Vendor_ID"]);
                }
            }
            if (result.Equals(""))
            {
                return "";
            }
            return result;
        }

        public static void deleteVendorType(string oldTempVendorID,string factory_Name)
        {
            bool sh = false;
            bool zh = false;
            bool zs = false;
            //查看其他厂是否有使用记录
            //直接查找更新就行了 写复杂了.....
            //string sqls = "select SH,ZH,ZS from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
            //DataTable table = DBHelp.GetDataSet(sqls);
            //if (table.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in table.Rows)
            //    {
            //        string ssql = "update As_Temp_Vendor set SH='" + dr["SH"].ToString() + "',ZH='" + dr["ZH"].ToString() + "',ZS='" + dr["ZS"].ToString() + "' where Temp_Vendor_ID='" + newTempVendorID + "'";
            //        DBHelp.ExecuteCommand(ssql);
            //    }
            //}
            #region
            string sql0 = "select Temp_Vendor_ID from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "' and SH='上海科勒'";
            using (SqlDataReader reader = DBHelp.GetReader(sql0))
            {
                if (reader.Read())
                {
                    sh = true;
                }
                else
                {
                    sh = false;
                }
            }


            string sql1 = "select Temp_Vendor_ID from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "' and ZS='中山科勒'";
            using (SqlDataReader reader = DBHelp.GetReader(sql1))
            {
                if (reader.Read())
                {
                    zs = true;
                }
                else
                {
                    zs = false;
                }
            }
            string sql2 = "select Temp_Vendor_ID from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "' and ZS='珠海科勒'";
            using (SqlDataReader reader = DBHelp.GetReader(sql2))
            {
                if (reader.Read())
                {
                    zh = true;
                }
                else
                {
                    zh = false;
                }
            }

            if (sh && !zh && !zs)//仅有上海厂
            {
                string sql = "delete from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
                DBHelp.ExecuteCommand(sql);
            }
            if (!sh && zh && !zs)//仅有珠海厂
            {
                string sql = "delete from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
                DBHelp.ExecuteCommand(sql);
            }
            if (!sh && !zh && zs)//仅有中山厂
            {
                string sql = "delete from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
                DBHelp.ExecuteCommand(sql);
            }

            if (sh && zh && !zs)//仅有上海珠海厂
            {
                if (factory_Name.Equals("上海科勒"))
                {
                    string sql = "update As_Temp_Vendor set SH='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                    //sql = "delete from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    //DBHelp.ExecuteCommand(sql);

                }
                if (factory_Name.Equals("珠海科勒"))
                {
                    string sql = "update As_Temp_Vendor set ZH='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                    //sql = "delete from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    //DBHelp.ExecuteCommand(sql);
                }
            }
            if (sh && !zh && zs)//仅有上海中山厂
            {
                if (factory_Name.Equals("上海科勒"))
                {
                    string sql = "update As_Temp_Vendor set SH='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                    //sql = "delete from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    //DBHelp.ExecuteCommand(sql);
                }
                if (factory_Name.Equals("中山科勒"))
                {
                    string sql = "update As_Temp_Vendor set ZS='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                    //sql = "delete from As_Temp_Vendor where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    //DBHelp.ExecuteCommand(sql);
                }
            }

            if (!sh && zh && zs)//仅有珠海中山厂
            {
                if (factory_Name.Equals("珠海科勒"))
                {
                    string sql = "update As_Temp_Vendor set ZH='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                }
                if (factory_Name.Equals("中山科勒"))
                {
                    string sql = "update As_Temp_Vendor set ZS='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                }
            }

            if (sh && zh && zs)
            {
                if (factory_Name.Equals("珠海科勒"))
                {
                    string sql = "update As_Temp_Vendor set ZH='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                }
                if (factory_Name.Equals("中山科勒"))
                {
                    string sql = "update As_Temp_Vendor set ZS='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                }
                if (factory_Name.Equals("上海科勒"))
                {
                    string sql = "update As_Temp_Vendor set SH='' where Temp_Vendor_ID='" + oldTempVendorID + "'";
                    DBHelp.ExecuteCommand(sql);
                }
            }

            #endregion
        }

        public static bool checkEmployeeAuthority(string employeeID)
        {
            string sql = "select Positon_Name from As_Employee where Positon_Name like '采购%' and Employee_ID='" + employeeID + "'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string getTempVendorName(string tempVendorID)
        {
            string tempVendorName = "";
            string sql = "select top 1 Temp_Vendor_Name from As_Temp_Vendorchange where Temp_Vendor_ID=@Temp_Vendor_ID";
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

        /// <summary>
        /// 是否为旧供应商
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static bool isOldVendor(string tempVendorID)
        {
            string sql = "select * from As_Employee_Vendor where Temp_Vendor_ID=@Temp_Vendor_ID and Type='OLD'";
            using (SqlDataReader reader = DBHelp.GetReader(sql,new SqlParameter[] { new SqlParameter("@Temp_Vendor_ID",tempVendorID)}))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string getTempVendorID(string TempVendorName)
        {
            string tempVendorID = "";
            string sql = "select Temp_Vendor_ID from As_Temp_Vendorchange where Temp_Vendor_Name=@Temp_Vendor_Name";
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


        public static string getTempVendorIDFixed(string TempVendorName,string vendorType,string factory)
        {
            string tempVendorID = "";
            string sql = "select As_Temp_Vendorchange.Temp_Vendor_ID from As_Temp_Vendorchange,As_Vendor_Type where As_Temp_Vendorchange.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendorchange.Temp_Vendor_Name=@Temp_Vendor_Name and As_Vendor_Type.Vendor_Type='" + vendorType + "' and As_Temp_Vendorchange.Factory_Name='" + factory + "'";
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
            string sql = "select distinct Normal_Vendor_ID from As_Temp_Vendorchange Where Temp_Vendor_ID=@ID and Normal_Vendor_ID is not null";
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

        public static As_Temp_Vendor getTempVendor(string tempVendorID,string factory)
        {
            As_Temp_Vendor tempVendor = null;
            string sql = "select * From As_Temp_Vendorchange Where Temp_Vendor_ID=@Temp_Vendor_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Factory_Name",factory)
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
                    tempVendor.Factory_Name = dr["Factory_Name"].ToString();
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
                new SqlParameter("@money",Math.Round(Convert.ToDouble(money), 3)),
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
            string sql = "Select count(*) From As_Temp_Vendorchange Where Temp_Vendor_Name=@Name";
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
