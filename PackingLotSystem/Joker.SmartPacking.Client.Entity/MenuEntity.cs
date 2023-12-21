using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Client.Entity
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuEntity
    {
        public int MenuId { get; set; }

        public string MenuHeader { get; set; }

        public string TargetView { get; set; }

        public int ParendId { get; set; }

        public string MenuIcon { get; set; }

        public int Index { get; set; }

        public int MenuType { get; set; }

    }
}
