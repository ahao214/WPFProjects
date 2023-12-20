using Joker.SmartPacking.Client.IBLL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Joker.SmartPacking.Client.Start.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        ILoginBll _loginBLL;

        public LoginViewModel(ILoginBll loginBll)
        {
            _loginBLL = loginBll;
        }

        private string _userName = "admin";

        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }

        private string _password = "111";

        public string Password
        {
            get { return _password; }
            set { SetProperty<string>(ref _password, value); }
        }


        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { SetProperty<string>(ref _errorMsg, value); }
        }


        // 登录命令
        public ICommand LoginCommand
        {
            get => new DelegateCommand<object>(OnLogin);
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="obj"></param>
        private void OnLogin(object obj)
        {
            try
            {
                this.ErrorMsg = string.Empty;
                if (string.IsNullOrEmpty(this.UserName))
                {
                    throw new Exception("请输入用户名");
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    throw new Exception("请输入密码");
                }

                // 登录操作
                if (_loginBLL.Login(this.UserName, this.Password).GetAwaiter().GetResult())
                {
                    // 关闭登录窗口，并且DialogResult返回True
                    (obj as Window).DialogResult = true;
                }
                else
                {
                    throw new Exception("登录失败!用户名或密码错误");
                }
            }
            catch (Exception err)
            {

                this.ErrorMsg = "登录失败!" + err.Message;
            }
        }


    }
}
