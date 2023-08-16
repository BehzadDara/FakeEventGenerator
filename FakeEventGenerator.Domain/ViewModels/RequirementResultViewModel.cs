using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.ViewModels
{
    public class RequirementResultViewModel
    {
        public CaseStudyEnum ResultType { get; set; }
        public string CaseStudy { get; set; } = string.Empty;
        public ResultCaseEnum ResultCaseType { get; set; }
        public string ResultCaseChange { get; set; } = string.Empty;
    }
}
