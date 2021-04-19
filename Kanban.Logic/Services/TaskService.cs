
using Kanban.DAL;
using Kanban.DAL.Dtos;
using Kanban.DAL.Models;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public TaskDto UpdateTask(TaskDto dto)
        {
            TaskModel taskToUpdate = dbContext.Tasks.FirstOrDefault(task => task.Id == dto.Id);
            taskToUpdate.Title = dto.Title;
            taskToUpdate.Description = dto.Description;

            if (taskToUpdate.State != (State)Enum.Parse(typeof(State), dto.State))
            {
                ChangeState(taskToUpdate, dto);
            }


            dbContext.SaveChanges();
            return dto;
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

        public TaskDto MakeTaskDone(int id)
        {
            var doneCol = dbContext.TaskColumns.FirstOrDefault(c => c.State == State.KÉSZ);

            var col = GetFolyamatbanColumn();
            var task = dbContext.Tasks.FirstOrDefault(t => t.Id == id);

            col.Tasks.Remove(task);
            task.State = State.KÉSZ;
            doneCol.Tasks.Add(task);

            dbContext.SaveChanges();

            return new TaskDto(
                    task.Id,
                    task.Title,
                    task.Description,
                    task.State.ToString(),
                    task.CreatedAt.ToString()
                );
        }

        public void DeleteTask(int id)
        {
            TaskModel task = dbContext.Tasks.FirstOrDefault(task => task.Id == id);
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
        }

        public IEnumerable<TaskColumnDto> GetTaskColumns()
        {
            return dbContext.TaskColumns.Select(c => new TaskColumnDto(
                c.ID,
                c.State.ToString(),
                MapTasksToDto(c.Tasks)
                ));
        }

        public TaskColumnDto CreateNewColumn(CreateTaskColumnDto dto)
        {
            var column = new TaskColumn((State)Enum.Parse(typeof(State), dto.State));

            dbContext.TaskColumns.Add(column);
            dbContext.SaveChanges();

            return new TaskColumnDto(
                    column.ID,
                    column.State.ToString(),
                    MapTasksToDto(column.Tasks)
                );
        }

        public TaskColumnDto AddTaskToColumn(int id, TaskDto dto)
        {
            TaskColumn column = dbContext.TaskColumns.Where(c => c.ID == id).FirstOrDefault();
            TaskModel task = dbContext.Tasks.Where(t => t.Id == dto.Id).FirstOrDefault();

            column.Tasks.Add(task);
            task.TaskColumn = column;
            task.TaskColumnID = column.ID;

            dbContext.SaveChanges();

            return MapColumnToDto(column);
        }

        public void DeleteColumn(int id)
        {
            var column = dbContext.TaskColumns.FirstOrDefault(c => c.ID == id);
            dbContext.TaskColumns.Remove(column);
            dbContext.SaveChanges();
        }

        private static IEnumerable<TaskDto> MapTasksToDto(IEnumerable<TaskModel> tasks)
        {
            List<TaskDto> dtos = new List<TaskDto>();


            foreach (TaskModel t in tasks)
            {
                TaskDto dto = new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    State = t.State.ToString(),
                    CreatedAt = t.CreatedAt.ToString("MM/dd/yyyy HH:mm")
                };

                dtos.Add(dto);
            }

            return dtos;
        }
        private TaskColumnDto MapColumnToDto(TaskColumn column)
        {
            return new TaskColumnDto(
                    column.ID,
                    column.State.ToString(),
                    MapTasksToDto(column.Tasks)
                );
        }

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

    }
}
