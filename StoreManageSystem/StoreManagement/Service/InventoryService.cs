using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    public class InventoryService :IService<Inventory>
    {
        public int Delete(Inventory t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(Inventory t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public Inventory Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Inventory.FirstOrDefault(item => item.Id == id);
            }
        }

        public Inventory Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Inventory.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<Inventory> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Inventory.ToList();
            }
        }

        public int Update(Inventory t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

    }
}
