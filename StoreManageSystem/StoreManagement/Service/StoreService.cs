using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class StoreService : IService<Store>
    {
        public int Delete(Store t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(Store t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public Store Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Store.FirstOrDefault(item => item.Id == id);
            }
        }

        public Store Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Store.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<Store> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Store.ToList();
            }
        }

        public int Update(Store t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
