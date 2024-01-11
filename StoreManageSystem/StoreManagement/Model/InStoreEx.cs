using GalaSoft.MvvmLight;
using System;


namespace StoreManagement.Model
{
    public class InStoreEx : ObservableObject
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(); }
        }

        private string goodsSerial = "";
        public string GoodsSerial
        {
            get { return goodsSerial; }
            set { goodsSerial = value; RaisePropertyChanged(); }
        }

        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        public Nullable<int> StoreId { get; set; }
        public string StoreName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Unit { get; set; }
        public double Number { get; set; }
        public double Price { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public Nullable<int> GoodsTypeId { get; set; }
        public Nullable<int> UserInfoId { get; set; }
        public string UserInfoName { get; set; }
        public string Tag { get; set; }
        public Nullable<bool> IsInventory { get; set; }

    }
}
