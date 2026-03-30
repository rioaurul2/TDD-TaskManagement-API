using TddTaskManagement.Application.DTOs;

namespace TddTaskManagement.Application.Services
{
    public class TaskService
    {
        public Domain.Models.Task Create(TaskDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            if (dto.Title == null) 
            {
                throw new ArgumentNullException(nameof(dto.Title));
            }

            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                throw new ArgumentException("The field is missing", nameof(dto.Title));
            }

            var createdTask = new Domain.Models.Task(dto.Title);

            return createdTask;
        }
    }
}
