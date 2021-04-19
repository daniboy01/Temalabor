using Kanban.DAL.Dtos;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.DAL.Repositories
{
    public interface IColumnRepository
    {
        IEnumerable<TaskColumnDto> GetTaskColumns();
        TaskColumnDto CreateNewColumn(CreateTaskColumnDto dto);
        TaskColumnDto AddTaskToColumn(int id, TaskDto dto);
        void DeleteColumn(int id);
        TaskDto MakeTaskDone(int id);
    }
}
