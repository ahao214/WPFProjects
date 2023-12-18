using SqlServerTool.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SqlServerTool
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        #region 全局应用变量ConnectionInfo对象

        /// <summary>
        /// 全局应用变量ConnectionInfo对象
        /// </summary>
        public static ConnectionInfo DbConnectionInfo;

        #endregion
    }
}
