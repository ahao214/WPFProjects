using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 物资设置
    /// </summary>
    public class GoodsTypeViewModel:ViewModelBase
    {
        public GoodsTypeViewModel()
        {
            GoodsTypeList = new GoodsTypeService().Select();
        }

        private GoodsType goodsType = new GoodsType();
        public GoodsType GoodsType
        {
            get { return goodsType; }
            set { goodsType = value; RaisePropertyChanged(); }
        }

        private List<GoodsType> goodsTypeList = new List<GoodsType>();
        public List<GoodsType> GoodsTypeList
        {
            get { return goodsTypeList; }
            set { goodsTypeList = value; RaisePropertyChanged(); }
        }

        //增加
        public RelayCommand<UserControl> AddCommand
        {
            get
            {

            }
        }
    }
}
