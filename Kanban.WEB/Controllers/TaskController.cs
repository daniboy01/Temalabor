using Kanban.DAL.Dtos;
using Kanban.Logic.Dtos;
using Kanban.Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.WEB.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }


        //GET -- return with all the date from database
        [HttpGet]
        public IEnumerable<TaskDto> Get()
        {
            return taskService.GetAll();
        }

        //GET -- return the data by id
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return null;
        }

        //POST -- get a dto form the http body and pass it to the logic layer for save
        [HttpPost]
        public TaskDto AddNewTask([FromBody] CreateTaskDto dto)
        {
            return taskService.CreateNewTask(dto);
        }

        //PUT -- update data 
        [HttpPut("{id}")]
        public void Put([FromBody] string dto)
        {

        }

        //DELETE -- delete TaskModel
        [HttpDelete("{id}")]
        public void Delete([FromBody] string dto)
        {

        }
    }
}
