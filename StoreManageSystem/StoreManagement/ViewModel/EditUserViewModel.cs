using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 编辑用户
    /// </summary>
    public class EditUserViewModel : ViewModelBase
    {
        private UserInfo user = AppData.Instance.User;
        public UserInfo User
        {
            get { return user; }
            set { user = value; RaisePropertyChanged(); }
        }





    }
}
