using Application.Login.Views;
using Application.Share.Names;
using Prism.Ioc;
using Prism.Modularity;



namespace Application.Login
{
    /// <summary>
    /// 登录模块
    /// </summary>
    [Module(ModuleName = ModuleNames.ApplicationLoginModule)]
    public class ApplicationLoginModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册LoginView
            containerRegistry.RegisterForNavigation<LoginView>
                ();

        }
    }
}
