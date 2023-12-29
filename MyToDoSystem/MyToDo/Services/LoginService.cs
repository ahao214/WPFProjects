using MyToDo.Shared;
using MyToDo.Shared.Dtos;

namespace MyToDo.Services
{
    /// <summary>
    /// 登录服务接口实现
    /// </summary>
    public class LoginService : ILoginService
    {
        private readonly HttpRestClient client;
        private readonly string serviceName = "Login";

        public LoginService(HttpRestClient client)
        {
            this.client = client;
        }

        public async Task<ApiResponse> LoginAsync(UserDto user)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Login";
            request.Parameter = user;
            return await client.ExecuteAsync(request);
        }

        public async Task<ApiResponse> RegisterAsync(UserDto user)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Register";
            request.Parameter = user;
            return await client.ExecuteAsync(request);
        }
    }
}
