using BankApp.Core.Service.Abstraction;
using BankApp.Repository.UnitOfWork.Abstraction;
using BankApps___Models.Model;
using Utilities;

namespace BankApp.Core.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> CreateTransactionAsync(Transaction transaction)
        {
            await _unitOfWork.TransactionRepository.CreateAsync(transaction);
            await _unitOfWork.Save();
            return $"Transaction Successful";
        }
        public async Task<string> WithdrawAsync(string accountNumber, decimal amountToWithdraw, string description)
        {
            Account account = await _accountService.GetAccountByAccountNumberAsync(accountNumber);
            if (account == null)
            {
                return $"AccountNumber: {accountNumber} does not exist";
            }
            if (amountToWithdraw > account.AccountBalance)
            {
                return $"Insufficient fund. Enter a lower amount";
            }
            account.AccountBalance -= amountToWithdraw;
            //creating a new transaction
            Transaction transaction = new Transaction();
            transaction.AccountNumber = accountNumber ;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionAmount = amountToWithdraw;
            transaction.TransactionType = "Debit";
            transaction.TransactionDescription = description;
            _unitOfWork.TransactionRepository.CreateAsync(transaction);
            _unitOfWork.Save();

            return $"You have successfully withdrawn {amountToWithdraw}";
        }

        public async Task<string> DepositAsync(string accountNumber, decimal amountToDeposit, string description)
        {
            Account account = await _accountService.GetAccountByAccountNumberAsync (accountNumber);
            if (account == null)
            {
                return $"Account Number: {accountNumber} does not exist";
            }
            account.AccountBalance += amountToDeposit;
            Transaction transaction = new Transaction();
            transaction.AccountNumber = accountNumber;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionAmount = amountToDeposit;
            transaction.TransactionType = "Deposit";
            transaction.TransactionDescription = description;
            _unitOfWork.TransactionRepository.CreateAsync (transaction);
            _unitOfWork.Save();
            return $"You have successfully deposited {amountToDeposit}";
        }

        public async Task<string> TransferAsync(string accountNumber, decimal amountToTransfer, string description)
        {
            Account account = await _accountService.GetAccountByAccountNumberAsync(accountNumber);
            if (account == null)
            {
                return $"Account Number: {accountNumber} does not exist";
            }
            
            account.AccountBalance -= amountToTransfer;
            Transaction transaction = new Transaction();
            transaction.AccountNumber = accountNumber;
            transaction.TransactionId = Utilitiess.GenerateUniqueId();
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionAmount = amountToTransfer;
            transaction.TransactionType = "Transfer";
            transaction.TransactionDescription = description;
            _unitOfWork.TransactionRepository.CreateAsync(transaction);
            _unitOfWork.Save();
            return $"You have successfully transfered {amountToTransfer}";
        }

        public async Task<IEnumerable<Transaction>> GetAllDailyTransactionByDateCreatedAsync(DateOnly transactionDate)
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
           await _unitOfWork.Save();
            return $"Transaction Successfully Deleted";
        }
    }
}
