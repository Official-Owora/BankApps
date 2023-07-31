using BankApp.Repository.Data;
using BankApp.Repository.Repository.Abstraction;
using BankApps___Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Repository.Implementation
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly Context _repositoryContext;
        private readonly DbSet<Transaction> _transactions;

        public TransactionRepository(Context repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _transactions = _repositoryContext.Set<Transaction>();
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
