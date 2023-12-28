using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;
using MyToDo.Api.Service;

namespace MyToDo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {        
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {            
            _service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) =>await _service.GetSingleAsync(id);       


    }
}
