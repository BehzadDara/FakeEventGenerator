using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class ActionResult : Entity
    {
        public ActionAggregate? ActionAggregate { get; set; }
        public Guid ActionAggregateId { get; set; }
        public CaseStudyEnum ResultType { get; set; }
        public string CaseStudy { get; set; } = string.Empty;
        public ResultCaseEnum ResultCaseType { get; set; }
        public string ResultCaseChange { get; set; } = string.Empty;
    }
}
