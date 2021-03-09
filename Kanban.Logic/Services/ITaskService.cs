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
        TaskDto CreateNewTask(TaskDto dto);
        TaskDto UpdateTask(TaskDto dto);
        void DeleteTask(TaskDto dto);
    }
}
