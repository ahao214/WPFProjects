using Joker.SmartPacking.Client.IBLL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Joker.SmartPacking.Client.Start.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        ILoginBll _loginBLL

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


        private void OnLogin(object obj)
        {
            try
            {
                this.ErrorMsg = string.Empty;
                if (string.IsNullOrEmpty(this.UserName))
                {
                    this.ErrorMsg = "请输入用户名";
                    return;
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    this.ErrorMsg = "请输入密码";
                    return;
                }

                // 登录操作
                if(_loginBLL.Login(this.UserName, this.Password).GetAwaiter().GetResult())
                {
                    // 关闭登录窗口，并且DialogResult返回True

                }

            }
            catch (Exception err)
            {

                throw;
            }
        }


    }
}
