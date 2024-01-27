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
    public class EditCustomerViewModel:ViewModelBase
    {
        public EditCustomerViewModel()
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
        /// 修改
        /// </summary>
        public RelayCommand<Window> EditCommand
        {
            get
            {
                var command = new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(Customer.Name) == true)
                    {
                        MessageBox.Show("客户名称不能为空");
                        return;
                    }

                    var service = new CustomerService();
                    int count = service.Update(Customer);
                    if (count > 0)
                    {
                        MessageBox.Show("修改成功");
                        // 关闭当前窗体
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                });
                return command;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        public RelayCommand<Window> CancelCommand
        {
            get
            {
                var command = new RelayCommand<Window>((window) =>
                {
                    window.Close();
                });
                return command;
            }
        }


    }
}
