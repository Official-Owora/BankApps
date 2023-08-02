using BankApp.Repository.Data;
using BankApp.Repository.Repository.Abstraction;
using BankApps___Models.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repository.Repository.Implementation
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly Context _context;
        private readonly DbSet<Account> _accounts;

        public AccountRepository(Context repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
            _accounts = _context.Set<Account>();
        }
        public async Task<Account> GetAccountByAccountNumberAsync(string accountNumber)
        {
            Account account = await _accounts.FindAsync(accountNumber);
            return account;
        }

        public async Task<Account> GetAccountByUserIdAsync(int UserId)
        {
            Account account = await _accounts.FindAsync(UserId);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            IEnumerable<Account> account = await _accounts.ToListAsync();
            return account;
        }
    }
}
