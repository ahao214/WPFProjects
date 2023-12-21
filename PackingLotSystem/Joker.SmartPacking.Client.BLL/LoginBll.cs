using Joker.SmartPacking.Client.Entity;
using Joker.SmartPacking.Client.IBLL;
using Joker.SmartPacking.Client.IDAL;
using System;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Client.BLL
{
    public class LoginBll : ILoginBll
    {
        ILoginDal _loginDal;
        public LoginBll(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public async Task<bool> Login(string username, string password)
        {
            var loginStr = await _loginDal.Login(username, password);
            // 用户信息反序列化
            UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(loginStr);
            if (userEntity != null)
            {
                return true;
            }

            return false;
        }
    }
}
