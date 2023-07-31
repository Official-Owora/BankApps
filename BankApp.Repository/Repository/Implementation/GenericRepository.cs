using BankApp.Repository.Data;
using BankApp.Repository.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repository.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _repositoryContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(Context repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _dbSet = repositoryContext.Set<T>();
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
