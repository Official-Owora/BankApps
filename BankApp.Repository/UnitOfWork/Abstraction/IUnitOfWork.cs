using BankApp.Repository.Repository.Abstraction;

namespace BankApp.Repository.UnitOfWork.Abstraction
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IUserRepository UserRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task Save();
        void Dispose();
    }
}
