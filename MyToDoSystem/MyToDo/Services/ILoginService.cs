using MyToDo.Shared;
using MyToDo.Shared.Dtos;

namespace MyToDo.Services
{
    /// <summary>
    /// 登录服务接口
    /// </summary>
    public interface ILoginService 
    {
        Task<ApiResponse<UserDto>> LoginAsync(UserDto dto);

        Task<ApiResponse> RegisterAsync(UserDto user);

    }
}
