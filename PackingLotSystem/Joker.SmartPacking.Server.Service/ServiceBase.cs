using Joker.SmartPacking.Server.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Server.Service
{
    public class ServiceBase : IServiceBase
    {
        protected DbContext Context { get; private set; }
        public ServiceBase(IEFContext.IEFContext efContext)
        {
            Context = efContext.CreateDBContext();
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);
            if (t == null)
                throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> list) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
