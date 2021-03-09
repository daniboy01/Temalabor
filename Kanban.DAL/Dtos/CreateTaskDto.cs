using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.DAL.Dtos
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}
