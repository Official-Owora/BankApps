using BankApps___Models.Model;

namespace BankApp.Core.Service.Abstraction
{
    public interface ITransactionService
    {
        Task<string> CreateTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllDailyTransactionByDateCreatedAsync(DateOnly transactionDate);
        Task<IEnumerable<Transaction>> GetAllTransactionsByAccountNumberAsync(string accountNumber);
        Task<string> DeleteTransactionAsync(Transaction transaction);
    }
}
