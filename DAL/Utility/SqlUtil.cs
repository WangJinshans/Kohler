using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL.Utility
{
     class SqlUtil
    {

        static SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string connectionstring;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public string ConnectionString
        {
            get { return connectionstring; }
        }

        public SqlUtil()
        {

            this.connectionstring =System.Configuration .ConfigurationManager.ConnectionStrings["connectionstring"].ToString ();
          

            if (conn == null)
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
            }
          

           if (conn.State == ConnectionState.Closed)
           {
               conn = new SqlConnection(connectionstring);
               conn.Open();
              
           }

           if (conn.State == ConnectionState.Broken)
           {

               conn = new SqlConnection(connectionstring);
               conn.Open();
           }

          

           if (conn.State == ConnectionState.Open)
           {
              
           }
           
            cmd = new SqlCommand();
            cmd.Connection = conn;
           
        }

        private void PreparedCommand(string sql, params SqlParameter[] param)
        {
            
            cmd.CommandText = sql;
            //清空Parameters中的参数
            cmd.Parameters.Clear();
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
                //foreach (SqlParameter p in param)
                //{
                //    cmd.Parameters.Add(p);
                //}
            }

        }


        private void PreparedCommandPro(string name, params SqlParameter[] param)
        {
            cmd.CommandText = name;
            //清空Parameters中的参数
            cmd.Parameters.Clear();
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
                //foreach (SqlParameter p in param)
                //{
                //    cmd.Parameters.Add(p);
                //}
            }
            cmd.CommandType = CommandType.StoredProcedure;
        }


        public object ExecuteScalar(string sql, params SqlParameter[] param)
        {
            PreparedCommand(sql, param);
            return cmd.ExecuteScalar();
        }


        public object ExecuteScalarPro(string Pro, params SqlParameter[] param)
        {
            PreparedCommandPro(Pro, param);
            return cmd.ExecuteScalar();
        }

        public object ExecuteScalar(string sql)
        {
            PreparedCommand(sql, null);
            return cmd.ExecuteScalar();
        }

        public object ExecuteScalarPro(string Pro)
        {
            PreparedCommandPro(Pro, null);
            return cmd.ExecuteScalar();
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] param)
        {
            PreparedCommand(sql, param);
            return cmd.ExecuteNonQuery();
        }


        public int ExecuteNonQueryPro(string Pro, params SqlParameter[] param)
        {
            PreparedCommandPro(Pro, param);
            return cmd.ExecuteNonQuery();
        }


        public int ExecuteNonQuery(string sql)
        {
            PreparedCommand(sql, null);
            return cmd.ExecuteNonQuery();
        }

        public int ExecuteNonQueryPro(string Pro)
        {
            PreparedCommandPro(Pro, null);
            return cmd.ExecuteNonQuery();
        }


        public SqlDataReader ExecuteQuery(string sql, params SqlParameter[] param)
        {
            PreparedCommand(sql, param);
            return cmd.ExecuteReader();
        }

        public SqlDataReader ExecuteQueryPro(string Pro, params SqlParameter[] param)
        {
            PreparedCommandPro(Pro, param);
            return cmd.ExecuteReader();
        }


        public SqlDataReader ExecuteQuery(string sql)
        {
            PreparedCommand(sql, null);
            return cmd.ExecuteReader();
        }

        public SqlDataReader ExecuteQueryPro(string Pro)
        {
            PreparedCommandPro(Pro, null);
            return cmd.ExecuteReader();
        }


        public DataSet Load(string sql, params SqlParameter[] param)
        {
            PreparedCommand(sql, param);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }

        public DataSet LoadPro(string Pro, params SqlParameter[] param)
        {
            PreparedCommandPro(Pro, param);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }

        public DataSet Load(string sql)
        {
            PreparedCommand(sql, null);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }

        public DataSet LoadPro(string Pro)
        {
            PreparedCommandPro(Pro, null);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }

        public List<T> Query<T>(string sql, params SqlParameter[] param)
        {
            DataSet ds = Load(sql, param);
            return DBUtil.DataSetToList<T>(ds, 0).ToList();
        }

        public List<T> QueryPro<T>(string Pro, params SqlParameter[] param)
        {
            DataSet ds = LoadPro(Pro, param);
            return DBUtil.DataSetToList<T>(ds, 0).ToList();
        }

        public List<T> Query<T>(string sql)
        {
            DataSet ds = Load(sql);
            return DBUtil.DataSetToList<T>(ds, 0).ToList();
            
        }


        public List<T> QueryPro<T>(string Pro)
        {
            DataSet ds = LoadPro(Pro);
            return DBUtil.DataSetToList<T>(ds, 0).ToList();

        }

        public object Get<T>(string sql, params SqlParameter[] param)
        {
            List<T> list = Query<T>(sql, param);
            if (list != null && list.Count > 0)
            {
                return list.First();
            }
            return null;
        }

        public object GetPro<T>(string Pro, params SqlParameter[] param)
        {
            List<T> list = QueryPro<T>(Pro, param);
            if (list != null && list.Count > 0)
            {
                return list.First();
            }
            return null;
        }

        public object Get<T>(string sql)
        {
            List<T> list = Query<T>(sql);
            if (list != null && list.Count > 0)
            {
                return list.First();
            }
            return null;
        }


        public object GetPro<T>(string Pro)
        {
            List<T> list = QueryPro<T>(Pro);
            if (list != null && list.Count > 0)
            {
                return list.First();
            }
            return null;
        }

        public void Close()
        {
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
          
        }





    }

   
}
