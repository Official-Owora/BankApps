using BankApps___Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Repository.Abstraction
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
