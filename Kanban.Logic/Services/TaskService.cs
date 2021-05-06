
using Kanban.DAL;
using Kanban.DAL.Dtos;
using Kanban.DAL.Models;
using Kanban.DAL.Repositories;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kanban.Logic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepoitory;
        private readonly IColumnRepository columnRepoitory;

        public TaskService(ITaskRepository taskRepoitory, 
            IColumnRepository columnRepoitory)
        {
            this.taskRepoitory = taskRepoitory;
            this.columnRepoitory = columnRepoitory;
        }

        public IEnumerable<TaskDto> GetAll()
        {
            return taskRepoitory.GetAll();
        }

        public TaskDto GetById(int id)
        {
            return taskRepoitory.GetById(id);
        }

        public TaskDto CreateNewTask(CreateTaskDto dto)
        {
            return taskRepoitory.CreateNewTask(dto);
        }

        public TaskDto UpdateTask(TaskDto dto)
        {
            return taskRepoitory.UpdateTask(dto);
        }

        

        public TaskDto MakeTaskDone(int id)
        {
            return columnRepoitory.MakeTaskDone(id);
        }

        public void DeleteTask(int id)
        {
            taskRepoitory.DeleteTask(id);
        }

        public IEnumerable<TaskColumnDto> GetTaskColumns()
        {
            return columnRepoitory.GetTaskColumns();
        }

        public TaskColumnDto CreateNewColumn(CreateTaskColumnDto dto)
        {
            return columnRepoitory.CreateNewColumn(dto);
        }

        public TaskColumnDto AddTaskToColumn(int id, TaskDto dto)
        {
            return columnRepoitory.AddTaskToColumn(id, dto);
        }

        public TaskColumnDto DeleteColumn(int id)
        {
            var columnToDelete = columnRepoitory.GetById(id);

            return columnRepoitory.DeleteColumn(columnToDelete);
        }

        public bool ColumnIsExist(int id)
        {
            return columnRepoitory.ColumnIsExist(id);
        }

        public bool TaskIsExist(int id)
        {
            return taskRepoitory.TaskIsExist(id);
        }
    }
}
