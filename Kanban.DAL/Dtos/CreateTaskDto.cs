namespace Kanban.DAL.Dtos
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string DeadLine { get; set; }

    }
}
