using System;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Client.IDAL
{
    public interface ILoginDal
    {
        Task<string> Login(string username, string password);

    }
}
