using HealthAttache.Data.Infrastructure;
using HealthAttache.Data.Repository.Common;

namespace HealthAttache.Data.UnitOfWork
{
    public interface IUnitOfWorkRequest:IUnitOfWork
    {
         IRequestRepository RequestRepository { get; }

        //IMovTaskRepository MovTaskRepository { get; }

    }
}