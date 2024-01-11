using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.ViewModel
{
    public class SelectGoodsViewModel : ViewModelBase
    {
        

        public SelectGoodsViewModel()
        {

        }

        private Goods goods = new Goods();

        public Goods Goods
        {
            get { return goods; }
            set { goods = value; RaisePropertyChanged(); }
        }

        private List<Goods> goodsList = new List<Goods>();

        public List<Goods> GoodsList
        {
            get { return goodsList; }
            set { goodsList = value; RaisePropertyChanged(); }
        }

        public RelayCommand LoadCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    GoodsList = new GoodsService().Select();
                });
            }
        }

    }
}
