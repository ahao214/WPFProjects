using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using ReactiveUI;
using System;
using System.Windows.Input;
using UI.Application.Share.Names;

namespace Shell.ViewModels
{
    internal class MainWindowViewModel : ReactiveObject
    {
        private readonly IModuleManager _moduleManager;

        private IRegionManager _regionManager { get; }
        public ICommand LoadCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager,IModuleManager moduleManager)
        {
            _regionManager = regionManager;
            _moduleManager = moduleManager;
            LoadCommand = new DelegateCommand(LoadWindow);
        }


        #region 登录窗体函数
        /// <summary>
        /// 登录窗体函数
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadWindow()
        {
            // 加载模块
            //_moduleManager.LoadModule("ApplicationLoginModule");
            // 请求导航
            _regionManager.RequestNavigate(RegionNames.MainRegion, "LoginView");

        }

        #endregion
    }
}
