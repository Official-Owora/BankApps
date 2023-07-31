using BankApp.Repository.Data;
using BankApp.Repository.Repository.Abstraction;
using BankApp.Repository.Repository.Implementation;
using BankApp.Repository.UnitOfWork.Abstraction;

namespace BankApp.Repository.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAccountRepository _accountRepository;
        private IUserRepository _userRepository;
        private ITransactionRepository _transactionRepository;
        private readonly Context _repositoryContext;

        public UnitOfWork(Context repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(_repositoryContext);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_repositoryContext);
        public ITransactionRepository TransactionRepository => _transactionRepository ??= new TransactionRepository(_repositoryContext);
        public async Task Save()
        {
            await _repositoryContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _repositoryContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
