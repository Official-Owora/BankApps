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
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        } 
        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(_context);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public ITransactionRepository TransactionRepository => _transactionRepository ??= new TransactionRepository(_context);
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
