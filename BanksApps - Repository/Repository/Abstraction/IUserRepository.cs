using BankApps___Models.Model;

namespace BanksApps___Repository.Repository.Abstraction
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
