using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HealthAttache.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void Delete(IEnumerable<T> entities);
        void Delete(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          string includeProperties = "");
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        int Count(Expression<Func<T, bool>> filter = null,
            string includeProperties = "");

        bool Exist(Expression<Func<T, bool>> where);

        bool CanDelete(int Id);
        //bool CanDelete(T entity);
        bool TryDelete(int Id);
        //bool TryDelete(T entity);
        //void ClearCache();
        //IQueryable<T> GetAllQueryable();

        //Dictionary<string,string> SerializePlaceholder(T entity);
        //Dictionary<string, string> SerializePlaceholder(long id);
        //Dictionary<string, string> SerializePlaceholder(string id);
        //string[] PlaceholderKeys();
    }
}