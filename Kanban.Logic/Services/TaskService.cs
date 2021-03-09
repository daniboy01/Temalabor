
using Kanban.DAL;
using Kanban.DAL.Dtos;
using Kanban.DAL.Models;
using Kanban.Logic.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Logic.Services
{
    public class TaskService : ITaskService
    {
        private readonly KanbanDbContext dbContext;

        public TaskService(KanbanDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TaskDto CreateNewTask(CreateTaskDto dto)
        {
            var newModel = new TaskModel(
                    dto.Title,
                    dto.Description,
                    (State)Enum.Parse(typeof(State), dto.State)
                );

            dbContext.Tasks.Add(newModel);
            dbContext.SaveChanges();

            return new TaskDto(
                    newModel.Id,
                    dto.Title,
                    dto.Description,
                    dto.State
                );
        }
        

        public void DeleteTask(TaskDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskDto> GetAll()
        {
            List<TaskDto> dtos = new List<TaskDto>();
            foreach(var task in dbContext.Tasks)
            {
                dtos.Add(mapToDto(task));
            }

            return dtos;
        }

        public TaskDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaskDto UpdateTask(TaskDto dto)
        {
            throw new NotImplementedException();
        }

        private TaskModel mapToModel(TaskDto dto)
        {
            return new TaskModel(
                    dto.Id,
                    dto.Title,
                    dto.Description,
                    (State)Enum.Parse(typeof(State), dto.State)
                );
            ;
        }

        private TaskDto mapToDto(TaskModel taskModel)
        {
            return new TaskDto(
                    taskModel.Id,
                    taskModel.Title,
                    taskModel.Description,
                    taskModel.State.ToString()
                );
        }

    }
}
