using HealthAttache.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace HealthAttache.Data.Repository
{
    public abstract class RepositoryBaseCache<T> : RepositoryBase<T> where T : class
    {
        protected virtual string CacheKey { get; }  

        public RepositoryBaseCache(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            
        }

        public override IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return GetAll().Where(where.Compile());
        }

        public override bool Exist(Expression<Func<T, bool>> where)
        {
            return GetAll().Where(where.Compile()).Any();
        }

        public override T Get(Expression<Func<T, bool>> where)
        {
            return GetAll().Where(where.Compile()).FirstOrDefault();
        }

        //public override IEnumerable<T> GetAll()
        //{
        //    var currentItems = MemoryCache.Default.Get(CacheKey);
        //    if (currentItems == null)
        //    {
        //        currentItems = base.GetAll();
        //        MemoryCache.Default.Add(CacheKey, currentItems, DateTimeOffset.Now.AddHours(12));
        //    }

        //    return (IEnumerable<T>)currentItems;
        //}

        //public override void ClearCache()
        //{
        //    MemoryCache.Default.Remove(CacheKey);
        //}

        

    }
}
