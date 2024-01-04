using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


    }
}
