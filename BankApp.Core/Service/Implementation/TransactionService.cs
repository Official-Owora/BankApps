using BankApp.Core.Service.Abstraction;
using BankApp.Repository.UnitOfWork.Abstraction;
using BankApps___Models.Model;

namespace BankApp.Core.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> CreateTransactionAsync(Transaction transaction)
        {
            await _unitOfWork.TransactionRepository.CreateAsync(transaction);
            _unitOfWork.Save();
            return $"Transaction Successful";
        }
        public async Task<IEnumerable<Transaction>> GetAllDailyTransactionByDateCreatedAsync(DateTime transactionDate)
        {
            IEnumerable<Transaction> transactions = await _unitOfWork.TransactionRepository.GetAllDailyTransactionByDateCreatedAsync(transactionDate);
            return transactions;
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactionsByAccountNumberAsync(string accountNumber)
        {
            IEnumerable<Transaction> alltransactions = await _unitOfWork.TransactionRepository.GetAllTransactionsByAccountNumberAsync(accountNumber);
            return alltransactions;
        }
        public async Task<string> DeleteTransactionAsync(Transaction transaction)
        {
            _unitOfWork.TransactionRepository.Delete(transaction);
            _unitOfWork.Save();
            return $"Transaction Successfully Deleted";
        }
    }
}
