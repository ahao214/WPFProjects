using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 编辑用户
    /// </summary>
    public class EditUserViewModel : ViewModelBase
    {
        private UserInfo user = AppData.Instance.User;
        public UserInfo User
        {
            get { return user; }
            set { user = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 确认
        /// </summary>
        public RelayCommand<Window> OKCommand
        {
            get
            {
                var command = new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(User.Name) == true)
                    {
                        MessageBox.Show("用户名不能为空");
                        return;
                    }

                    UserInfoService service = new UserInfoService();
                    int count = service.Update(User);
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

        /// <summary>
        /// 取消
        /// </summary>
        public RelayCommand<Window> CancelCommand
        {
            get
            {
                var command = new RelayCommand<Window>((window) =>
                {
                    window.Close();
                });
                return command;
            }
        }

    }
}
