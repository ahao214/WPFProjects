using System;
using System.Collections.Generic;
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

    }

}
