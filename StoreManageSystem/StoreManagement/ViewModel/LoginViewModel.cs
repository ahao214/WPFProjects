using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System.Linq;
using System.Windows;


namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private UserInfo user = new UserInfo() { Name = "admin", Password = "1" };
        public UserInfo User
        {
            get { return user; }
            set { user = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        public RelayCommand<Window> LoginCommand
        {
            get
            {
                var command = new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(User.Name) == true || string.IsNullOrEmpty(User.Password) == true)
                    {
                        return;
                    }

                    UserInfoService userInfoService = new UserInfoService();
                    var users = userInfoService.Select();
                    var item = users.FirstOrDefault(t => t.Name == User.Name && t.Password == User.Password);
                    if (item != null)
                    {
                        MessageBox.Show("登录成功");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        // 关闭当前窗体
                        window.Close();
                    }
                });
                return command;
            }
        }

    }
}
