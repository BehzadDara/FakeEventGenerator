using FakeEventGenerator.Infrastructure.Repositories;

namespace FakeEventGenerator.Infrastructure
{
    public class UnitOfWork
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
        public EnvironmentRepository EnvironmentRepository
        {
            get
            {
                environmentRepository ??= new EnvironmentRepository(_dBContext);
                return environmentRepository;
            }
        }

        private ItemRepository? itemRepository;
        public ItemRepository ItemRepository
        {
            get
            {
                itemRepository ??= new ItemRepository(_dBContext);
                return itemRepository;
            }
        }

        private HumanRepository? humanRepository;
        public HumanRepository HumanRepository
        {
            get
            {
                humanRepository ??= new HumanRepository(_dBContext);
                return humanRepository;
            }
        }

        private ActionRepository? actionRepository;
        public ActionRepository ActionRepository
        {
            get
            {
                actionRepository ??= new ActionRepository(_dBContext);
                return actionRepository;
            }
        }

    }
}
