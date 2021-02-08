
using Requests.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HealthAttache.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected RequestDBEntities _dataContext;
        protected readonly IDbSet<T> _dbset;
        protected virtual string EntityName { get; }

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected RequestDBEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }


        #region ADD ...
        //Add item
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
         }
        //Add item collection
        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _dbset.Add(entity);
         }
        #endregion

        #region Update ....
        //Update Item
        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
         }
        //Update Item Collection
        public void Update(IEnumerable<T> entities)
        {
            foreach (var dbObj in entities.Select(entity => _dataContext.Entry(entity)))
            {
                dbObj.State = EntityState.Modified;
            }
         }
        #endregion

        #region Delete....
        //Delete Item
        //public virtual void Delete(T entity)
        //{
        //    _dbset.Remove(entity);
        //}
        public virtual void Delete(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Deleted;
            _dbset.Remove(entity);
         }

        //Delete Item by ID
        public void Delete(int id)
        {
            var entity = _dbset.Find(id);
            if (entity == null)
                return;
             Delete(entity);
        }
        //Delete Item Collection
        public virtual void Delete(IEnumerable<T> entities)
        {
            foreach (var dbObj in entities.Select(entity => _dataContext.Entry(entity)))
            {
                dbObj.State = EntityState.Deleted;
            }
         }

        //Delete Item Collection by IDs
        public void Delete(IEnumerable<int> ids)
        {
            var entities = ids.Select(id => _dbset.Find(id)).ToList();
             Delete(entities);
        }
        //Delete Item Collection With where expression
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
         }
#endregion

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual T GetById(long id)
        {
            return _dbset.Find(id);
        }

        public virtual T GetById(string id)
        {
            return _dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }


        //////////////////////
        public virtual int Count(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.Count();
        }

        public virtual bool Exist(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).Any();
        }

        //public virtual IQueryable<T> GetAllQueryable()
        //{
        //    return _dbset;
        //}




        public virtual bool CanDelete(int Id)
        {
            return true;
        }

        //public virtual bool CanDelete(T entity)
        //{
        //    return true;
        //}

        public virtual bool TryDelete(int Id)
        {
            if (CanDelete(Id))
            {
                Delete(Id);
                return true;
            }
            else
            {
                return false;
            }
        }

        //public virtual bool TryDelete(T entity)
        //{
        //    if (CanDelete(entity))
        //    {
        //        Delete(entity);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}




        #region Commit ...
       
        //public void Commit()
        //{
        //    DataContext.SaveChanges();
        //}
        //public virtual Dictionary<string, string> SerializePlaceholder(T entity)
        //{
        //    return new Dictionary<string, string>();
        //}
        //public virtual Dictionary<string, string> SerializePlaceholder(long id)
        //{
        //    return new Dictionary<string, string>();
        //}
        //public virtual Dictionary<string, string> SerializePlaceholder(string id)
        //{
        //    return new Dictionary<string, string>();
        //}
      
        #endregion
    }
}