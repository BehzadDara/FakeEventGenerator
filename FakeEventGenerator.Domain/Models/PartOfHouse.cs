using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class PartOfHouse
    {
        public PartOfHouseEnum Type { get; set; }

        public int Coordinate1X { get; set; }
        public int Coordinate1Y { get; set; }
        public int Coordinate2X { get; set; }
        public int Coordinate2Y { get; set; }

        public bool HasAnItem(Item item)
        {
            return Methods.IsAnItemInAPartOfHouse(item, this);
        }
    }
}
