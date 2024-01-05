using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using StoreManagement.Windows;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 物资设置
    /// </summary>
    public class GoodsTypeViewModel : ViewModelBase
    {
        public GoodsTypeViewModel()
        {
            GoodsTypeList = new GoodsTypeService().Select();
        }

        private GoodsType goodsType = new GoodsType();
        public GoodsType GoodsType
        {
            get { return goodsType; }
            set { goodsType = value; RaisePropertyChanged(); }
        }

        private List<GoodsType> goodsTypeList = new List<GoodsType>();
        public List<GoodsType> GoodsTypeList
        {
            get { return goodsTypeList; }
            set { goodsTypeList = value; RaisePropertyChanged(); }
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
                    if (string.IsNullOrEmpty(GoodsType.Name) == true)
                    {
                        MessageBox.Show("物资类别不能为空");
                        return;
                    }
                    GoodsType.InsertDate = DateTime.Now;
                    var service = new GoodsTypeService();
                    int count = service.Insert(GoodsType);
                    if (count > 0)
                    {
                        GoodsTypeList = service.Select();
                        MessageBox.Show("操作成功");
                        GoodsType = new GoodsType();
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
                    var old = view.Tag as GoodsType;
                    if (old == null)
                        return;
                    var model = ServiceLocator.Current.GetInstance<EditGoodsTypeViewModel>();
                    model.GoodsType = old;
                    var window = new EditGoodsTypeWindow();
                    window.ShowDialog();
                    GoodsTypeList = new GoodsTypeService().Select();
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
                        var old = view.Tag as GoodsType;
                        if (old == null)
                            return;
                        var service = new GoodsTypeService();
                        int count = service.Delete(old);
                        if (count > 0)
                        {
                            GoodsTypeList = service.Select();
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
