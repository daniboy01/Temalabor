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


        //GET api/tasks get all tasks from database
        [HttpGet]
        public IEnumerable<TaskDto> Get()
        {
            return taskService.GetAll();
        }

        //GET -- api/tasks/{id}
        [HttpGet("{id}")]
        public TaskDto GetById(int id)
        {
            return taskService.GetById(id);
        }

        //POST -- api/tasks data from dto
        [HttpPost]
        public TaskDto CreateNewTask([FromBody] CreateTaskDto dto)
        {
            return taskService.CreateNewTask(dto);
        }

        //PUT -- api/tasks data from dto
        [HttpPut]
        public TaskDto UpdateTask([FromBody] TaskDto dto)
        {
            return taskService.UpdateTask(dto);
        }

        //DELETE -- api/tasks data from dto
        [HttpDelete("{id}")]
        public void DeleteTask(int id)
        {
            taskService.DeleteTask(id);
        }

        [HttpPost("{id}")]
        public TaskDto MakeTaskDone(int id)
        {
            return taskService.MakeTaskDone(id);
        }
    }
}
