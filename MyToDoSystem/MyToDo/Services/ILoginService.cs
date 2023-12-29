using MyToDo.Shared;
using MyToDo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    /// <summary>
    /// 登录服务接口
    /// </summary>
    public interface ILoginService 
    {
        Task<ApiResponse> LoginAsync(UserDto dto);

        Task<ApiResponse> ResgiterAsync(UserDto user);

    }
}
