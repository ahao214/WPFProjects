using Joker.SmartPacking.Client.BLL;
using Joker.SmartPacking.Client.DAL;
using Joker.SmartPacking.Client.IBLL;
using Joker.SmartPacking.Client.IDAL;
using Joker.SmartPacking.Client.Start.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Joker.SmartPacking.Client.Start
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            // 先打开登录窗口，如果登录成功，则打开主窗口
            if (Container.Resolve<LoginView>().ShowDialog() == false)
            {
                Application.Current?.Shutdown();
            }
            else
            {
                base.InitializeShell(shell);
            }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册
            containerRegistry.Register<ILoginDal, LoginDal>();
            containerRegistry.Register<ILoginBll, LoginBll>();
        }
    }
}
