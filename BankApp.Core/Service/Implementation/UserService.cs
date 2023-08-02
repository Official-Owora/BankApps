using BankApp.Core.Service.Abstraction;
using BankApp.Repository.Repository.Abstraction;
using BankApp.Repository.UnitOfWork.Abstraction;
using BankApps___Models.Model;

namespace BankApp.Core.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task <string> CreateUserAsync(User user)
        {
            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.Save();
            return "User created Successfully";
        }
        public async Task<object> GetUserByEmailAsync(string email)
        {
            User emailAddress = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            if (emailAddress == null)
            {
                return $"User does not exist";
            }
            return emailAddress;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllUsersAsync();
            return users;
        }
        
    }
}
