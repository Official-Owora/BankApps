using BanksApps___Repository.Data;
using BanksApps___Repository.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BanksApps___Repository.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
