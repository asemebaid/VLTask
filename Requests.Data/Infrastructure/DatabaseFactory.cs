using Requests.Data;

namespace HealthAttache.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private RequestDBEntities _dataContext;

        public RequestDBEntities Get()
        {
            return _dataContext ?? (_dataContext = new RequestDBEntities());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}