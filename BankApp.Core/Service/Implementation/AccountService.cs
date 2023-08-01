using BankApp.Core.Service.Abstraction;
using BankApp.Repository.UnitOfWork.Abstraction;
using BankApps___Models.Model;

namespace BankApp.Core.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> CreateAccountAsync(Account account)
        {
            await _unitOfWork.AccountRepository.CreateAsync(account);
            _unitOfWork.Save();
            return "Account Successfully created";
        }
        public async Task<Account> GetAccountByAccountNumberAsync(string accountNumber)
        {
            Account number = await _unitOfWork.AccountRepository.GetAccountByAccountNumberAsync(accountNumber);
            return  number;
        }
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            IEnumerable<Account> accounts = await _unitOfWork.AccountRepository.GetAllAccountsAsync();
            return accounts;
        }
        public async Task<Account> GetAccountByUserIdAsync(int UserId)
        {
            Account userId = await _unitOfWork.AccountRepository.GetAccountByUserIdAsync(UserId);
            return userId;
        }
    }
}
