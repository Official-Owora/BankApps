using BankApp.Core.Service.Abstraction;
using BankApp.Repository.UnitOfWork.Abstraction;
using BankApps___Models.Enums;
using BankApps___Models.Model;

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
            transaction.TransactionType = TransactionType.Withdraw;
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
            transaction.TransactionType = TransactionType.Deposit;
            transaction.TransactionDescription = description;
            _unitOfWork.TransactionRepository.CreateAsync (transaction);
            _unitOfWork.Save();
            return $"You have successfully deposited {amountToDeposit}";
        }

        public async Task<string> TransferAsync(string accountNumber, decimal amountToTransfer, string description, string creditAccountNumber, string receiverName)
        {
            Account senderAccount = await _accountService.GetAccountByAccountNumberAsync(accountNumber);
            Account receiverAccount = await _accountService.GetAccountByAccountNumberAsync(creditAccountNumber); 
            if (senderAccount.AccountBalance - amountToTransfer >= senderAccount.AccountBalance)
            {
                senderAccount.AccountBalance -= amountToTransfer;
                receiverAccount.AccountBalance += amountToTransfer;
                return $"Account Number: {accountNumber} does not exist";
            }
            else
            {
                return ("Insufficient fund");
            }
            Transaction senderTransaction = new()
            {
                AccountNumber = accountNumber,
                TransactionDate = DateTime.Now,
                TransactionAmount = amountToTransfer,
                TransactionDescription = description,
                TransactionType = TransactionType.Transfer,
                TransactionStatus = Status.Successful,
                ReceiverAccountNumber = creditAccountNumber,
                ReceiverName = receiverName,
            };
            Transaction receiverTransaction = new()
            {
                AccountNumber = creditAccountNumber,
                TransactionDate = DateTime.Now,
                TransactionType= TransactionType.Transfer,
                TransactionStatus = Status.Successful,
                TransactionDescription= description,
                TransactionAmount= amountToTransfer,

            };
            _unitOfWork.AccountRepository.Update(senderAccount);
            await _unitOfWork.TransactionRepository.CreateAsync(senderTransaction);
            await _unitOfWork.TransactionRepository.CreateAsync(receiverTransaction);
            await _unitOfWork.Save();
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
        public async Task<string> DeleteTransactionByIdAsync(Transaction transaction)
        {
            _unitOfWork.TransactionRepository.DeleteByIdAsync(transaction);
            await _unitOfWork.Save();
            return $"Transaction Successfully Deleted";
            _unitOfWork.Dispose();
            /* public async Task DeleteTransactionByIdAsync(int id)
             {
                 Transaction transaction = _unitOfWork.TransactionRepository.DeleteByIdAsync(id);
                 Transaction transaction = await _unitOfWork.TransactionRepository.DeleteByIdAsync(transaction);
                 _unitOfWork.TransactionRepository.DeleteByIdAsync(transaction);
                 await _unitOfWork.Save();
                 _unitOfWork.Dispose();
             }*/
        }
    }
}
