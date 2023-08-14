using FakeEventGenerator.Domain.Interfaces;

namespace FakeEventGenerator.Domain.IRepositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetAsync(Specification<T> spec);
        Task<IList<T>> ListAsync(Specification<T> spec);
        Task<IList<T>> ListAllAsync();
    }
}
