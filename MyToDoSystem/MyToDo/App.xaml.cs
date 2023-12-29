using DryIoc;
using MyToDo.Common;
using MyToDo.Services;
using MyToDo.ViewModels;
using MyToDo.ViewModels.Dialogs;
using MyToDo.Views;
using MyToDo.Views.Dialogs;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Windows;

namespace MyToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            //设置启动窗口:MainWindow
            return Container.Resolve<MainView>();
        }

        public static void LoginOut(IContainerProvider containerProvider)
        {
            Current.MainWindow.Hide();

            var dialog = containerProvider.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }

                Current.MainWindow.Show();
            });
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    //Environment.Exit(0);
                    Application.Current.Shutdown();
                    return;
                }

                var service = App.Current.MainWindow.DataContext as IConfigureService;
                if (service != null)
                    service.Configure();
                base.OnInitialized();
            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer()
                .Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:5074/", serviceKey: "webUrl");

            containerRegistry.Register<ILoginService, LoginService>();
            containerRegistry.Register<IToDoService, ToDoService>();
            containerRegistry.Register<IMemoService, MemoService>();
            containerRegistry.Register<IDialogHostService, DialogHostService>();

            containerRegistry.RegisterForNavigation<AddToDoView,AddToDoViewModel>();
            containerRegistry.RegisterForNavigation<AddMemoView,AdddMemoViewModel>();

            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();

            // 导航注册
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();

            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();

            containerRegistry.RegisterForNavigation<AboutView>();
            containerRegistry.RegisterForNavigation<MsgView,MsgViewModel>();
        }
    }

}
