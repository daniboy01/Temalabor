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
        TaskColumnDto GetById(int id);
        TaskColumnDto CreateNewColumn(CreateTaskColumnDto dto);
        TaskColumnDto AddTaskToColumn(int id, TaskDto dto);
        TaskColumnDto DeleteColumn(TaskColumnDto dto);
        TaskDto MakeTaskDone(int id);
        bool ColumnIsExist(int id);
    }
}
