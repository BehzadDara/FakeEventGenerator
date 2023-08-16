using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using FakeEventGenerator.Domain.ViewModels;
using FakeEventGenerator.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FakeEventGenerator.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FakeEventGeneratorController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly List<EnvironmentVariable> environmentVariables = new();
        private readonly List<PartOfHouse> partsOfHouse = new();
        private readonly List<Item> items = new();
        private readonly List<Human> humans = new();
        private readonly List<ActionAggregate> actionAggregates = new();
        private readonly Random random = new();
        public FakeEventGeneratorController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            environmentVariables = _unitOfWork.EnvironmentRepository.GetAll().Result;
            partsOfHouse = _unitOfWork.PartOfHouseRepository.GetAll().Result;
            items = _unitOfWork.ItemRepository.GetAll().Result;
            humans = _unitOfWork.HumanRepository.GetAll().Result;
            actionAggregates = _unitOfWork.ActionRepository.GetAll().Result;
        }

        [HttpPost]
        public List<ActionAggregateViewModel> Post([FromBody] RequirementResultViewModel input)
        {
            var myActions = actionAggregates.Where(x => x.Results.Any(y =>
                y.ResultType.Equals(input.ResultType) &&
                y.CaseStudy.Equals(input.CaseStudy) &&
                y.ResultCaseType.Equals(input.ResultCaseType) &&
                y.ResultCaseChange.Equals(input.ResultCaseChangeFrom) &&
                y.ResultCaseChange.Equals(input.ResultCaseChangeTo)
                )
            ).ToList();

            foreach (var myAction in myActions)
            {
                var result = GenerateFakeEvents(myAction, 0, true, true);
                if (result.Any())
                    return result.OrderBy(x => x.Time).ToList();
            }

            return new();
        }

        private List<ActionAggregateViewModel> GenerateFakeEvents(ActionAggregate input, int time, bool lookAtNexts, bool lookAtPreviouses)
        {
            var result = new List<ActionAggregateViewModel>();

            if (IsValidActionNow(input))
            {
                time += input.Delay;
                result.Add(new ActionAggregateViewModel
                {
                    Name = input.Name,
                    Description = input.Description,
                    Time = time
                });

                foreach (var myResult in input.Results)
                {
                    var change = myResult.ResultCaseChange.Split('-');
                    if (change.Last().IndexOf("IF") >= 0)
                    {
                        var c = change.Last().Split(":");
                        change = change.SkipLast(1).ToArray();

                        if (c.Last().Equals("Day") || c.Last().Equals("Night"))
                        {
                            var h = DateTime.Now.Hour > 6 && DateTime.Now.Hour < 18 ? "Day" : "Night";

                            if (!h.Equals(c.Last()))
                            {
                                continue;
                            }
                        }

                    }

                    if (myResult.ResultType.Equals(CaseStudyEnum.Environment))
                    {
                        var environmentVariable = environmentVariables.First(x => x.Type.ToString().Equals(myResult.ResultType));

                        var factor = myResult.ResultCaseType.Equals(ResultCaseEnum.Increase) ? 1 : -1;
                        environmentVariable.Value += factor * int.Parse(change.First());

                        _unitOfWork.EnvironmentRepository.Update(environmentVariable);
                    }

                    else if (myResult.ResultType.Equals(CaseStudyEnum.ItemPosition))
                    {
                        var item = items.First(x => x.Name.Equals(myResult.CaseStudy));

                        item.CoordinateX= int.Parse(change[0]);
                        item.CoordinateX= int.Parse(change[1]);
                        _unitOfWork.ItemRepository.Update(item);
                    }

                    else if (myResult.ResultType.Equals(CaseStudyEnum.ItemState))
                    {
                        var item = items.First(x => x.Name.Equals(myResult.CaseStudy));

                        item.State = Enum.Parse<ItemState>(change.First());
                        _unitOfWork.ItemRepository.Update(item);
                    }

                    else if (myResult.ResultType.Equals(CaseStudyEnum.HumanPosition))
                    {
                        var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                        human.CoordinateX = int.Parse(change[0]);
                        human.CoordinateX = int.Parse(change[1]);
                        _unitOfWork.HumanRepository.Update(human);
                    }

                    else if (myResult.ResultType.Equals(CaseStudyEnum.HumanBodyStatus))
                    {
                        var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                        human.BodyStatus = Enum.Parse<BodyStatusEnum>(change.First());
                        _unitOfWork.HumanRepository.Update(human);
                    }
                }
                _unitOfWork.Complete();

                if (lookAtNexts)
                {
                    foreach (var nextAction in input.NextActions)
                    {
                        if (nextAction.Possibility >= random.Next(0, 100))
                        {
                            result.AddRange(GenerateFakeEvents(nextAction.ActionAggregate!, time + nextAction.Delay, true, false));
                        }
                    }
                }

            }
            else
            {
                if (lookAtPreviouses)
                {
                    var backResult = new List<ActionAggregateViewModel>();

                    var myPastActions = actionAggregates.Where(x => x.NextActions.Any(y => y.Id.Equals(input.Id)));
                    foreach (var myAction in myPastActions)
                    {
                        result = GenerateFakeEvents(myAction, time, false, true);
                        if (result.Any())
                            break;
                    }

                    if (result.Any())
                    {
                        result.Add(new ActionAggregateViewModel
                        {
                            Name = input.Name,
                            Description = input.Description,
                            Time = time
                        });

                        result.AddRange(GenerateFakeEvents(input, time, true, false));
                    }

                }

            }

            return result;
        }

        private bool IsValidActionNow(ActionAggregate myAction)
        {
            if (myAction.StartPossibility < random.Next(0, 100))
            {
                return false;
            }

            foreach (var myCondition in myAction.Conditions)
            {
                if (myCondition.ConditionType.Equals(CaseStudyEnum.Environment))
                {
                    var environmentVariable = environmentVariables.First(x => x.Type.ToString().Equals(myCondition.CaseStudy));

                    var result = CheckEnvironmentConditionWithExpection
                        (environmentVariable.Value, int.Parse(myCondition.ConditionCaseExpectation), myCondition.ConditionCaseType);
                    if (!result)
                    {
                        return false;
                    }
                }

                else if (myCondition.ConditionType.Equals(CaseStudyEnum.ItemPosition))
                {
                    var item = items.First(x => x.Name.Equals(myCondition.CaseStudy));

                    var result = CheckPositionConditionWithExpection
                        (item, myCondition.ConditionCaseExpectation, myCondition.ConditionCaseType);
                    if (!result)
                    {
                        return false;
                    }
                }

                else if (myCondition.ConditionType.Equals(CaseStudyEnum.ItemState))
                {
                    var item = items.First(x => x.Name.Equals(myCondition.CaseStudy));

                    var result = CheckStateConditionWithExpection
                        (item, myCondition.ConditionCaseExpectation, myCondition.ConditionCaseType);
                    if (!result)
                    {
                        return false;
                    }
                }

                else if (myCondition.ConditionType.Equals(CaseStudyEnum.HumanPosition))
                {
                    var human = humans.First(x => x.Name.Equals(myCondition.CaseStudy));

                    var result = CheckPositionConditionWithExpection
                        (human, myCondition.ConditionCaseExpectation, myCondition.ConditionCaseType);
                    if (!result)
                    {
                        return false;
                    }
                }

                else if (myCondition.ConditionType.Equals(CaseStudyEnum.HumanBodyStatus))
                {
                    var human = humans.First(x => x.Name.Equals(myCondition.CaseStudy));

                    var result = CheckStateConditionWithExpection
                        (human, myCondition.ConditionCaseExpectation, myCondition.ConditionCaseType);
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        private static bool CheckEnvironmentConditionWithExpection(int real, int expection, ConditionCaseEnum conditionCaseType)
        {
            return conditionCaseType switch
            {
                ConditionCaseEnum.LessThanOrEqual => real <= expection,
                ConditionCaseEnum.GreaterThanOrEqual => real >= expection,
                ConditionCaseEnum.EqualTo => real == expection,
                _ => false
            };
        }

        private bool CheckPositionConditionWithExpection(Item item, string expection, ConditionCaseEnum conditionCaseType)
        {
            var partOfHouse = partsOfHouse.First(x => x.HasAnItem(item));
            return conditionCaseType switch
            {
                ConditionCaseEnum.IsIn => partOfHouse.Type.ToString().Equals(expection),
                ConditionCaseEnum.IsNotIn => !partOfHouse.Type.ToString().Equals(expection),
                _ => false
            };
        }

        private bool CheckPositionConditionWithExpection(Human human, string expection, ConditionCaseEnum conditionCaseType)
        {
            var partOfHouse = partsOfHouse.First(x => x.HasAHuman(human));
            return conditionCaseType switch
            {
                ConditionCaseEnum.IsIn => partOfHouse.Type.ToString().Equals(expection),
                ConditionCaseEnum.IsNotIn => !partOfHouse.Type.ToString().Equals(expection),
                _ => false
            };
        }

        private bool CheckStateConditionWithExpection(Item item, string expection, ConditionCaseEnum conditionCaseType)
        {
            return conditionCaseType switch
            {
                ConditionCaseEnum.IsIn => item.State.ToString().Equals(expection),
                ConditionCaseEnum.IsNotIn => !item.State.ToString().Equals(expection),
                _ => false
            };
        }

        private bool CheckStateConditionWithExpection(Human human, string expection, ConditionCaseEnum conditionCaseType)
        {
            return conditionCaseType switch
            {
                ConditionCaseEnum.IsIn => human.BodyStatus.ToString().Equals(expection),
                ConditionCaseEnum.IsNotIn => !human.BodyStatus.ToString().Equals(expection),
                _ => false
            };
        }

    }
}
