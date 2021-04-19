using System.Collections.Generic;

namespace Kanban.DAL.Models
{
    public class TaskColumn
    {
        public int ID { get; set; }
        public State State { get; set; }
        public List<TaskModel> Tasks { get; set; }

        public TaskColumn(State state)
        {
            State = state;
            Tasks = new List<TaskModel>();
        }
    }
}
