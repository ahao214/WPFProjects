/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:StoreManagement"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using StoreManagement.Service;


namespace StoreManagement.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<EditPasswordViewModel>();
            SimpleIoc.Default.Register<EditUserViewModel>();

            #region 基础数据
            SimpleIoc.Default.Register<GoodsTypeViewModel>();
            SimpleIoc.Default.Register<GoodsViewModel>();
            SimpleIoc.Default.Register<StoreViewModel>();
            SimpleIoc.Default.Register<SupplierViewModel>();
            SimpleIoc.Default.Register<EditGoodsTypeViewModel>();
            SimpleIoc.Default.Register<EditGoodsViewModel>();
            SimpleIoc.Default.Register<EditStoreViewModel>();
            SimpleIoc.Default.Register<EditSupplierViewModel>();

            SimpleIoc.Default.Register<SpecViewModel>();
            SimpleIoc.Default.Register<EditSpecViewModel>();

            #endregion

            #region 入库

            SimpleIoc.Default.Register<InStoreViewModel>();

            #endregion

            SimpleIoc.Default.Register<SelectGoodsViewModel>();

            SimpleIoc.Default.Register<CustomerViewModel>();
            SimpleIoc.Default.Register<EditCustomerViewModel>();

            SimpleIoc.Default.Register<OutStoreViewModel>();

            SimpleIoc.Default.Register<QuantViewModel>();
            SimpleIoc.Default.Register<InventoryViewModel>();

            SimpleIoc.Default.Register<QuantInStoreViewModel>();



        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public EditPasswordViewModel EditPassword
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditPasswordViewModel>();
            }
        }

        public EditUserViewModel EditUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditUserViewModel>();
            }
        }

        #region 基础数据
        public GoodsTypeViewModel GoodsType
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GoodsTypeViewModel>();
            }
        }

        public GoodsViewModel Goods
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GoodsViewModel>();
            }
        }

        public StoreViewModel Store
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StoreViewModel>();
            }
        }

        public SupplierViewModel Supplier
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SupplierViewModel>();
            }
        }

        public EditGoodsTypeViewModel EditGoodsType
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditGoodsTypeViewModel>();
            }
        }

        public EditStoreViewModel EditStore
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditStoreViewModel>();
            }
        }

        public EditSupplierViewModel EditSupplier
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditSupplierViewModel>();
            }
        }

        public EditGoodsViewModel EditGoods
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditGoodsViewModel>();
            }
        }

        public SpecViewModel Spec
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SpecViewModel>();
            }
        }

        public EditSpecViewModel EditSpec
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditSpecViewModel>();
            }
        }

        #endregion


        #region 入库

        public InStoreViewModel InStore
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InStoreViewModel>();
            }
        }

        #endregion

        public SelectGoodsViewModel SelectGoods
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelectGoodsViewModel>();
            }
        }

        public CustomerViewModel Customer
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomerViewModel>();
            }
        }

        public EditCustomerViewModel EditCustomer
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditCustomerViewModel>();
            }
        }

        public OutStoreViewModel OutStore
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OutStoreViewModel>();
            }
        }

        public QuantViewModel Quant
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuantViewModel>();
            }
        }

        public InventoryViewModel Inventory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InventoryViewModel>();
            }
        }

        public QuantInStoreViewModel QuantInStore
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuantInStoreViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}