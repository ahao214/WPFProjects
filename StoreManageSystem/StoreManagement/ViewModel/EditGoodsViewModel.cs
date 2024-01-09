using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System.Collections.Generic;
using System.Windows;


namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 物资登记
    /// </summary>
    public class EditGoodsViewModel : ViewModelBase
    {
        public EditGoodsViewModel()
        {
            GoodsTypeList = new GoodsTypeService().Select();
            SpecList = new SpecService().Select();
        }

        private Goods goods;

        public Goods Goods
        {
            get { return goods; }
            set { goods = value; }
        }

        private List<GoodsType> goodsTypeList = new List<GoodsType>();
        /// <summary>
        /// 物资类别集合
        /// </summary>
        public List<GoodsType> GoodsTypeList
        {
            get { return goodsTypeList; }
            set { goodsTypeList = value; RaisePropertyChanged(); }
        }

        private List<Spec> specList = new List<Spec>();
        /// <summary>
        /// 物资规格集合
        /// </summary>
        public List<Spec> SpecList
        {
            get { return specList; }
            set { specList = value; RaisePropertyChanged(); }
        }


        private GoodsType goodsType = new GoodsType();
        /// <summary>
        /// 物资类别
        /// </summary>
        public GoodsType GoodsType
        {
            get { return goodsType; }
            set { goodsType = value; RaisePropertyChanged(); }
        }

        private Spec spec = new Spec();
        /// <summary>
        /// 物资规格
        /// </summary>
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
                    if (string.IsNullOrEmpty(Goods.Name) == true ||
                    string.IsNullOrEmpty(Goods.Serial) == true)
                    {
                        MessageBox.Show("序号和名称不能为空");
                        return;
                    }
                    Goods.GoodsTypeId = goodsType.Id;
                    Goods.SpecId = spec.Id;

                    var service = new GoodsService();
                    int count = service.Update(Goods);
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
