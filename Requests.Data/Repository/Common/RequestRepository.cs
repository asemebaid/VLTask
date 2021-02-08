using HealthAttache.Data.Infrastructure;
using Requests.Data;
using Requests.Data.Dtos;
using System;
using System.Collections.Generic;

using System.Linq;


namespace HealthAttache.Data.Repository.Common
{
    public class RequestRepository : RepositoryBase<Request>, IRequestRepository
    {
     

        public RequestRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public override Request GetById(long id)
        {
            return Get(c => c.RequestId == id);
        }
            

    }

    public interface IRequestRepository : IRepository<Request>
    {

    }
}
