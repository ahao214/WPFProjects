//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class OutStore
    {
        public int Id { get; set; }
        public string GoodsSerial { get; set; }
        public string Name { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string StoreName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public Nullable<int> SpecId { get; set; }
        public string SpecName { get; set; }
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
