using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public abstract class UpdateRepository<T> : GetAllRepository<T> where T : class
    {
        protected UpdateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Update(T input)
        {
            Set.Update(input);
        }
    }
}
