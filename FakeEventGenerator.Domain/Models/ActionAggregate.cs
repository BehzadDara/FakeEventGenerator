namespace FakeEventGenerator.Domain.Models
{
    public class ActionAggregate : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Delay { get; set; }
        public List<ActionCondition> Conditions { get; set; } = new();
        public List<ActionResult> Results { get; set; } = new();
        public int EndPossibility { get; set; }
        public List<NextAction> NextActions { get; set; } = new();
        public List<ActionDetail> ActionDetails { get; set; } = new();
        //public string Details { get; set; } = string.Empty;
    }
}
