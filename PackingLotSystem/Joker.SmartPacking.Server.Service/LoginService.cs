using Joker.SmartPacking.Server.IService;
using Microsoft.EntityFrameworkCore;
using System;

namespace Joker.SmartPacking.Server.Service
{
    public class LoginService :ServiceBase, ILoginService
    {
        public LoginService(IEFContext.IEFContext efContext):base(efContext)
        {
            
        }

      
    }
}
