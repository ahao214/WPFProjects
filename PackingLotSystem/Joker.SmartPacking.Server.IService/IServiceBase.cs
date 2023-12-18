using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Server.IService
{
    public interface IServiceBase
    {
        #region Query
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id)where T : class;
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T,bool>> funcWhere) where T : class;

        #endregion

        #region Add

        /// <summary>
        /// 新增数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Insert<T> (T t) where T : class;

        /// <summary>
        /// 新增数据，即时Commit
        /// 多条sql，一个连接，事物插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        IEnumerable<T> Insert<T>(IEnumerable<T> list) where T : class;

        #endregion


        #region Update

        /// <summary>
        /// 更新数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Update<T> (T t)where T : class;

        /// <summary>
        /// 更新数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Update<T> (IEnumerable<T> tList) where T : class;

        #endregion


        #region Delete

        /// <summary>
        /// 根据主键删除数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        void Delete<T>(int Id) where T : class; 

        /// <summary>
        /// 删除数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Delete<T>(T t) where T : class;
        /// <summary>
        /// 删除数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList) where T: class;

        #endregion


        #region Other

        /// <summary>
        /// 立即保存全部修改
        /// 把增/删的savechange给放到这里，是为了保证事物的
        /// </summary>
        void Commit();

        #endregion
    }
}
