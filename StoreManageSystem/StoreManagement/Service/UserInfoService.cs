using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserInfoService : IService<UserInfo>
    {
        public int Delete(UserInfo t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(UserInfo t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public UserInfo Select(int id)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.UserInfo.FirstOrDefault(item => item.Id == id);
            }
        }

        public UserInfo Select(string Name)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.UserInfo.FirstOrDefault(item => item.Name == Name);
            }
        }

        public List<UserInfo> Select()
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                return db.UserInfo.ToList();
            }
        }

        public int Update(UserInfo t)
        {
            using (StoreDBEntities db = new StoreDBEntities())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
