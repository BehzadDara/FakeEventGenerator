using FakeEventGenerator.Domain.Models;

namespace FakeEventGenerator.Domain.ViewModels
{
    public class ActionOutputList
    {
        public List<ActionAggregate> ActionAggregates { get; private set; } = new();

        public void Add(ActionAggregate actionAggregate)
        {
            if (!ActionAggregates.Any(x => x.Id.Equals(actionAggregate.Id)))
            {
                ActionAggregates.Add(actionAggregate);
            }
        }

        public void AddRange(List<ActionAggregate> actionAggregates)
        {
            actionAggregates.ForEach(Add);
        }

    }
}
