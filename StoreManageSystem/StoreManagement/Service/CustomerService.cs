using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    /// <summary>
    /// 客户
    /// </summary>
    public class CustomerService : IService<Customer>
    {
        public int Delete(Customer t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(Customer t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public Customer Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Customer.FirstOrDefault(item => item.Id == id);
            }
        }

        public Customer Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Customer.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<Customer> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.Customer.ToList();
            }
        }

        public int Update(Customer t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
