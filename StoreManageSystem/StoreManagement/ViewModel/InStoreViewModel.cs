using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Model;
using StoreManagement.Service;
using StoreManagement.View;
using StoreManagement.Windows;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Windows;


namespace StoreManagement.ViewModel
{
    public class InStoreViewModel : ViewModelBase
    {


        private Goods goods;

        public Goods Goods
        {
            get { return goods; }
            set { goods = value; }
        }

        #region 物资类别

        private List<GoodsType> goodsTypeList = new List<GoodsType>();
        /// <summary>
        /// 物资类别集合
        /// </summary>
        public List<GoodsType> GoodsTypeList
        {
            get { return goodsTypeList; }
            set { goodsTypeList = value; RaisePropertyChanged(); }
        }

        private GoodsType goodsType = new GoodsType();
        /// <summary>
        /// 物资类别
        /// </summary>
        public GoodsType GoodsType
        {
            get { return goodsType; }
            set { goodsType = value; RaisePropertyChanged(); }
        }

        #endregion


        #region 物资规格

        private List<Spec> specList = new List<Spec>();
        /// <summary>
        /// 物资规格集合
        /// </summary>
        public List<Spec> SpecList
        {
            get { return specList; }
            set { specList = value; RaisePropertyChanged(); }
        }

        private Spec spec = new Spec();
        /// <summary>
        /// 物资规格
        /// </summary>
        public Spec Spec
        {
            get { return spec; }
            set { spec = value; RaisePropertyChanged(); }
        }
        #endregion

        #region 仓库

        private List<Store> storeList = new List<Store>();
        /// <summary>
        /// 仓库集合
        /// </summary>
        public List<Store> StoreList
        {
            get { return storeList; }
            set { storeList = value; RaisePropertyChanged(); }
        }

        private Store store = new Store();
        /// <summary>
        /// 仓库
        /// </summary>
        public Store Store
        {
            get { return store; }
            set { store = value; RaisePropertyChanged(); }
        }

        #endregion

        #region 供应商

        private List<Supplier> supplierList = new List<Supplier>();
        /// <summary>
        /// 供应商集合
        /// </summary>
        public List<Supplier> SupplierList
        {
            get { return supplierList; }
            set { supplierList = value; RaisePropertyChanged(); }
        }

        private Supplier supplier = new Supplier();
        /// <summary>
        /// 供应商
        /// </summary>
        public Supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; RaisePropertyChanged(); }
        }

        #endregion


        #region 入库

        private InStoreEx inStore = new InStoreEx();

        public InStoreEx InStore
        {
            get { return inStore; }
            set { inStore = value; RaisePropertyChanged(); }
        }

        private List<InStore> inStoreList = new List<InStore>();
        /// <summary>
        /// 入库
        /// </summary>
        public List<InStore> InStoreList
        {
            get { return inStoreList; }
            set { inStoreList = value; RaisePropertyChanged(); }
        }

        #endregion

        /// <summary>
        /// 打开物资选择窗口
        /// </summary>
        public RelayCommand OpenSelectGoodsWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var window = new SelectGoodsWindow();
                    var result = window.ShowDialog();
                    if (result.HasValue && result.Value == true)
                    {
                        var vm = window.DataContext as SelectGoodsViewModel;
                        InStore.GoodsSerial = vm.Goods.Serial;
                        InStore.Name = vm.Goods.Name;
                    }
                });
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public RelayCommand LoadCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    StoreList = new StoreService().Select();
                    SupplierList = new SupplierService().Select();
                    InStoreList = new InStoreService().Select();
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
                    if (!(obj is InStoreView view))
                        return;

                    if (string.IsNullOrEmpty(InStore.Name) == true ||
                    string.IsNullOrEmpty(InStore.GoodsSerial) == true)
                    {
                        MessageBox.Show("序号和名称不能为空");
                        return;
                    }

                    InStore.InsertDate = DateTime.Now;
                    InStore.UserInfoId = AppData.Instance.User.Id;

                    if (Store.Id == 0)
                    {
                        MessageBox.Show("仓库不能为空");
                        return;
                    }

                    if (Supplier.Id == 0)
                    {
                        MessageBox.Show("供应商不能为空");
                        return;
                    }

                    InStore.StoreId = Store.Id;
                    InStore.SupplierId = Supplier.Id;

                    var service = new InStoreService();
                    int count = service.Insert(InStore);
                    if (count > 0)
                    {
                        InStoreList = service.Select();
                        MessageBox.Show("操作成功");
                        InStore = new InStoreEx();
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
        //public RelayCommand<Button> EditCommand
        //{
        //    get
        //    {
        //        var command = new RelayCommand<Button>((view) =>
        //        {
        //            var old = view.Tag as Goods;
        //            if (old == null)
        //                return;
        //            var vm = ServiceLocator.Current.GetInstance<EditGoodsViewModel>();

        //            vm.Goods = old;
        //            vm.GoodsType = vm.GoodsTypeList.FirstOrDefault(t => t.Id == old.GoodsTypeId);
        //            vm.Spec = vm.SpecList.FirstOrDefault(t => t.Id == old.SpecId);


        //            var window = new EditGoodsWindow();
        //            window.ShowDialog();
        //            GoodsList = new GoodsService().Select();
        //        });
        //        return command;
        //    }
        //}

        /// <summary>
        /// 删除
        /// </summary>
        //public RelayCommand<Button> DeleteCommand
        //{
        //    get
        //    {
        //        var command = new RelayCommand<Button>((view) =>
        //        {
        //            if (MessageBox.Show("是否执行操作?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //            {
        //                var old = view.Tag as Goods;
        //                if (old == null)
        //                    return;
        //                var service = new GoodsService();
        //                int count = service.Delete(old);
        //                if (count > 0)
        //                {
        //                    GoodsList = service.Select();
        //                    MessageBox.Show("操作成功");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("操作失败");
        //                }
        //            }
        //        });
        //        return command;
        //    }
        //}
    }
}
