using Joker.SmartPacking.Server.EFCore;
using Joker.SmartPacking.Server.IEFContext;
using System;

namespace Joker.SmartPacking.Server.EFContext
{
    public class EFContext : IEFContext.IEFContext
    {

        public EFCoreContext CreateDBContext()
        {
            return new EFCoreContext();

        }
    }
}
