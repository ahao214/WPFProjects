using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Model
{
    /// <summary>
    /// 密码
    /// </summary>
    public class EditPasswordModel : ObservableObject
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        private string oldPassword = "";
        public string OldPassword
        {
            get { return oldPassword; }
            set { oldPassword = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 新密码
        /// </summary>
        private string newPassword = "";
        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 确认密码
        /// </summary>
        private string comfirPassword = "";
        public string ComfirPassword
        {
            get { return comfirPassword; }
            set { comfirPassword = value; RaisePropertyChanged(); }
        }
    }
}
