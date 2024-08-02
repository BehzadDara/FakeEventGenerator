using CsvHelper.Configuration.Attributes;

namespace FakeEventGenerator.Domain.Models;

public class FinalResult2
{
    [Index(0)]
    public DateTime Time { get; set; }
    [Index(1)]
    public string ItemName { get; set; } = string.Empty;
    [Index(2)]
    public string Value { get; set; } = string.Empty;
    [Index(3)]
    public bool IsReal { get; set; }
}
