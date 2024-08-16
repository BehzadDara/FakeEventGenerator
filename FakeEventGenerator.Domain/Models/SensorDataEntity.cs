namespace FakeEventGenerator.Domain.Models;

public class SensorDataEntity// : Entity
{
    public int Id { get; set; }
    public ActionDetail? ActionDetail { get; set; }
    public Guid ActionDetailId { get; set; }
    public DateTime Time { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
