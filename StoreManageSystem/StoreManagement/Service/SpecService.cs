using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Service
{
    public class SpecService:IService<Spec>
    {
        public int Delete(Spec t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(Spec t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public Spec Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Spec.FirstOrDefault(item => item.Id == id);
            }
        }

        public Spec Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Spec.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<Spec> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Spec.ToList();
            }
        }

        public int Update(Spec t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
