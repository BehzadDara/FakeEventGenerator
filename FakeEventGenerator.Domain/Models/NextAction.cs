namespace FakeEventGenerator.Domain.Models
{
    public class NextAction : Entity
    {
        public ActionAggregate? ActionAggregate { get; set; }
        public Guid ActionAggregateId { get; set; }
        //public int NumberOfActions { get; set; }
        public int Possibility { get; set; }
        public int Delay { get; set; }
    }
}
