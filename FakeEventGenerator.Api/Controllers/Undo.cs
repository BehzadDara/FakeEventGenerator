using FakeEventGenerator.Domain.DTOs;
using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using FakeEventGenerator.Domain.ViewModels;
using FakeEventGenerator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FakeEventGenerator.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UndoController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly List<EnvironmentVariable> environmentVariables = new();
        private readonly List<Item> items = new();
        private readonly List<Human> humans = new();
        public UndoController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            environmentVariables = _unitOfWork.EnvironmentRepository.GetAll().Result;
            items = _unitOfWork.ItemRepository.GetAll().Result;
            humans = _unitOfWork.HumanRepository.GetAll().Result;
        }

        [HttpGet]
        public void OpenBalconyWindow()
        {
            var human1 = humans.First(x => x.Name.Equals("Human1"));
            human1.Location =  PartOfHouseEnum.Bedroom1;
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

        [HttpGet]
        public void IncreaseOrDecreaseSound()
        {
            var human2 = humans.First(x => x.Name.Equals("Human2"));
            human2.Location =  PartOfHouseEnum.Bedroom2;
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

        [HttpGet]
        public void HumanFeelCold()
        {
            var human2 = humans.First(x => x.Name.Equals("Human2"));
            human2.Location =  PartOfHouseEnum.Bedroom2;
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

    }
}
