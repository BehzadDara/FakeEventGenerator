using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class EnvironmentVariable
    {
        public EnvironmentVariableEnum Type { get; set; }
        public int Value { get; set; }
    }
}
