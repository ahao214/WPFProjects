using Joker.SmartPacking.Server.IService;
using Microsoft.EntityFrameworkCore;
using System;

namespace Joker.SmartPacking.Server.Service
{
    public class LoginService : ILoginService
    {
        DbContext _context;
        public LoginService(IEFContext.IEFContext efContext)
        {
            _context = efContext.CreateDBContext();
        }

        public void Get(string un, string pwd)
        {


        }
    }
}
