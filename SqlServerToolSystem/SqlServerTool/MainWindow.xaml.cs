using SqlServerTool.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlServerTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region 日志文件的全路径
        /// <summary>
        /// 日志文件的全路径
        /// </summary>
        private readonly string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\ConnInfo.log";

        #endregion

        #region 对话框标题信息
        /// <summary>
        /// 对话框标题信息
        /// </summary>
        private const string Caption = "信息提示";
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 开始连接数据库事件
        /// <summary>
        /// 开始连接数据库事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConn_Click(object sender, RoutedEventArgs e)
        {
            string server = CbServer.Text.Trim();
            ConnectionInfo conn = new ConnectionInfo
            {
                Server = string.IsNullOrEmpty(server) ? "." : server,
                DataBase = TxtDbName.Text.Trim(),
                UserId = TxtUserId.Text.Trim(),
                Password = TxtUserPass.Password.Trim(),
            };
            DBHelper db = new DBHelper(conn.ToString());
            try
            {
                object o = db.GetValue("select 1 ");
                if (o != null)
                {
                    // 添加日志
                    AddServerLog(conn);
                }
                else
                {
                    //AddServerLog(conn);
                    MessageBox.Show("登录失败", Caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        #endregion


        #region 添加登录成功后的日志(日志内容是连接信息)
        /// <summary>
        /// 添加登录成功后的日志(日志内容是连接信息)
        /// </summary>
        /// <param name="conn"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void AddServerLog(ConnectionInfo conn)
        {
            string connInfo = string.Format("{0}|{1}|{2}|{3}", conn.Server, conn.DataBase, conn.UserId, conn.Password);
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(connInfo);
            sw.Close();
        }

        #endregion

        #region 退出程序
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Close();    
            //Application.Current.Shutdown();
            Environment.Exit(0);
        }
        #endregion
    }
}
