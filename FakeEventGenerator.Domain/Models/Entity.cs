namespace FakeEventGenerator.Domain.Models
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
