﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;
using MyToDo.Api.Service;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 待办事项控制器
    /// </summary>
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
        public async Task<ApiResponse> Get(int id) => await _service.GetSingleAsync(id);

        //[HttpGet]
        //public async Task<ApiResponse> GetAll(int id) => await _service.GetAllAsync(id);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] ToDo model) => await _service.AddAsync(model);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] ToDo model) => await _service.UpdateAsync(model);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await _service.DeleteAsync(id);
    }
}
