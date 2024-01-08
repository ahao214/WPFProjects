using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using StoreManagement.View;
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
    public class SpecViewModel : ViewModelBase
    {
        public SpecViewModel()
        {
            SpecList = new SpecService().Select();
        }

        private Spec spec = new Spec();

        public Spec Spec
        {
            get { return spec; }
            set { spec = value; RaisePropertyChanged(); }
        }

        private List<Spec> specList = new List<Spec>();

        public List<Spec> SpecList
        {
            get { return specList; }
            set { specList = value; RaisePropertyChanged(); }
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
                    if (string.IsNullOrEmpty(spec.Name) == true)
                    {
                        MessageBox.Show("名称不能为空");
                        return;
                    }
                    spec.InsertDate = DateTime.Now;
                    var service = new SpecService();
                    int count = service.Insert(spec);
                    if (count > 0)
                    {
                        SpecList = service.Select();
                        MessageBox.Show("操作成功");
                        Spec = new Spec();
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
                    var old = view.Tag as Spec;
                    if (old == null)
                        return;
                    var model = ServiceLocator.Current.GetInstance<EditSpecViewModel>();
                    model.Spec = old;
                    var window = new EditSpecWindow();
                    window.ShowDialog();
                    SpecList = new SpecService().Select();
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
                        var old = view.Tag as Spec;
                        if (old == null)
                            return;
                        var service = new SpecService();
                        int count = service.Delete(old);
                        if (count > 0)
                        {
                            SpecList = service.Select();
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
