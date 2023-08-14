using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class HumanRepository : WriteRepository<Human>
    {
        public HumanRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
