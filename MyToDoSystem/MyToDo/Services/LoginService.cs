using MyToDo.Shared;
using MyToDo.Shared.Dtos;
using RestSharp.Deserializers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ApiResponse> LoginAsync(UserDto dto)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Login";
            request.Parameter = dto;
            return await client.ExecuteAsync(request);

        }

        public async Task<ApiResponse> ResgiterAsync(UserDto dto)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Register";
            request.Parameter = dto;
            return await client.ExecuteAsync(request);
        }
    }
}
