using BankApps___Models.Model;

namespace BankApp.Core.Service.Abstraction
{
    public interface IAuthenticationService
    {
        Task<(bool status, string error)> RegisterUser(string email, string password);
        Task<(User user, string error)> Login(string email, string password);
    }
}
