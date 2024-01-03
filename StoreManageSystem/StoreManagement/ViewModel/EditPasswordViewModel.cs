using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System.Linq;
using System.Windows;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class EditPasswordViewModel: ViewModelBase
    {
       

        public RelayCommand<Window> EditPasswordCommand
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
                        this.AppData.User = item;
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
