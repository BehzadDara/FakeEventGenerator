using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;

namespace FakeEventGenerator.Domain.IRepositories
{
    public interface IEnvironmentRepository
    {
        public Task<int> GetValueAsync(EnvironmentVariableEnum type);
        public Task ChangeValueAsync(EnvironmentVariable environmentVariable);
        public void SetValue(EnvironmentVariable environmentVariable);
    }
}
