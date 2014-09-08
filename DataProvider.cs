using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel1WS
{
    public class DataProvider
    {
        private static SqlConnection _con = null;

        static DataProvider()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            _con = new SqlConnection(strConnection);
        }

        public static SqlConnection getConnection()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            _con = new SqlConnection(strConnection);
            return _con;
        }
        public static DataTable ExecuteQuery(string strQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                _con.Open();

                SqlDataAdapter da = new SqlDataAdapter(strQuery, _con);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu truy vấn: " + ex.ToString());
            }
            finally
            {
                _con.Close();
            }
            return dt;
        }

        public static DataTable ExecuteQuery(string strQuery, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                _con.Open();

                SqlCommand cmd = new SqlCommand(strQuery, _con);
                cmd.CommandType = CommandType.StoredProcedure;
                if(param!=null)
                    cmd.Parameters.AddRange(param);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu truy vấn: " + ex.ToString());
            }
            finally
            {
                _con.Close();
            }
            return dt;
        }

        public static int ExecuteNonQuery(string strQuery, SqlParameter[] param)
        {
            int kq = 0;
            try
            {
                _con.Open();

                SqlCommand cmd = new SqlCommand(strQuery, _con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                kq = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu truy vấn: " + ex.ToString());
            }
            finally
            {
                _con.Close();
            }
            return kq;
        }

        public static int ExecuteNonQuery(string strQuery)
        {
            int kq = 0;
            try
            {
                _con.Open();

                SqlCommand cmd = new SqlCommand(strQuery, _con);

                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu truy vấn: " + ex.ToString());
            }
            finally
            {
                _con.Close();
            }
            return kq;
        }

        public static DataTable ExcuteQueryDataTable(SqlCommand cm)
        {
            DataTable dt = new DataTable();
            cm.Connection = _con;
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            adapter.Fill(dt);
            return dt;
        }

    }
}