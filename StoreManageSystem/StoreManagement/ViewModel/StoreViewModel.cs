using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using StoreManagement.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 仓库管理
    /// </summary>
    public class StoreViewModel : ViewModelBase
    {
        public StoreViewModel()
        {
            StoreList = new StoreService().Select();
        }

        private Store store = new Store();
        public Store Store
        {
            get { return store; }
            set { store = value; RaisePropertyChanged(); }
        }

        private List<Store> storeList = new List<Store>();
        public List<Store> StoreList
        {
            get { return storeList; }
            set { storeList = value; RaisePropertyChanged(); }
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
                    if (string.IsNullOrEmpty(store.Name) == true)
                    {
                        MessageBox.Show("仓库名称不能为空");
                        return;
                    }
                    Store.InsertDate = DateTime.Now;
                    var service = new StoreService();
                    int count = service.Insert(Store);
                    if (count > 0)
                    {
                        StoreList = service.Select();
                        MessageBox.Show("操作成功");
                        Store = new Store();
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
                    var old = view.Tag as Store;
                    if (old == null)
                        return;
                    var model = ServiceLocator.Current.GetInstance<EditStoreViewModel>();
                    model.Store = old;
                    var window = new EditStoreWindow();
                    window.ShowDialog();
                    StoreList = new StoreService().Select();
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
                        var old = view.Tag as Store;
                        if (old == null)
                            return;
                        var service = new StoreService();
                        int count = service.Delete(old);
                        if (count > 0)
                        {
                            StoreList = service.Select();
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
