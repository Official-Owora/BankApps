using BankApps___Models.Model;

namespace BankApp.Core.Service.Abstraction
{
    public interface IAuthentication
    {
        Task<User> LoginUser(string email, string password);
        Task<User> RegisterUser(string email, string password);
    }
}
