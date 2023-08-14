using FakeEventGenerator.Domain.Enums;
using System.Collections.Generic;

namespace FakeEventGenerator.Domain.Models
{
    public class PartOfHouse
    {
        public PartOfHouseEnum Type { get; set; }

        public int Coordinate1X { get; set; }
        public int Coordinate1Y { get; set; }
        public int Coordinate2X { get; set; }
        public int Coordinate2Y { get; set; }

        public bool IsInAPart(int coordinateX, int coordinateY)
        {
            return Coordinate1X < coordinateX && Coordinate1Y < coordinateY &&
                Coordinate2X > coordinateX && Coordinate2Y > coordinateY;
        }
    }
}
