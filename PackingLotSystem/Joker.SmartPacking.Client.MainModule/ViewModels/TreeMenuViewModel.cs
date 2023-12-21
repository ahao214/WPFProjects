using Joker.SmartPacking.Client.Entity;
using Joker.SmartPacking.Client.MainModule.Models;
using System.Collections.Generic;


namespace Joker.SmartPacking.Client.MainModule.ViewModels
{
    /// <summary>
    /// 树形菜单
    /// </summary>
    public class TreeMenuViewModel
    {
        public List<MenuItemModel> Menus { get; set; } = new List<MenuItemModel>();

        // 列表,没有树形结构
        private List<MenuEntity> origMenus = null;

        public TreeMenuViewModel()
        {
            // 需要获取菜单数据

        }


    }
}
