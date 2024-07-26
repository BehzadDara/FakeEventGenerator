using FakeEventGenerator.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FakeEventGenerator.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UndoController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public UndoController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public void Human1()
        {
            var coreService = new CoreService(_unitOfWork);
            coreService.UndoHuman1();
        }

        [HttpGet]
        public void Human21()
        {
            var coreService = new CoreService(_unitOfWork);
            coreService.UndoHuman21();
        }

        [HttpGet]
        public void Human22()
        {
            var coreService = new CoreService(_unitOfWork);
            coreService.UndoHuman22();
        }

    }
}
