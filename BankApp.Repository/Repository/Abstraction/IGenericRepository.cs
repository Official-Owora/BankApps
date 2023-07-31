namespace BankApp.Repository.Repository.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
