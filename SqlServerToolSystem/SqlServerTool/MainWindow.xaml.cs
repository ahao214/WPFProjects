using SqlServerTool.DatabaseHelper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlServerTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 对话框标题信息
        /// </summary>
        private const string Caption = "信息提示";

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

                }
                else
                {
                    MessageBox.Show("登录失败", Caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
