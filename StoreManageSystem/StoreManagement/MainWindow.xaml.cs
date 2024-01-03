using StoreManagement.View;
using StoreManagement.Windows;
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

namespace StoreManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                container.Content = new IndexView();

            };

        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBlockPwd_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var window = new EditPasswordWindow();
            window.ShowDialog();
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var window = new EditUserWindow();
            window.ShowDialog();
        }
    }
}
