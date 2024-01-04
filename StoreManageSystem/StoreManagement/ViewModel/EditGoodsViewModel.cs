using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreManagement.Service;
using System.Windows;


namespace StoreManagement.ViewModel
{
    /// <summary>
    /// 物资登记
    /// </summary>
    public class EditGoodsViewModel:ViewModelBase
    {
        private Goods goods;

        public Goods Goods
        {
            get { return goods; }
            set { goods = value; }
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
