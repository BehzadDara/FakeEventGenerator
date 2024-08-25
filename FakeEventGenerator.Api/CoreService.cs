using CsvHelper;
using FakeEventGenerator.Domain.DTOs;
using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using FakeEventGenerator.Domain.ViewModels;
using FakeEventGenerator.Infrastructure;
using System.Globalization;
using System.Text.Json;

namespace FakeEventGenerator.Api;

public class CoreService
{
    private DateTime currentDateTime = new(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 7, 58, 0);

    private readonly UnitOfWork _unitOfWork;
    private readonly List<EnvironmentVariable> environmentVariables = new();
    private readonly List<Item> items = new();
    private readonly List<Human> humans = new();
    private readonly List<ActionAggregate> actionAggregates = new();
    private readonly ActionAggregate stopPoint;
    private readonly Random random = new();

    private int counter = 1;

    private readonly List<int> times = new();
    private int iterator = 0;
    private int globalTime = 0;

    public CoreService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        environmentVariables = _unitOfWork.EnvironmentRepository.GetAll().Result;
        items = _unitOfWork.ItemRepository.GetAll().Result;
        humans = _unitOfWork.HumanRepository.GetAll().Result;
        actionAggregates = _unitOfWork.ActionRepository.GetAll().Result;
        /*stopPoint = actionAggregates.First(x => x.Results.Any(y =>
            y.ResultType.Equals(CaseStudyEnum.HumanPosition) &&
            y.CaseStudy.Equals("Human2") &&
            y.ResultCaseType.Equals(ResultCaseEnum.Position) &&
            BeResultCaseChange(y.ResultType, y.ResultCaseChange, "Kitchen")));*/

    }

    public List<ActionAggregateViewModel> Post(RequirementResultViewModel input)
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
            if (result.ActionAggregates.Any())
            {
                var stopPointResult = GenerateNextFakeEvents(stopPoint, true, true, true);
                stopPointResult.ActionAggregates.ForEach(result.Add);

                return result.ActionAggregates.Select(x => new ActionAggregateViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Time = GetTime()
                }).ToList();
            }
        }

        return new();
    }

    public List<ActionAggregateViewModel> Get(string input)
    {
        var myAction = actionAggregates.FirstOrDefault(x => x.Name.Equals(input));

        if (myAction is not null)
        {
            var result = GenerateNextFakeEvents(myAction, true, true, true);
            if (result.ActionAggregates.Any())
            {
                var stopPointResult = GenerateNextFakeEvents(stopPoint, true, true, true);
                stopPointResult.ActionAggregates.ForEach(result.Add);

                return result.ActionAggregates.Select(x => new ActionAggregateViewModel
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

    private ActionOutputList GenerateNextFakeEvents(ActionAggregate input, bool previousAvailable, bool nextAvailable, bool isOriginal)
    {
        var result = new ActionOutputList();

        if (IsValidActionNow(input))
        {
            var factor = Math.Round(new Random().NextDouble() * 2 + 1, 2);
            globalTime += (int)(factor * input.Delay);

            times.Add(globalTime);

            result.Add(input);
            SetResults(input.Results);

            if (input.EndPossibility < random.Next(0, 100))
            {
                return result;
            }

            if (nextAvailable)
            {
                var nextActions = input.NextActions.OrderByDescending(x => x.Possibility + random.Next(0, 100)).ToList();

                foreach (var nextAction in nextActions)
                {
                    var tmpTime = globalTime;

                    var factor2 = Math.Round(new Random().NextDouble() * 2 + 1, 2);
                    globalTime += (int)(factor2 * nextAction.Delay);

                    result = GenerateNextFakeEvents(nextAction.ActionAggregate!, false, true, false);
                    globalTime = tmpTime;

                    if (result.ActionAggregates.Any())
                    {
                        break;
                    }
                }
            }

        }
        else if (previousAvailable)
        {
            result = GeneratePreviousFakeEvents(input);

            if (isOriginal && result.ActionAggregates.Any() && result.ActionAggregates.Last().EndPossibility < random.Next(0, 100))
            {
                var nextActions = result.ActionAggregates.Last().NextActions;
                nextActions = nextActions.OrderByDescending(x => x.Possibility + random.Next(0, 100)).ToList();

                foreach (var nextAction in nextActions)
                {
                    var myAction = actionAggregates.First(x => x.Id.Equals(nextAction.Id));

                    var tmpTime = globalTime;

                    var factor = Math.Round(new Random().NextDouble() * 2 + 1, 2);
                    globalTime += (int)(factor * nextAction.Delay);

                    var res = GenerateNextFakeEvents(myAction, false, true, false);
                    globalTime = tmpTime;

                    if (res.ActionAggregates.Any())
                    {
                        result.AddRange(res.ActionAggregates);
                        break;
                    }
                }
            }
        }

        return result;
    }

    private ActionOutputList GeneratePreviousFakeEvents(ActionAggregate input)
    {
        var result = new ActionOutputList();

        var myPreviousActionChooses = actionAggregates
                        .Where(x => x.NextActions.Any(y => y.Id.Equals(input.Id)))
                        .Select(x => new PreviousActionChoose { Action = x, Possibility = x.NextActions.First(y => y.Id.Equals(input.Id)).Possibility })
                        .ToList();

        var myActions = myPreviousActionChooses
                        .OrderByDescending(x => x.Possibility + random.Next(0, 100))
                        .Select(x => x.Action)
                        .ToList();

        foreach (var myAction in myActions)
        {
            result = GenerateNextFakeEvents(myAction, true, false, false);
            if (result.ActionAggregates.Any())
            {
                var next = myAction.NextActions.First(x => x.Id.Equals(input.Id));

                var factor = Math.Round(new Random().NextDouble() * 2 + 1, 2);
                globalTime += (int)(factor * next.Delay);

                globalTime += next.Delay;
                break;
            }
        }

        if (result.ActionAggregates.Any())
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

    private static bool CheckPositionConditionWithExpection(Item item, string expection, ConditionCaseEnum conditionCaseType)
    {
        return conditionCaseType switch
        {
            ConditionCaseEnum.IsIn => item.Location.ToString().Equals(expection),
            ConditionCaseEnum.IsNotIn => !item.Location.ToString().Equals(expection),
            _ => false
        };
    }

    private static bool CheckPositionConditionWithExpection(Human human, string expection, ConditionCaseEnum conditionCaseType)
    {
        return conditionCaseType switch
        {
            ConditionCaseEnum.IsIn => human.Location.ToString().Equals(expection),
            ConditionCaseEnum.IsNotIn => !human.Location.ToString().Equals(expection),
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
                environmentVariable.Value += factor * int.Parse(change[0]);

                _unitOfWork.EnvironmentRepository.Update(environmentVariable);
            }

            else if (myResult.ResultType.Equals(CaseStudyEnum.ItemPosition))
            {
                var item = items.First(x => x.Name.Equals(myResult.CaseStudy));

                var b = Enum.TryParse(change[0], out PartOfHouseEnum partOfHouseEnum);
                if (!b)
                {
                    throw new Exception($"{change[0]} is not a part of house");
                }

                item.Location = partOfHouseEnum;
                _unitOfWork.ItemRepository.Update(item);
            }

            else if (myResult.ResultType.Equals(CaseStudyEnum.ItemState))
            {
                var item = items.First(x => x.Name.Equals(myResult.CaseStudy));

                item.State = Enum.Parse<ItemState>(change[0]);
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

                var b = Enum.TryParse(change[0], out PartOfHouseEnum partOfHouseEnum);
                if (!b)
                {
                    throw new Exception($"{change[0]} is not a part of house");
                }

                human.Location = partOfHouseEnum;
                _unitOfWork.HumanRepository.Update(human);
            }

            else if (myResult.ResultType.Equals(CaseStudyEnum.HumanBodyStatus))
            {
                var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                human.BodyStatus = Enum.Parse<BodyStatusEnum>(change[0]);
                _unitOfWork.HumanRepository.Update(human);
            }

            else if (myResult.ResultType.Equals(CaseStudyEnum.HumanFeelToDegree))
            {
                var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                human.FeelToDegree = Enum.Parse<FeelToDegreeEnum>(change[0]);
                _unitOfWork.HumanRepository.Update(human);
            }

            else if (myResult.ResultType.Equals(CaseStudyEnum.MentalStatus))
            {
                var human = humans.First(x => x.Name.Equals(myResult.CaseStudy));

                human.MentalStatus = Enum.Parse<MentalStatusEnum>(change[0]);
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






    public void UndoHuman1()
    {
        var human1 = humans.First(x => x.Name.Equals("Human1"));
        human1.Location = PartOfHouseEnum.Bedroom1;
        human1.BodyStatus = BodyStatusEnum.Stand;
        human1.MentalStatus = MentalStatusEnum.Tired;
        _unitOfWork.HumanRepository.Update(human1);

        var balconyWindow = items.First(x => x.Name.Equals("BalconyWindow"));
        balconyWindow.State = ItemState.Close;
        _unitOfWork.ItemRepository.Update(balconyWindow);

        var balconyDoor1 = items.First(x => x.Name.Equals("BalconyDoor1"));
        balconyDoor1.State = ItemState.Close;
        _unitOfWork.ItemRepository.Update(balconyDoor1);

        var light = environmentVariables.First(x => x.Type.Equals(EnvironmentVariableEnum.Light));
        light.Value = 10;
        _unitOfWork.EnvironmentRepository.Update(light);

        _unitOfWork.Complete();
    }

    public void UndoHuman21()
    {
        var human2 = humans.First(x => x.Name.Equals("Human2"));
        human2.Location = PartOfHouseEnum.Bedroom2;
        human2.BodyStatus = BodyStatusEnum.Stand;
        human2.MentalStatus = MentalStatusEnum.Bored;
        _unitOfWork.HumanRepository.Update(human2);

        var bedroom2Door = items.First(x => x.Name.Equals("Bedroom2Door"));
        bedroom2Door.State = ItemState.Close;
        _unitOfWork.ItemRepository.Update(bedroom2Door);

        var livingRoomDoor = items.First(x => x.Name.Equals("LivingRoomDoor"));
        livingRoomDoor.State = ItemState.Close;
        _unitOfWork.ItemRepository.Update(livingRoomDoor);

        var tv = items.First(x => x.Name.Equals("TV"));
        tv.State = ItemState.Off;
        tv.MetaData = JsonSerializer.Serialize(new TVMetaData
        {
            Sound = 60
        });
        _unitOfWork.ItemRepository.Update(tv);

        var light = environmentVariables.First(x => x.Type.Equals(EnvironmentVariableEnum.Light));
        light.Value = 10;
        _unitOfWork.EnvironmentRepository.Update(light);

        var sound = environmentVariables.First(x => x.Type.Equals(EnvironmentVariableEnum.Sound));
        sound.Value = 60;
        _unitOfWork.EnvironmentRepository.Update(sound);

        _unitOfWork.Complete();
    }

    public void UndoHuman22()
    {
        var human2 = humans.First(x => x.Name.Equals("Human2"));
        human2.Location = PartOfHouseEnum.Bedroom2;
        human2.FeelToDegree = FeelToDegreeEnum.Medium;
        _unitOfWork.HumanRepository.Update(human2);

        var bedroom2Door = items.First(x => x.Name.Equals("Bedroom2Door"));
        bedroom2Door.State = ItemState.Close;
        _unitOfWork.ItemRepository.Update(bedroom2Door);

        var livingRoomDoor = items.First(x => x.Name.Equals("LivingRoomDoor"));
        livingRoomDoor.State = ItemState.Close;
        _unitOfWork.ItemRepository.Update(livingRoomDoor);

        var airConditioner = items.First(x => x.Name.Equals("AirConditioner3"));
        airConditioner.State = ItemState.Off;
        airConditioner.MetaData = JsonSerializer.Serialize(new AirConditionerMetaData
        {
            Temperature = 20,
            Speed = 10
        });
        _unitOfWork.ItemRepository.Update(airConditioner);

        var degree = environmentVariables.First(x => x.Type.Equals(EnvironmentVariableEnum.Degree));
        degree.Value = 20;
        _unitOfWork.EnvironmentRepository.Update(degree);

        _unitOfWork.Complete();
    }

    public List<Predata> CombineO4H()
    {

    }

    public List<PreData> GenerateO4H()
    {
        var action = actionAggregates.First(x => x.Name == "Entrance|Entering");

        var result = new List<PreData>();

        result.AddRange(GenerateRecursively(action));
        /*counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;
        result.AddRange(GenerateRecursively(action));
        counter++;*/

        return result;
    }

    public List<PreData> GenerateRecursively(ActionAggregate action)
    {
        var result = new List<PreData>();
        result.AddRange(GenerateFinalResult(action));

        var nexts = action.NextActions;
        if (nexts.Count != 0)
        {
            var nextAction = nexts.OrderByDescending(x => x.Possibility + random.Next(0, 100)).First();
            var choosedAction = actionAggregates.First(x => x.Id == nextAction.Id);
            var nextResult = GenerateRecursively(choosedAction);
            result.AddRange(nextResult);
        }

        return result;
    }

    public List<PreData> GenerateFinalResult(ActionAggregate action)
    {
        var result = new List<PreData>();

        /*var result = new List<FinalResult>
        {
            new() {
                ItemName = "label",
                Value = $"START:{action.Name}",
                Day = counter
            }
        };*/

        var listOfDetails = action.ActionDetails;
        var details = listOfDetails![random.Next(0, listOfDetails.Count)];
        foreach (var detail in details.SensorDatas)//.Where(x => x.ItemName != "label"))
        {
            var tmp = JsonSerializer.Deserialize<PreData>(detail.PreData);

            result.Add(tmp!);
            //result.AddRange(ExtractFinalResultFromPreData(tmp!, counter));
        }

        /*result.Add(new FinalResult
        {
            ItemName = "label",
            Value = $"STOP:{action.Name}",
            Day = counter
        });*/

        return result;
    }

    private static List<FinalResult> ExtractFinalResultFromPreData(PreData preData, int counter)
    {
        var results = new List<FinalResult>();

        var properties = typeof(PreData).GetProperties();

        foreach (var property in properties)
        {
            if (property.Name == "id" || property.Name == "activity")
                continue;

            var result = new FinalResult
            {
                ItemName = property.Name,
                Value = property.GetValue(preData)?.ToString() ?? string.Empty,
                Day = counter
            };

            results.Add(result);
        }

        return results;
    }

    public async Task FillDetail()
    {
        var actionDetails = ReadCsvFile("FullData.csv");
        var preDatas = ReadPreCsvFile("FullData_prepped.csv");

        Guid guid = new();
        var tmpList = new List<SensorData>();
        foreach (var actionDetail in actionDetails.Where(x => x.Id > 416_911))// && x.Id <= 746_764))
        {

            if (actionDetail.Value.StartsWith("START"))
            {
                var tmp = actionDetail.Value[6..];
                guid = actionAggregates.First(x => x.Name == tmp).Id;
            }

            tmpList.Add(actionDetail);

            if (actionDetail.Value.StartsWith("STOP"))
            {
                var tmp2List = tmpList.Select(x => new SensorDataEntity
                {
                    Time = x.Time,
                    ItemName = x.ItemName,
                    Value = x.Value,
                    PreDataId = x.Id,
                    PreData = JsonSerializer.Serialize(preDatas.First(y => y.id == x.Id))
                }).ToList();

                await _unitOfWork._dBContext.Set<ActionDetail>().AddAsync(new ActionDetail
                {
                    ActionAggregateId = guid,
                    SensorDatas = tmp2List
                });

                tmpList = new List<SensorData>();

                _unitOfWork.Complete();
            }
        }

    }

    static List<SensorData> ReadCsvFile(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return new List<SensorData>(csv.GetRecords<SensorData>());
    }

    static List<PreData> ReadPreCsvFile(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return new List<PreData>(csv.GetRecords<PreData>());
    }

    public void CheckData()
    {
        var action = actionAggregates.First(x => x.Name == "Entrance|Entering");
        var listOfDetails = action.ActionDetails;

        for (var i = 0; i < listOfDetails.Count; i++)
        {
            var t1 = listOfDetails[i].SensorDatas.OrderBy(x => x.Time).ToList();

            for (var j = 0; j < t1.Count; j++)
            {
                var t2 = t1[j];

                if (t2.ItemName == "entrance_door")
                {
                    if (t2.Value == "CLOSED")
                    {

                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

    }
}
