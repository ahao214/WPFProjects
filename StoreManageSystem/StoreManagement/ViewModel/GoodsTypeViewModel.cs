using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 物资设置
    /// </summary>
    public class GoodsTypeViewModel:ViewModelBase
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

        ////增加
        //public RelayCommand<UserControl> AddCommand
        //{
        //    get
        //    {
        //        var command = new RelayCommand<UserControl>((view) =>
        //        {
        //            if (string.IsNullOrEmpty(GoodsType.Name) == true)
        //            {
        //                MessageBox.Show("不能为空");


        //            }
        //        });
        //        return command;
        //    }
        //}

        ///// <summary>
        ///// 修改
        ///// </summary>
        //public RelayCommand<Button> EditCommand
        //{
        //    get
        //    {
        //        var command = new RelayCommand<Button>((view) =>
        //        {
        //            var old = view.Tag as GoodsType;
        //            if(old == null )
        //            {
        //                return;
        //            }
        //            var model = ServiceLocator.Current.GetInstance<EditGoodsTypeViewModel>();

        //        });
        //        return command;
        //    }
        //}

        ///// <summary>
        ///// 删除
        ///// </summary>
        //public RelayCommand<Button> DeleteCommand
        //{
        //    get
        //    {
        //        var command = new RelayCommand<Button>((view) =>
        //        {

        //        });
        //        return command;
        //    }
        //}


    }
}
