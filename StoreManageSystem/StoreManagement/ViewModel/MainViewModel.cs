using GalaSoft.MvvmLight;

namespace StoreManagement.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public AppData AppData { get; private set; } = AppData.Instance;

        public MainViewModel()
        {
           
        }
    }
}