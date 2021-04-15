using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Logic.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

        public string CreatedAt { get; set; }


        public TaskDto(int id, string title, string description, 
            string state, string createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            State = state;
            CreatedAt = createdAt;
        }

        public TaskDto() { }
    }
}
