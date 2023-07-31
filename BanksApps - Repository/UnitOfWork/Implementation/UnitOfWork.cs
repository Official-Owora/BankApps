using BanksApps___Repository.Data;
using BanksApps___Repository.Repository.Abstraction;
using BanksApps___Repository.Repository.Implementation;
using BanksApps___Repository.UnitOfWork.Abstraction;

namespace BanksApps___Repository.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAccountRepository _accountRepository;
        private IUserRepository _userRepository;
        private ITransactionRepository _transactionRepository;
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public IAccountRepository Accounts => _accountRepository ??= new AccountRepository(_context);
        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        public ITransactionRepository Transactions => _transactionRepository ??= new TransactionRepository(_context);
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
