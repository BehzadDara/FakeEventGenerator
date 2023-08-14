using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class EnvironmentRepository : WriteRepository<EnvironmentVariable>
    {
        public EnvironmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
