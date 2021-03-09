using Kanban.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.DAL
{
    public class KanbanDbContext : DbContext
    {
        protected KanbanDbContext() { }

        public KanbanDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
