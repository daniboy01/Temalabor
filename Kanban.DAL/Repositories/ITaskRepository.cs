using Kanban.DAL.Dtos;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.DAL.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto GetById(int id);
        TaskDto CreateNewTask(CreateTaskDto dto);
        TaskDto UpdateTask(TaskDto dto);
        void DeleteTask(int id);
    }
}
