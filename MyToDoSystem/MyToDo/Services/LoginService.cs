using MyToDo.Shared.Dtos;
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
    public class LoginService : BaseService<UserDto>, ILoginService
    {
        public LoginService(HttpRestClient client) : base(client, "Login")
        {

        }
    }
}
