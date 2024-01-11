using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Windows;


namespace StoreManagement.ViewModel
{
    public class InStoreViewModel : ViewModelBase
    {
        private InStore inStore = new InStore();

        public InStore InStore
        {
            get { return inStore; }
            set { inStore = value; RaisePropertyChanged(); }
        }


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
