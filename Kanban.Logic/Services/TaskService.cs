
using Kanban.DAL;
using Kanban.DAL.Dtos;
using Kanban.DAL.Models;
using Kanban.Logic.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<TaskDto> GetAll()
        {
            List<TaskDto> dtos = new List<TaskDto>();
            foreach (var task in dbContext.Tasks)
            {
                dtos.Add(mapToDto(task));
            }

            return dtos;
        }

        public TaskDto GetById(int id)
        {
            return mapToDto(dbContext.Tasks.FirstOrDefault(task => task.Id == id));
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

        public TaskDto UpdateTask(TaskDto dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(TaskDto dto)
        {
            throw new NotImplementedException();
        }

        // private helper methods
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
