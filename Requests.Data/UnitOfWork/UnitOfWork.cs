using HealthAttache.Data.Infrastructure;
using HealthAttache.Data.Repository.Common;
using Requests.Data;
using System;
//using HealthAttache.Domain.Entities.SelfService;

namespace HealthAttache.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWorkRequest
    {
        #region class members

        private readonly IDatabaseFactory _databaseFactory;
        private RequestDBEntities _dataContext;
        protected RequestDBEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        } 
        //DbContextTransaction transaction;
        #endregion
          

        #region constrictors

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }
        public UnitOfWork()
        {
            this._databaseFactory = new DatabaseFactory();
        } 
        #endregion

       

        #region base methods 

        public void Commit()
        {
            DataContext.SaveChanges();
        }
        
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                   // DataContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
         
  
        //RequestRepository
        private IRequestRepository _RequestRepository;

        public IRequestRepository RequestRepository
        {
            get
            {
                if (_RequestRepository == null)
                    _RequestRepository = new RequestRepository(_databaseFactory);
                return _RequestRepository;
            }
        }
          
    }
}