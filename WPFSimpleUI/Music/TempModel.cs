using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class TempModel
    {
        private string _account;

        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;   
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private List<string> _loginTypes;
        public List <string >LoginTypes
        {
            get { return _loginTypes; }
            set { _loginTypes = value; }
        }

        public TempModel()
        {
            Account = "root";
            LoginTypes= new List<string> ();
            LoginTypes.Add("手机号登录");
            LoginTypes.Add("账号密码登录");
            LoginTypes.Add("二维码登录");
        }

    }
}
