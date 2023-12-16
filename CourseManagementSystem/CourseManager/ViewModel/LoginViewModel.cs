using CourseManager.Common;
using CourseManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManager.ViewModel
{
    public class LoginViewModel
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();


        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        public CommandBase CloseWindowCommand { get; set; }

        /// <summary>
        /// 登录按钮事件
        /// </summary>
        public CommandBase LoginCommand { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }


        public LoginViewModel()
        {
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });

            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });

        }

        /// <summary>
        /// 登录逻辑
        /// </summary>
        /// <param name="o"></param>
        private void DoLogin(object o)
        {
            this.ErrorMsg = string.Empty;
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMsg = "请输入用户名";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMsg = "密码不能为空";
                return;
            }
        }



    }
}
