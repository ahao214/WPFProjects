using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public class GoodsTypeService:IService<GoodsType>
    {
        public int Delete(GoodsType t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(GoodsType t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public GoodsType Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.GoodsType.FirstOrDefault(item => item.Id == id);
            }
        }

        public GoodsType Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.GoodsType.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<GoodsType> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.GoodsType.ToList();
            }
        }

        public int Update(GoodsType t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
