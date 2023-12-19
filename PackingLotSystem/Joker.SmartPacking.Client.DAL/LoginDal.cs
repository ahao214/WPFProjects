using Joker.SmartPacking.Client.IDAL;
using System;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Client.DAL
{
    public class LoginDal : ILoginDal
    {
        public Task<string> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
