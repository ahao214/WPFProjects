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
    public class CustomerViewModel:ViewModelBase
    {
        public CustomerViewModel()
        {
            CustomerList = new CustomerService().Select();
        }

        private Customer customer = new Customer();
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; RaisePropertyChanged(); }
        }

        private List<Customer> customerList = new List<Customer>();
        public List<Customer> CustomerList
        {
            get { return customerList; }
            set { customerList = value; RaisePropertyChanged(); }
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
                    if (string.IsNullOrEmpty(Customer .Name ) == true)
                    {
                        MessageBox.Show("物资类别不能为空");
                        return;
                    }
                    Customer.InsertDate = DateTime.Now;
                    var service = new CustomerService();
                    int count = service.Insert(Customer);
                    if (count > 0)
                    {
                        CustomerList = service.Select();
                        MessageBox.Show("操作成功");
                        Customer = new Customer();
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
                    var old = view.Tag as Customer;
                    if (old == null)
                        return;
                    var model = ServiceLocator.Current.GetInstance<CustomerViewModel>();
                    model.Customer = old;
                    var window = new EditCustomerWindow();
                    window.ShowDialog();
                    CustomerList = new CustomerService().Select();
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
                        var old = view.Tag as Customer;
                        if (old == null)
                            return;
                        var service = new CustomerService();
                        int count = service.Delete(old);
                        if (count > 0)
                        {
                            CustomerList = service.Select();
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
