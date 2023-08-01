using BankApps___Models.Model;

namespace BankApp.Core.Service.Abstraction
{
    public interface IAccountService
    {
        Task<string> CreateAccountAsync(Account account);
        Task<Account> GetAccountByAccountNumberAsync(string accountNumber);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByUserIdAsync(int UserId);
    }
}
