using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelp
    {
        private static SqlConnection connection;
        public static SqlConnection Connection//连接数据库
        {
            get
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();

                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }


        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return result;
        }

        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            try
            {
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return result;
            }
            catch (Exception e)
            {
                cmd.Dispose();
                return 0;
            }
        }

        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="dc"></param>
        ///// <returns></returns>
        //public static int ExecuteStoredProcedure(string name, Dictionary<string, string> dc)
        //{
        //    SqlCommand cmd = new SqlCommand(name, Connection);
        //    cmd.CommandType = CommandType.StoredProcedure;//存储过程
        //    cmd.Parameters.Add(new SqlParameter("@temp_vendor_ID", SqlDbType.NVarChar, 50));
        //    cmd.Parameters.Add(new SqlParameter("@factory_Name", SqlDbType.NVarChar, 50));
        //    cmd.Parameters.Add(new SqlParameter("@leagalPerson", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@range", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@stocks", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@place", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@namePartTwoSwitch", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@namePartThreeSwitch", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@namePartFourSwitch", SqlDbType.NVarChar, 10));
        //    cmd.Parameters["@temp_vendor_ID"].Value = dc["temp_vendor_ID"].ToString().Trim();
        //    cmd.Parameters["@factory_Name"].Value = dc["factory_Name"].ToString().Trim();
        //    cmd.Parameters["@leagalPerson"].Value = dc["leagalPerson"].ToString().Trim();
        //    cmd.Parameters["@range"].Value = dc["range"].ToString().Trim();
        //    cmd.Parameters["@stocks"].Value = dc["stocks"].ToString().Trim();
        //    cmd.Parameters["@place"].Value = dc["place"].ToString().Trim();
        //    cmd.Parameters["@namePartTwoSwitch"].Value = dc["namePartTwoSwitch"].ToString().Trim();
        //    cmd.Parameters["@namePartThreeSwitch"].Value = dc["namePartThreeSwitch"].ToString().Trim();
        //    cmd.Parameters["@namePartFourSwitch"].Value = dc["namePartFourSwitch"].ToString().Trim();
        //    int number = cmd.ExecuteNonQuery();
        //    return number;
        //}



        ///// <summary>
        ///// 执行修改类型判断存储过程
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="dc"></param>
        ///// <returns></returns>
        //public static int ExecuteModifyCheckResultStoredProcedure(string storedProcedureName, string temp_Vendor_ID, string factory_Name, string newType,string oldType, bool promise, bool assign, bool charge, float money)
        //{
        //    if (temp_Vendor_ID == "")
        //    {
        //        return -1;
        //    }
        //    SqlCommand cmd = new SqlCommand(storedProcedureName, Connection);
        //    cmd.CommandType = CommandType.StoredProcedure;//存储过程
        //    cmd.Parameters.Add(new SqlParameter("@temp_vendor_id", SqlDbType.NVarChar, 50));
        //    cmd.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar, 50));
        //    cmd.Parameters.Add(new SqlParameter("@oldType", SqlDbType.NVarChar, 50));
        //    cmd.Parameters.Add(new SqlParameter("@promise", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@assign", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@charge", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@money", SqlDbType.NVarChar, 10));
        //    cmd.Parameters.Add(new SqlParameter("@factory", SqlDbType.NVarChar, 10));
        //    cmd.Parameters["@temp_vendor_id"].Value = temp_Vendor_ID;
        //    cmd.Parameters["@type"].Value = newType;
        //    cmd.Parameters["@oldType"].Value = oldType;
        //    cmd.Parameters["@promise"].Value = promise;
        //    cmd.Parameters["@assign"].Value = assign;
        //    cmd.Parameters["@charge"].Value = charge;
        //    cmd.Parameters["@money"].Value = money;
        //    cmd.Parameters["@factory"].Value = factory_Name;
        //    int number = cmd.ExecuteNonQuery();
        //    return number;
        //}

        public static int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            return result;
        }

        public static string GetScalarString(string sql,SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            object ob = cmd.ExecuteScalar();
            cmd.Dispose();
            return ob is DBNull?"":ob.ToString();
        }

        public static int GetScalarFix(string sql,params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            return result;
        }

        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return result;
        }


        public static int GetScalarID(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            return result;
        }

        public static SqlDataReader GetReader(string safeSql)
        {
            //SqlCommand cmd = new SqlCommand(safeSql, Connection);
            //SqlDataReader reader = cmd.ExecuteReader();
            //return reader;
            using (SqlCommand cmd = new SqlCommand(safeSql, Connection))
            {
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            //SqlCommand cmd = new SqlCommand(sql, Connection);
            //cmd.Parameters.AddRange(values);
            //SqlDataReader reader = cmd.ExecuteReader();
            //return reader;

            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                try
                {
                    cmd.Parameters.AddRange(values);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();
            cmd.Dispose();
            return ds.Tables[0];
        }

        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();
            cmd.Dispose();
            return ds.Tables[0];
        }

        /// <summary>
        /// 简单防sql注入程序
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Sqlstring(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt");
            str = str.Replace("'", "''");
            str = str.Replace("*", "");
            str = str.Replace("\n", "<br/>");
            str = str.Replace("\r\n", "<br/>");
            //str = str.Replace("?","");
            str = str.Replace("select", "");
            str = str.Replace("insert", "");
            str = str.Replace("update", "");
            str = str.Replace("delete", "");
            str = str.Replace("create", "");
            str = str.Replace("drop", "");
            str = str.Replace("delcare", "");
            str = str.Replace("--", "");
            str = str.Replace("@", "");

            if (str.Trim().ToString() == "") { str = "null"; }

            return str;
        }
    }
}
