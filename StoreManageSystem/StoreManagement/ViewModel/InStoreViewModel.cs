using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Model;
using StoreManagement.Windows;


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

    }
}
