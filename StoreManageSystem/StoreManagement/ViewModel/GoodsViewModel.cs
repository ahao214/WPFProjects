using GalaSoft.MvvmLight;
using StoreManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 物资登记
    /// </summary>
    public class GoodsViewModel : ViewModelBase
    {
        public GoodsViewModel()
        {
            GoodsList = new GoodsService().Select();
        }
        private Goods goods;

        public Goods Goods
        {
            get { return goods; }
            set { goods = value; }
        }

        private List<Goods> goodsList;
        public List<Goods> GoodsList
        {
            get { return goodsList; }
            set { goodsList = value; RaisePropertyChanged(); }
        }

    }
}
