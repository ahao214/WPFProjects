using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using StoreManagement.View;
using StoreManagement.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
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
            GoodsTypeList = new GoodsTypeService().Select();
            SpecList = new SpecService().Select();
        }
        private Goods goods = new Goods();

        public Goods Goods
        {
            get { return goods; }
            set { goods = value; RaisePropertyChanged(); }
        }

        private List<Goods> goodsList;
        public List<Goods> GoodsList
        {
            get { return goodsList; }
            set { goodsList = value; RaisePropertyChanged(); }
        }

        private List<GoodsType> goodsTypeList = new List<GoodsType>();
        /// <summary>
        /// 物资类别集合
        /// </summary>
        public List<GoodsType> GoodsTypeList
        {
            get { return goodsTypeList; }
            set { goodsTypeList = value; RaisePropertyChanged(); }
        }

        private List<Spec> specList = new List<Spec>();
        /// <summary>
        /// 物资规格
        /// </summary>
        public List<Spec> SpecList
        {
            get { return specList; }
            set { specList = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 加载页面时获取数据
        /// </summary>
        public RelayCommand LoadCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    GoodsList = new GoodsService().Select();
                    GoodsTypeList = new GoodsTypeService().Select();
                    SpecList = new SpecService().Select();
                });

            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        public RelayCommand<UserControl> AddCommand
        {
            get
            {
                var command = new RelayCommand<UserControl>((obj) =>
                {
                    if (!(obj is GoodsView view))
                        return;

                    if (string.IsNullOrEmpty(Goods.Name) == true ||
                    string.IsNullOrEmpty(Goods.Serial) == true)
                    {
                        MessageBox.Show("序号和名称不能为空");
                        return;
                    }

                    Goods.InsertDate = DateTime.Now;
                    Goods.UserInfoId = AppData.Instance.User.Id;
                    var goodsTye = view.comboboxGoodsType.SelectedItem as GoodsType;
                    var spec = view.comboboxSpec.SelectedItem as Spec;
                    if (goodsTye != null)
                    {
                        Goods.GoodsTypeId = goodsTye.Id;
                    }
                    if (spec != null)
                    {
                        Goods.SpecId = spec.Id;
                    }
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
                    var vm = ServiceLocator.Current.GetInstance<EditGoodsViewModel>();

                    vm.Goods = old;
                    vm.GoodsType = vm.GoodsTypeList.FirstOrDefault(t => t.Id == old.GoodsTypeId);
                    vm.Spec = vm.SpecList.FirstOrDefault(t => t.Id == old.SpecId);


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
