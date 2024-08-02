namespace FakeEventGenerator.Domain.Models;

public class ActionDetail : Entity
{
    public ActionAggregate? ActionAggregate { get; set; }
    public Guid ActionAggregateId { get; set; }
    public List<SensorDataEntity> SensorDatas { get; set; } = new();
}
