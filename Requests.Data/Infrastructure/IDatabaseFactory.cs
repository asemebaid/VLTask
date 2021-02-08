using Requests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthAttache.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        RequestDBEntities Get();
    }
}
