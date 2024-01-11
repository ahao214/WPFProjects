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

        private Nullable<int> storeId = 0;

        public Nullable<int> StoreId
        {
            get { return storeId; }
            set { storeId = value; RaisePropertyChanged(); }
        }


        private string storeName = "";


        public string StoreName
        {
            get { return storeName; }
            set { storeName = value; RaisePropertyChanged(); }
        }

        private int supplierId = 0;
        public int SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; RaisePropertyChanged(); }
        }

        private string supplierName = "";
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; RaisePropertyChanged(); }
        }

        private string unit = "";

        public string Unit
        {
            get { return unit; }
            set { unit = value; RaisePropertyChanged(); }
        }

        private double number = 0;
        public double Number
        {
            get { return number; }
            set { number = value; RaisePropertyChanged(); }
        }

        private double price = 0;
        public double Price
        {
            get { return price; }
            set { price = value; RaisePropertyChanged(); }
        }

        private Nullable<System.DateTime> insertDate;
        public Nullable<System.DateTime> InsertDate
        {
            get { return insertDate; }
            set { insertDate = value; RaisePropertyChanged(); }
        }


        private string tag = "";
        public string Tag
        {
            get { return tag; }
            set { tag = value; RaisePropertyChanged(); }
        }

        private Nullable<bool> isInventory = false;
        public Nullable<bool> IsInventory
        {
            get { return isInventory; }
            set { isInventory = value; RaisePropertyChanged(); }
        }

        private Nullable<System.DateTime> inventoryDate;
        public Nullable<System.DateTime> InventoryDate
        {
            get { return inventoryDate; }
            set { inventoryDate = value; RaisePropertyChanged(); }
        }

    }
}
