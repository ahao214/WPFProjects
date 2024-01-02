using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    public class InStoreService : IService<InStore>
    {
        public int Delete(InStore t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(InStore t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public InStore Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.InStore.FirstOrDefault(item => item.Id == id);
            }
        }

        public InStore Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.InStore.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<InStore> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.InStore.ToList();
            }
        }

        public int Update(InStore t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
