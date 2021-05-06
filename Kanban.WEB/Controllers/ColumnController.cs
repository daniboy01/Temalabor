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
        public ActionResult<IEnumerable<TaskColumnDto>> Get()
        {
            return Ok(taskService.GetTaskColumns());
        }

        //POST api/columns
        [HttpPost]
        public ActionResult<TaskColumnDto> CreateNewColumn([FromBody] CreateTaskColumnDto dto)
        {
            if(dto == null)
            {
                return BadRequest();
            }

            return Ok(taskService.CreateNewColumn(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<TaskColumnDto> AddTaskToColumn(int id, [FromBody] TaskDto taskDto)
        {
            if(!taskService.TaskIsExist(taskDto.Id) || !taskService.ColumnIsExist(id))
            {
                return NotFound();
            }

            return Ok(taskService.AddTaskToColumn(id, taskDto));
        }

        //DELETE api/columns/{id}
        [HttpDelete("{id}")]
        public ActionResult<TaskColumnDto> DeleteColumn(int id)
        {
            if (!taskService.ColumnIsExist(id))
            {
                return NotFound($"Column with id: {id} not found!");
            }

            return Ok(taskService.DeleteColumn(id));
        }
    }
}
