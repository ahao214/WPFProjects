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
    public class EditSpecViewModel : ViewModelBase
    {
        public EditSpecViewModel()
        {

        }

        private Spec spec = new Spec();

        public Spec Spec
        {
            get { return spec; }
            set { spec = value; RaisePropertyChanged(); }
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
                    if (string.IsNullOrEmpty(Spec.Name) == true)
                    {
                        MessageBox.Show("不能为空");
                        return;
                    }

                    var service = new SpecService();
                    int count = service.Update(Spec);
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
