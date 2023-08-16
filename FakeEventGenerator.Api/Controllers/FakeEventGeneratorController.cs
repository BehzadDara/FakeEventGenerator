using FakeEventGenerator.Domain.DTOs;
using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using FakeEventGenerator.Domain.ViewModels;
using FakeEventGenerator.Infrastructure;
using FakeEventGenerator.Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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


        private List<int> times = new List<int>();
        private int iterator = 0;
        private int globalTime = 0;
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
                BeResultCaseChange(y.ResultType, y.ResultCaseChange, input.ResultCaseChange)
                )
            ).ToList();

            foreach (var myAction in myActions)
            {
                var result = GenerateNextFakeEvents(myAction, true, true, true);
                if (result.Any())
                {

                    return result.Select(x => new ActionAggregateViewModel
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Time = GetTime()
                    }).ToList();
                }
            }

            return new();
        }

        private static bool BeResultCaseChange(CaseStudyEnum resultType, string resultCaseChange, string inputCaseChange)
        {
            if (resultType.Equals(CaseStudyEnum.ItemMetaData) || resultType.Equals(CaseStudyEnum.Environment))
            {
                var tmps = resultCaseChange.Split('-');

                if (tmps.Length >= 2)
                    return int.Parse(inputCaseChange) >= int.Parse(tmps[0]) && int.Parse(inputCaseChange) <= int.Parse(tmps[1]);
                else
                    return int.Parse(inputCaseChange) == int.Parse(tmps[0]);
            }
            else
            {
                return resultCaseChange.Equals(inputCaseChange);
            }
        }

        private int GetTime()
        {
            var result = times[iterator];
            iterator++;

            return result;
        }

        private List<ActionAggregate> GenerateNextFakeEvents(ActionAggregate input, bool previousAvailable, bool nextAvailable, bool isOriginal)
        {
            var result = new List<ActionAggregate>();

            if (IsValidActionNow(input))
            {
                globalTime += input.Delay;
                times.Add(globalTime);

                result.Add(input);
                SetResults(input.Results);

                if (nextAvailable)
                {
                    foreach (var nextAction in input.NextActions)
                    {
                        if (nextAction.Possibility >= random.Next(0, 100))
                        {
                            var tmpTime = globalTime;
                            globalTime += nextAction.Delay;
                            result.AddRange(GenerateNextFakeEvents(nextAction.ActionAggregate!, false, true, false));
                            globalTime = tmpTime;
                        }
                    }
                }

            }
            else if(previousAvailable)
            {
                result = GeneratePreviousFakeEvents(input);

                if (isOriginal && result.Any()) {
                    foreach (var nextAction in result.Last().NextActions)
                    {
                        var myAction = actionAggregates.First(x => x.Id.Equals(nextAction.Id));

                        var tmpTime = globalTime;
                        globalTime += nextAction.Delay;
                        var res = GenerateNextFakeEvents(myAction, false, true, false);
                        globalTime = tmpTime;

                        if (res.Any())
                        {
                            result.AddRange(res);
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private List<ActionAggregate> GeneratePreviousFakeEvents(ActionAggregate input)
        {
            var result = new List<ActionAggregate>();

            var myActions = actionAggregates.Where(x => x.NextActions.Any(y => y.Id.Equals(input.Id))).ToList();
            foreach (var myAction in myActions)
            {
                result = GenerateNextFakeEvents(myAction, true, false, false);
                if (result.Any())
                {
                    var next = myAction.NextActions.First(x => x.Id.Equals(input.Id));
                    globalTime += next.Delay;
                    break;
                }
            }

            if (result.Any())
            {
                globalTime += input.Delay;
                times.Add(globalTime);

                result.Add(input);
                SetResults(input.Results);
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

                    var result = CheckBodyStatusConditionWithExpection
                        (human, myCondition.ConditionCaseExpectation, myCondition.ConditionCaseType);
                    if (!result)
                    {
                        return false;
                    }
                }

                else if (myCondition.ConditionType.Equals(CaseStudyEnum.HumanFeelToDegree))
                {
                    var human = humans.First(x => x.Name.Equals(myCondition.CaseStudy));

                    var result = CheckFeelToDegreeConditionWithExpection
                        (human, myCondition.ConditionCaseExpectation, myCondition.ConditionCaseType);
                    if (!result)
                    {
                        return false;
                    }
                }

                else if (myCondition.ConditionType.Equals(CaseStudyEnum.MentalStatus))
                {
                    var human = humans.First(x => x.Name.Equals(myCondition.CaseStudy));

                    var result = CheckMentalStatusConditionWithExpection
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
                ConditionCaseEnum.StateIs => item.State.ToString().Equals(expection),
                ConditionCaseEnum.StateIsNot => !item.State.ToString().Equals(expection),
                _ => false
            };
        }

        private bool CheckBodyStatusConditionWithExpection(Human human, string expection, ConditionCaseEnum conditionCaseType)
        {
            return conditionCaseType switch
            {
                ConditionCaseEnum.StateIs => human.BodyStatus.ToString().Equals(expection),
                ConditionCaseEnum.StateIsNot => !human.BodyStatus.ToString().Equals(expection),
                _ => false
            };
        }

        private bool CheckFeelToDegreeConditionWithExpection(Human human, string expection, ConditionCaseEnum conditionCaseType)
        {
            return conditionCaseType switch
            {
                ConditionCaseEnum.StateIs => human.FeelToDegree.ToString().Equals(expection),
                ConditionCaseEnum.StateIsNot => !human.FeelToDegree.ToString().Equals(expection),
                _ => false
            };
        }

        private bool CheckMentalStatusConditionWithExpection(Human human, string expection, ConditionCaseEnum conditionCaseType)
        {
            return conditionCaseType switch
            {
                ConditionCaseEnum.StateIs => human.MentalStatus.ToString().Equals(expection),
                ConditionCaseEnum.StateIsNot => !human.MentalStatus.ToString().Equals(expection),
                _ => false
            };
        }

        private void SetResults(List<Domain.Models.ActionResult> input)
        {
            foreach (var myResult in input)
            {
                var change = myResult.ResultCaseChange.Split('-');
                if (change.Last().IndexOf("IF") >= 0)
                {
                    var c = change.Last().Split(":");
                    change = change.SkipLast(1).ToArray();

                    if (c.Last().Equals("Day") || c.Last().Equals("Night"))
                    {
                        var h = DateTime.Now.Hour > 6 && DateTime.Now.Hour < 20 ? "Day" : "Night";

                        if (!h.Equals(c.Last()))
                        {
                            continue;
                        }
                    }

                }

                if (myResult.ResultType.Equals(CaseStudyEnum.Environment))
                {
                    var environmentVariable = environmentVariables.First(x => x.Type.ToString().Equals(myResult.CaseStudy));

                    var factor = myResult.ResultCaseType.Equals(ResultCaseEnum.Increase) ? 1 : -1;
                    environmentVariable.Value += factor * int.Parse(change.First());

                    _unitOfWork.EnvironmentRepository.Update(environmentVariable);
                }

                else if (myResult.ResultType.Equals(CaseStudyEnum.ItemPosition))
                {
                    var item = items.First(x => x.Name.Equals(myResult.CaseStudy));

                    item.CoordinateX = int.Parse(change[0]);
                    item.CoordinateY = int.Parse(change[1]);
                    _unitOfWork.ItemRepository.Update(item);
                }

                else if (myResult.ResultType.Equals(CaseStudyEnum.ItemState))
                {
                    var item = items.First(x => x.Name.Equals(myResult.CaseStudy));

                    item.State = Enum.Parse<ItemState>(change.First());
                    _unitOfWork.ItemRepository.Update(item);
                }

                else if (myResult.ResultType.Equals(CaseStudyEnum.ItemMetaData))
                {
                    var tmps = myResult.CaseStudy.Split('-');
                    var item = items.First(x => x.Name.Equals(tmps[0]));

                    var factor = myResult.ResultCaseType.Equals(ResultCaseEnum.Increase) ? 1 : -1;

                    item.MetaData = ChangeMetaData(tmps[0], tmps[1], item.MetaData, factor * int.Parse(change[0]), factor * int.Parse(change[1]));

                    _unitOfWork.ItemRepository.Update(item);
                }

                else if (myResult.ResultType.Equals(CaseStudyEnum.HumanPosition))
                {
                    var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                    human.CoordinateX = int.Parse(change[0]);
                    human.CoordinateY = int.Parse(change[1]);
                    _unitOfWork.HumanRepository.Update(human);
                }

                else if (myResult.ResultType.Equals(CaseStudyEnum.HumanBodyStatus))
                {
                    var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                    human.BodyStatus = Enum.Parse<BodyStatusEnum>(change.First());
                    _unitOfWork.HumanRepository.Update(human);
                }

                else if (myResult.ResultType.Equals(CaseStudyEnum.HumanFeelToDegree))
                {
                    var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                    human.FeelToDegree = Enum.Parse<FeelToDegreeEnum>(change.First());
                    _unitOfWork.HumanRepository.Update(human);
                }

                else if (myResult.ResultType.Equals(CaseStudyEnum.MentalStatus))
                {
                    var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                    human.MentalStatus = Enum.Parse<MentalStatusEnum>(change.First());
                    _unitOfWork.HumanRepository.Update(human);
                }
            }
            _unitOfWork.Complete();
        }

        private static string ChangeMetaData(string item, string field, string metaData, int fromChange, int toChange)
        {
            var change = Convert.ToInt32(Math.Floor((double)(fromChange + toChange) / 2));

            string str = string.Empty;

            if (item.Equals("AirConditioner"))
            {
                var result = JsonSerializer.Deserialize<AirConditionerMetaData>(metaData);
                if (field.Equals("Temperature"))
                    result!.Temperature += change;
                else if (field.Equals("Speed"))
                    result!.Speed += change;

                str = JsonSerializer.Serialize(result);
            }
            else if (item.Equals("Lamp1") || item.Equals("Lamp2"))
            {
                var result = JsonSerializer.Deserialize<LampMetaData>(metaData);
                if (field.Equals("Severity"))
                    result!.Severity += change;

                str = JsonSerializer.Serialize(result);
            }
            else if (item.Equals("Laptop"))
            {
                var result = JsonSerializer.Deserialize<LaptopMetaData>(metaData);
                if (field.Equals("Charge"))
                    result!.Charge += change;
                else if (field.Equals("IsInCharge"))
                    result!.IsInCharge = change > 0;

                str = JsonSerializer.Serialize(result);
            }
            else if (item.Equals("Sofa"))
            {
                var result = JsonSerializer.Deserialize<SofaMetaData>(metaData);
                if (field.Equals("Capacity"))
                    result!.Capacity += change;

                str = JsonSerializer.Serialize(result);
            }
            else if (item.Equals("TV"))
            {
                var result = JsonSerializer.Deserialize<TVMetaData>(metaData);
                if (field.Equals("Sound"))
                    result!.Sound += change;
                else if (field.Equals("Channel"))
                    result!.Channel += change;

                str = JsonSerializer.Serialize(result);
            }

            return str;
        }
    }
}
