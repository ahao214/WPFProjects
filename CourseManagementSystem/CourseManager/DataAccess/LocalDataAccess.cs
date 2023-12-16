using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.DataAccess
{
    /// <summary>
    /// 数据库处理
    /// </summary>
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;

        public LocalDataAccess()
        {

        }

        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapter;

        private void Dispose()
        {
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if(conn !=null)
            {                
                conn.Close();
                conn.Dispose();
                conn = null;
            }

        }

        /// <summary>
        /// 链接数据库初始化
        /// </summary>
        private bool DBConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;


            if (conn == null) 
            {
                conn = new SqlConnection("");
            }
            try
            {
                conn.Open();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void CheckUserInfo(string username, string password)
        {


        }


    }
}
