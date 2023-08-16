using FakeEventGenerator.Domain.Models;

namespace FakeEventGenerator.Domain
{
    public static class Methods
    {
        public static bool IsAnItemInAPartOfHouse(int x, int y, PartOfHouse partOfHouse)
        {
            return partOfHouse.Coordinate1X < x && partOfHouse.Coordinate1Y < y &&
                partOfHouse.Coordinate2X > x && partOfHouse.Coordinate2Y > y;
        }
    }
}
