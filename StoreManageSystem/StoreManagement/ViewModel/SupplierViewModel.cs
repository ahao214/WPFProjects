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
    /// 供应商
    /// </summary>
    public class SupplierViewModel : ViewModelBase
    {
        public SupplierViewModel()
        {
            SupplierList = new SupplierService().Select();
        }

        private Supplier supplier = new Supplier();

        public Supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; RaisePropertyChanged(); }
        }

        private List<Supplier> supplierList = new List<Supplier>();

        public List<Supplier> SupplierList
        {
            get { return supplierList; }
            set { supplierList = value; RaisePropertyChanged(); }
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
                    if (string.IsNullOrEmpty(Supplier.Name) == true || string.IsNullOrEmpty(Supplier.Contact) ||
                    string.IsNullOrEmpty(Supplier.Telephone))
                    {
                        MessageBox.Show("不能为空");
                        return;
                    }
                    Supplier.InsertDate = DateTime.Now;
                    var service = new SupplierService();
                    int count = service.Insert(Supplier);
                    if (count > 0)
                    {
                        SupplierList = service.Select();
                        MessageBox.Show("操作成功");
                        Supplier = new Supplier();
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
                    var old = view.Tag as Supplier;
                    if (old == null)
                        return;
                    var model = ServiceLocator.Current.GetInstance<EditSupplierViewModel>();
                    model.Supplier = old;
                    var window = new EditSupplierWindow();
                    window.ShowDialog();
                    SupplierList = new SupplierService().Select();
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
                    if(MessageBox .Show ("是否执行操作?","",MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                    {
                        var old = view.Tag as Supplier;
                        if (old == null)
                            return;
                        var service = new SupplierService();
                        int count = service.Delete(old);
                        if(count > 0)
                        {
                            SupplierList = service.Select();
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
