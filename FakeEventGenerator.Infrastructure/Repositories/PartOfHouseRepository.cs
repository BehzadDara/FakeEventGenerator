using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class PartOfHouseRepository : GetAllRepository<PartOfHouse>
    {
        public PartOfHouseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
