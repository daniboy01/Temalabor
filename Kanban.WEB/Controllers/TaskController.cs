using Kanban.DAL.Dtos;
using Kanban.Logic.Dtos;
using Kanban.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<TaskDto>> Get()
        {
            return Ok(taskService.GetAll());
        }

        //GET -- api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetById(int id)
        {
            var task = taskService.GetById(id);

            if(task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        //POST -- api/tasks data from dto
        [HttpPost]
        public ActionResult<TaskDto> CreateNewTask([FromBody] CreateTaskDto dto)
        {
            if(dto == null)
            {
                return BadRequest();
            }
            return Ok(taskService.CreateNewTask(dto));
        }

        //PUT -- api/tasks data from dto
        [HttpPut]
        public ActionResult<TaskDto> UpdateTask([FromBody] TaskDto dto)
        {
            var task = taskService.GetById(dto.Id);

            if(task == null)
            {
                return NotFound();
            }

            return Ok(taskService.UpdateTask(dto));
        }

        //DELETE -- api/tasks data from dto
        [HttpDelete("{id}")]
        public ActionResult<TaskDto> DeleteTask(int id)
        {
            if (!taskService.TaskIsExist(id))
            {
                return NotFound();
            }

            return Ok(taskService.DeleteTask(id));
        }

        [HttpPost("{id}")]
        public ActionResult<TaskDto> MakeTaskDone(int id)
        {
            if (!taskService.TaskIsExist(id))
            {
                return NotFound();
            }

            return Ok(taskService.MakeTaskDone(id));
        }
    }
}
