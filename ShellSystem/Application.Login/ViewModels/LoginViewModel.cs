using ReactiveUI;


namespace Application.Login.ViewModels
{
    /// <summary>
    /// 登录
    /// </summary>
    internal class LoginViewModel:ReactiveObject
    {

        public string Title { get; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version =>System.Windows.Application.ResourceAssembly .GetName ().Version.ToString();

    }
}
