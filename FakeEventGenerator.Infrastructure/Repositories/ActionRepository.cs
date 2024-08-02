using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class ActionRepository : ReadRepository<ActionAggregate>
    {
        public ActionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<List<ActionAggregate>> GetAll()
        {
            return await Set
                .Include(x => x.Conditions)
                .Include(x => x.Results)
                .Include(x => x.NextActions)
                .Include(x => x.ActionDetails).ThenInclude(x => x.SensorDatas)
                .ToListAsync();
        }
    }
}
