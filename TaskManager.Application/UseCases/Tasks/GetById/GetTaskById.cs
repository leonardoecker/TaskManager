using TaskManager.Communication.Responses;
using TaskManager.Entity.Repositories;

namespace TaskManager.Application.UseCases.GetById;

public class GetTaskByIdUseCase
{
    private readonly ITaskRepository taskRepository = new TaskRepository();

    public ResponseTaskJson? Execute(Guid id)
    {

        var task = taskRepository.GetById(id);

        if (task is null)
        {
            return null;
        }

        return new ResponseTaskJson
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            DueDate = task.DueDate,
            Priority = (Communication.Enums.Priority)task.Priority,
            Status = (Communication.Enums.Status)task.Status
        };
    }
}