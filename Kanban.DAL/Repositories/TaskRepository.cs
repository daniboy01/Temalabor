using Kanban.DAL.Dtos;
using Kanban.DAL.Models;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanban.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly KanbanDbContext dbContext;

        public TaskRepository(KanbanDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TaskDto CreateNewTask(CreateTaskDto dto)
        {
            var inProgressCol = GetFolyamatbanColumn();

            var newModel = new TaskModel(
                    dto.Title,
                    dto.Description,
                    State.FOLYAMATBAN
                );

            inProgressCol.Tasks.Add(newModel);
            newModel.TaskColumn = inProgressCol;
            newModel.TaskColumnID = inProgressCol.ID;

            dbContext.Tasks.Add(newModel);
            dbContext.SaveChanges();

            return CreateTaskDto(newModel);
        }

        public IEnumerable<TaskDto> GetAll()
        {
            return dbContext.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                State = t.State.ToString(),
                CreatedAt = t.CreatedAt.ToString("MM/dd/yyyy HH:mm"),
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
                    State = t.State.ToString(),
                    CreatedAt = t.CreatedAt.ToString("MM/dd/yyyy HH:mm"),
                }).FirstOrDefault();
        }

        public bool TaskIsExist(int id)
        {
            return dbContext.Tasks.Any(t => t.Id == id);
        }

        public TaskDto UpdateTask(TaskDto dto)
        {
            TaskModel taskToUpdate = dbContext.Tasks.FirstOrDefault(task => task.Id == dto.Id);
            taskToUpdate.Title = dto.Title;
            taskToUpdate.Description = dto.Description;

            if(dto.State == null)
            {
                dto.State = taskToUpdate.State.ToString();
            }

            else
            {
                ChangeState(taskToUpdate, dto);
            }


            dbContext.SaveChanges();
            return dto;
        }

        public TaskDto DeleteTask(TaskDto dto)
        {
            TaskModel task = dbContext.Tasks.FirstOrDefault(task => task.Id == dto.Id);
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt.ToString(),
                State = task.State.ToString()
            };
        }


        //private helper methods
        private TaskColumn GetFolyamatbanColumn()
        {
            var col = dbContext.TaskColumns.FirstOrDefault(c => c.State == State.FOLYAMATBAN);

            if (col == null)
            {
                TaskColumn column = new TaskColumn(State.FOLYAMATBAN);
                dbContext.TaskColumns.Add(column);
                dbContext.SaveChanges();
                return column;
            }

            return col;
        }

        private TaskDto CreateTaskDto(TaskModel model)
        {
            return new TaskDto(
                    model.Id,
                    model.Title,
                    model.Description,
                    model.State.ToString(),
                    model.CreatedAt.ToString("MM/dd/yyyy HH:mm")
                );
        }
        private void ChangeState(TaskModel task, TaskDto dto)
        {
            var col = dbContext.TaskColumns.FirstOrDefault(c => c.State == task.State);
            col.Tasks.Remove(task);

            var newState = (State)Enum.Parse(typeof(State), dto.State);
            task.State = newState;

            var newCol = dbContext.TaskColumns.FirstOrDefault(c => c.State == (State)Enum.Parse(typeof(State), dto.State));
            newCol.Tasks.Add(task);

            dbContext.SaveChanges();

        }
    }
}
