using BankApp.Core.Service.Abstraction;
using BankApp.Core.Service.Implementation;
using BankApp.Core.ServiceManager.Abstraction;
using BankApp.Repository.UnitOfWork.Abstraction;

namespace BankApp.Core.ServiceManager.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private IUserService _userService;
        private IAccountService _accountService;
        private ITransactionService _transactionService;
        private IAuthenticationService _authenticationService;

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUserService UserService => _userService ?? new UserService(_unitOfWork);

        public IAccountService AccountService => _accountService ?? new AccountService(_unitOfWork);

        public ITransactionService TransactionService => _transactionService ?? new TransactionService(_unitOfWork);
        public IAuthenticationService AuthenticationService => _authenticationService ?? new AuthenticationServices(_unitOfWork);
    }
}
