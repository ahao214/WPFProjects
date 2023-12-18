using Joker.SmartPacking.Server.EFCore;
using Joker.SmartPacking.Server.IEFContext;
using System;

namespace Joker.SmartPacking.Server.EFContext
{
    public class EFContext : IEFContext.IEFContext
    {
        IConfiguration.IConfiguration _configuration;
        public EFContext(IConfiguration.IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EFCoreContext CreateDBContext()
        {
            return new EFCoreContext(_configuration.Read("DBConnectionStrings"));
        }
    }
}
