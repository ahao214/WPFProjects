using Joker.SmartPacking.Server.EFCore;
using System;

namespace Joker.SmartPacking.Server.IEFContext
{
    public interface IEFContext
    {
        EFCoreContext CreateDBContext();


    }
}
