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
        public LoginModel LoginModel { get; set; }


        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        public CommandBase CloseWindowCommand { get; set; }

        public LoginViewModel()
        {
            this .LoginModel = new LoginModel();
            this.LoginModel.UserName = "Joke";
            this.LoginModel.Password = "123";


            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });

            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
        }


    }
}
