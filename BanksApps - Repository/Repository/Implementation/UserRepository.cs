using BankApps___Models.Model;
using BanksApps___Repository.Data;
using BanksApps___Repository.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BanksApps___Repository.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly Context _context;
        private readonly DbSet<User> _users;

        public UserRepository(Context context) : base(context) 
        {
            _context = context;
            _users = _context.Set<User>();
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
