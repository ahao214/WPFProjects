using Microsoft.EntityFrameworkCore;
using System;

namespace Joker.SmartPacking.Server.EFCore
{    
    public class EFCoreContext:DbContext
    {
        private string strConn = "Data Source=LAPTOP-3HE8JVHO;Initial Catalog=ParkingLotDB;User ID=sa;Pwd=hao@chen214";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
