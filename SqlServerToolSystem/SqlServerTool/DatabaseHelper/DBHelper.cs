using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerTool.DatabaseHelper
{
    /// <summary>
    /// DBHelper类
    /// </summary>
    public class DBHelper
    {
        #region 数据库连接字符串
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string connString = string.Empty;

        #endregion

        #region 构造函数初始化连接字符串
        /// <summary>
        /// 构造函数初始化连接字符串
        /// </summary>
        /// <param name="_connString"></param>
        public DBHelper(string _connString)
        {
            connString = _connString;
        }
        #endregion

        #region 返回一个连接对象
        /// <summary>
        /// 返回一个连接对象
        /// </summary>
        /// <returns></returns>
        private SqlConnection CreateConn()
        {
            return new SqlConnection(connString);
        }

        #endregion

        #region 返回一个对象

        /// <summary>
        /// 返回一个对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object GetValue(string sql)
        {
            object o = null;
            using (SqlConnection conn = CreateConn())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                o = cmd.ExecuteScalar();
                conn.Close();
            }

            return o;
        }

        #endregion

        #region 返回DataSet集合
        /// <summary>
        /// 返回DataSet集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = CreateConn())
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);
                return ds;
            }
        }

        #endregion


        #region 返回DataTable集合
        /// <summary>
        /// 返回DataTable集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            return GetDataSet(sql).Tables[0];
        }

        #endregion

        #region 执行SQL语句返回受影响的行数
        /// <summary>
        /// 执行SQL语句返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(string sql)
        {
            int i = 0;
            using (SqlConnection conn = CreateConn())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;
        }

        #endregion
    }

}
