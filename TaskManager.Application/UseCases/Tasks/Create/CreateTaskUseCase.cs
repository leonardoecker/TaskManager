using TaskManager.Communication.Requests;
using TaskManager.Entity.Models;
using TaskManager.Entity.Repositories;

namespace TaskManager.Application.UseCases.Create;

public class CreateTaskUseCase
{
    private readonly ITaskRepository taskRepository = new TaskRepository();

    public void Execute(RequestTaskJson request)
    {
        TaskItem task = new()
        {
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = (Entity.Enums.Priority)request.Priority,
            Status = (Entity.Enums.Status)request.Status,
        };

        taskRepository.Create(task);
    }
}