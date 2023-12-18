using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerTool.DatabaseHelper
{
    /// <summary>
    /// 数据库模型
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
        public string DataBase {  get; set; }

    }
}
