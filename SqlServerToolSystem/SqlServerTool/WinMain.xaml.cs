﻿using SqlServerTool.CustomClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SqlServerTool
{
    /// <summary>
    /// WinMain.xaml 的交互逻辑
    /// </summary>
    public partial class WinMain : Window
    {

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WinMain()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWinCaption();
            LoadTreeView();
        }

        #endregion

        #region 加载树形菜单(表 视图 存储过程 自定义函数)
        /// <summary>
        /// 加载树形菜单(表 视图 存储过程 自定义函数)
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadTreeView()
        {
            List<TreeNode> nodes = new List<TreeNode>
            {
                new TreeNode("数据库表","DataTable",0,0),
                new TreeNode("视图","DataView",0,0),
                new TreeNode("存储过程","DataTable",0,0),
                new TreeNode("自定义函数","DataTable",0,0),
            };
        }

        #endregion

        #region 构造WinMain窗体标题
        /// <summary>
        /// 构造WinMain窗体标题
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadWinCaption()
        {
            Title += string.Format($"-服务器:{App.DbConnectionInfo.Server} 数据库: {App.DbConnectionInfo.DataBase}");
        }

        #endregion
    }
}
