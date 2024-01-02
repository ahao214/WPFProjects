using System;
using System.Windows;
using System.Windows.Controls;


namespace StoreManagement.Control
{
    /// <summary>
    /// ButtonCard.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonCard : UserControl
    {
        public ButtonCard()
        {
            InitializeComponent();
        }



        public string Logo
        {
            get { return (string)GetValue(LogoProperty); }
            set { SetValue(LogoProperty, value); }
        }

        public static readonly DependencyProperty LogoProperty =
            DependencyProperty.Register("Logo", typeof(string), typeof(ButtonCard), new PropertyMetadata("&#xe621;", new PropertyChangedCallback(OnLogoPropertyChangedCallback)));

        private static void OnLogoPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ButtonCard button)
            {
                button.textBlockLogo.Text = e.NewValue.ToString();
            }
        }


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ButtonCard), new PropertyMetadata("这是标题", new PropertyChangedCallback(OnTitlePropertyChangedCallback)));

        private static void OnTitlePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ButtonCard button)
            {
                button.textBlockTitle.Text = e.NewValue.ToString();
            }
        }


        public new string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(ButtonCard), new PropertyMetadata("这是一些对标题的文字说明", new PropertyChangedCallback(OnContentPropertyChangedCallback)));

        private static void OnContentPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ButtonCard button)
            {
                button.textBlockContent.Text = e.NewValue.ToString();
            }
        }
    }
}
