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
        private string _userName = "admin";

        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }

        private string _password;

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
                if(string.IsNullOrEmpty (this .UserName ))
                {
                    this.ErrorMsg = "请输入用户名";
                    return;
                }
                if(string .IsNullOrEmpty (this .Password ))
                {
                    this.ErrorMsg = "请输入密码";
                    return;
                }
            }
            catch (Exception err)
            {

                throw;
            }
        }


    }
}
