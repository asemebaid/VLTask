using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HealthAttache.Data.Infrastructure
{
    public interface IRepositoryLookup<T> : IRepository<T> where T : class
    {
        bool NameIsExist(string name);
        bool NameIsExist(string name, int id);
        IEnumerable<T> GetAllActive();
        IEnumerable<T> GetAllActiveOrderByName();
    }
}