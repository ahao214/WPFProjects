using CourseManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Model
{
    public class UserModel : NotifyBase
    {
        private string _avatar;

        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; this.DoNofity(); }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; this.DoNofity(); }
        }

        private int _gender;

        public int Gender
        {
            get { return _gender; }
            set { _gender = value; this.DoNofity(); }
        }



    }
}
