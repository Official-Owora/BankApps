using BankApps___Models.Model;

namespace BankApp.Core.Service.Abstraction
{
    public interface ITransactionService
    {
        Task<string> CreateTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllDailyTransactionByDateCreatedAsync(DateOnly transactionDate);
        Task<IEnumerable<Transaction>> GetAllTransactionsByAccountNumberAsync(string accountNumber);
        Task<string> DeleteTransactionByIdAsync(Transaction transaction);
        //Task DeleteTransactionByIdAsync(int id);
        Task<string> TransferAsync(string accountNumber, decimal amountToTransfer, string description, string creditNumber, string receiverName);
        //Task<string> TransferAsync(string accountNumber, decimal amountToTransfer, string description);
        Task<string> WithdrawAsync(string accountNumber, decimal amountToWithdraw, string description);
        Task<string> DepositAsync(string accountNumber, decimal amountToDeposit, string description);
    }
}
