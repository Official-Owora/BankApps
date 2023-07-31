using BankApps___Models.Model;

namespace BanksApps___Repository.Repository.Abstraction
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetAccountByAccountNumberAsync(string accountNumber);
        Task<Account> GetAccountByUserId(int id);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
    }
}
