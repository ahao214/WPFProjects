using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Model;
using StoreManagement.Service;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class EditPasswordViewModel : ViewModelBase
    {
        private EditPasswordModel passwordModel = new EditPasswordModel();

        public EditPasswordModel PasswordModel
        {
            get { return passwordModel; }
            set { passwordModel = value; RaisePropertyChanged(); }
        }

        public RelayCommand<Window> EditPasswordCommand
        {
            get
            {
                var command = new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(passwordModel.OldPassword) == true || string.IsNullOrEmpty(passwordModel.NewPassword) == true || string.IsNullOrEmpty(passwordModel.ConfirmPassword) == true)
                    {
                        MessageBox.Show("不能为空");
                        return;
                    }

                    if (AppData.Instance.User.Password != passwordModel.OldPassword)
                    {
                        MessageBox.Show("旧的密码错误");
                        return;
                    }
                    if (passwordModel.NewPassword != passwordModel.ConfirmPassword)
                    {
                        MessageBox.Show("两次新密码不一致");
                        return;
                    }

                    var user = AppData.Instance.User;
                    user.Password = passwordModel.NewPassword;

                    UserInfoService service = new UserInfoService();
                    int count = service.Update(user);

                    if (count > 0)
                    {
                        MessageBox.Show("修改成功");
                        // 关闭当前窗体
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                });
                return command;
            }
        }
    }
}
