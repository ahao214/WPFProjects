using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Model;
using StoreManagement.Service;
using StoreManagement.Windows;
using System.Collections.Generic;


namespace StoreManagement.ViewModel
{
    public class InStoreViewModel : ViewModelBase
    {
        private InStoreEx inStore = new InStoreEx();

        public InStoreEx InStore
        {
            get { return inStore; }
            set { inStore = value; RaisePropertyChanged(); }
        }

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
                    GoodsTypeList = new GoodsTypeService().Select();
                    SpecList = new SpecService().Select();
                    StoreList = new StoreService().Select();
                    SupplierList = new SupplierService().Select();
                });
            }
        }

    }
}
