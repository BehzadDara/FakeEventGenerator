using CsvHelper.Configuration.Attributes;

namespace FakeEventGenerator.Domain.Models;

public class SensorData
{
    [Index(0)]
    public DateTime Time { get; set; }
    [Index(1)]
    public string ItemName { get; set; } = string.Empty;
    [Index(2)]
    public string Value { get; set; } = string.Empty;
}
