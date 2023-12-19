using System;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Client.IBLL
{
    public interface ILoginBll
    {
        Task<bool> Login(string username, string password);
    }
}
