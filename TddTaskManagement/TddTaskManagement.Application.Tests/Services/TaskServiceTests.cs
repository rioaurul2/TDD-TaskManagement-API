using TddTaskManagement.Application.DTOs;
using TddTaskManagement.Application.Services;

namespace TddTaskManagement.Application.Tests.Services
{
    public class TaskServiceTests
    {
        [Fact]
        public void Create_ShouldReturnTask_WhenTitleIsValid()
        {
            //arrange
            TaskDto taskDto = new TaskDto
            {
                Title = "Task 1",
            };

            var taskService = new TaskService();

            //act
            var task = taskService.Create(taskDto);

            //assert
            Assert.Equal(taskDto.Title, task.Title);
            Assert.NotSame(taskDto, task);
        }

        [Fact]
        public void Create_ShouldThrowArgumentNullException_WhenTitleIsNull ()
        {
            //arrange
            TaskDto taskDto = new TaskDto
            {
                Title = null!,
            };

            var taskService = new TaskService();

            //act + assert
            var result = Assert.Throws<ArgumentNullException>(() => taskService.Create(taskDto));
            Assert.Equal(nameof(taskDto.Title), result.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_ShouldThrowArgumentException_WhenTitleIsEmptyOrWhiteSpace(string title)
        {
            // arrange
            var taskDto = new TaskDto
            {
                Title = title
            };

            var taskService = new TaskService();

            // act
            var result = Assert.Throws<ArgumentException>(() => taskService.Create(taskDto));

            // assert
            Assert.Equal(nameof(taskDto.Title), result.ParamName);
        }
    }
}
