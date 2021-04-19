using Kanban.DAL;
using Kanban.DAL.Dtos;
using Kanban.Logic.Services;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Kanban.Tests
{
    public class TaskServiceTests
    {
        private readonly TaskService taskService;
        private readonly Mock<KanbanDbContext> _kanbanDbContextMock = new Mock<KanbanDbContext>();

        public TaskServiceTests()
        {
            taskService = new TaskService(_kanbanDbContextMock.Object);
        }

        [Fact]
        public void GetAll_ShouldReturn_1()
        {
            var newTask = new CreateTaskDto
            {
                Title = "teszt",
                Description = "tesztelelk"
            };



            taskService.CreateNewTask(newTask);

            var allTask = taskService.GetAll();

            Assert.Equal(1, allTask.Count());
        }

    }
}
