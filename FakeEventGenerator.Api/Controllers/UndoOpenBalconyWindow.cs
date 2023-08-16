using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using FakeEventGenerator.Domain.ViewModels;
using FakeEventGenerator.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FakeEventGenerator.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UndoOpenBalconyWindowController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly List<EnvironmentVariable> environmentVariables = new();
        private readonly List<PartOfHouse> partsOfHouse = new();
        private readonly List<Item> items = new();
        private readonly List<Human> humans = new();
        private readonly List<ActionAggregate> actionAggregates = new();
        private readonly Random random = new();
        public UndoOpenBalconyWindowController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            environmentVariables = _unitOfWork.EnvironmentRepository.GetAll().Result;
            partsOfHouse = _unitOfWork.PartOfHouseRepository.GetAll().Result;
            items = _unitOfWork.ItemRepository.GetAll().Result;
            humans = _unitOfWork.HumanRepository.GetAll().Result;
            actionAggregates = _unitOfWork.ActionRepository.GetAll().Result;
        }

        [HttpGet]
        public void Get()
        {
            var human1 = humans.First(x => x.Name.Equals("Human1"));
            human1.CoordinateX = 10;
            human1.CoordinateY = 74;
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

    }
}
