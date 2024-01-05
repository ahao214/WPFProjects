using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System.Windows;

namespace StoreManagement.ViewModel
{
    public class EditStoreViewModel:ViewModelBase
    {
        public EditStoreViewModel()
        {
                
        }

        private Store store = new Store();
        public Store Store
        {
            get { return store; }
            set { store = value; RaisePropertyChanged(); }
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
                    if (string.IsNullOrEmpty(Store.Name) == true                    )
                    {
                        MessageBox.Show("仓库名称不能为空");
                        return;
                    }

                    var service = new StoreService();
                    int count = service.Update(Store);
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
