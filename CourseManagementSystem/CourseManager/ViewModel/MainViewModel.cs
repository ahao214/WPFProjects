using CourseManager.Common;
using CourseManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManager.ViewModel
{
    /// <summary>
    /// 主页面
    /// </summary>
    public class MainViewModel : NotifyBase
    {
        public UserModel UserInfo { get; set; }

        private int _searchText;

        public int SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.DoNofity(); }
        }


        private FrameworkElement _mainContent;

        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set { _mainContent = value; this.DoNofity(); }
        }

        public CommandBase NavChangedCommand { get; set; }
        public MainViewModel()
        {
            UserInfo = new UserModel();
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExecute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExecute = new Func<object, bool>((o) => true);
        }

        /// <summary>
        /// 首页按钮切换
        /// </summary>
        /// <param name="obj"></param>
        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType("CourseManager.View." + obj.ToString());

            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);


        }



    }
}
