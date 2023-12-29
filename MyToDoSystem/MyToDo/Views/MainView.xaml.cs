using MaterialDesignThemes.Wpf;
using MyToDo.Common;
using MyToDo.Extensions;
using Prism.Events;
using System.Windows;
using System.Windows.Input;

namespace MyToDo.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private readonly IDialogHostService _dialogHostService;

        public MainView(IEventAggregator aggregator, IDialogHostService dialogHostService)
        {
            InitializeComponent();

            // 注册等待消息窗口
            aggregator.Register(arg =>
            {
                DialogHost.IsOpen = arg.IsOpen;
                if (DialogHost.IsOpen)
                {
                    DialogHost.DialogContent = new ProgressView();
                }
            });

            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };
            btnClose.Click += async (s, e) =>
            {
                var result = await dialogHostService.Question("温馨提示", "确认退出系统?");
                if (result.Result != Prism.Services.Dialogs.ButtonResult.OK)
                {
                    return;
                }
                this.Close();
            };
            ColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
            ColorZone.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            };

            menuBar.SelectionChanged += (s, e) =>
            {
                // 菜单点击之后，菜单隐藏
                drawerHost.IsLeftDrawerOpen = false;
            };
            _dialogHostService = dialogHostService;
        }
    }
}
