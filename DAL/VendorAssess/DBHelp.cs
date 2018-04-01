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
            using (SqlCommand cmd = new SqlCommand(safeSql, Connection))
            {
                try
                {
                    int result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return result;
                }
                catch
                {
                    cmd.Dispose();
                    return 0;
                }
            }
        }

        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
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
        }

        public static int GetScalar(string safeSql)
        {
            using (SqlCommand cmd = new SqlCommand(safeSql, Connection))
            {
                try
                {
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    return result;
                }
                catch
                {
                    cmd.Dispose();
                    return 0;
                }
            }
        }

        public static string GetScalarString(string sql,SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                try
                {
                    cmd.Parameters.AddRange(values);
                    object ob = cmd.ExecuteScalar();
                    cmd.Dispose();
                    return ob is DBNull ? "" : ob.ToString();
                }
                catch
                {
                    cmd.Dispose();
                    return "";

                }
            }
        }

        public static int GetScalarFix(string sql,params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                try
                {
                    cmd.Parameters.AddRange(values);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    return result;
                }
                catch
                {
                    cmd.Dispose();
                    return 0;
                }
            }
            
        }

        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                try
                {
                    cmd.Parameters.AddRange(values);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return result;
                }
                catch
                {
                    cmd.Dispose();
                    return 0;
                }

            }

        }


        public static int GetScalarID(string sql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                try
                {
                    cmd.Parameters.AddRange(values);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    return result;
                }
                catch
                {
                    cmd.Dispose();
                    return 0;
                }
            }
        }

        public static SqlDataReader GetReader(string safeSql)
        {
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
