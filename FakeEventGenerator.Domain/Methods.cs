using FakeEventGenerator.Domain.Models;

namespace FakeEventGenerator.Domain
{
    public static class Methods
    {
        public static bool IsAnItemInAPartOfHouse(Item item, PartOfHouse partOfHouse)
        {
            return partOfHouse.Coordinate1X < item.CoordinateX && partOfHouse.Coordinate1Y < item.CoordinateY &&
                partOfHouse.Coordinate2X > item.CoordinateX && partOfHouse.Coordinate2Y > item.CoordinateY;
        }
    }
}
