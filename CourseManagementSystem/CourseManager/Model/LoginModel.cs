using CourseManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Model
{
    /// <summary>
    /// 登录Model
    /// </summary>
    public class LoginModel : NotifyBase
    {
        private string _username = "admin";

        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                this.DoNofity();
            }
        }

        private string _password = "111";
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.DoNofity();
            }
        }

        private string _validationCode = "abc";
        public string ValidationCode
        {
            get { return _validationCode; }
            set
            {
                _validationCode = value;
                this.DoNofity();
            }
        }
    }
}
