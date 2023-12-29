using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel()
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
        }



        public string Title { get; set; } = "ToDo";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }


        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        private string  password;

        public string  Password
        {
            get { return password; }
            set { password = value; }
        }


        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login": Login();break;
                case "LoginOut":LoginOut();break;

            }
        }

        #region 登录方法

        private void LoginOut()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 退出方法

        private void Login()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
