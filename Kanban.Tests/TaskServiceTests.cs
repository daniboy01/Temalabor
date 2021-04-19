using Kanban.DAL;
using Kanban.DAL.Dtos;
using Kanban.DAL.Models;
using Kanban.DAL.Repositories;
using Kanban.Logic.Dtos;
using Kanban.Logic.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kanban.Tests
{
    public class TaskServiceTests
    {
        private readonly TaskService taskService;
        private readonly Mock<ITaskRepository> _taskRepoMock = new Mock<ITaskRepository>();
        private readonly Mock<IColumnRepository> _columnRepoMock = new Mock<IColumnRepository>();

        public TaskServiceTests()
        {
            taskService = new TaskService(_taskRepoMock.Object, _columnRepoMock.Object);
        }

        [Fact]
        public void GetByIdTest()
        {
            var taskId = 1;

            var taskDto = new TaskDto(
                    taskId,
                    "tesztCím",
                    "tesztLeírás",
                    "FOLYAMATBAN",
                    "04/19/2021 17:30"
                );

            _taskRepoMock.Setup(x => x.GetById(taskId))
                .Returns(taskDto);

            var task = taskService.GetById(taskId);

            Assert.Equal(taskId, task.Id);
            Assert.Equal("tesztCím", task.Title);
        }

        [Fact]
        public void GetAllTest()
        {
            List<TaskDto> dtos = new List<TaskDto>();
            dtos.Add(new TaskDto(1,
                    "tesztCím",
                    "tesztLeírás",
                    "FOLYAMATBAN",
                    "04/19/2021 17:30"));
            dtos.Add(new TaskDto(1,
                    "tesztCím2",
                    "tesztLeírás2",
                    "FOLYAMATBAN",
                    "04/19/2021 17:30"));
            dtos.Add(new TaskDto(1,
                    "tesztCím3",
                    "tesztLeírás3",
                    "FOLYAMATBAN",
                    "04/19/2021 17:30"));

            _taskRepoMock.Setup(x => x.GetAll()).Returns(dtos);

            var allTask = taskService.GetAll();

            Assert.Equal(3, dtos.Count);
            Assert.Equal(dtos[1].Title, dtos[1].Title);

        }

        [Fact]
        public void CreateNewTaskTest()
        {
            var createDto = new CreateTaskDto
            {
                Title = "teszt",
                Description = "elek"
            };

            var responseDto = new TaskDto(
                    1,
                    "teszt",
                    "elek",
                    "FOLYAMATBAN",
                    "04/19/2021 17:30"
                );

            _taskRepoMock.Setup(x => x.CreateNewTask(createDto)).Returns(responseDto);

            var result = taskService.CreateNewTask(createDto);

            Assert.Equal(1, result.Id);
        }

    }
}
