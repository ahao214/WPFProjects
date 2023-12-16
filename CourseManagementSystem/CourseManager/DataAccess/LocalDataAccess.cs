﻿using CourseManager.DataAccess.DataEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        /// <param name="pwd"></param>
        public UserEntity CheckUserInfo(string username, string pwd)
        {
            try
            {
                if (DBConnection())
                {
                    string userSql = "select * from users where user_name=@user_name and password=@pwd and is_validation=1";
                    adapter = new SqlDataAdapter(userSql, conn);
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@user_name", SqlDbType.VarChar) { Value = username });
                    adapter .SelectCommand.Parameters .Add (new SqlParameter ("@pwd",SqlDbType.VarChar) { Value = pwd });
                    DataTable dt = new DataTable();
                    int count = adapter.Fill(dt);
                    if (count <= 0)
                    {
                        throw new Exception("用户名或密码不正确");
                    }
                    DataRow dr = dt.Rows[0];
                    if(dr.Field <Int32>("is_can_login") ==0)
                    {
                        throw new Exception("当前用户没有权限使用此平台");
                    }
                    UserEntity userInfo = new UserEntity  ();
                    userInfo.UserName = dr.Field<string>("user_name");
                    userInfo.RealName = dr.Field<string>("real_name");
                    userInfo.Password = dr.Field<string>("password");
                    userInfo.Avatar = dr.Field<string>("avatar");
                    userInfo.Gender = dr.Field<Int32>("gender");
                    return userInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
            return null;
        }


    }
}
