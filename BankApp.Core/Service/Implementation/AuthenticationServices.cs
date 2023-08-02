using BankApp.Core.Service.Abstraction;
using BankApp.Repository.UnitOfWork.Abstraction;
using BankApps___Models.Model;
using Utilitys.Utilitiess;

namespace BankApp.Core.Service.Implementation
{
    public class AuthenticationServices : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(bool status, string error)> RegisterUser(string email, string password)
        {
            if (email.IsValidEmail())
            {
                var passwordValue = password.GenerateHash();
                User user = new User() { EmailAddress = email, Password = passwordValue[0], PasswordHash = passwordValue[1] };
                _unitOfWork.UserRepository.CreateAsync(user);
                await _unitOfWork.Save();
                return(true, string.Empty);
            }
            else
            {
                return (false, "Invalid email");
            }
        }
        public async Task<(User user, string error)> Login(string email, string password)
        {
            if (email.IsValidEmail())
            {
                User user = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
                if (user == null || !password.CompareHash(user.PasswordHash, user.Password))
                {
                    return (user, "Email or password is incorrect");
                }
                return (user, string.Empty);
            }
            return (new User(), "Invalid email address");
        }
    }
    
}
