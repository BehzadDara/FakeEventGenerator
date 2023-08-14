using FakeEventGenerator.Domain.Interfaces;
using FakeEventGenerator.Domain.IRepositories;
using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected IQueryable<T> Table => Set;
        protected IQueryable<T> TableAsNoTracking => Set.AsNoTracking();
        protected DbSet<T> Set => _dbContext.Set<T>();

        public async Task<T?> GetAsync(Specification<T> spec)
        {
            var query = await ListAsync(spec);

            return query.FirstOrDefault();
        }

        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Update(T entity)
        {
            Set.Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
                await DeleteAsync(entity);
        }

        public async Task DeleteAsync(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                await DeleteAsync(entity);
            }
        }

        public Task DeleteAsync(T entity)
        {
            Set.Remove(entity);

            return Task.CompletedTask;
        }

        public virtual async Task<IList<T>> ListAsync(Specification<T> spec)
        {
            var query = await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec).ToListAsync();
            return query;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await Table.SingleOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<IList<T>> ListAllAsync()
        {
            var entities = await TableAsNoTracking.ToListAsync();
            return entities;
        }

    }
}