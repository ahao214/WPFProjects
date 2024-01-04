using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using StoreManagement.Windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        /// <summary>
        /// 添加
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                var command = new RelayCommand(() =>
                {
                    if (string.IsNullOrEmpty(Goods.Name) == true || 
                    string.IsNullOrEmpty(Goods.Unit))
                    {
                        MessageBox.Show("不能为空");
                        return;
                    }
                    Goods.InsertDate = DateTime.Now;
                    var service = new GoodsService();
                    int count = service.Insert(Goods);
                    if (count > 0)
                    {
                        GoodsList = service.Select();
                        MessageBox.Show("操作成功");
                        Goods = new Goods();
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                });
                return command;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public RelayCommand<Button> EditCommand
        {
            get
            {
                var command = new RelayCommand<Button>((view) =>
                {
                    var old = view.Tag as Goods;
                    if (old == null)
                        return;
                    var model = ServiceLocator.Current.GetInstance<EditGoodsViewModel>();
                    model.Goods = old;
                    var window = new EditGoodsWindow();
                    window.ShowDialog();
                    GoodsList = new GoodsService().Select();
                });
                return command;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand<Button> DeleteCommand
        {
            get
            {
                var command = new RelayCommand<Button>((view) =>
                {
                    if (MessageBox.Show("是否执行操作?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var old = view.Tag as Goods;
                        if (old == null)
                            return;
                        var service = new GoodsService();
                        int count = service.Delete(old);
                        if (count > 0)
                        {
                            GoodsList = service.Select();
                            MessageBox.Show("操作成功");
                        }
                        else
                        {
                            MessageBox.Show("操作失败");
                        }
                    }
                });
                return command;
            }
        }

    }
}
