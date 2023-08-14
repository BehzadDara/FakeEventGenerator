using FakeEventGenerator.Domain;
using FakeEventGenerator.Domain.IRepositories;
using FakeEventGenerator.Infrastructure.Repositories;

namespace FakeEventGenerator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FakeEventGeneratorDBContext _dBContext;

        public UnitOfWork(FakeEventGeneratorDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Complete()
        {
            _dBContext.SaveChanges();
        }

        private EnvironmentRepository? environmentRepository;
        public IEnvironmentRepository EnvironmentRepository
        {
            get
            {
                environmentRepository ??= new EnvironmentRepository(_dBContext);
                return environmentRepository;
            }
        }

    }
}
