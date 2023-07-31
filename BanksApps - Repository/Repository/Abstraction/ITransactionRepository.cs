using BankApps___Models.Model;

namespace BanksApps___Repository.Repository.Abstraction
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsByAccountNumberAsync(string accountNumber);
        Task<IEnumerable<Transaction>> GetAllDailyTransactionByDateCreatedAsync(DateTime CreatedDate);
    }
}
