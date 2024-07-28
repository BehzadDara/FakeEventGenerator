﻿using FakeEventGenerator.Domain.ViewModels;
using FakeEventGenerator.Infrastructure;
using IronXL;
using Microsoft.AspNetCore.Mvc;

namespace FakeEventGenerator.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FakeEventGeneratorController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public FakeEventGeneratorController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public void GenerateRealDataAsync()
        {
            var result = new List<List<ActionAggregateViewModel>>();

            var input = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.HumanFeelToDegree,
                CaseStudy = "Human2",
                ResultCaseType = Domain.Enums.ResultCaseEnum.State,
                ResultCaseChange = "Cold"
            };

            for (var i = 0; i < 1000; i++)
            {
                var service = new CoreService(_unitOfWork);
                var resulttmp = service.Post(input);
                result.Add(resulttmp);
                var serviceUndo = new CoreService(_unitOfWork);
                serviceUndo.UndoHuman21();
                serviceUndo.UndoHuman22();
            }

            var input2 = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.Environment,
                CaseStudy = "Sound",
                ResultCaseType = Domain.Enums.ResultCaseEnum.Increase,
                ResultCaseChange = "35"
            };

            for (var i = 0; i < 300; i++)
            {
                var service = new CoreService(_unitOfWork);
                var resulttmp = service.Post(input2);
                result.Add(resulttmp);
                var serviceUndo = new CoreService(_unitOfWork);
                serviceUndo.UndoHuman21();
                serviceUndo.UndoHuman22();
            }

            var input3 = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.Environment,
                CaseStudy = "Sound",
                ResultCaseType = Domain.Enums.ResultCaseEnum.Decrease,
                ResultCaseChange = "35"
            };

            for (var i = 0; i < 400; i++)
            {
                var service = new CoreService(_unitOfWork);
                var resulttmp = service.Post(input3);
                result.Add(resulttmp);
                var serviceUndo = new CoreService(_unitOfWork);
                serviceUndo.UndoHuman21();
                serviceUndo.UndoHuman22();
            }

            var input4 = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.ItemState,
                CaseStudy = "SafeBox",
                ResultCaseType = Domain.Enums.ResultCaseEnum.State,
                ResultCaseChange = "Open"
            };

            for (var i = 0; i < 1500; i++)
            {
                var service = new CoreService(_unitOfWork);
                var resulttmp = service.Post(input4);
                result.Add(resulttmp);
                var serviceUndo = new CoreService(_unitOfWork);
                serviceUndo.UndoHuman21();
                serviceUndo.UndoHuman22();
            }

            var rnd = new Random();
            result = result.OrderBy(x => rnd.Next()).ToList();

            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet("Result Sheet");

            var row = 1;
            foreach (var item in result)
            {
                var column = 'A';
                foreach (var action in item)
                {
                    sheet[$"{column}{row}"].Value = action.Name;
                    sheet[$"{(char)(column + 1)}{row}"].Value = action.Time;
                    column = (char)(column + 2);
                }
                row++;
            }

            workbook.SaveAs("RealData.xlsx");





        }

        [HttpGet]
        public void GenerateFakeDataAsync()
        {
            var input1 = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.HumanFeelToDegree,
                CaseStudy = "Human2",
                ResultCaseType = Domain.Enums.ResultCaseEnum.State,
                ResultCaseChange = "Cold"
            };

            var input2 = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.Environment,
                CaseStudy = "Sound",
                ResultCaseType = Domain.Enums.ResultCaseEnum.Increase,
                ResultCaseChange = "35"
            };

            var input3 = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.Environment,
                CaseStudy = "Sound",
                ResultCaseType = Domain.Enums.ResultCaseEnum.Decrease,
                ResultCaseChange = "35"
            };

            var input = new List<RequirementResultViewModel> { input1, input2, input3 };

            var inputFake = new RequirementResultViewModel
            {
                ResultType = Domain.Enums.CaseStudyEnum.ItemState,
                CaseStudy = "SafeBox",
                ResultCaseType = Domain.Enums.ResultCaseEnum.State,
                ResultCaseChange = "Open"
            };


            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet("Result Sheet");
            var row = 1;

            for (int i = 0; i < 300; i++)
            {
                var result = new List<ActionAggregateViewModel>();

                var rnd = new Random();
                var randomIndex = rnd.Next(input.Count);

                var service1 = new CoreService(_unitOfWork);
                var tmpResult = service1.Post(input[randomIndex]);
                tmpResult.ForEach(x => x.Description = "F");
                result.AddRange(tmpResult);
                var serviceUndo1 = new CoreService(_unitOfWork);
                serviceUndo1.UndoHuman21();
                serviceUndo1.UndoHuman22();

                var service2 = new CoreService(_unitOfWork);
                var tmpResult2 = service2.Post(inputFake);
                tmpResult2.ForEach(x => x.Description = "R");
                result.AddRange(tmpResult2);
                var serviceUndo2 = new CoreService(_unitOfWork);
                serviceUndo2.UndoHuman21();
                serviceUndo2.UndoHuman22();

                result = result.OrderBy(x => x.Time).ToList();

                var column = 'A';
                foreach (var action in result)
                {
                    sheet[$"{column}{row}"].Value = action.Name;
                    sheet[$"{column}{row + 1}"].Value = action.Time;
                    sheet[$"{column}{row + 2}"].Value = action.Description;
                    column = (char)(column + 1);
                }

                row += 3;

            }

            workbook.SaveAs("FakeData.xlsx");
        }

        [HttpPost]
        public List<ActionAggregateViewModel> Post([FromBody] RequirementResultViewModel input)
        {
            var service = new CoreService(_unitOfWork);
            var result = service.Post(input);
            return result;
        }

        [HttpGet]
        public List<ActionAggregateViewModel> Get(string input)
        {
            var service = new CoreService(_unitOfWork);
            var result = service.Get(input);
            return result;
        }

    }
}
