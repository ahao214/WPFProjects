using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MyToDo.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager _regionManager;


        public SettingsViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            _regionManager = regionManager; 
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
        }


        /// <summary>
        /// 切换导航
        /// </summary>
        /// <param name="bar"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;
            _regionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(obj.NameSpace);

        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar { Icon = "Home", Title = "个性化", NameSpace = "SkinView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookOutline", Title = "系统设置", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookPlus", Title = "关于更多", NameSpace = "AboutView" });         

        }
    }
}
