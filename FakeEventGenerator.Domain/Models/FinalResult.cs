using CsvHelper.Configuration.Attributes;

namespace FakeEventGenerator.Domain.Models;

public class FinalResult
{
    [Index(0)]
    public string ItemName { get; set; } = string.Empty;
    [Index(1)]
    public string Value { get; set; } = string.Empty;
    [Index(2)]
    public int Day { get; set; } = 0;
}
