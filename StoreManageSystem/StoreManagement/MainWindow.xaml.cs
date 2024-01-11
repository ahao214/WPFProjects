using StoreManagement.View;
using StoreManagement.Windows;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

                AutoMapper.Configration.Configure();    // 实例化Mapper
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


        private void StoreView_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button == null)
                return;

            // 获取当前程序集
            Assembly assembly = Assembly.GetExecutingAssembly();
            var space = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;
            var path = space + ".View." + button.Name;
            dynamic obj = assembly.CreateInstance(path);
            if (obj == null) return;
            container.Content = obj;
        }
    }
}
