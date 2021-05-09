using Kanban.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban.DAL
{
    public class KanbanDbContext : DbContext
    {
        protected KanbanDbContext() { }

        public KanbanDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }

        public DbSet<TaskColumn> TaskColumns { get; set; }
    }
}
