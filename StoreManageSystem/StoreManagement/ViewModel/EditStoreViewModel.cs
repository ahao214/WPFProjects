using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.ViewModel
{
    public class EditStoreViewModel:ViewModelBase
    {

        private Store store = new Store();
        public Store Store
        {
            get { return store; }
            set { store = value; RaisePropertyChanged(); }
        }
    }
}
