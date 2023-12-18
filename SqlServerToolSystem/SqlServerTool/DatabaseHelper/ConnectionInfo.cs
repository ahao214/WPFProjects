using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerTool.DatabaseHelper
{
    /// <summary>
    /// 连接数据库所需信息
    /// </summary>
    public class ConnectionInfo
    {
        /// <summary>
        /// 数据库服务器地址(名称)
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 数据库登录ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 数据库登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 数据库的名称
        /// </summary>
        public string DataBase { get; set; }

        #region 重新转换字符串函数
        /// <summary>
        /// 重新转换字符串函数
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Server={0};Database={1};User Id={2};Password={3}", Server, DataBase, UserId, Password);
        } 
        #endregion
    }
}
