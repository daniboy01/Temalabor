
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
            return dbContext.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                State = t.State.ToString()
            }).ToList();
        }

        public TaskDto GetById(int id)
        {
            return dbContext.Tasks.Where(t => t.Id == id).Select(
                t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                State = t.State.ToString()
            }).FirstOrDefault();
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
            TaskModel taskToUpdate = dbContext.Tasks.FirstOrDefault(task => task.Id == dto.Id);
            taskToUpdate.Title = dto.Title;
            taskToUpdate.Description = dto.Description;
            taskToUpdate.State = (State)Enum.Parse(typeof(State), dto.State);
            dbContext.SaveChanges();
            return dto;
        }

        public void DeleteTask(TaskDto dto)
        {
            TaskModel task = dbContext.Tasks.FirstOrDefault(task => task.Id == dto.Id);
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
        }

    }
}
