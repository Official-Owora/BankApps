using BankApp.Repository.Data;
using BankApp.Repository.Repository.Abstraction;
using BankApps___Models.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repository.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly Context _repositoryContext;
        private readonly DbSet<User> _users;

        public UserRepository(Context repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _users = _repositoryContext.Set<User>();
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            IEnumerable<User> user = await _users.ToListAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            User user = await _users.FindAsync(email);
            return user;
        }
    }
}
