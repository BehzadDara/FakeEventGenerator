using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class ItemRepository : WriteRepository<Item>
    {
        public ItemRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
