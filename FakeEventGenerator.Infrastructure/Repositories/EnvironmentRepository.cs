using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.IRepositories;
using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class EnvironmentRepository : IEnvironmentRepository
    {
        private readonly DbContext _dbContext;
        public EnvironmentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<EnvironmentVariable> Set => _dbContext.Set<EnvironmentVariable>();

        public async Task<int> GetValueAsync(EnvironmentVariableEnum type)
        {
            return (await Set.FirstAsync(x => x.Type == type)).Value;
        }
        public async Task ChangeValueAsync(EnvironmentVariable environmentVariable)
        {
            var oldValue = await GetValueAsync(environmentVariable.Type);

            SetValue(new EnvironmentVariable
            {
                Type = environmentVariable.Type,
                Value = oldValue + environmentVariable.Value
            });
        }
        public void SetValue(EnvironmentVariable environmentVariable)
        {
            Set.Update(environmentVariable);
        }
    }
}
