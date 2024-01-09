using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    /// <summary>
    /// 商品
    /// </summary>
    public class GoodsService : IService<Goods>
    {
        public int Delete(Goods t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(Goods t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public Goods Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Goods.FirstOrDefault(item => item.Id == id);
            }
        }

        public Goods Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Goods.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<Goods> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Goods.Include("Spec").Include("GoodsType").ToList();
            }
        }

        public int Update(Goods t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
