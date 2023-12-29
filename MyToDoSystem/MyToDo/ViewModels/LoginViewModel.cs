﻿using MyToDo.Extensions;
using MyToDo.Services;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace MyToDo.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private readonly ILoginService loginService;
        private readonly IEventAggregator aggregator;

        public LoginViewModel(ILoginService loginService, IEventAggregator aggregator)
        {
            UserDto = new ResgiterUserDto();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.loginService = loginService;
            this.aggregator = aggregator;
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

        #region Login

        private int selectIndex;

        public int SelectIndex
        {
            get { return selectIndex; }
            set { selectIndex = value; RaisePropertyChanged(); }
        }


        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; RaisePropertyChanged(); }
        }

        private string passWord;


        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
                // 注册账号
                case "Register": Resgiter(); break;
                // 跳转注册页面
                case "Go": SelectedIndex = 1; break;
                // 返回登录页面
                case "Return": SelectedIndex = 0; break;
            }
        }

        private ResgiterUserDto userDto;

        public ResgiterUserDto UserDto
        {
            get { return userDto; }
            set { userDto = value; RaisePropertyChanged(); }
        }

        async void Login()
        {
            if (string.IsNullOrWhiteSpace(account) ||
                string.IsNullOrWhiteSpace(PassWord))
            {
                aggregator.SendMessage("用户名或密码不能为空", "Login");
                return;
            }

            var loginResult = await loginService.LoginAsync(new Shared.Dtos.UserDto()
            {
                Account = Account,
                PassWord = PassWord,
                UserName = Account
            });

            if (loginResult != null && loginResult.Status)
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                return;
            }
            else
            {
                //登录失败提示...
                aggregator.SendMessage(loginResult.Message, "Login");
            }
        }

        private async void Resgiter()
        {
            if (string.IsNullOrWhiteSpace(UserDto.Account) ||
                string.IsNullOrWhiteSpace(UserDto.UserName) ||
                string.IsNullOrWhiteSpace(UserDto.PassWord) ||
                string.IsNullOrWhiteSpace(UserDto.NewpassWord))
            {
                aggregator.SendMessage("请输入完整的注册信息！", "Login");
                return;
            }

            if (UserDto.PassWord != UserDto.NewpassWord)
            {
                aggregator.SendMessage("密码不一致,请重新输入！", "Login");
                return;
            }

            var resgiterResult = await loginService.RegisterAsync(new Shared.Dtos.UserDto()
            {
                Account = UserDto.Account,
                UserName = UserDto.UserName,
                PassWord = UserDto.PassWord
            });

            if (resgiterResult != null && resgiterResult.Status)
            {
                aggregator.SendMessage("注册成功", "Login");
                //注册成功,返回登录页页面
                SelectedIndex = 0;
                return;
            }
            else
            {
                aggregator.SendMessage(resgiterResult.Message, "Login");
            }
        }

        void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        #endregion
    }
}
