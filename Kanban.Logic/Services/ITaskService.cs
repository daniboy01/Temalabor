using Kanban.DAL.Dtos;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Logic.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto GetById(int id);
        TaskDto CreateNewTask(CreateTaskDto dto);
        TaskDto UpdateTask(TaskDto dto);
        void DeleteTask(int id);
        IEnumerable<TaskColumnDto> GetTaskColumns();
        TaskColumnDto CreateNewColumn(CreateTaskColumnDto dto);
        TaskColumnDto AddTaskToColumn(int id, TaskDto dto);
        void DeleteColumn(int id);
        TaskDto MakeTaskDone(int id);
    }
}
