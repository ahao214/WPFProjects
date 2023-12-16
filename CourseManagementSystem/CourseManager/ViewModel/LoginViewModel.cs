using CourseManager.Common;
using CourseManager.DataAccess;
using CourseManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace CourseManager.ViewModel
{
    public class LoginViewModel:NotifyBase
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
            set { _errorMsg = value; this.DoNofity(); }
        }

        private bool  _showProgress;

        public bool ShowProgress
        {
            get { return _showProgress; }
            set { _showProgress = value; }
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
            //this.ShowProgress = Visibility.Visible;
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMsg = "请输入用户名";
                //this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMsg = "密码不能为空";
                //this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.ValidationCode))
            {
                this.ErrorMsg = "验证码不能为空";
                //this.ShowProgress = Visibility.Collapsed;
                return;
            }

            if (LoginModel.ValidationCode.ToLower() != "abc")
            {
                this.ErrorMsg = "验证码不正确";
                //this.ShowProgress = Visibility.Collapsed;
                return;
            }

            Task.Run(new Action(() =>
            {
                try
                {
                    var user = LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.Password);
                    if (user == null)
                    {
                        throw new Exception("登录失败!用户名或密码错误");
                    }
                    GlobalValues.UserInfo = user;

                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        (o as Window).DialogResult = true;
                    }));

                }
                catch (Exception ex)
                {

                    this.ErrorMsg = ex.Message;
                }
            }));
        }



    }
}
