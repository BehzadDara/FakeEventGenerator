using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public abstract class GetAllRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public GetAllRepository(DbContext dbContext)
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
