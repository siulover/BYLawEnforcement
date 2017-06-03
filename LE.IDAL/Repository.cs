using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace LE.IDAL
{
    /// /// <summary>
    /// 数据库存储类，Repository在Git中是资源库、版本库。在数据中市存储库的意思。
    /// </summary>
    /// <typeparam name="T">设置泛类型T必须为对象类型</typeparam>
    public class Repository<T> where T : class
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        public DbContext Dbcontext { get; set; }
        public Repository()
        { }
        public Repository(DbContext dbContext)
        {
            Dbcontext = dbContext;
        }
        #region 查找单个实体
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="ID">实体主键值</param>
        /// <returns></returns>
        public T Find(int ID)
        {
            return Dbcontext.Set<T>().Find(ID);
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> where)
        {
            return Dbcontext.Set<T>().SingleOrDefault(where);
        }
        #endregion

        #region 查找实体列表
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindList()
        {
            return Dbcontext.Set<T>();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <typeparam name="TKey">排序建类型</typeparam>
        /// <param name="order">排序表达式</param>
        /// <param name="asc">是否正序</param>
        /// <returns></returns>
        public IQueryable<T> FindList<TKey>(Expression<Func<T, TKey>> order, bool asc)
        {
            return asc ? Dbcontext.Set<T>().OrderBy(order) : Dbcontext.Set<T>().OrderByDescending(order);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <typeparam name="TKey">排序键类型</typeparam>
        /// <param name="order">排序键</param>
        /// <param name="asc">是否正序</param>
        /// <param name="number">获取的记录数量</param>
        /// <returns></returns>
        public IQueryable<T> FindList<TKey>(Expression<Func<T, TKey>> order, bool asc, int number)
        {
            return asc ? Dbcontext.Set<T>().OrderBy(order).Take(number) : Dbcontext.Set<T>().OrderByDescending(order).Take(number);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            return Dbcontext.Set<T>().Where(where);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <param name="number">获取的记录数量</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where, int number)
        {
            return Dbcontext.Set<T>().Where(where).Take(number);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <typeparam name="TKey">排序键类型</typeparam>
        /// <param name="where">查询Lambda表达式</param>
        /// <param name="order">排序键</param>
        /// <param name="asc">是否正序</param>
        /// <returns></returns>
        public IQueryable<T> FindList<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool asc)
        {
            return asc ? Dbcontext.Set<T>().Where(where).OrderBy(order) : Dbcontext.Set<T>().Where(where).OrderByDescending(order);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <typeparam name="TKey">排序键类型</typeparam>
        /// <param name="where">查询Lambda表达式</param>
        /// <param name="order">排序键</param>
        /// <param name="asc">是否正序</param>
        /// <param name="number">获取的记录数量</param>
        /// <returns></returns>
        public IQueryable<T> FindList<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool asc, int number)
        {
            return asc ? Dbcontext.Set<T>().Where(where).OrderBy(order).Take(number) : Dbcontext.Set<T>().Where(where).OrderByDescending(order).Take(number);
        }
        #endregion


        #region 分页查找
        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。必须大于1</param>
        /// <param name="pageIndex">页码。首页从1开始，页码必须大于1</param>
        /// <param name="totalNumber">总记录数</param>
        /// <returns>用IQueryable,是因为在LinQ中，虽然前面很多查询表达式等等，但是都没有执行，返回的IQueryable也是没有数据的，直到执行ToList时才会去数据库取当前页</returns>
        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber)
        {
            //IQuaryable只有展开的时候才会去查询数据库，比如tolist、toarray，foreach等等
            //where一个加一个，和拼接字符串一样是不会查询的
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            IQueryable<T> _list = Dbcontext.Set<T>();
            totalNumber = _list.Count();
            return _list.Skip((pageIndex - 1) * pageIndex).Take(pageSize);
        }

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。必须大于1</param>
        /// <param name="pageIndex">页码。首页从1开始，页码必须大于1</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="order">排序键</param>
        /// <param name="asc">是否正序</param>
        /// <returns></returns>
        public IQueryable<T> FindPageList<TKey>(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, TKey>> order, bool asc)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            IQueryable<T> _list = Dbcontext.Set<T>();
            _list = asc ? _list.OrderBy(order) : _list.OrderByDescending(order);
            totalNumber = _list.Count();
            return _list.Skip((pageIndex - 1) * pageIndex).Take(pageSize);
        }

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。必须大于1</param>
        /// <param name="pageIndex">页码。首页从1开始，页码必须大于1</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="where">查询表达式</param>
        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            IQueryable<T> _list = Dbcontext.Set<T>().Where(where);
            totalNumber = _list.Count();
            return _list.Skip((pageIndex - 1) * pageIndex).Take(pageSize);
        }

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。必须大于1</param>
        /// <param name="pageIndex">页码。首页从1开始，页码必须大于1</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="where">查询表达式 穿入时使用 u=> u.xxxx==yyyy等表达式</param>
        /// <param name="order">排序键 传入时使用 u=>u.ordercolnae</param>
        /// <param name="asc">是否正序</param>
        public IQueryable<T> FindPageList<TKey>(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool asc)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            IQueryable<T> _list = Dbcontext.Set<T>().Where(where);
            _list = asc ? _list.OrderBy(order) : _list.OrderByDescending(order);
            totalNumber = _list.Count();
            return _list.Skip((pageIndex - 1) * pageIndex).Take(pageSize);
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>受影响的对象的数目</returns>
        public int Add(T entity)
        {
            return Add(entity, true);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns>在“isSave”为True时返回受影响的对象的数目，为False时直接返回0</returns>
        public int Add(T entity, bool isSave)
        {
            Dbcontext.Set<T>().Add(entity);
            return isSave ? Dbcontext.SaveChanges() : 0;
        }
        #endregion

        #region 更新


        /// <summary>
        /// 更新实体【立即保存】
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>在“isSave”为True时返回受影响的对象的数目，为False时直接返回0</returns>
        public int Update(T entity)
        {
            return Update(entity, true);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns>在“isSave”为True时返回受影响的对象的数目，为False时直接返回0</returns>
        public int Update(T entity, bool isSave)
        {
            Dbcontext.Set<T>().Attach(entity);
            Dbcontext.Entry<T>(entity).State = EntityState.Modified;
            return isSave ? Dbcontext.SaveChanges() : 0;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除实体【立即保存】
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>受影响的对象的数目</returns>
        public int Delete(T entity)
        {
            return Delete(entity, true);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns>在“isSave”为True时返回受影响的对象的数目，为False时直接返回0</returns>
        public int Delete(T entity, bool isSave)
        {
            Dbcontext.Set<T>().Attach(entity);
            Dbcontext.Entry<T>(entity).State = EntityState.Deleted;
            return isSave ? Dbcontext.SaveChanges() : 0;
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>受影响的对象的数目</returns>
        public int Delete(IEnumerable<T> entities)
        {
            Dbcontext.Set<T>().RemoveRange(entities);
            return Dbcontext.SaveChanges();
        }
        #endregion

        #region 统计实体的数量
        /// <summary>
        /// 记录数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Dbcontext.Set<T>().Count();
        }

        /// <summary>
        /// 记录数
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Dbcontext.Set<T>().Count(predicate);
        }
        #endregion

        #region 判断记录是否存在
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="predicate">表达式，Func<t,bool>为一个匿名函数泛型的委托一个是,T为输入值类型，bool返回值类型。多个输入参数时为Func<T, T2，bool></param>
        /// <returns></returns>
        public bool IsContains(Expression<Func<T, bool>> predicate)
        {

            //Func<int, bool> myFunc = x => x == 5;
            //bool result = myFunc(4);
            //returns false of course

            return Count(predicate) > 0;
        }
        #endregion

        #region 立即保存数据的更改
        // <summary>
        /// 保存数据【在Add、Upate、Delete未立即保存的情况下使用】
        /// </summary>
        /// <returns>受影响的记录数</returns>
        public int Save()
        {
            return Dbcontext.SaveChanges();
        }
        #endregion
    }
}
