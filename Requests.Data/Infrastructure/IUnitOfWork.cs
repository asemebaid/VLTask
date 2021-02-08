namespace HealthAttache.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        //void CommitTransaction();

        //void BeginTransaction();

        //void RollbackTransaction();

        void Commit();
    }
}