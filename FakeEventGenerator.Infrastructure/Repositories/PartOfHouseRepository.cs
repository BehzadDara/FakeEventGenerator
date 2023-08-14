using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.IRepositories;
using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class PartOfHouseRepository : IPartOfHouseRepository
    {
        private readonly DbContext _dbContext;
        public PartOfHouseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<PartOfHouse> Set => _dbContext.Set<PartOfHouse>();

        public async Task<List<PartOfHouse>> GetAll()
        {
            return await Set.ToListAsync();
        }
    }
}
