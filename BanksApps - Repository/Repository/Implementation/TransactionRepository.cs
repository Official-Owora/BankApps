using BankApps___Models.Model;
using BanksApps___Repository.Data;
using BanksApps___Repository.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BanksApps___Repository.Repository.Implementation
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly Context _context;
        private readonly DbSet<Transaction> _transactions;

        public TransactionRepository(Context context) : base(context)
        {
            _context = context;
            _transactions = _context.Set<Transaction>(); 
        }

        public async Task<IEnumerable<Transaction>> GetAllDailyTransactionByDateCreatedAsync(DateTime transactionDate)
        {
            IEnumerable<Transaction> transactions = await _transactions.Where(x => x.TransactionDate == transactionDate).ToListAsync();
            return transactions;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByAccountNumberAsync(string accountNumber)
        {
            IEnumerable<Transaction> transactions = await _transactions.Where(x => x.AccountNumber == accountNumber).ToListAsync();
            return transactions;
        }
    }
}
