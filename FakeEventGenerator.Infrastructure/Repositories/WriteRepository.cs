using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public abstract class WriteRepository<T> : ReadRepository<T> where T : class
    {
        protected WriteRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Update(T input)
        {
            Set.Update(input);
        }
    }
}
