using BankApps___Models.Model;
using BanksApps___Repository.Data;
using BanksApps___Repository.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BanksApps___Repository.Repository.Implementation
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly Context _context;
        private readonly DbSet<Account> _accounts;

        public AccountRepository(Context context) : base(context)
        {
            _context = context;
            _accounts = _context.Set<Account>();
        }

        public async Task<Account> GetAccountByAccountNumberAsync(string accountNumber)
        {
            Account account = await _accounts.FindAsync(accountNumber);
            return account;
        }

        public async Task<Account> GetAccountByUserId(int id)
        {
            Account account = await _accounts.FindAsync(id);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            IEnumerable<Account> account = await _accounts.ToListAsync();
            return account;
        }
    }
}
