using Kanban.DAL.Dtos;
using Kanban.DAL.Models;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanban.DAL.Repositories
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly KanbanDbContext dbContext;

        public ColumnRepository(KanbanDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public IEnumerable<TaskColumnDto> GetTaskColumns()
        {
            return dbContext.TaskColumns.Select(c => new TaskColumnDto(
                        c.ID,
                        c.State.ToString(),
                        MapTasksToDto(c.Tasks)
                        ));
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

        //private helper methods
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
