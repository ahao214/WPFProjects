﻿using MyToDo.Extensions;
using Prism.Events;
using System.Windows.Controls;

namespace MyToDo.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView(IEventAggregator aggregator)
        {
            InitializeComponent();
            //注册提示消息
            aggregator.RegisterMessage(arg =>
            {
                LoginSnakeBar.MessageQueue.Enqueue(arg.Message);
            }, "Login");
        }
    }
}
