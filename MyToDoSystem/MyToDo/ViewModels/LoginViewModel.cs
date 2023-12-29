using MyToDo.Services;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyToDo.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel(ILoginService loginService)
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            _loginService = loginService;
        }

        public string Title { get; set; } = "ToDo";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        private string password;
        private readonly ILoginService _loginService;
        private readonly IEventAggregator _aggregator;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        private ResgiterUserDto userDto;

        public ResgiterUserDto UserDto
        {
            get { return userDto; }
            set { userDto = value; RaisePropertyChanged(); }
        }


        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
                // 返回登录页面
                case "ResgiterPage": SelectedIndex = 1; break;
                // 注册账号
                case "Register": Register(); break;
                // 跳转注册页面
                case "Return": SelectedIndex = 0; break;
            }
        }

        private async void Register()
        {
            if (string.IsNullOrEmpty(UserDto.UserName) || string.IsNullOrEmpty(UserDto.Account) || string.IsNullOrEmpty(UserDto.PassWord) || string.IsNullOrEmpty(UserDto.NewPassWord))
            {
                return;
            }
            if (UserDto.PassWord != UserDto.NewPassWord)
            {
                return;
            }

            var regResult = await _loginService.ResgiterAsync(new Shared.Dtos.UserDto()
            {
                Account = UserDto.Account,
                UserName = UserDto.UserName,
                PassWord = UserDto.PassWord
            });

            if (regResult != null || regResult.Status)
            {
                SelectedIndex = 0;

            }

        }

        

        #region 登录方法

        private async void Login()
        {
            if (string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Password))
            {
                return;
            }

            var loginResult = await _loginService.LoginAsync(new Shared.Dtos.UserDto()
            {
                Account = Account,
                PassWord = Password
            });

            if (loginResult.Status)
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            }
            // 登录失败

        }

        #endregion

        #region 退出方法 

        private void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        #endregion
    }
}
