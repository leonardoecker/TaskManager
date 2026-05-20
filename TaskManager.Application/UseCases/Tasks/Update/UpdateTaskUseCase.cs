using TaskManager.Communication.Requests;
using TaskManager.Entity.Models;
using TaskManager.Entity.Repositories;

namespace TaskManager.Application.UseCases.Update;

public class UpdateTaskUseCase
{
    private readonly ITaskRepository taskRepository = new TaskRepository();

    public bool Execute(Guid id, RequestTaskJson request)
    {

        var task = taskRepository.GetById(id);

        if (task is null)
        {
            return false;
        }

        TaskItem newTask = new()
        {
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = (Entity.Enums.Priority)request.Priority,
            Status = (Entity.Enums.Status)request.Status,
        };

        taskRepository.Update(id, newTask);

        return true;
    }
}