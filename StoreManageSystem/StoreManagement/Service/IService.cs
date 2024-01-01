using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service
{
    /// <summary>
    /// 基础接口类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : class
    {
        int Insert(T t);
        int Delete(T t);
        int Update(T t);
        T Select(int id);
        T Select(string Name);
        List<T> Select();

    }
}
