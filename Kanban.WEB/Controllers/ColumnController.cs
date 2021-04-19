using Kanban.DAL.Dtos;
using Kanban.Logic.Dtos;
using Kanban.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kanban.WEB.Controllers
{
    [Route("api/columns")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly ITaskService taskService;

        public ColumnController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        //GET api/columns
        [HttpGet]
        public IEnumerable<TaskColumnDto> Get()
        {
            return taskService.GetTaskColumns();
        }

        //POST api/columns
        [HttpPost]
        public TaskColumnDto CreateNewColumn([FromBody] CreateTaskColumnDto dto)
        {
            return taskService.CreateNewColumn(dto);
        }

        [HttpPost("{id}")]
        public TaskColumnDto AddTaskToColumn(int id, [FromBody] TaskDto taskDto)
        {
            return taskService.AddTaskToColumn(id, taskDto);
        }

        //DELETE api/columns/{id}
        [HttpDelete("{id}")]
        public void DeleteColumn(int id)
        {
            taskService.DeleteColumn(id);
        }
    }
}
