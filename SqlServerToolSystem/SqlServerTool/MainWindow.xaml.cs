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

        #region 存放日志文件内容(数据库连接信息)
        /// <summary>
        /// 存放日志文件内容(数据库连接信息)
        /// </summary>
        private string connString = string.Empty;

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
                    App.DbConnectionInfo = conn;
                    MessageBox.Show("数据库连接成功", Caption, MessageBoxButton.OK, MessageBoxImage.Information
                     );
                    // 打开主窗体
                    WinMain main = new WinMain();
                    main.Show();
                    Close();
                }
                else
                {
                    AddServerLog(conn);
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

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(fileName);
                string log = sr.ReadToEnd();
                sr.Close();
                if (!string.IsNullOrEmpty(log))
                {
                    string ser = log.Split('|')[0];
                    CbServer.Items.Clear();
                    CbServer.Items.Add(ser);
                    //CbServer.Text = ser;
                    connString = log;
                }
            }
        }
        #endregion

        #region 窗体按键事件
        /// <summary>
        /// 窗体按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter按键
            if (e.Key == Key.Enter)
            {
                BtnConn_Click(null, null);
            }

        }
        #endregion

        #region 获取日志文件里面的数据库连接信息进行赋值
        /// <summary>
        /// 获取日志文件里面的数据库连接信息进行赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbServer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConnectionInfo info = GetConnectionInfo(CbServer.SelectedItem.ToString());
            if (info != null)
            {
                TxtDbName.Text = info.DataBase;
                TxtUserId.Text = info.UserId;
                TxtUserPass.Password = info.Password;

            }
        }

        #endregion

        #region 获取ConnectionInfo对象信息

        /// <summary>
        /// 获取ConnectionInfo对象信息
        /// </summary>
        /// <returns></returns>
        private ConnectionInfo GetConnectionInfo(string server)
        {
            if (string.IsNullOrEmpty(server))
                return null;
            if (string.IsNullOrEmpty(connString))
                return null;
            string[] s = connString.Split('|');
            if (s.Length != 4)
                return null;
            ConnectionInfo info = new ConnectionInfo
            {
                Server = s[0],
                DataBase = s[1],
                UserId = s[2],
                Password = s[3]
            };
            return info;
        }

        #endregion
    }
}
