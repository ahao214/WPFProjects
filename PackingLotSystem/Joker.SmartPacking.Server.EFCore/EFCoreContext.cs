using Joker.SmartPacking.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Joker.SmartPacking.Server.EFCore
{
    public class EFCoreContext : DbContext
    {
        private string strConn = "Data Source=LAPTOP-3HE8JVHO;Initial Catalog=ParkingLotDB;User ID=sa;Pwd=hao@chen214";

        public EFCoreContext()
        {
           
        }

        public EFCoreContext(string strConn)
        {
            this.strConn = strConn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn);
        }

        public DbSet<SysUserInfo> SysUserInfo { get; set; }


    }
}
