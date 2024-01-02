using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    /// <summary>
    /// 出库
    /// </summary>
    public class OutStoreService : IService<OutStore>
    {
        public int Delete(OutStore t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(OutStore t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public OutStore Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.OutStore.FirstOrDefault(item => item.Id == id);
            }
        }

        public OutStore Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.OutStore.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<OutStore> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.OutStore.ToList();
            }
        }

        public int Update(OutStore t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
