using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public class AppData:ViewModelBase
    {
        public static AppData Instance { get; private set; } = new Lazy<AppData>().Value;

        private UserInfo user = new UserInfo() { Name = "admin", Password = "1" };
        public UserInfo User
        {
            get { return user; }
            set { user = value; RaisePropertyChanged(); }
        }

    }
}
