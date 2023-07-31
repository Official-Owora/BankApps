using BankApps___Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Repository.Abstraction
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsByAccountNumberAsync(string accountNumber);
        Task<IEnumerable<Transaction>> GetAllDailyTransactionByDateCreatedAsync(DateTime CreatedDate);
    }
}
