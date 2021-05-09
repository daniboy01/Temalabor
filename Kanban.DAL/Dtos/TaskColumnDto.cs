using Kanban.Logic.Dtos;
using System.Collections.Generic;

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
