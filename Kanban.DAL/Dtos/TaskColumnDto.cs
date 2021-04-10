using Kanban.DAL.Models;
using Kanban.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.DAL.Dtos
{
    public class TaskColumnDto
    {
        public int ID { get; set; }
        public string State { get; set; }
        public IEnumerable<TaskDto> Tasks { get; set; }

        public TaskColumnDto(int id, string state, IEnumerable<TaskDto> tasks)
        {
            ID = id;
            State = state;
            Tasks = tasks;
        }
    }
}
