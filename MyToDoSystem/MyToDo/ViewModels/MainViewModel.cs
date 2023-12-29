using MyToDo.Common;
using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;


namespace MyToDo.ViewModels
{
    public class MainViewModel : BindableBase, IConfigureService
    {
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager _regionManager;

        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();            
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
           
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });
            _regionManager = regionManager;
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
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal = back.Context.NavigationService.Journal;
            });

        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        // 向后走命令
        public DelegateCommand GoBackCommand { get; private set; }
        // 向前走命令
        public DelegateCommand GoForwardCommand { get; private set; }

        private IRegionNavigationJournal journal;


        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });

        }

        /// <summary>
        /// 配置首页初始化参数
        /// </summary>
        public void Configure()
        {
            CreateMenuBar();
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");

        }
    }
}
