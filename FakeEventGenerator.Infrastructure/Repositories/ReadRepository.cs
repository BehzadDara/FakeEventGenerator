using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public abstract class ReadRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<T> Set => _dbContext.Set<T>();

        public async Task<List<T>> GetAll()
        {
            return await Set.ToListAsync();
        }
    }
}
