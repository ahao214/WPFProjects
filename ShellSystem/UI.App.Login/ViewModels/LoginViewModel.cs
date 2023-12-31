
namespace UI.App.Login.ViewModels
{
    /// <summary>
    /// 登录
    /// </summary>
    internal class LoginViewModel
    {
        public string Title { get; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version => System.Windows.Application.ResourceAssembly.GetName().Version.ToString();
    }
}
