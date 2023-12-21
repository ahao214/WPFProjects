using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Joker.SmartPacking.Client.MainModule
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // 初始化的时候，添加一个组件到对应的区域
            // 比如 左侧菜单

            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftMenuTreeRegion", typeof(Views.TreeMenuView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Views.TreeMenuView>();
        }
    }
}
