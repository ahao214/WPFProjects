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
    public class EditGoodsTypeViewModel:ViewModelBase
    {
        public EditGoodsTypeViewModel()
        {
                
        }

        private GoodsType goodsType;

		public GoodsType GoodsType 
		{
			get { return goodsType; }
			set { goodsType = value; }
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
                    if (string.IsNullOrEmpty(GoodsType.Name) == true )
                    {
                        MessageBox.Show("物资类型不能为空");
                        return;
                    }

                    var service = new GoodsTypeService();
                    int count = service.Update(GoodsType);
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
