using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class Human : Entity
    {
        public string Name { get; set; } = string.Empty;
        public PartOfHouseEnum Location { get; set; }
        public FeelToDegreeEnum FeelToDegree { get; set; }
        public BodyStatusEnum BodyStatus { get; set; }
        public MentalStatusEnum MentalStatus { get; set; }
    }
}
