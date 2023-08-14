using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;

namespace FakeEventGenerator.Domain.IRepositories
{
    public interface IPartOfHouseRepository
    {
        public Task<List<PartOfHouse>> GetAll();
    }
}
