using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class HumanRepository : UpdateRepository<Human>
    {
        public HumanRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
