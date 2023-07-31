namespace BanksApps___Repository.UnitOfWork.Abstraction
{
    public interface IUnitOfWork
    {
        Task Save();
        void Dispose();
    }
}
