using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    public class SupplierService:IService<Supplier>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete(Supplier t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(Supplier t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public Supplier Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Supplier.FirstOrDefault(item => item.Id == id);
            }
        }

        public Supplier Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Supplier.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<Supplier> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Supplier.ToList();
            }
        }

        public int Update(Supplier t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
