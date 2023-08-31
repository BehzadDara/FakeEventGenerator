using FakeEventGenerator.Domain.Models;

namespace FakeEventGenerator.Domain.ViewModels
{
    public class PreviousActionChoose
    {
        public ActionAggregate Action { get; set; } = new();
        public int Possibility { get; set; }
    }
}
