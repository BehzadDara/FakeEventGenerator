using CsvHelper.Configuration.Attributes;

namespace FakeEventGenerator.Domain.Models;

public class FinalResult2
{
    [Index(0)]
    public string ItemName { get; set; } = string.Empty;
    [Index(1)]
    public string Value { get; set; } = string.Empty;
    [Index(2)]
    public bool IsReal { get; set; }
}
