using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using Shell.Views;
using Prism.Modularity;
using Core.Tools;

namespace Shell
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            MainWindow window = new MainWindow();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            // 加载自己写的模块，比如加载Core.Tools模块
            moduleCatalog.AddModule<CoreToolsModule>(); //加载工具模块



        }

        protected override IModuleCatalog CreateModuleCatalog()
        {

            return new DirectoryModuleCatalog()
            {
                ModulePath = @".\Modules"
            };  // 配置模块目录


        }



    }
}
