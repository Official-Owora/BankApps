using BankApps___Models.Model;

namespace BankApp.Core.Service.Abstraction
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(User user);
        Task<object> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
