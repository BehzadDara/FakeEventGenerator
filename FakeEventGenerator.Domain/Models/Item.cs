using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class Item : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ItemEnum Type { get; init; }
        public ItemState State { get; set; }
        public PartOfHouseEnum Location { get; set; }
        public bool IsMovable { get; set; }
        public string MetaData { get; set; } = string.Empty;
    }
}
