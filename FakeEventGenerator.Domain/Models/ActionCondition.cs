using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class ActionCondition : Entity
    {
        public ActionAggregate? ActionAggregate { get; set; }
        public Guid ActionAggregateId { get; set; }
        public CaseStudyEnum ConditionType { get; set; }
        public string CaseStudy { get; set; } = string.Empty;
        public ConditionCaseEnum ConditionCaseType { get; set; }
        public string ConditionCaseExpectation { get; set; } = string.Empty;
    }
}
