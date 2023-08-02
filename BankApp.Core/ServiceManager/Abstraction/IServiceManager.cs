using BankApp.Core.Service.Abstraction;

namespace BankApp.Core.ServiceManager.Abstraction
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IAccountService AccountService { get; }
        ITransactionService TransactionService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
