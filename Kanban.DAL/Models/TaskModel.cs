﻿using System;

namespace Kanban.DAL.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public State? State { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? DeadLine { get; set; }


        public int? TaskColumnID { get; set; }

        public TaskColumn? TaskColumn { get; set; }

        public TaskModel(string title, string description, State? state)
        {
            Title = title;
            Description = description;
            State = state;
            CreatedAt = DateTime.Now;
        }

        public TaskModel(int id, string title, string description, State? state)
        {
            Id = id;
            Title = title;
            Description = description;
            State = state;
        }
    }
}
