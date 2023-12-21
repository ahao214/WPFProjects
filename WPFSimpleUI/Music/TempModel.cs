using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        public ICommand LoginCommand { get; set; }  

        public ICommand CancelRemberCommand { get; set; }   


        public TempModel()
        {
            //LoginCommand= new RelayCommand(LoginAction);
            //CancelRemberCommand = new RelayCommand<bool>(CancelAction);

            Account = "root";
            LoginTypes= new List<string> ();
            LoginTypes.Add("手机号登录");
            LoginTypes.Add("账号密码登录");
            LoginTypes.Add("二维码登录");
        }

        private void CancelAction(bool obj)
        {
            MessageBox.Show($"check status{obj}");
        }


        private void LoginAction()
        {
            if(Account == "root" && Password=="111")
            {
                MessageBox.Show("Login Successful");
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

        }
    }
}
