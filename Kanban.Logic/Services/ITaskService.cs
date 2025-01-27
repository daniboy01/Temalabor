﻿using Kanban.DAL.Dtos;
using Kanban.Logic.Dtos;
using System.Collections.Generic;

namespace Kanban.Logic.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto GetById(int id);
        TaskDto CreateNewTask(CreateTaskDto dto);
        TaskDto UpdateTask(TaskDto dto);
        TaskDto DeleteTask(int id);
        IEnumerable<TaskColumnDto> GetTaskColumns();
        TaskColumnDto CreateNewColumn(CreateTaskColumnDto dto);
        TaskColumnDto AddTaskToColumn(int id, TaskDto dto);
        TaskColumnDto DeleteColumn(int id);
        TaskDto MakeTaskDone(int id);
        bool ColumnIsExist(int id);
        bool TaskIsExist(int id);
    }
}
