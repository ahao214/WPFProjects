using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;

namespace MyToDo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task <IActionResult> Get(int id)
        {
            var repository = _unitOfWork.GetRepository<ToDo>();


            return null;
        }


    }
}
